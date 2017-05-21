using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailXOR.UserSettings;
using MailXOR.EmailEngine;
using mshtml;

namespace MailXOR.UI
{
    public partial class ComposeEmail : Form
    {
        private UserAccount _userAccount;
        private MailEngine _mailEngine;
        private IHTMLDocument2 doc;
        private bool _isReply = false;
        private string _originalContent = "";
        private List<string> _attachmentLabels = new List<string>();
        private List<string> _attachmentPaths = new List<string>();
        private int _attachmentQuantity = 0;

        public ComposeEmail(UserAccount ua)
        {
            InitializeComponent();
            _userAccount = ua;
            _mailEngine = new MailEngine();
        }

        public ComposeEmail(UserAccount ua, string recipient)
        {
            InitializeComponent();
            _userAccount = ua;
            _mailEngine = new MailEngine();
            _sendToTxt.Text = recipient;
        }

        public ComposeEmail(UserAccount ua, string recipient, string originalContent)
        {
            InitializeComponent();
            _userAccount = ua;
            _mailEngine = new MailEngine();
            _sendToTxt.Text = recipient;
            _isReply = true;
            _originalContent = originalContent;
        }

        private void LoadOriginalMessage()
        {
            if (_isReply)
            {
                _emailBodyWebBrowser.DocumentText = _originalContent;
            }
        }

        private void RefreshAttachmentLabel(string attachment)
        {
            _attachmentLabels.Add(Path.GetFileName(attachment));
            var _attachmentConcat = String.Join("    &&&&    ", _attachmentLabels.ToArray());
            _attachmentsLbl.Text = _attachmentConcat.ToString();
        }

        private void AttachAttachments(string attachment)
        {
            _mailEngine.AttachmentPath = attachment;
        }

        private void _sendMailBtn_Click(object sender, EventArgs e)
        {
            _mailEngine.ProcessMailToSend(_sendToTxt.Text, _sendSubjectTxt.Text, _emailBodyWebBrowser.DocumentText, _userAccount.UserUsername);
            this.Close();
        }

        private void _addAttachmentBtn_Click(object sender, EventArgs e)
        {
            DialogResult _filePick = _openAttachmentDialog.ShowDialog();
            if (_filePick == DialogResult.OK)
            {
                AttachAttachments(_openAttachmentDialog.FileName);
                RefreshAttachmentLabel(_openAttachmentDialog.FileName);
                _attachmentQuantity++; // Increment quantity
            }

            if (_attachmentLabels.Count > 0)
                _attachmentQuantityLbl.Text = _attachmentQuantity.ToString();
        }

        private void _addAttachmentBtn_MouseHover(object sender, EventArgs e)
        {
            if (_openAttachmentDialog.FileName != null)
            {
                ToolTip _attachmentToolTip = new ToolTip();
                _attachmentToolTip.SetToolTip(this._addAttachmentBtn, _openAttachmentDialog.FileName.ToString());
            }
        }

        private void ComposeEmail_Load(object sender, EventArgs e)
        {
            _emailBodyWebBrowser.DocumentText = "<html><body></body></html>";

            doc = _emailBodyWebBrowser.Document.DomDocument as IHTMLDocument2;
            doc.designMode = "On";

            LoadOriginalMessage();
        }
    }
}
