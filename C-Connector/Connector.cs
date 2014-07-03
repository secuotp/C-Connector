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
    public class Connector
    {
        public XmlDocument connector(string xml, string url, string service)
        {
            string method = "";
            
            if(service.Equals("O-02")){
                method = "GET";
            } else if(service.Equals("U-02")){
                method = "PUT";
            } else {
                method = "POST";
            }

            string uri = url;
            HttpWebRequest req = HttpWebRequest.Create(uri) as HttpWebRequest;
            req.Method = method;
            req.ContentType = "application/xml";
            String send = "request=" + xml;
            byte[] data = Encoding.Default.GetBytes(send);
            req.ContentLength = data.Length;

            Stream sw = req.GetRequestStream();
            sw.Write(data, 0, data.Length);
            sw.Close();

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(res.GetResponseStream());

            string recieve = sr.ReadToEnd().ToString();
            XmlDocument result = new XmlDocument();
            result.LoadXml(recieve);
            result.Normalize();

            return result;
        }
    }
}
