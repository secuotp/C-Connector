using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;

namespace C_Connector
{
    public class XMLConnector
    {

        public XmlDocument connector(string xml)
        {
            XmlDocument xmld = new XmlDocument();
            xmld.LoadXml(xml);


            return xmld;
        }
    }
}
