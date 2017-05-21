using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Timesheet
{
    [Serializable()]
    [DataContract]
    public class Day
    {
        [DataMember]
        public DateTime date;

        [DataMember]
        public string description;

        [DataMember]
        public List<Hours> hours;

        public Day()
        {
            hours = new List<Hours>();
        }

        public void AddHoursObject(Hours range)
        {
            hours.Add(range);
        }

        //private string HumanReadableDate()
        //{
        //    //return date.
        //}
    }
}