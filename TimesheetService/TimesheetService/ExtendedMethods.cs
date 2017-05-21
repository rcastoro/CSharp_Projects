using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace TimesheetService
{
    public static class ExtendedMethods
    {        
        public static List<Timesheet.Timesheet> ToTimesheet(this DataTable value)
        {
            List<Timesheet.Timesheet> _tsList = new List<Timesheet.Timesheet>();
            List<DataTable> _dtList = new List<DataTable>();
            DataTable _dt = new DataTable();
            Timesheet.Timesheet _ts;
            Timesheet.Employee _emp = new Timesheet.Employee();
            Timesheet.Day _day = new Timesheet.Day();
            Timesheet.Hours _hour;
            int pair = 0;

            var timesheetid = from record in value.AsEnumerable()
                              group record by record.Field<Guid>("ID") into final
                              select final.Key;

            foreach(Guid id in timesheetid)
            {
                var timesheet = from record in value.AsEnumerable()
                                 where record.Field<Guid>("ID") == id
                                 select record;

                _dt = timesheet.CopyToDataTable<DataRow>();
                _dtList.Add(_dt);
            }

            foreach (DataTable dt in _dtList)
            {
                _ts = new Timesheet.Timesheet();

                foreach (DataRow row in dt.Rows)
                {
                    if (_day.date != (DateTime)row["Date"])
                    {
                        if (pair >= 1)
                        {
                            _ts.days.Add(_day);
                            pair = 0;
                        }

                        _day = new Timesheet.Day();
                        _day.date = (DateTime)row["Date"];
                        _day.description = row["DateDescription"].ToString();
                    }

                    _hour = new Timesheet.Hours();
                    _hour.start = row["StartHours"].ToString();
                    _hour.end = row["EndHours"].ToString();
                    _hour.hours = (double)row["Hours"];
                    _hour.lunch = (double)row["Lunch"];
                    _day.AddHoursObject(_hour);
                    _emp.firstname = row["FirstName"].ToString();
                    _emp.lastname = row["LastName"].ToString();
                    _emp.email = row["DefaultEmailAddress"].ToString();
                    _emp.employeeToken = (Guid)row["EmployeeToken"];
                    _ts.month = Int32.Parse(row["Month"].ToString());
                    _ts.year = Int32.Parse(row["Year"].ToString());
                    _ts.quarter = Int32.Parse(row["Quarter"].ToString());
                    _ts.totalhours = float.Parse(row["TotalHours"].ToString());
                    pair++;
                }
                _ts.days.Add(_day);
                _ts.employee = _emp;
                _tsList.Add(_ts);
                pair = 0;
            }
            return _tsList;
        }
    }
}