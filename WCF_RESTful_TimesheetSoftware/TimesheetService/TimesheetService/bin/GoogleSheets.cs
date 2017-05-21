using System;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

using System.Security.Cryptography.X509Certificates;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace TimesheetService
{
    class GoogleSheets
    {
        // A known public activity.
        Timesheet.Timesheet _ts = new Timesheet.Timesheet();
        public string fileTitle;
        private static String ACTIVITY_ID = "z12gtjhq3qn2xxl2o224exwiqruvtda0i";
        static String CLIENT_ID = "416347511338-jlntl7fu5bo8008ohrfrhvcj48qjbgug.apps.googleusercontent.com";
        static String CLIENT_SECRET = "Y4hG3yE34wBBMQuxmQNm5H1s";
        static String APP_USER_AGENT = "Clock Watcher";
        static String[] SCOPES = new [] { DriveService.Scope.Drive };

        public GoogleSheets()
        {
            //Authorize();
        }

        public GoogleSheets(Timesheet.Timesheet ts)
        {
            _ts = ts;
            DriveService service = GetCredentials().Result;
            //stream.CopyTo(mstream);
            fileTitle = CreateExcelTimesheet();

            Google.Apis.Drive.v2.Data.File body = new Google.Apis.Drive.v2.Data.File();
            body.Title = fileTitle;
            body.Description = "Test1";
            body.MimeType = "application/vnd.ms-excel";

            byte[] byteArray = System.IO.File.ReadAllBytes(@"C:\Dump\" + fileTitle);
            MemoryStream mstream = new MemoryStream(byteArray);
            FilesResource.InsertMediaUpload request = service.Files.Insert(body, mstream, "application/vnd.ms-excel");
            request.Upload();

            Google.Apis.Drive.v2.Data.File file = request.ResponseBody;        
        }
        /// <summary> Returns the request initializer required for authorized requests. </summary>
        private static async Task<DriveService> GetCredentials()
        {
            ClientSecrets secrets = new ClientSecrets
            {
                ClientId = CLIENT_ID,
                ClientSecret = CLIENT_SECRET
            };

            IDataStore credentialPersistanceStore = getPersistentCredentialStore();

            UserCredential credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(secrets,
                    SCOPES, getUserId(), CancellationToken.None, credentialPersistanceStore);

            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = APP_USER_AGENT
            });

            return service;

        }

        /// <summary>
        /// Returns an ID string for the current user. IDs are unique within this application.
        /// </summary>
        private static String getUserId()
        {
            // TODO: Generate a unique user ID within your system for this user. The credential
            // data store will use this as a key to look up saved credentials.
            return "roccavincent@gmail.com";
        }

        /// <summary> Returns a persistent data store for user's credentials. </summary>
        private static IDataStore getPersistentCredentialStore()
        {
            // TODO: This uses a local file store to cache credentials. You should replace this with
            // the appropriate IDataStore for your application.
            return new FileDataStore("Drive.Sample.Credentals");
        }

        private string CreateExcelTimesheet()
        {
            string firstname = _ts.employee.firstname.ToString();
            string lastname = _ts.employee.lastname.ToString();
            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(_ts.month);

            int dtFrom = _ts.FromDate().Month;
            int dtTo = _ts.ToDate().Month;

            string title = lastname + ", " + firstname.Substring(0, 1) + " - " + monthName + " " + _ts.year.ToString() + " "  + _ts.FromDate().Day.ToString() + "-" + _ts.ToDate().Day.ToString();

            ExcelFunctionality excel = new ExcelFunctionality();
            excel.CreateWorkbook(_ts, title , 1);
            excel.SetWorksheetHeader(0, "Timesheet for " + firstname + " " + lastname + " | " + _ts.FromDate().Month.ToString() + "/" + _ts.FromDate().Day.ToString() + '/' + _ts.year.ToString() + " - " + _ts.ToDate().Month + '/' + _ts.ToDate().Day.ToString() + '/' + _ts.year.ToString());
            excel.AddCellToWorksheet(0, 1, 0, "Date");
            excel.AddCellToWorksheet(0, 1, 1, "Start Time");
            excel.AddCellToWorksheet(0, 1, 2, "End Time");
            excel.AddCellToWorksheet(0, 1, 3, "Lunch");
            
            excel.AddCellToWorksheet(0, 1, 4, "Hours");

            excel.AddTimesheet(_ts);
            fileTitle = excel.SaveWorkbook();

            return fileTitle;
        }
    }
}
