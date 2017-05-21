using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Runtime.Serialization;
using System.IO;
using System.Globalization;
using System.Xml.Serialization;
using Timesheet;
using System.Xml;

namespace TimesheetClient
{
    public partial class MainForm : Form
    {
        enum Month
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            July,
            September,
            October,
            November,
            December
        };

        string _url;
        string _urlGetEmployee;
        string _urlAddTimesheet;

        Timesheet.Employee emp = new Timesheet.Employee();
        double totalHours = 0.0;
        List<Timesheet.Timesheet> _tsList = new List<Timesheet.Timesheet>();
        DataTable _dtNewTimesheet;
        DataTable _dtNewTimesheet_Formatted;

        public MainForm(string pUrl, string pUrlAddTimesheet, string pUrlGetEmployee)
        {
            InitializeComponent();
            _url = pUrl;
            _urlGetEmployee = pUrlGetEmployee;
            _urlAddTimesheet = pUrlAddTimesheet;
            InitiateConsole();
        }

        #region Console Functionality

        private void InitiateConsole()
        {
            _pnlViewTimesheet.Visible = false;
            _pnlAddTimesheet.Visible = false;
            //SetupListView();
            LoadTimesheets();
            MenuStrip_LoadTimesheetMenuItems();
        }

        private void InitiateConsole(bool IsReturning)
        {
            if (IsReturning)
            {
                _pnlViewTimesheet.Visible = false;
                _pnlAddTimesheet.Visible = false;
                _pnlCC.Visible = true;
            }            
        }

        //private void SetupListView()
        //{

        //}

        private List<Timesheet.Timesheet> DeserializeService()
        {
            var request = (HttpWebRequest)WebRequest.Create(_url);
            request.Method = "GET";
            var response = (HttpWebResponse)request.GetResponse();

            List<Timesheet.Timesheet> result;
            var dataContractSerializier = new DataContractSerializer(typeof(List<Timesheet.Timesheet>));

            using (var responseStream = response.GetResponseStream())
            {
                result = (List<Timesheet.Timesheet>)dataContractSerializier.ReadObject(responseStream);
            }
            response.Close();
            return result;
        }

        private List<Timesheet.Timesheet> LoadTimesheets()
        {
            _tsList = DeserializeService();

            _listviewTimesheets.Items.Add("Add Timesheet");
            _listviewTimesheets.Items[0].ImageIndex = 0;    // Add (ADD) timesheet icon always
            int i = 1;

            foreach (Timesheet.Timesheet ts in _tsList)
            {
                string monthName = new DateTime(ts.year, ts.month, 1).ToString("MMM", CultureInfo.InvariantCulture);

                int dtFrom = ts.FromDate().Month;
                int dtTo = ts.ToDate().Month;

                _listviewTimesheets.Items.Add(ts.FromDate().Month + "/" + ts.FromDate().Day.ToString() + '/' + ts.year.ToString() + " - " + ts.ToDate().Month + '/' + ts.ToDate().Day.ToString() + '/' + ts.year.ToString()).Tag = i;
                _listviewTimesheets.Items[i].ImageIndex = 1;    // Add (ADD) timesheet icon always
                i++;
            }
            _listviewTimesheets.Sort();
            return _tsList;
        }

        #endregion

        #region Menu Strip

        public void MenuStrip_LoadTimesheetMenuItems()
        {
            int i = 0;
            _viewTimesheetToolStripMenuItem.DropDownItems.Clear();
            foreach (Timesheet.Timesheet ts in _tsList)
            {
                _viewTimesheetToolStripMenuItem.DropDownItems.Add(ts.month.ToString() + '/' + ts.FromDate().Day.ToString() + '/' + ts.year.ToString());
                _viewTimesheetToolStripMenuItem.DropDownItems[i].Click += new EventHandler(_toolstripmenuitem_ClickViewTimesheet);
                i++;
            }
        }

        #endregion

        #region Add Timsheet
        //Add Timesheet functionality
        private void InititateAddTimesheet()
        {
            if (_pnlViewTimesheet.Visible)
                _pnlViewTimesheet.Visible = false;
            if (_pnlCC.Visible)
                _pnlCC.Visible = false;

            _pnlAddTimesheet.Visible = true;
            BindGridAddTimesheet(GuessTimesheetPeriod());
            FormatViewTimesheetDataGridView(_gridAddTimesheet);
        }

        private void BindGridAddTimesheet(List<DateTime> lsGuessedDates, float lunch = 0.5f)
        {
            totalHours = 0.0f;
            Timesheet.Timesheet ts = new Timesheet.Timesheet();
            _dtNewTimesheet = new DataTable();

            _dtNewTimesheet.TableName = "EmployeeTimesheets";
            _dtNewTimesheet.Columns.Add(new DataColumn("Date", typeof(DateTime)));
            _dtNewTimesheet.Columns.Add(new DataColumn("Time Begin", typeof(DateTime)));    // Time Start
            _dtNewTimesheet.Columns.Add(new DataColumn("Time End", typeof(DateTime)));
            _dtNewTimesheet.Columns.Add(new DataColumn("Lunch", typeof(double)));
            _dtNewTimesheet.Columns.Add(new DataColumn("Hours", typeof(double)));
            _dtNewTimesheet.Columns.Add(new DataColumn("Synopsis", typeof(string)));

            //Format new DataTable for conversion to TImesheet
            _dtNewTimesheet_Formatted = _dtNewTimesheet.Copy();

            //new - fill
            _dtNewTimesheet_Formatted.Columns.Add(new DataColumn("EmployeeToken", typeof(string)));
            _dtNewTimesheet_Formatted.Columns.Add(new DataColumn("DateDescription", typeof(string)));
            _dtNewTimesheet_Formatted.Columns.Add(new DataColumn("FirstName", typeof(string)));
            _dtNewTimesheet_Formatted.Columns.Add(new DataColumn("LastName", typeof(string)));
            _dtNewTimesheet_Formatted.Columns.Add(new DataColumn("DefaultEmailAddress", typeof(string)));
            _dtNewTimesheet_Formatted.Columns.Add(new DataColumn("Month", typeof(int)));
            _dtNewTimesheet_Formatted.Columns.Add(new DataColumn("Year", typeof(int)));
            _dtNewTimesheet_Formatted.Columns.Add(new DataColumn("Quarter", typeof(int)));
            _dtNewTimesheet_Formatted.Columns.Add(new DataColumn("TotalHours", typeof(string)));
            _dtNewTimesheet_Formatted.Columns["Time Begin"].ColumnName = "StartHours";
            _dtNewTimesheet_Formatted.Columns["Time End"].ColumnName = "EndHours";

            // Get Guessed timesheet period dates, pre-fill datagridview rows;
            DateTime dtFromDate = lsGuessedDates[0];
            DateTime dtToDate = lsGuessedDates[1];
            DateTime dtFromTime = new DateTime(dtFromDate.Year, dtFromDate.Month, dtFromDate.Day, 8, 30, 00, 00);
            DateTime dtToTime = new DateTime(dtFromDate.Year, dtFromDate.Month, dtFromDate.Day, 17, 00, 00, 00);
            int inc = 0;
            
            for (DateTime date = dtFromDate.Date; date <= dtToDate; date = date.AddDays(1))
            {

                DataRow row = _dtNewTimesheet.NewRow();
                DataRow rowFormatted = _dtNewTimesheet_Formatted.NewRow(); // Do one for this dt as well

                _dtNewTimesheet.Rows.Add(row);
                _dtNewTimesheet_Formatted.Rows.Add(rowFormatted); // Do one for this dt as well

                if (date.DayOfWeek.ToString() == "Saturday" || date.DayOfWeek.ToString() == "Sunday")
                {
                    // Notta
                }
                else
                {
                    // original dt
                    _dtNewTimesheet.Rows[inc]["Date"] = date;
                    _dtNewTimesheet.Rows[inc]["Time Begin"] = dtFromTime;
                    _dtNewTimesheet.Rows[inc]["Time End"] = dtToTime;

                    // copy
                    _dtNewTimesheet_Formatted.Rows[inc]["Date"] = date;
                    _dtNewTimesheet_Formatted.Rows[inc]["StartHours"] = dtFromTime;
                    _dtNewTimesheet_Formatted.Rows[inc]["EndHours"] = dtToTime;

                    TimeSpan duration = new TimeSpan(dtFromTime.Ticks - dtToTime.Ticks);
                    float rowHours = duration.TotalFloatHours();
                    float rowTotalHours = rowHours - lunch;
                    rowTotalHours.Truncate(2);

                    _dtNewTimesheet.Rows[inc]["Lunch"] = lunch;
                    _dtNewTimesheet.Rows[inc]["Hours"] = rowTotalHours;

                    //Copy
                    _dtNewTimesheet_Formatted.Rows[inc]["Lunch"] = lunch;
                    _dtNewTimesheet_Formatted.Rows[inc]["Hours"] = rowTotalHours;

                    totalHours += rowHours - lunch;

                    int quarter = dtFromDate.Day >= 1 && dtFromDate.Day <= 15 ? 1 : 2 ;

                    if (_tsList.Count == 0)
                    {
                        string serviceUrlGetEmployee;
                        serviceUrlGetEmployee = _urlGetEmployee + Properties.Settings.Default.EmployeeToken.ToString();
                        var request = (HttpWebRequest)WebRequest.Create(serviceUrlGetEmployee);
                        request.Method = "GET";
                        var response = (HttpWebResponse)request.GetResponse();

                        var dataContractSerializier = new DataContractSerializer(typeof(Timesheet.Employee));

                        using (var responseStream = response.GetResponseStream())
                        {
                            emp = (Timesheet.Employee)dataContractSerializier.ReadObject(responseStream);
                        }
                        response.Close();

                        _dtNewTimesheet_Formatted.Rows[inc]["TotalHours"] = totalHours;
                        _dtNewTimesheet_Formatted.Rows[inc]["FirstName"] = emp.firstname.ToString();
                        _dtNewTimesheet_Formatted.Rows[inc]["LastName"] = emp.lastname.ToString();
                        _dtNewTimesheet_Formatted.Rows[inc]["EmployeeToken"] = emp.employeeToken;
                        _dtNewTimesheet_Formatted.Rows[inc]["DefaultEmailAddress"] = emp.email.ToString();
                        _dtNewTimesheet_Formatted.Rows[inc]["Month"] = dtFromDate.Month;
                        _dtNewTimesheet_Formatted.Rows[inc]["Year"] = dtFromDate.Year;
                        _dtNewTimesheet_Formatted.Rows[inc]["Quarter"] = quarter;

                    }

                    //Copy only
                    if (_tsList.Count > 0)
                    {
                        _dtNewTimesheet_Formatted.Rows[inc]["TotalHours"] = totalHours;
                        _dtNewTimesheet_Formatted.Rows[inc]["DateDescription"] = "Coming in v2";
                        _dtNewTimesheet_Formatted.Rows[inc]["FirstName"] = _tsList[0].employee.firstname.ToString();
                        _dtNewTimesheet_Formatted.Rows[inc]["LastName"] = _tsList[0].employee.lastname.ToString();
                        _dtNewTimesheet_Formatted.Rows[inc]["EmployeeToken"] = _tsList[0].employee.employeeToken.ToString();
                        _dtNewTimesheet_Formatted.Rows[inc]["DefaultEmailAddress"] = _tsList[0].employee.email.ToString();
                        _dtNewTimesheet_Formatted.Rows[inc]["Month"] = dtFromDate.Month;
                        _dtNewTimesheet_Formatted.Rows[inc]["Year"] = dtFromDate.Year;
                        _dtNewTimesheet_Formatted.Rows[inc]["Quarter"] = quarter;
                    }
                }
                inc++;
            }

            // SET U.I. GRID TO ORIGINAL DATA TABLE AND BIND
            _gridAddTimesheet.DataSource = _dtNewTimesheet;
            _gridAddTimesheet.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "_delCol" , HeaderText = "None", DisplayIndex = 0});

            //Time only in time fields
            _gridAddTimesheet.Columns["Time Begin"].DefaultCellStyle.Format = "hh:mm:ss tt";
            _gridAddTimesheet.Columns["Time End"].DefaultCellStyle.Format = "hh:mm:ss tt";

            _gridAddTimesheet.Columns["Lunch"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            _lbl_AddTimesheet_TotalHoursValue.Text = totalHours.ToString();
            _lbl_AddTimesheet_EmailValue.Text = _tsList.Count == 0 ? emp.email.ToString() : _tsList[0].employee.email.ToString();             /// FIX THIS
            _lbl_AddTimesheet_TimestampValue.Text = DateTime.Now.ToString();
        }

        public List<DateTime> GuessTimesheetPeriod()
        {
            List<DateTime> _lsGussedDates = new List<DateTime>();
            DateTime dtNow = DateTime.Today;

            if (dtNow.Day >= 25)
            {
                DateTime dtFrom = new DateTime(dtNow.Year, dtNow.Month, 16);
                DateTime dtTo = new DateTime(dtNow.Year, dtNow.Month, DateTime.DaysInMonth(dtNow.Year, dtNow.Month));
                _dt_AddTimesheet_From.Value = dtFrom;
                _dt_AddTimesheet_To.Value = dtTo;
                _lsGussedDates.Add(dtFrom);
                _lsGussedDates.Add(dtTo);
            }
            else if (dtNow.Day <= 5)
            {
                DateTime dtFrom = new DateTime(dtNow.Year, dtNow.Month - 1, 16);
                DateTime dtTo = new DateTime(dtNow.Year, dtNow.Month - 1, DateTime.DaysInMonth(dtNow.Year, dtNow.Month - 1));
                _dt_AddTimesheet_From.Value = dtFrom;
                _dt_AddTimesheet_To.Value = dtTo;
                _lsGussedDates.Add(dtFrom);
                _lsGussedDates.Add(dtTo);
            }
            else
            {
                DateTime dtFrom = new DateTime(dtNow.Year, dtNow.Month, 1);
                DateTime dtTo = new DateTime(dtNow.Year, dtNow.Month, 15);
                _dt_AddTimesheet_From.Value = dtFrom;
                _dt_AddTimesheet_To.Value = dtTo;
                _lsGussedDates.Add(dtFrom);
                _lsGussedDates.Add(dtTo);
            }
            //FillDateComboBox(); -- This sets Date column of datagridview as a DateTimePicker - don't use yet
            return _lsGussedDates;
        }

        // UpdateTotalRowHours for changes in grid cells Time Start, Time End, and Lunch
        private void UpdateTotalRowHours(DataGridView dgv, int rowIndex)
        {
            DataGridViewRow gridRow = dgv.Rows[rowIndex];
            DateTime dtFromTime = (DateTime)gridRow.Cells["Time Begin"].Value;
            DateTime dtToTime = (DateTime)gridRow.Cells["Time End"].Value;
            DateTime dtFromTimeFinal = new DateTime(dtFromTime.Year, 1, 1, dtFromTime.Hour, dtFromTime.Minute, dtFromTime.Second);
            DateTime dtToTimeFinal = new DateTime(dtToTime.Year, 1, 1, dtToTime.Hour, dtToTime.Minute, dtToTime.Second);
            double lunchHours = (double)gridRow.Cells["Lunch"].Value;

            TimeSpan duration = new TimeSpan(dtFromTimeFinal.Ticks - dtToTimeFinal.Ticks);
            float rowHours = duration.TotalFloatHours();
            double rowHoursTotal = rowHours - lunchHours;
            float rowHoursTotalFloat = (float)rowHoursTotal;
            rowHoursTotalFloat.Truncate(2);

            gridRow.Cells["Hours"].Value = rowHoursTotalFloat;

            totalHours = 0;
            for (int i = 0; i < dgv.Rows.Count - 1; i++)
            {
                if (dgv.Rows[i].Cells["Date"].Value.ToString() != "" && dgv.Rows[i] != null)
                {
                    totalHours += (double)dgv.Rows[i].Cells["Hours"].Value;
                }
            }
            float totalHoursFloat = (float)totalHours;
            totalHoursFloat = totalHoursFloat.Truncate(2);
            _lbl_AddTimesheet_TotalHoursValue.Text = totalHoursFloat.ToString();


            for(int i = 0; i<dgv.Rows.Count - 1; i++)
            {
                if (dgv.Rows[i].Cells["Date"].Value.ToString() != "")
                {
                    float hours = float.Parse(_dtNewTimesheet.Rows[i]["Hours"].ToString());
                    hours = hours.Truncate(2);
                    _dtNewTimesheet_Formatted.Rows[i]["StartHours"] = _dtNewTimesheet.Rows[i]["Time Begin"];
                    _dtNewTimesheet_Formatted.Rows[i]["EndHours"] = _dtNewTimesheet.Rows[i]["Time End"];
                    _dtNewTimesheet_Formatted.Rows[i]["Lunch"] = _dtNewTimesheet.Rows[i]["Lunch"];
                    _dtNewTimesheet_Formatted.Rows[i]["Hours"] = hours;
                    _dtNewTimesheet_Formatted.Rows[i]["TotalHours"] = totalHoursFloat.ToString();
                }
            }
            FormatViewTimesheetDataGridView(dgv);
        }

        #endregion
        
        #region View Timesheet
        // View Timesheet functionality

        private void InitiateViewTimesheet(int index)
        {
            if (_pnlAddTimesheet.Visible)
                _pnlAddTimesheet.Visible = false;
            if (_pnlCC.Visible)
                _pnlCC.Visible = false;

            _pnlViewTimesheet.Visible = true;
            Timesheet.Timesheet ts = _tsList[index];

            string monthName = new DateTime(ts.year, ts.month, 1).ToString("MMM", CultureInfo.InvariantCulture);
            _lbl_ViewTimesheet_TotalHours.Text = ts.totalhours + "hrs.";

            int inc = 0;
            int dayInt = 0;
            DateTime minDate = new DateTime();
            DateTime maxDate = new DateTime();

            foreach (Timesheet.Day day in ts.days)
            {
                dayInt = Convert.ToInt32(day.date.Day);

                if (inc == 0)
                {
                    minDate = day.date;
                }
                
                if (dayInt > maxDate.Day)
                {
                    maxDate = day.date.Date;
                }

                inc++;
            }

            _dt_ViewTimesheet_From.Value = minDate;
            _dt_ViewTimesheet_To.Value = maxDate;


            DataTable dt = FlattenToDatatable(ts);
            _gridTimesheet.DataSource = dt;

            //Place DAY description in each tooltip on Date cell
            int i = 0;
            foreach (DataGridViewRow row in _gridTimesheet.Rows)
            {
                Timesheet.Day day;
                if (i == 0)
                    day = _tsList[index].days[i];
                else
                    day = _tsList[index].days[i-1];

                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.ToolTipText = day.description.ToString();
                }
                i++;
            }
            FormatViewTimesheetDataGridView(_gridTimesheet);
        }

        private void FormatViewTimesheetDataGridView(DataGridView grid)
        {
            int inc = 0;
            foreach (DataGridViewRow row in grid.Rows)
            {
                row.DefaultCellStyle.BackColor = inc % 2 == 0 ? Color.Beige : Color.White ;
                inc++;
            }
        }

        public DataTable FlattenToDatatable(Timesheet.Timesheet ts)
        {
            DataTable dt = new DataTable();
            DataRow row;
            dt.TableName = "Records";

            DataColumn dateCol = new DataColumn();
            dateCol.ColumnName = "Date";
            DataColumn startCol = new DataColumn();
            startCol.ColumnName = "Time Begin";
            DataColumn endCol = new DataColumn();
            endCol.ColumnName = "Time End";
            DataColumn lunchCol = new DataColumn("Lunch", typeof(double));
            DataColumn hourCol = new DataColumn();
            hourCol.ColumnName = "Hours";

            dt.Columns.Add(dateCol);
            dt.Columns.Add(startCol);
            dt.Columns.Add(endCol);
            dt.Columns.Add(lunchCol);
            dt.Columns.Add(hourCol);

            foreach (Timesheet.Day day in ts.days)
            {
                foreach (Timesheet.Hours hour in day.hours)
                {
                    row = dt.NewRow();
                    string dateOnly = day.date.ToShortDateString();
                    row["Date"] = dateOnly;

                    DateTime datestart = Convert.ToDateTime(hour.start);
                    DateTime dateend = Convert.ToDateTime(hour.end);

                    string strstart = datestart.ToShortTimeString();
                    string strend = dateend.ToShortTimeString();

                    row["Time Begin"] = strstart;
                    row["Time End"] = strend;
                    row["Lunch"] = (double)hour.lunch;
                    row["Hours"] = hour.hours;
                    dt.Rows.Add(row);
                }
            }
            return dt;
        }

        #endregion

        #region Events

        private void _toolstripmenuitem_ClickViewTimesheet(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            int index = (menuItem.OwnerItem as ToolStripMenuItem).DropDownItems.IndexOf(menuItem);
            InitiateViewTimesheet(index);
        }

        private void _listviewTimesheets_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_listviewTimesheets.FocusedItem.Bounds.Contains(e.Location))
                {
                    if (_listviewTimesheets.SelectedIndices[0] == 0)
                    {
                        InititateAddTimesheet();
                    }
                    else if (_listviewTimesheets.SelectedIndices[0] >= 1)
                    {
                        InitiateViewTimesheet(_listviewTimesheets.SelectedIndices[0] - 1);
                    }
                }
            }
        }

        private void _picReturn_Click(object sender, EventArgs e)
        {
            InitiateConsole(true);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _dt_AddTimesheet_From.Enabled = true;
            _dt_AddTimesheet_To.Enabled = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            InitiateConsole(true);
        }

        private void _refreshAddTimesheetGrid_Click(object sender, EventArgs e)
        {
            // Refresh _gridAddTimesheet with new date range after manual override
            List<DateTime> lsDates = new List<DateTime>();
            lsDates.Add(_dt_AddTimesheet_From.Value);
            lsDates.Add(_dt_AddTimesheet_To.Value);
            BindGridAddTimesheet(lsDates);
            FormatViewTimesheetDataGridView(_gridAddTimesheet);
        }

        private void _gridAddTimesheet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // if end time changes, update total hours
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                UpdateTotalRowHours((DataGridView)sender, e.RowIndex);
            }
            // if start time changes, update total hours
            else if (e.RowIndex >= 0 && e.ColumnIndex == 2)
            {
                UpdateTotalRowHours((DataGridView)sender, e.RowIndex);
            }
            // if lunch hours change, update total hours
            else if (e.RowIndex >= 0 && e.ColumnIndex == 3)
            {
                UpdateTotalRowHours((DataGridView)sender, e.RowIndex);
            }
        }

        private void _btnSubmitTimesheet_Click(object sender, EventArgs e)
        {
            string NewTimesheetID;

            List<Timesheet.Timesheet> tsList = new List<Timesheet.Timesheet>();
            Timesheet.Timesheet ts = new Timesheet.Timesheet();
            ts = _dtNewTimesheet_Formatted.ToTimesheet();

            string xml = SerializeTimesheet(ts);

            SubmitPOST post = new SubmitPOST(xml, _urlAddTimesheet);
            NewTimesheetID = post.Response[0];
            if (NewTimesheetID != null)
            {
                _listviewTimesheets.Items.Clear();
                InitiateConsole(true);
                LoadTimesheets();
                MenuStrip_LoadTimesheetMenuItems();
            }
        }

        private string SerializeTimesheet(Timesheet.Timesheet ts)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            using (StreamReader reader = new StreamReader(memoryStream))
            {
                DataContractSerializer serializer = new DataContractSerializer(ts.GetType());
                serializer.WriteObject(memoryStream, ts);
                memoryStream.Position = 0;
                return reader.ReadToEnd();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Properties.Settings.Default.EmployeeToken.ToString());
            MessageBox.Show("Your Employee Token has been copied to the clipboard.", "Copy Employee Token", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            InitiateConsole(true);
        }

        private void _addTimesheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InititateAddTimesheet();
        }
        #endregion

        private void _gridAddTimesheet_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception is FormatException)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 1)
                {
                    MessageBox.Show("Warning: Start Time not in correct format, try hh:mm:ss am/pm");
                }
                else if (e.RowIndex >= 0 && e.ColumnIndex == 2)
                {
                    MessageBox.Show("Warning: End Time not in correct format, try hh:mm:ss am/pm");
                }
                else if (e.RowIndex >= 0 && e.ColumnIndex == 3)
                {
                    MessageBox.Show("Warning: Hours are not in correct format, X or X.X");
                }
            }
        }

        private void RemoveRows()
        {
            foreach (int rowIndex in indexToDelete)
            {
                _dtNewTimesheet.Rows.RemoveAt(rowIndex);
            }
            indexToDelete.Clear();
        }

        //to top - global
        List<int> indexToDelete = new List<int>();

        private void _gridAddTimesheet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(_gridAddTimesheet.Columns.IndexOf(_gridAddTimesheet.Columns["_delCol"])))
            {
                indexToDelete.Add(e.RowIndex);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            RemoveRows();
        }
    }
}