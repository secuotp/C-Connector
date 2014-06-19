using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;

namespace C_Connector
{
    class XMLConnector
    {

        public static void connector(string xml)
        {
            XmlDocument xmld = new XmlDocument();
            xmld.LoadXml(string.Format("<root>{0}</root>",xml));

            WebRequest req = null;

        }
    }
}
