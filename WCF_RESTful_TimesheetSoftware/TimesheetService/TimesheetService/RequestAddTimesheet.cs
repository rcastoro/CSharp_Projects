using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace TimesheetService
{
    [DataContract(Namespace = "TimesheetService")]
    public class RequestAddTimesheet
    {
        [DataMember]
        public string FirstName { get; set; }
    }
}