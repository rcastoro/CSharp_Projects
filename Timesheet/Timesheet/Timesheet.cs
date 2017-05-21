using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Collections;
using System.Data;

namespace Timesheet
{
    [Serializable()]
    [DataContract]
    public class Timesheet
    {
        [DataMember]
        public Employee employee;

        [DataMember]
        public List<Day> days;

        [DataMember]
        public int month;

        [DataMember]
        public int year;

        [DataMember]
        public int quarter;

        [DataMember]
        public float totalhours;

        public Timesheet()
        {
            days = new List<Day>();
        }

        public DateTime FromDate()
        {
            DateTime minDate = new DateTime();

            var query = days.GroupBy(r => r.date)
                    .Select(grp => new
                              {
                                  Min = grp.Min(t => t.date)
                              });

            minDate = Convert.ToDateTime(query.Min(r=> r.Min));
            return minDate;
        }

        public DateTime ToDate()
        {
            DateTime maxDate = new DateTime();

            var query = days.GroupBy(r => r.date)
                    .Select(grp => new
                    {
                        Max = grp.Max(t => t.date)
                    });

            maxDate = Convert.ToDateTime(query.Max(r=> r.Max));
            return maxDate;
        }
    }
}