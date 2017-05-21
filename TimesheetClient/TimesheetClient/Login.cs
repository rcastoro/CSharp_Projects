using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Net;

namespace TimesheetClient
{
    public partial class Login : Form
    {
        private string _urlRequestToken;
        private string _employeeToken;

        public Login()
        {
            InitializeComponent();
        }

        public Login(string pUrlRequestToken, string pEmployeeToken)
        {
            InitializeComponent();
            _urlRequestToken = pUrlRequestToken;
            _employeeToken = pEmployeeToken;
            bool error = false;
            while (this.ShowDialog() == DialogResult.No)
            {
                error = true;

                if (error)
                    _lblError.Text = "Try Again";

                this.ShowDialog();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string serviceUrlGetEmployee;
            serviceUrlGetEmployee = _urlRequestToken + _employeeToken;
            var request = (HttpWebRequest)WebRequest.Create(serviceUrlGetEmployee);
            request.Method = "GET";
            var response = (HttpWebResponse)request.GetResponse();

            bool result;
            var dataContractSerializier = new DataContractSerializer(typeof(bool));

            using (var responseStream = response.GetResponseStream())
            {
                result = (bool)dataContractSerializier.ReadObject(responseStream);
            }
            response.Close();

            if (result)
            {
                MessageBox.Show("Employee token reminder sent to email on file. Check email and enter key here.");
            }
        }

        private void _btnLogin_Click(object sender, EventArgs e)
        {
            if (_employeeToken == _txtBxEmployeeToken.Text.ToLower())
            {
                Properties.Settings.Default.EmployeeToken = _employeeToken;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }
        }
    }
}
