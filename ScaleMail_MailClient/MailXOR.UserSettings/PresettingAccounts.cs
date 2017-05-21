using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailXOR.UserSettings
{
    class PresettingAccounts
    {
        public PresettingAccounts()
        {
            /*
             * presetting types:
             * 1 = Hotmail
             * 2 = Gmail
             * 3 = Outlook
             * 4....
            */
        }

        private int _presettingType;
        public int PresettingType
        {
            get
            {
                return _presettingType;
            }
            set
            {
                _presettingType = value;
            }
        }

        private string[] _serverSettings = new string[9];
        public string[] ServerSettings
        {
            get
            {
                return _serverSettings;
            }
        }

        public void LoadPresetting()
        {
            switch (_presettingType)
            {
                case 1:
                    // Incoming Mail Server (POP3, IMAP) Hotmail
                   _serverSettings[0] = "0";
                   _serverSettings[1] = "995";
                   _serverSettings[2] = "SSL";
                   _serverSettings[3] = "pop3.live.com";
                   _serverSettings[4] = "";
                   _serverSettings[5] = "";
                   _serverSettings[6] = "587";
                   _serverSettings[7] = "SSL";
                   _serverSettings[8] = "smtp.live.com";
                    break;
                case 2:
                    // Incoming Mail Server (POP3, IMAP) gmail
                    _serverSettings[0] = "1";
                    _serverSettings[1] = "995";
                    _serverSettings[2] = "SSL";
                    _serverSettings[3] = "imap.gmail.com";
                    _serverSettings[4] = "";
                    _serverSettings[5] = "";
                    _serverSettings[6] = "465";
                    _serverSettings[7] = "SSL";
                    _serverSettings[8] = "smtp.gmail.com";
                    break;
                case 3:
                    // Incoming Mail Server (POP3, IMAP) Hotmail
                    _serverSettings[0] = "0";
                    _serverSettings[1] = "995";
                    _serverSettings[2] = "SSL";
                    _serverSettings[3] = "pop3.live.com";
                    _serverSettings[4] = "";
                    _serverSettings[5] = "";
                    _serverSettings[6] = "587";
                    _serverSettings[7] = "SSL";
                    _serverSettings[8] = "smtp.live.com";
                    break;
                default:
                    break;
            }

        }
    }
}
