using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Globalization;

namespace TimesheetClient
{
    public partial class _timesheetForm : Form
    {
        public _timesheetForm()
        {
            InitializeComponent();
        }

        public _timesheetForm(Timesheet.Timesheet ts)
        {
            InitializeComponent();
            SetupForm(ts);
            DataTable dt = FlattenToDatatable(ts);

            //var timesheetrange = (from table in dt.AsEnumerable()
            //                      group table by table["Date"] into g
            //                      let f = g.FirstOrDefault() 
            //                     select new
            //                     {
            //                         MinDate = g.Min(c => c["Date"]),
            //                         MaxDate = g.Max(c => c["Date"]),
            //                     });

            _gridTimesheet.DataSource = dt;
            FormatDataGridView();
        }

        private void FormatDataGridView()
        {

            string previousDate = "";
            foreach (DataGridViewRow row in _gridTimesheet.Rows)
            {
                if (row.Cells["Date"].Value != null)
                {
                    if (previousDate == row.Cells["Date"].Value.ToString())
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                    previousDate = row.Cells["Date"].Value.ToString();
                }
            }
        }

        private void SetupForm(Timesheet.Timesheet ts)
        {
            string monthName = new DateTime(ts.year, ts.month, 1).ToString("MMM", CultureInfo.InvariantCulture);
            this.Text = monthName + " " + ts.year + " Qtr: " + ts.quarter;

            _lblDate.Text = monthName + " " + ts.year + " Qtr: " + ts.quarter;
        }

        public DataTable FlattenToDatatable(Timesheet.Timesheet ts)
        {
            DataTable dt = new DataTable();
            DataRow row;
            dt.TableName = "Records";

            DataColumn dateCol = new DataColumn();
            dateCol.ColumnName = "Date";
            DataColumn startCol = new DataColumn();
            startCol.ColumnName = "StartHours";
            DataColumn endCol = new DataColumn();
            endCol.ColumnName = "EndHours";
            DataColumn hourCol = new DataColumn();
            hourCol.ColumnName = "Hours";

            dt.Columns.Add(dateCol);
            dt.Columns.Add(startCol);
            dt.Columns.Add(endCol);
            dt.Columns.Add(hourCol);

            foreach (Timesheet.Day day in ts.days)
            {
                foreach (Timesheet.Hours hour in day.hours)
                {
                    row = dt.NewRow();
                    string dateOnly = day.date.ToShortDateString();
                    row["Date"] = dateOnly;

                    row["StartHours"] = hour.start;
                    row["EndHours"] = hour.end;
                    row["Hours"] = hour.hours;
                    dt.Rows.Add(row);
                }
            }
            return dt;
        }
    }
}
