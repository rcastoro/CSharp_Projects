using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

namespace TimesheetService
{
    [DataContract]
    public class ResponseData
    {
        [DataMember]
        public string EmployeeToken { get; set; }

        [DataMember]
        public bool Relogin { get; set; }
    }
}