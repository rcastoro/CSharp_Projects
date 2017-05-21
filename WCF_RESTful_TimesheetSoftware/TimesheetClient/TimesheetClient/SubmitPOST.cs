using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Linq;

namespace TimesheetClient
{
    class SubmitPOST
    {
        public string XML { get; set; }
        public string ServiceURL { get; set; }
        public List<string> Response { get; set; }

        public SubmitPOST()
        {
            
        }

        public SubmitPOST(string pXml, string pUrlRegister)
        {
            XML = pXml;
            ServiceURL = pUrlRegister;

            Response = new List<string>();
            Response = POST();
        }

        private List<string> POST()
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            string postData = XML.ToString();
            string strResult = string.Empty;
            byte[] data = encoding.GetBytes(postData);
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(ServiceURL);
            // set method as post
            webrequest.Method = "POST";
            // set content type
            webrequest.ContentType = "text/xml; charset=utf-8";
            // set content length
            webrequest.ContentLength = data.Length;
            // get stream data out of webrequest object
            Stream newStream = webrequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();
            // declare & read response from service
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();

            // set utf8 encoding
            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            // read response stream from response object
            StreamReader loResponseStream =
        new StreamReader(webresponse.GetResponseStream(), enc);
            // read string from stream data
            strResult = loResponseStream.ReadToEnd();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(strResult);

            // close the stream object
            loResponseStream.Close();
            // close the response object
            webresponse.Close();

            XmlParse xmlParser = new XmlParse(xmlDoc);
            
            foreach (string str in xmlParser)
            {
                Response.Add(str);
            }
            
            return Response;
        }

    }
}
