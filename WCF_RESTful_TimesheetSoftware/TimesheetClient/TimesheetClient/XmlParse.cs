using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace TimesheetClient
{
    class XmlParse : IEnumerable<string>
    {
        public XmlDocument Xml { get; set; }
        public List<string> ResponseMessage { get; set; }
        public string XmlNodePath { get; set; }

        private XmlParse()
        {

        }

        //public XmlParse(XmlDocument pXml)
        //{
        //    Xml = pXml;
        //    XmlDocument XmlDoc = new XmlDocument();
        //    XmlNodeList XmlNodeList = XmlDoc.DocumentElement.SelectNodes("/");
        //    Parse(XmlNodeList);
        //    EmployeeToken
        //}


        public XmlParse(XmlDocument pXml)
        {
            Xml = new XmlDocument();
            Xml = pXml;
            XmlNodeList XmlNodeList = Xml.DocumentElement.SelectNodes("/");
            Parse(XmlNodeList);
        }

        private void Parse(XmlNodeList xmlNodeList)
        {
            ResponseMessage = new List<string>();

            foreach (XmlNode node in xmlNodeList[0].FirstChild)
            {
                ResponseMessage.Add(node.InnerText.ToString());
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            foreach (string str in ResponseMessage)
            {

                if (str == null)
                {
                    break;
                }
                yield return str;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            // Lets call the generic version here
            return this.GetEnumerator();
        }

    }
}
