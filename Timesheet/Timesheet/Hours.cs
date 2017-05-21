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
    public class Hours
    {
        [DataMember]
        public string start;

        [DataMember]
        public string end;

        [DataMember]
        public double lunch;

        [DataMember]
        public double hours;
    }
}