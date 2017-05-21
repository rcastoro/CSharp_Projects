using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using Timesheet;
using System.Configuration;
using System.Net.Mail;
using System.Globalization;

namespace TimesheetService
{
    public class TimesheetService : ITimesheetService
    {

        public Timesheet.Employee GetEmployee(string employeeToken)
        {
            TimesheetDS.EmployeeDataTable dt = new TimesheetDS.EmployeeDataTable();
            TimesheetDSTableAdapters.EmployeeTableAdapter adapter = new TimesheetDSTableAdapters.EmployeeTableAdapter();
            Timesheet.Employee emp = new Timesheet.Employee();

            Guid employeeGUID = Guid.Parse(employeeToken);

            adapter.Fill(dt, employeeGUID);
            emp.employeeToken = employeeGUID;
            emp.email = dt[0]["EmailAddress"].ToString();
            emp.firstname = dt[0]["FirstName"].ToString();
            emp.lastname = dt[0]["LastName"].ToString();
            return emp;
        }

        public List<Timesheet.Timesheet> GetTimesheets(string employeeToken)
        {
            TimesheetDS.EmployeeTimesheetsDataTable dt = new TimesheetDS.EmployeeTimesheetsDataTable();
            TimesheetDSTableAdapters.EmployeeTimesheetsTableAdapter adapter = new TimesheetDSTableAdapters.EmployeeTimesheetsTableAdapter();
            List<Timesheet.Timesheet> _tsList = new List<Timesheet.Timesheet>();

            Guid employeeGUID = Guid.Parse(employeeToken);

            adapter.Fill(dt, employeeGUID);
            _tsList = dt.ToTimesheet();
            return _tsList;
        }

        public bool RequestEmailToken(string employeeToken)
        {
            TimesheetDS.EmployeeDataTable dt = new TimesheetDS.EmployeeDataTable();
            TimesheetDSTableAdapters.EmployeeTableAdapter adapter = new TimesheetDSTableAdapters.EmployeeTableAdapter();
            Timesheet.Employee emp = new Timesheet.Employee();

            Guid employeeGUID = Guid.Parse(employeeToken);

            adapter.Fill(dt, employeeGUID);
            emp.employeeToken = employeeGUID;
            emp.email = dt[0]["EmailAddress"].ToString();
            emp.firstname = dt[0]["FirstName"].ToString();
            emp.lastname = dt[0]["LastName"].ToString();

            return SendEmployeeTokenEmail(emp);
        }

        private bool SendEmployeeTokenEmail(Employee emp)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "SMTP.MAILSERVER.COM";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("<youremail@email.com>", "<yourpassword>");

            MailMessage mm = new MailMessage("<SUPPORT EMAIL>", emp.email.ToString());
            mm.Body = "Your requested employee token is: " + emp.employeeToken.ToString();
            mm.Subject = "Requested SHMS timesheet employee token";
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);

            return true;
        }

        public ResponseData Register(RequestRegister reqData)
        {
            TimesheetDS.EmployeeRegisterDataTable dt = new TimesheetDS.EmployeeRegisterDataTable();
            TimesheetDSTableAdapters.EmployeeRegisterTableAdapter adapter = new TimesheetDSTableAdapters.EmployeeRegisterTableAdapter();
            int id;

            id = Convert.ToInt32(adapter.RegisterEmployee(reqData.FirstName, reqData.LastName, reqData.Email));
            adapter.Fill(dt, id);
            string employeeToken = dt[0].EmployeeToken.ToString();
            bool relogin = dt[0].Relogin;

            var response = new ResponseData
                                {
                                    EmployeeToken = employeeToken.ToString(),
                                    Relogin = relogin
                                };
            return response;
        }

        public ResponseData AddTimesheet(Timesheet.Timesheet tsPost)
        {
            TimesheetDS.EmployeeTimesheetsDataTable dt = new TimesheetDS.EmployeeTimesheetsDataTable();
            TimesheetDSTableAdapters.EmployeeTimesheetsTableAdapter adapter = new TimesheetDSTableAdapters.EmployeeTimesheetsTableAdapter();
            int id;
            bool IsFirstHalf = tsPost.quarter == 1 ? true : false;

            id = Convert.ToInt32(adapter.AddTimesheet(tsPost.employee.employeeToken, tsPost.month, tsPost.year, tsPost.totalhours, IsFirstHalf));
            string TimesheetID = Convert.ToString(adapter.GetTimesheetID(id));

            var response = new ResponseData
                                {
                                    EmployeeToken = TimesheetID
                                };

            string TimesheetDayID;

            for (int i = 0; i < tsPost.days.Count(); i++)
            {
                id = Convert.ToInt32(adapter.AddTimesheetDay(Guid.Parse(TimesheetID), tsPost.days[i].date, tsPost.days[i].description.ToString()));
                TimesheetDayID = Convert.ToString(adapter.GetTimesheetDayID(id));

                for (int x = 0; x < tsPost.days[0].hours.Count(); x++)
                {
                    adapter.AddTimesheetHours(Guid.Parse(TimesheetDayID), Convert.ToDateTime(tsPost.days[i].hours[x].start), Convert.ToDateTime(tsPost.days[i].hours[x].end), (double)tsPost.days[i].hours[x].hours, (double)tsPost.days[i].hours[x].lunch);
                }
            }

            // Send Excel to Google Drive
            GoogleSheets _gs = new GoogleSheets(tsPost);

            //string monthName = new DateTime(tsPost.year, tsPost.month, 1).ToString("MMM", CultureInfo.InvariantCulture);
            //string empName = tsPost.employee.lastname.ToString() + ", " + tsPost.employee.lastname.ToString();
            //string body = "Timesheet for " + tsPost.employee.lastname.ToString() + ", " + tsPost.employee.firstname.ToString() + " - " + monthName + " " + tsPost.year.ToString() + " " + "Period: " + tsPost.quarter.ToString();
            
            //GoogleSheets _gs = new GoogleSheets(tsPost);
            //string fileTitle = _gs.fileTitle;

            //byte[] byteArray = System.IO.File.ReadAllBytes(@"C:\Users\Administrator\Desktop\Timesheet\TimesheetService_Deploy\bin\" + fileTitle + ".xls");

            //MailAttachment attach = new MailAttachment(byteArray, fileTitle+".xls");

            return response;
        }

        /// <summary>
        /// Send an email from [DELETED]
        /// </summary>
        /// <param name="to">Message to address</param>
        /// <param name="body">Text of message to send</param>
        /// <param name="subject">Subject line of message</param>
        /// <param name="fromAddress">Message from address</param>
        /// <param name="fromDisplay">Display name for "message from address"</param>
        /// <param name="credentialUser">User whose credentials are used for message send</param>
        /// <param name="credentialPassword">User password used for message send</param>
        /// <param name="attachments">Optional attachments for message</param>
        private static void Email(string to,
                                 string body,
                                 string subject,
                                 string fromAddress,
                                 string fromDisplay,
                                 string credentialUser,
                                 string credentialPassword,
                                 params MailAttachment[] attachments)
        {
            string host = ConfigurationManager.AppSettings["SMTPHost"];
            try
            {
                MailMessage mail = new MailMessage();
                mail.Body = body;
                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress(to));
                mail.From = new MailAddress(fromAddress, fromDisplay, Encoding.UTF8);
                mail.Subject = subject;
                mail.SubjectEncoding = Encoding.UTF8;
                mail.Priority = MailPriority.Normal;
                foreach (MailAttachment ma in attachments)
                {
                    mail.Attachments.Add(ma.File);
                }
                SmtpClient smtp = new SmtpClient();

                smtp.Port = 587;
                smtp.Host = "smtp.live.com";
                smtp.EnableSsl = true;
                smtp.Timeout = 10000;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(credentialUser, credentialPassword);

                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                //nah
            }
        }

    }
}
