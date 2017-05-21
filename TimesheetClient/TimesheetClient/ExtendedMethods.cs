using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;

namespace TimesheetClient
{
    static class ExtendedMethods
    {
        public static float TotalFloatHours(this TimeSpan value)
        {
            const int dividen = 60;

            double minuteDouble = TimeSpan.FromTicks(value.Ticks).TotalMinutes;
            float minutes = (float)minuteDouble;
            float hours = (float)minutes / dividen;
            hours = -hours;
            return hours;
        }

        public static float Truncate(this float value, int digits)
        {
            double mult = Math.Pow(10.0, digits);
            double result = Math.Truncate(mult * value) / mult;
            return (float)result;
        }

        public static Timesheet.Timesheet ToTimesheet(this DataTable value)
        {
            Timesheet.Timesheet ts = new Timesheet.Timesheet();
            Timesheet.Employee emp = new Timesheet.Employee();
            Timesheet.Day day = new Timesheet.Day();
            Timesheet.Hours hour;
            int pair = 0;
            DateTime dayCheck;

            foreach (DataRow row in value.Rows)
            {
                dayCheck = new DateTime();
                if (DateTime.TryParse(row["Date"].ToString(), out dayCheck))
                {
                    if (day.date != (DateTime)row["Date"])
                    {
                        if (pair >= 1)
                        {
                            ts.days.Add(day);
                            pair = 0;
                        }

                        day = new Timesheet.Day();
                        day.date = (DateTime)row["Date"];
                        day.description = row["DateDescription"].ToString();
                    }

                    hour = new Timesheet.Hours();
                    hour.start = row["StartHours"].ToString();
                    hour.end = row["EndHours"].ToString();
                    hour.hours = (double)row["Hours"];
                    hour.lunch = (double)row["Lunch"];
                    day.AddHoursObject(hour);
                    emp.firstname = row["FirstName"].ToString();
                    emp.lastname = row["LastName"].ToString();
                    emp.employeeToken = Guid.Parse(Properties.Settings.Default.EmployeeToken);
                    emp.email = row["DefaultEmailAddress"].ToString();
                    ts.month = Int32.Parse(row["Month"].ToString());
                    ts.year = Int32.Parse(row["Year"].ToString());
                    ts.quarter = Int32.Parse(row["Quarter"].ToString());
                    ts.totalhours = float.Parse(row["TotalHours"].ToString());
                    pair++;
                }
            }
            ts.days.Add(day);
            ts.employee = emp;
            return ts;
        }
    }
}
