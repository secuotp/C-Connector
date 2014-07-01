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
        public string connector(string xml, string url)
        {
            string uri = url;
            HttpWebRequest req = HttpWebRequest.Create(uri) as HttpWebRequest;
            req.Method = "POST";
            req.ContentType = "application/xml";
            String send = "request=" + xml;
            byte[] data = Encoding.Default.GetBytes(send);
            req.ContentLength = data.Length;

            Stream sw = req.GetRequestStream();
            sw.Write(data, 0, data.Length);
            sw.Close();

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(res.GetResponseStream());

            return sr.ReadToEnd().ToString();
        }
    }
}
