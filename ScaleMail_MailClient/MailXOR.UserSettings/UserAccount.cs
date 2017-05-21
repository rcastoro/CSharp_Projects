using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace MailXOR.UserSettings
{
    public class UserAccount
    {
        // Properties
        private string[] _userSettings = new string[9];
        bool _settingsExist = false;
        private string _settingsFileName;
        private string _settingsPath;
        private string _settingsLocation;
        private string _account;
        private bool _pendingMailSMTP = false;

        public UserAccount()
        {
            // Default Constructor
            _settingsExist = SettingsExist();
        }

        public UserAccount(string account)
        {
            if (account != null)
                _account = account;
            _settingsExist = SettingsExist();
        }

        public bool UserSettingsExist
        {
            get
            {
                return _settingsExist;
            }
        }

        private bool _settingsVerified = false;
        public bool SettingsVerified
        {
            get
            {
                return _settingsVerified;
            }
            set
            {
                _settingsVerified = value;
            }
        }

        private string _inUserProtocol = "";
        public string InUserProtocol
        {
            get
            {
                return _inUserProtocol;
            }
            set
            {
                _inUserProtocol = value;
            }
        }

        private string _inUserPort = "";
        public string InUserPort
        {
            get
            {
                return _inUserPort;
            }
            set
            {
                _inUserPort = value;
            }
        }

        private string _inUserSSL = "";
        public string InUserSSL
        {
            get
            {
                return _inUserSSL;
            }
            set
            {
                _inUserSSL = value;
            }

        }

        private string _inUserServer = "";
        public string InUserServer
        {
            get
            {
                return _inUserServer;
            }
            set
            {
                _inUserServer = value;
            }
        }

        private string _userUsername = "";
        public string UserUsername
        {
            get
            {
                return _userUsername;
            }
            set
            {
                _userUsername = value;
            }
        }

        private string _userPassword = "";
        public string UserPassword
        {
            // Implement encryption using  byte[] cipherBytes = Convert.FromBase64String(cipherText);
            get
            {
                return _userPassword;
            }
            set
            {
                _userPassword = value;
            }
        }

        private string _outUserServer = "";
        public string OutUserServer
        {
            get
            {
                return _outUserServer;
            }
            set
            {
                _outUserServer = value;
            }
        }

        private string _outUserPort = "";
        public string OutUserPort
        {
            get
            {
                return _outUserPort;
            }
            set
            {
                _outUserPort = value;
            }
        }

        private string _outUserSSL = "";
        public string OutUserSSL
        {
            get
            {
                return _outUserSSL;
            }
            set
            {
                _outUserSSL = value;
            }
        }

        public bool PendingMail
        {
            get
            {
                return _pendingMailSMTP;
            }
            set
            {
                _pendingMailSMTP = value;
            }
        }

        private List<string> _usernames = new List<string>();
        public List<string> Usernames
        {
            get
            {
                _usernames = GetUsernames();
                return _usernames;
            }
            set
            {
                _usernames = value;
            }
        }

        public void Initialize()
        {
            if (_settingsExist)
                LoadUserSettings();
            else
                CreateNewUserSettings();
        }

        protected bool SettingsExist()
        {
            return Properties.Settings1.Default["Username"] == string.Empty ? false : true;
        }

        protected void LoadUserSettings()
        {
            ProcessSettings();
        }

        protected void CreateNewUserSettings()
        {

            if (Properties.Settings1.Default["Username"] == string.Empty)
            {
                _inUserProtocol =   Properties.Settings1.Default["IN_Protocol"].ToString();
                _inUserPort =       Properties.Settings1.Default["IN_Port"].ToString();
                _inUserSSL =        Properties.Settings1.Default["IN_SSL"].ToString();
                _inUserServer =     Properties.Settings1.Default["IN_Server"].ToString();
                _userUsername =     Properties.Settings1.Default["Username"].ToString();
                _userPassword =     Properties.Settings1.Default["Password"].ToString();

                _outUserPort =      Properties.Settings1.Default["OUT_Port"].ToString();
                _outUserSSL =       Properties.Settings1.Default["OUT_SSL"].ToString();
                _outUserServer =    Properties.Settings1.Default["OUT_Server"].ToString();
            }
            else
            {
                _inUserProtocol =   Properties.Settings2.Default["IN_Protocol"].ToString();
                _inUserPort =       Properties.Settings2.Default["IN_Port"].ToString();
                _inUserSSL =        Properties.Settings2.Default["IN_SSL"].ToString();
                _inUserServer =     Properties.Settings2.Default["IN_Server"].ToString();
                _userUsername =     Properties.Settings2.Default["Username"].ToString();
                _userPassword =     Properties.Settings2.Default["Password"].ToString();
                                                       
                _outUserPort =      Properties.Settings2.Default["OUT_Port"].ToString();
                _outUserSSL =       Properties.Settings2.Default["OUT_SSL"].ToString();
                _outUserServer =    Properties.Settings2.Default["OUT_Server"].ToString();
            }
        }

        protected void ProcessSettings()
        {
            if (Properties.Settings1.Default["Username"].ToString() == _account)
            {
                _inUserProtocol = Properties.Settings1.Default["IN_Protocol"].ToString();
                _inUserPort = Properties.Settings1.Default["IN_Port"].ToString();
                _inUserSSL = Properties.Settings1.Default["IN_SSL"].ToString();
                _inUserServer = Properties.Settings1.Default["IN_Server"].ToString();
                _userUsername = Properties.Settings1.Default["Username"].ToString();
                _userPassword = Properties.Settings1.Default["Password"].ToString();
                _outUserPort = Properties.Settings1.Default["OUT_Port"].ToString();
                _outUserSSL = Properties.Settings1.Default["OUT_SSL"].ToString();
                _outUserServer = Properties.Settings1.Default["OUT_Server"].ToString();
            }
            else if (Properties.Settings2.Default["Username"].ToString() == _account)
            {
                _inUserProtocol = Properties.Settings2.Default["IN_Protocol"].ToString();
                _inUserPort = Properties.Settings2.Default["IN_Port"].ToString();
                _inUserSSL = Properties.Settings2.Default["IN_SSL"].ToString();
                _inUserServer = Properties.Settings2.Default["IN_Server"].ToString();
                _userUsername = Properties.Settings2.Default["Username"].ToString();
                _userPassword = Properties.Settings2.Default["Password"].ToString();
                _outUserPort = Properties.Settings2.Default["OUT_Port"].ToString();
                _outUserSSL = Properties.Settings2.Default["OUT_SSL"].ToString();
                _outUserServer = Properties.Settings2.Default["OUT_Server"].ToString();
            }
            else
            {
                _inUserProtocol = Properties.Settings1.Default["IN_Protocol"].ToString();
                _inUserPort = Properties.Settings1.Default["IN_Port"].ToString();
                _inUserSSL = Properties.Settings1.Default["IN_SSL"].ToString();
                _inUserServer = Properties.Settings1.Default["IN_Server"].ToString();
                _userUsername = Properties.Settings1.Default["Username"].ToString();
                _userPassword = Properties.Settings1.Default["Password"].ToString();
                _outUserPort = Properties.Settings1.Default["OUT_Port"].ToString();
                _outUserSSL = Properties.Settings1.Default["OUT_SSL"].ToString();
                _outUserServer = Properties.Settings1.Default["OUT_Server"].ToString();
            }

            if (_pendingMailSMTP)
            {
                _outUserPort = Properties.Settings1.Default["OUT_Port"].ToString();
                _outUserSSL = Properties.Settings1.Default["OUT_SSL"].ToString();
                _outUserServer = Properties.Settings1.Default["OUT_Server"].ToString();
            }
        }

        // override for preset server settings
        protected void ProcessSettings(int presettingType)
        {
            _inUserProtocol =   _userSettings[0];
            _inUserPort =       _userSettings[1];
            _inUserSSL =        _userSettings[2];
            _inUserServer =     _userSettings[3];
            _userUsername =     _userSettings[4];
            _userPassword =     _userSettings[5];

            _outUserPort =      _userSettings[6];
            _outUserSSL =       _userSettings[7];
            _outUserServer =    _userSettings[8];
        }

        public void LoadPresettings(int presettingType)
        {
            PresettingAccounts _presettingAccounts = new PresettingAccounts();
            _presettingAccounts.PresettingType = presettingType;
            _presettingAccounts.LoadPresetting();
            _userSettings = _presettingAccounts.ServerSettings;
            ProcessSettings(presettingType);
        }

        public void SaveUserSettings(string username)
        {
            if (Properties.Settings1.Default["Username"] != string.Empty && Properties.Settings2.Default["Username"] == string.Empty)
            {
                Properties.Settings2.Default["Username"] = _userUsername;
                Properties.Settings2.Default["Password"] = _userPassword;
                Properties.Settings2.Default["IN_Protocol"] = _inUserProtocol;
                Properties.Settings2.Default["IN_Port"] = _inUserPort;
                Properties.Settings2.Default["IN_SSL"] = _inUserSSL;
                Properties.Settings2.Default["IN_Server"] = _inUserServer;
                Properties.Settings2.Default["OUT_Port"] = _outUserPort;
                Properties.Settings2.Default["OUT_SSL"] = _outUserSSL;
                Properties.Settings2.Default["OUT_Server"] = _outUserServer;
                Properties.Settings2.Default.Save();
            }
            else
            {
                Properties.Settings1.Default["Username"] = _userUsername;
                Properties.Settings1.Default["Password"] = _userPassword;
                Properties.Settings1.Default["IN_Protocol"] = _inUserProtocol;
                Properties.Settings1.Default["IN_Port"] = _inUserPort;
                Properties.Settings1.Default["IN_SSL"] = _inUserSSL;
                Properties.Settings1.Default["IN_Server"] = _inUserServer;
                Properties.Settings1.Default["OUT_Port"] = _outUserPort;
                Properties.Settings1.Default["OUT_SSL"] = _outUserSSL;
                Properties.Settings1.Default["OUT_Server"] = _outUserServer;
                Properties.Settings1.Default.Save();
            }
        }

        private List<string> GetUsernames()
        {
            List<string> usernames = new List<string>();
            if (Properties.Settings1.Default["Username"] != string.Empty)
            {
                usernames.Add(Properties.Settings1.Default["Username"].ToString());

                if (Properties.Settings2.Default["Username"] != string.Empty)
                    usernames.Add(Properties.Settings2.Default["Username"].ToString());
            }
            return usernames;
        }
    }
}
