using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailXOR.UserSettings;

namespace MailXOR.UI
{
    public partial class UserAccountForm : Form
    {
        private UserAccount _userAccount;
        private bool _isPresetting = false;

        public UserAccountForm()
        {
            InitializeComponent();
        }

        public UserAccountForm(UserAccount userAccount)
        {
            InitializeComponent();

            _userAccount = userAccount;
        }

        protected void TestSettings()
        {

            if (_inServerTxt.Text == "")
                return;
            else if (_inPortTxt.Text == "")
                return;
            else if (_usernameTxt.Text == "")
                return;
            else if (_passwordTxt.Text == "")
                return;

            _userAccount.InUserProtocol = _inProtocolCbo.Text;
            _userAccount.InUserPort = _inPortTxt.Text;
            if (_inSSLChkBx.Checked == true)
                _userAccount.InUserSSL = "SSL";
            else
                _userAccount.InUserSSL = "NoSSL";
            _userAccount.InUserServer = _inServerTxt.Text;
            _userAccount.UserUsername = _usernameTxt.Text;
            _userAccount.UserPassword = _passwordTxt.Text;

        }

        protected void SaveSettings()
        {
                _userAccount.InUserProtocol = _inProtocolCbo.Text;
                _userAccount.InUserPort = _inPortTxt.Text;
                if (_inSSLChkBx.Checked == true)
                    _userAccount.InUserSSL = "SSL";
                else
                    _userAccount.InUserSSL = "NoSSL";
                _userAccount.InUserServer = _inServerTxt.Text;
                _userAccount.UserUsername = _usernameTxt.Text;
                _userAccount.UserPassword = _passwordTxt.Text;

                _userAccount.OutUserPort = _outPortTxt.Text;
                _userAccount.OutUserServer = _outServerTxt.Text;
                if (_outSSLChkBx.Checked == true)
                    _userAccount.OutUserSSL = "SSL";
                else
                    _userAccount.OutUserSSL = "NoSSL";
        }

        private void _testSettingsBtn_Click(object sender, EventArgs e)
        {
            TestSettings();
        }

        private void _saveSettingsBtn_Click(object sender, EventArgs e)
        {

            if (_isPresetting)
            {
                _userAccount.UserUsername = _usernameTxt.Text;
                _userAccount.UserPassword = _passwordTxt.Text;
            }
            SaveSettings();
            this.Close();
        }

        private void _presetAccountsCboBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_presetAccountsCboBx.SelectedIndex > 0)
            {
                _userAccount.LoadPresettings(_presetAccountsCboBx.SelectedIndex);

                _inProtocolCbo.SelectedIndex = Int32.Parse(_userAccount.InUserProtocol);
                if (_userAccount.InUserSSL == "SSL")
                    _inSSLChkBx.Checked = true;
                else
                    _inSSLChkBx.Checked = false;
                _inServerTxt.Text = _userAccount.InUserServer;
                _inPortTxt.Text = _userAccount.InUserPort;

                _inProtocolCbo.Enabled = false;
                _inSSLChkBx.Enabled = false;
                _inServerTxt.Enabled = false;
                _inPortTxt.Enabled = false;

                _outPortTxt.Enabled = false;
                _outServerTxt.Enabled = false;
                _outSSLChkBx.Enabled = false;

                if (_userAccount.OutUserSSL == "SSL")
                    _outSSLChkBx.Checked = true;
                else
                    _outSSLChkBx.Checked = false;
                _outPortTxt.Text = _userAccount.OutUserPort;
                _outServerTxt.Text = _userAccount.OutUserServer;


                _isPresetting = true;

            }
        }
    }
}
