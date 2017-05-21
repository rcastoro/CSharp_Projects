using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Activation;
using System.Data;

namespace TimesheetService
{
    [ServiceContract]
    public interface ITimesheetService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/getemployee/{employeeToken}",
            RequestFormat = WebMessageFormat.Xml,
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare)]
        Timesheet.Employee GetEmployee(string employeeToken);

        [OperationContract]
        [WebGet(UriTemplate = "/employee/{employeeToken}",
            RequestFormat = WebMessageFormat.Xml,
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare)]
        List<Timesheet.Timesheet> GetTimesheets(string employeeToken);

        [OperationContract]
        [WebGet(UriTemplate = "/requestemailtoken/{employeeToken}",
            RequestFormat = WebMessageFormat.Xml,
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare)]
        bool RequestEmailToken(string employeeToken);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Xml,
            RequestFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/register")]
        ResponseData Register(RequestRegister rData);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Xml,
            RequestFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/addtimesheet")]
        ResponseData AddTimesheet(Timesheet.Timesheet ts);
    }
}
