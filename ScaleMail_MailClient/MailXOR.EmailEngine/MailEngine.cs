using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using MailXOR.UserSettings;
using Limilabs.Mail;
using Limilabs.Mail.Headers;
using Limilabs.Client.POP3;
using Limilabs.Client.IMAP;
using Limilabs.Client.SMTP;
using Limilabs.Mail.MIME;
using System.Xml.Serialization;
using System.IO;
using System.Data;

namespace MailXOR.EmailEngine
{
    [XmlRoot("Node", Namespace = "Object")]
    public class MailEngine
    {
        // Properties
        private Pop3 _pop3 = new Pop3();
        private Imap _imap = new Imap();
        private Smtp _smtp = new Smtp();
        private BackgroundWorker _worker;
        private static UserAccount _ua;
        private int largestUID = 0;
        private int emailStartCount = 0;
        private int highestPercentageReached = 0;

        [XmlAttribute]
        private List<DataSet> _emailDSList = new List<DataSet>();
        private DataSet _emailContent = new DataSet();
        private List<DataTable> _emailDataTableList;

        private List<string> _attachmentList = new List<string>();
        private string xmlStore = "store.scalemail.xml";

        // Constructor
        public MailEngine(UserAccount ua, BackgroundWorker worker, bool isAddAcount)
        {
            if (ConnectToServer(ua) == 1)
            {
                if (DeserializeEmailArray())    // Existing Accounts exists - Find if current settings match dataset (mailbox) already in existance
                {
                    List<DataSet> dstest = _emailDSList;
                    if (isAddAcount && ReturnCurrentAccountDSIndex() == 0)
                    {

                        GetEmail(worker);
                        SerializeEmailArray();

                    }
                    else
                    {
                        // Store appropriate dataset (mailbox) into memory
                        _emailContent = _emailDSList[ReturnCurrentAccountDSIndex()];

                        //foreach(DataTable table in _emailContent.Tables)
                        //{
                        //    table.DefaultView.Sort = "Date DESC";
                        //}
                    }
                }
                else    // New account - Get mail then serialize immediatly
                {
                    GetEmail(worker);
                    SerializeEmailArray();
                }
                _engineStarted = true;
            }
            else
            {
                if (_ua.InUserProtocol == "POP3")
                    _pop3.Close();
                else
                    _imap.Close();

                _engineStarted = false;
            }
        }

        // Constructor
        public MailEngine()
        {
            // Implement
        }

        private string _attachmentPath;
        public string AttachmentPath
        {
            get
            {
                return _attachmentPath;
            }
            set
            {
                _attachmentPath = value;
                _attachmentList.Add(_attachmentPath);
            }
        }

        private bool _getNewMessages = false;
        public bool GetNewMessages
        {
            get
            {
                return _getNewMessages;
            }
            set
            {
                _getNewMessages = value;
            }
        }

        private bool _engineStarted;
        public bool EngineStarted
        {
            get
            {
                return _engineStarted;
            }
            set
            {
                _engineStarted = value;
            }
        }

        private List<string> _folderList = new List<string>();
        public List<string> GetFolderList
        {
            get {
                    // Get Folders
                    GetFolders();

                    return _folderList;
                }
        }

        public DataSet EmailContent
        {
            get
            {
                return _emailContent;
            }
        }


        /// <summary>
        /// Test the settings inputted into the User Account Settings form when POP3 is selected
        /// </summary>
        /// <param name="ua"></param>
        public void TestServerPOP3(UserAccount ua)
        {
            ConnectToServer(ua);
        }

        /// <summary>
        /// Opens connection with email server based on UserAccount user settings
        /// </summary>
        /// <param name="ua"></param>
        /// <returns></returns>
        protected int ConnectToServer(UserAccount ua)
        {
            _ua = ua;
            try
            {
                if (ua.InUserProtocol == "POP3")
                {
                    // Connect to Server
                    if (ua.InUserSSL == "SSL")
                        _pop3.ConnectSSL(ua.InUserServer, Int32.Parse(ua.InUserPort));
                    else
                        _pop3.Connect(ua.InUserServer, Int32.Parse(ua.InUserPort));

                    // Use credentials
                    _pop3.UseBestLogin(ua.UserUsername, ua.UserPassword);
                    ua.SettingsVerified = true;
                    return 1;
                }
                else
                {
                    _imap.ConnectSSL(ua.InUserServer);
                    _imap.Login(ua.UserUsername, ua.UserPassword);
                    ua.SettingsVerified = true;
                    return 1;
                }
            }
            catch (Exception ex)
            {
                ua.SettingsVerified = false;
                return 0;
            }
        }

        /// <summary>
        /// Get folders, email, and metadata from email account using protocol specified in UserAccount.UserProtocol
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        public void GetEmail(BackgroundWorker worker)
        {
            // Create Datatable, DataSet and add columns
            _emailDataTableList = new List<DataTable>();

            int increment = 0;

            // Get Folders
            GetFolders();

            foreach (string folderName in _folderList)
            {

                // Select which folder to read from
                if (_ua.InUserProtocol == "IMAP" && folderName == "[Gmail]")
                    break;

                // Add DataTable named the same as current folder in this foreach loop
                _emailDataTableList.Add(AddDataTable(folderName));

                // Get Emails
                if (_ua.InUserProtocol == "POP3")
                    GetMailUsingPOP3(folderName, increment, worker);
                else
                    GetMailUsingIMAP(folderName, increment, worker, _folderList.Count); 

                // Increment the loop index for next folder
                increment++;
            }
            _emailContent.DataSetName = _ua.UserUsername;
            AddAccountMailboxDSToList();
            SerializeEmailArray();
            _emailContent = _emailDSList[ReturnCurrentAccountDSIndex()];
        }

        private int ReturnCurrentAccountDSIndex()
        {
            int index = 0;
            foreach (DataSet ds in _emailDSList)
            {
                if (ds.DataSetName == _ua.UserUsername)
                    return index;
                index++;
            }
            return 0;
        }

        /// <summary>
        /// Send message built in ProcessMailToSend()
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        protected int SendMail(IMail email)
        {
            try
            {
                // COnnect to server
                if (_ua.OutUserSSL == "SSL")
                {
                    _smtp.ConnectSSL(_ua.OutUserServer, Int32.Parse(_ua.OutUserPort));
                    _smtp.Login(_ua.UserUsername, _ua.UserPassword);
                }
                else
                {
                    _smtp.Connect(_ua.OutUserServer, Int32.Parse(_ua.OutUserPort));
                    _smtp.UseBestLogin(_ua.UserUsername, _ua.UserPassword);
                }

                _smtp.SendMessage(email); // SET TO EMAIL

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// Build email from MailBuilder using interface IMail, pass to SendMail()
        /// </summary>
        /// <param name="sendTo">Recipient</param>
        /// <param name="sendSubject">Subject</param>
        /// <param name="sendMailContents">Body</param>
        /// <param name="sendFrom">Sender</param>
        public void ProcessMailToSend(string sendTo, string sendSubject, string sendMailContents, string sendFrom)
        {

            // Append scalemail signature
            sendMailContents += "<br/>Sent using <img src=\"http://i42.photobucket.com/albums/e333/rcastoro1/scalemailSignature_zpse308b52b.gif \" border=\"0\" alt=\" photo scalemailSignature_zpse308b52b.gif\"/> v1.0 ^-^";

            MailBuilder builder = new MailBuilder();
            builder.From.Add(new MailBox(sendFrom, ""));
            builder.To.Add(new MailBox(sendTo, ""));
            builder.Subject = sendSubject;
            builder.Html = sendMailContents;

            foreach (string attachment in _attachmentList)
            {
                MimeData attach = builder.AddAttachment(attachment);
            }

            IMail email = builder.Create();

            SendMail(email);
        }

        /// <summary>
        /// Get mail using POP3 Mail Protocol
        /// </summary>
        /// <param name="folderName">Current Folder / Name of DataTable</param>
        /// <param name="emailCount">Count of email in folder</param>
        /// <param name="increment">Current Index</param>
        /// <param name="worker">BackgroundWorker that started this thread</param>
        private void GetMailUsingPOP3(string folderName, int increment, BackgroundWorker worker)
        {
            List<string> emails = _pop3.GetAll();
            foreach (string uid in emails)
            {
                // If top 5 perfect of emails, then download.
                if (float.Parse(uid) >= 42000f)
                {
                    // Add new row to DataTable
                    DataRow emailDataRow = _emailDataTableList[increment].NewRow();

                    IMail emailData = new MailBuilder()
                        .CreateFromEml(_pop3.GetMessageByUID(uid));
                    // This takes just as long cause it downloads entire messages either way
                    emailDataRow["GUID"] = uid;
                    emailDataRow["Date"] = emailData.Date.ToString();
                    emailDataRow["From"] = emailData.From;
                    emailDataRow["Body"] = emailData.GetBodyAsHtml();
                    emailDataRow["Subject"] = emailData.Date.ToString() + " - " + emailData.Subject;
                    emailDataRow["Viewed"] = 0;

                    _emailDataTableList[increment].Rows.Add(emailDataRow);
                }
            }
            _emailContent.Tables.Add(_emailDataTableList[increment]); //add data table if there is none in DS yet.
            _emailContent.Tables.Remove(folderName);
        }
        
        /// <summary>
        /// Get mail using IMAP Mail Protocol
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="emailCount"></param>
        /// <param name="increment"></param>
        /// <param name="worker"></param>
        private void GetMailUsingIMAP(string folderName, int increment, BackgroundWorker worker, int totalFolderCount)
        {
            _imap.Select(folderName);

            int percentComplete = 0;

            bool alreadyOwn = false;

            List<long> emailList = _imap.GetAll();

            int inc = 0;
            foreach (int uid in emailList)
            {
                DataRow emailDataRow;
                if (_getNewMessages)
                {
                    worker.ReportProgress(50);
                    emailDataRow = _emailContent.Tables[folderName].NewRow();
                }
                else
                {
                    emailDataRow = _emailDataTableList[increment].NewRow();
                }

                alreadyOwn = false;

                if (_emailContent.Tables.Count > 0)
                {
                    for (int x = 0; x < _emailContent.Tables[increment].Rows.Count; x++)
                    {
                        if (_emailContent.Tables[increment].Rows[x][0].ToString() == uid.ToString())
                        {
                            alreadyOwn = true;
                        }
                    }
                }

                if (alreadyOwn == false)
                {

                    var eml = _imap.GetMessageByUID(uid);
                    IMail emailData = new MailBuilder()
                        .CreateFromEml(eml);

                    emailDataRow["GUID"] = uid;
                    emailDataRow["Date"] = emailData.Date.ToString();
                    emailDataRow["From"] = emailData.From;
                    emailDataRow["Body"] = emailData.GetBodyAsHtml();
                    emailDataRow["Subject"] = emailData.Date.ToString() + " - " + emailData.Subject;
                    emailDataRow["Viewed"] = 1;

                    if (_getNewMessages)
                    {
                        worker.ReportProgress(100);
                        _emailContent.Tables[increment].Rows.Add(emailDataRow);
                    }
                    else
                    {
                        _emailDataTableList[increment].Rows.Add(emailDataRow);
                    }
                }

                percentComplete = (inc * 100 / emailList.Count);
                worker.ReportProgress(percentComplete);

                inc++;

            }
            if (!_getNewMessages)
            {
                _emailContent.Tables.Add(_emailDataTableList[increment]); //add data table if there is none in DS yet.
            }

        }

        /// <summary>
        /// Serialize (save) emailDS (all email data already loaded) into XML Document
        /// </summary>
        private void SerializeEmailArray()
        {
            if (File.Exists(xmlStore))
                File.Delete(xmlStore);

            StreamWriter serialWriter = new StreamWriter(xmlStore);
            XmlSerializer xmlWriter = new XmlSerializer(_emailDSList.GetType());
            xmlWriter.Serialize(serialWriter, _emailDSList);
            serialWriter.Close();
        }

        /// <summary>
        /// Deserialize (load) emailDS (all email data already loaded) from XML Document
        /// </summary>
        /// <returns></returns>
        private bool DeserializeEmailArray()
        {
            if (File.Exists(xmlStore))
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(_emailDSList.GetType());
                    TextReader tr = new StreamReader(xmlStore);
                    _emailDSList = (List<DataSet>)serializer.Deserialize(tr);
                    tr.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Get's the UID of the most recent email downloaded
        /// </summary>
        /// <returns></returns>
        private int GetLargestUID()
        {
            return Convert.ToInt32(_emailContent.Tables[0].Rows[_emailContent.Tables[0].Rows.Count - 1]["GUID"]);
        }

        /// <summary>
        /// Load all folders in email account into list
        /// </summary>
        private void GetFolders()
        {
            if (_folderList.Count != 0)
                _folderList.Clear();

            if (_ua.InUserProtocol == "IMAP")
            {
                foreach (FolderInfo mailFolder in _imap.GetFolders())
                {
                    if (mailFolder.Name.Substring(1, 4) != "[Gma")
                        _folderList.Add(mailFolder.Name.ToString());
                }
            }
            else
            {
                _folderList.Add("Inbox");
            }
        }


        /// <summary>
        /// Create DataTable to be used to load all email into
        /// Used in conjuction with GetMail and UsePOP3 && || UseIMAP
        /// </summary>
        /// <param name="folderName"></param>
        /// <returns>DataTable named as folder with the necessary email columns</returns>
        private DataTable AddDataTable(string folderName)
        {
            DataTable dataTable = new DataTable();

            dataTable.TableName = folderName;
            dataTable.Columns.Add("GUID");
            dataTable.Columns.Add("Date");
            dataTable.Columns.Add("From");
            dataTable.Columns.Add("Body");
            dataTable.Columns.Add("Subject");
            dataTable.Columns.Add("Viewed");

            return dataTable;
        }

        private void AddAccountMailboxDSToList()
        {
            _emailDSList.Add(_emailContent);
        }
    }
}
