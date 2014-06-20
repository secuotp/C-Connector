using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace C_Connector
{
    public class XMLConnector
    {
        public string connector(string xml)
        {
            string uri = "http://secuotp.sit.kmutt.ac.th/SecuOTP-Service/manage/register/end-user";
            HttpWebRequest req = HttpWebRequest.Create(uri) as HttpWebRequest;
            req.Method = "POST";
            req.ContentType = "text/xml";
            req.ContentLength = 0;

            String data = "request=" + xml;

            StreamWriter sw = new StreamWriter(req.GetRequestStream());
            sw.WriteLine(data);
            req.GetResponse();
            
            return req.ToString();
        }
    }
}
