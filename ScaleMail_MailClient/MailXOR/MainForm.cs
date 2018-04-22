using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailXOR.EmailEngine;
using MailXOR.UserSettings;
using MailXOR.UI;
using System.Threading;

namespace MailXOR
{
    public partial class MainForm : Form
    {

        private MailEngine _mailEngineReceive;
        private UserAccount _userAccount;
        private DataSet _emailContent;
        private bool _isEditSettingsClick = false;
        private bool _isAddAccount = false;
        private int _hoveredIndex = -1;
        private ToolTip _inboxToolTip = new ToolTip();
        private ToolTip _fromNameToolTip = new ToolTip();
        private string[] _fromArray = new string[2];
        private List<string> _folderList;
        private List<ToolStripButton> _accountButtonList = new List<ToolStripButton>();

        public MainForm()
        {
            // Constructor
            InitializeComponent();
        }

        protected void PopulateInboxList(int table)
        {
            _listboxInbox.DataSource = null;
            _listboxInbox.Refresh();
            _listboxInbox.DataSource = _emailContent.Tables[GetSelectedFolder()];
            _listboxInbox.ValueMember = "GUID";
            _listboxInbox.DisplayMember = "Subject";
        }

        protected void PopulateFolderList()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Index");
            dt.Columns.Add("FolderName");
            int i = 0;

            foreach (string folderName in _folderList)
            {
                DataRow dr = dt.NewRow();
                dr["Index"] = i;
                dr["FolderName"] = folderName;
                dt.Rows.Add(dr);
                i++;
            }

            _listboxFolders.DataSource = null;
            _listboxFolders.Refresh();
            _listboxFolders.DataSource = dt;
            _listboxFolders.ValueMember = dt.Columns["Index"].ToString();
            _listboxFolders.DisplayMember = dt.Columns["FolderName"].ToString();
        }

        protected int StartMailEngine(BackgroundWorker worker)
        {
            _mailEngineReceive = new MailEngine(_userAccount, worker, _isAddAccount);

            if (!_mailEngineReceive.EngineStarted)
                return 1;

            _emailContent = _mailEngineReceive.EmailContent;
            return 0;
        }

        protected void StartUserAccount(string account)
        {
            if (_userAccount == null || account != null)
                _userAccount = new UserAccount(account);

            if (!_userAccount.UserSettingsExist || _isEditSettingsClick)
            {
                UserAccountForm frmConfigureSettings = new UserAccountForm(_userAccount);
                frmConfigureSettings.ShowDialog();
                _userAccount.SaveUserSettings(_userAccount.UserUsername);
            }
            _userAccount.Initialize();
        }

        private void DisplayEmail(int index)
        {

            string folder = GetSelectedFolder();

            _emailViewWindow.Navigate("about:blank");
            try
            {
                if (_emailViewWindow.Document != null)
                {
                    _emailViewWindow.Document.Write(string.Empty);
                }
            }
            catch (Exception e)
            { } // do nothing with this
            if (_emailContent != null && _emailContent.Tables[folder].Rows.Count > 0)
            {
                string emailTitle = _emailContent.Tables[folder].Rows[index]["Subject"].ToString();
                string emailBody = _emailContent.Tables[folder].Rows[index]["Body"].ToString();
                string emailFrom = _emailContent.Tables[folder].Rows[index]["From"].ToString();
                string emailDate = _emailContent.Tables[folder].Rows[index]["Date"].ToString();

                _emailTitleLbl.Text = emailTitle.Substring(emailTitle.IndexOf('-') + 2);
                _emailViewWindow.DocumentText = emailBody;

                // Parse out name and address from emailFrom variable
                if (ParseFromField(emailFrom))
                {
                    // Set Label Text to name of sender
                    _fromValueLabel.Text = _fromArray[0];
                    _fromValueLabel.Font = new Font(_fromValueLabel.Font.Name, 9, FontStyle.Bold | FontStyle.Underline);
                    _fromNameToolTip.SetToolTip(_fromValueLabel, _fromArray[1]);
                }
                else
                {
                    _fromValueLabel.Text = _fromArray[1];
                    _fromValueLabel.Font = new Font(_fromValueLabel.Font.Name, 9, FontStyle.Bold | FontStyle.Underline);
                }
                
                _receivedOnValueLabel.Text = emailDate;
            }
        }

        private void ComposeEmail()
        {
            ComposeEmail frmComposeEmail = new ComposeEmail(_userAccount);
            frmComposeEmail.ShowDialog();
        }

        private void ComposeEmail(string recipient)
        {
            ComposeEmail frmComposeEmail = new ComposeEmail(_userAccount, recipient);
            frmComposeEmail.ShowDialog();
        }

        private void ComposeEmail(string recipient, string originalContent)
        {
            ComposeEmail frmComposeEmail = new ComposeEmail(_userAccount, recipient, originalContent);
            frmComposeEmail.ShowDialog();
        }

        private string GetSelectedFolder()
        {
            return "Inbox";
        }

        private int GetSelectedEmailIndex()
        {
            return _listboxInbox.SelectedIndex;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {

            //var _thread = new Thread(StartUserAccount());
            StartUserAccount(null);

            // Implement the method to disable controls too but cross-thread error
            Application.UseWaitCursor = true; 

            // Start background thread to get mail
            _mailBackgroundWorker.RunWorkerAsync();
        }

        private void _listboxInbox_Click(object sender, EventArgs e)
        {
            DisplayEmail(_listboxInbox.SelectedIndex);
        }


        private void composeEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComposeEmail();
        }

        private void _editAccountSettingsToolStripSubMenuItem_Click(object sender, EventArgs e)
        {
            _isEditSettingsClick = true;

            // Reset _userAccount
            _userAccount = null;
            StartUserAccount(null);
            _isAddAccount = true;

            // Start background thread to get mail
            _mailBackgroundWorker.RunWorkerAsync();

            _isEditSettingsClick = false;
        }

        private void _aboutToolStripSubMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm frmAboutForm = new AboutForm();
            frmAboutForm.ShowDialog();
        }

        private void _sendAndRecieveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _mailEngineReceive.GetNewMessages = true;

            Application.UseWaitCursor = true;
            _updateMailBackgroundWorker.RunWorkerAsync();
        }

        private void _listboxInbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = _listboxInbox.SelectedIndex >= 1 ? _listboxInbox.SelectedIndex : 0;
            DisplayEmail(index);
        }

        private void _listboxInbox_MouseMove(object sender, MouseEventArgs e)
        {
            int newHoveredIndex = _listboxInbox.IndexFromPoint(e.Location);

            if (_hoveredIndex != newHoveredIndex)
            {
                _hoveredIndex = newHoveredIndex;
                if (_hoveredIndex > -1)
                {
                    string subject = _emailContent.Tables[0].Rows[_hoveredIndex]["Subject"].ToString();
                    _inboxToolTip.Active = false;
                    _inboxToolTip.SetToolTip(_listboxInbox, subject);
                    _inboxToolTip.Active = true;
                }
            }
        }

        private void _inboxTitleTextbox_TextChanged(object sender, EventArgs e)
        {
            // Implement effect
        }

        private int InitializeEmailEngine(BackgroundWorker worker)
        {
            if (StartMailEngine(worker) == 1)
            {
                StartUserAccount(null);
            }
            return 1;
        }

        private void SetBusyStatus(bool active)
        {
            Application.UseWaitCursor = active;
            _sendAndRecieveToolStripMenuItem.Enabled = active == true ? false : true;
        }

        private bool ParseFromField(string emailFrom)
        {

            int nameStart = emailFrom.IndexOf("'");
            int nameEnd = emailFrom.IndexOf("'", nameStart + 1);
            string fromName = emailFrom.Substring(nameStart + 1, (nameEnd - nameStart) - 1);

            int addressStart = emailFrom.IndexOf("'", nameEnd + 1);
            int addressEnd = emailFrom.IndexOf("'", addressStart + 1);
            string fromAddress = emailFrom.Substring(addressStart + 1, (addressEnd - addressStart) - 1);

            if (fromName == "")
                _fromArray[0] = "";

            _fromArray[0] = fromName;       // 0 = Name
            _fromArray[1] = fromAddress;    // 1 = Email

            if (nameEnd - nameStart > 1)
                return true;
            else
                return false;
        }

        private void _mailBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get background worker that raised this event
            BackgroundWorker worker = sender as BackgroundWorker;

            worker.ReportProgress(0);

            e.Result = InitializeEmailEngine(worker);
            Application.UseWaitCursor = false;
        }

        private void _mailBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_isAddAccount)
                _isAddAccount = false;

            _folderList = _mailEngineReceive.GetFolderList;
            PopulateFolderList();
            PopulateInboxList(0);

            //Reset progress bar
            _mailProgressBar.Value = 0;

            _fromLabel.Visible = true;
            _receivedOnLabel.Visible = true;
            _replyPictureBtn.Visible = true;
            Application.UseWaitCursor = false;

            LoadAccountButtons();
        }

        void tsBtn_Click(object sender, EventArgs e)
        {
            ToolStripButton account = sender as ToolStripButton;
            StartUserAccount(account.Name);
            _mailBackgroundWorker.RunWorkerAsync();
        }

        private void _mailBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _mailProgressBar.Value = e.ProgressPercentage;
        }

        private void _updateMailBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get background worker that raised this event
            BackgroundWorker worker = sender as BackgroundWorker;

            _mailEngineReceive.GetEmail(worker);
        }

        private void _updateMailBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _emailContent = _mailEngineReceive.EmailContent;
            PopulateInboxList(0);
            Application.UseWaitCursor = false;
        }

        private void _listboxFolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateInboxList(_listboxFolders.SelectedIndex == -1 ? 0 : _listboxFolders.SelectedIndex);
        }

        private void _fromValueLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_fromArray[0] != "")
                _fromNameToolTip.Active = true;
            else
                _fromNameToolTip.Active = false;
        }

        private void _fromValueLabel_Click(object sender, EventArgs e)
        {
            ComposeEmail(_fromArray[1]);
        }

        private void _replyPictureBtn_Click(object sender, EventArgs e)
        {
            ComposeEmail(_fromArray[1], _emailContent.Tables[GetSelectedFolder()].Rows[GetSelectedEmailIndex()]["Body"].ToString());
        }

        private void LoadAccountButtons()
        {
            if (_accountButtonList.Count == 0)
            {
                foreach (string account in _userAccount.Usernames)
                {
                    ToolStripButton tsBtn = new ToolStripButton(account);
                    tsBtn.Name = account;
                    _accountToolStrip.Items.Add(tsBtn);
                    tsBtn.Click += new EventHandler(tsBtn_Click);
                }
            }
        }
    }
}
