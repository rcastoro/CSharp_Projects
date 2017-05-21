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
    public class Employee
    {
        [DataMember]
        public Guid employeeToken;

        [DataMember]
        public string email;

        [DataMember]
        public string firstname;

        [DataMember]
        public string lastname;
    }
}