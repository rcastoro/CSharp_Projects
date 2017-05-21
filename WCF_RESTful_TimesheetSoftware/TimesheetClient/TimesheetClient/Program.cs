using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TimesheetClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            ////Localhost
            //string url = "http://localhost:3537/TimesheetService.svc/employee/";
            //string urlRegister = "http://localhost:3537/TimesheetService.svc/register";
            //string urlAddTimesheet = "http://localhost:3537/TimesheetService.svc/addtimesheet";
            //string urlGetEmployee = "http://localhost:3537/TimesheetService.svc/getemployee/";
            //string urlRequestToken = "http://localhost:3537/TimesheetService.svc/requestemailtoken/";

            //AWS
            string url = "http://52.11.81.117/TimesheetService.svc/employee/";
            string urlRegister = "http://52.11.81.117/TimesheetService.svc/register";
            string urlAddTimesheet = "http://52.11.81.117/TimesheetService.svc/addtimesheet";
            string urlGetEmployee = "http://52.11.81.117/TimesheetService.svc/getemployee/";
            string urlRequestToken = "http://52.11.81.117/TimesheetService.svc/requestemailtoken/";

            Properties.Settings.Default.Reset();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            using (var _regForm = new Register(urlRegister, urlRequestToken))
            {
                if (_regForm.DialogResult == DialogResult.OK)
                {
                    Application.Run(new MainForm(url + Properties.Settings.Default.EmployeeToken.ToString(), urlAddTimesheet, urlGetEmployee));
                }
                else
                {
                    _regForm.ShowDialog();
                    if (_regForm.DialogResult == DialogResult.OK)
                    {
                        url = url + Properties.Settings.Default.EmployeeToken.ToString();
                        Application.Run(new MainForm(url, urlAddTimesheet, urlGetEmployee));
                    }
                }
            }
        }
    }
}
