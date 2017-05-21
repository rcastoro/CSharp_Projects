using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Text;
using System.Net;
using System.IO;

namespace TimesheetClient
{
    partial class Register : Form
    {
        string _urlRegister;
        string _urlRequestToken;
        public string employeeToken;
        public bool relogin;

        public Register()
        {
            InitializeComponent();
        }

        public Register(string urlRegister, string urlRequestToken)
        {
            InitializeComponent();

            if (Properties.Settings.Default.EmployeeToken != "00000000-0000-0000-0000-000000000000")
            {
                employeeToken = Properties.Settings.Default.EmployeeToken;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            _urlRegister = urlRegister;
            _urlRequestToken = urlRequestToken;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterEmployee();
            if (relogin)
            {
                using (var _loginForm = new Login(_urlRequestToken, employeeToken))
                {
                    if (_loginForm.DialogResult == DialogResult.OK)
                    {
                        Properties.Settings.Default.Save();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                    }
                }
            }
            else
            {
                Properties.Settings.Default.EmployeeToken = employeeToken;
                Properties.Settings.Default.Save();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void RegisterEmployee()
        {
            const string quote = "\"";
            string xml = @"<RequestRegister xmlns=" + quote + "TimesheetService" + quote + ">" +
                                      "<Email>" + _txtBxEmail.Text.ToString() + "</Email>" +
                                      "<FirstName>" + _txtBxFirstName.Text.ToString() + "</FirstName>" +
                                      "<LastName>" + _txtBxLastName.Text.ToString() + "</LastName>" +
                                    "</RequestRegister>";

            SubmitPOST post = new SubmitPOST(xml, _urlRegister);
            employeeToken = post.Response[0];
            relogin = Convert.ToBoolean(post.Response[1]);
        }
    }
}
