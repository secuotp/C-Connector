using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace C_Connection
{
    public class XMLDocCreate
    {
        public static readonly string REGISTER_END_USER = "S-01";
        private static readonly string REGISTER_END_USER_NAME = "Register End-User";

        public string createRequest(string service, XMLParameter siteAuthentication, XMLParameter userInfo)
        {
            XmlDocument xml = new XmlDocument();
            XmlDeclaration dec = xml.CreateXmlDeclaration("1.0","UTF-8",null);
            XmlElement root = xml.DocumentElement;
            xml.InsertBefore(dec,root);

            XmlElement rootNode = xml.CreateElement(string.Empty,"secuotp",string.Empty);
            xml.AppendChild(rootNode);

            XmlElement serviceNode = xml.CreateElement(string.Empty, "service", string.Empty);
            serviceNode.SetAttribute("sid", service);
            XmlText servicename = xml.CreateTextNode(getServiceName(service));
            serviceNode.AppendChild(servicename);
            rootNode.AppendChild(serviceNode);

            XmlElement authenticationNode = xml.CreateElement(string.Empty, "authentication", string.Empty);
            rootNode.AppendChild(authenticationNode);

            while (userInfo.hasNext())
            {
                string[] text = siteAuthentication.pop();
                XmlElement node = xml.CreateElement(string.Empty, text[0] , string.Empty);
                XmlText value = xml.CreateTextNode(text[1]);
                authenticationNode.AppendChild(node);
                authenticationNode.AppendChild(value);
            }

            XmlElement parameterNode = xml.CreateElement(string.Empty, "parameter", string.Empty);
            rootNode.AppendChild(parameterNode);

            while (userInfo.hasNext())
            {
                string[] text = siteAuthentication.pop();
                XmlElement node = xml.CreateElement(string.Empty, text[0], string.Empty);
                XmlText value = xml.CreateTextNode(text[1]);
                parameterNode.AppendChild(node);
                parameterNode.AppendChild(value);
            }

            xml.Normalize();
            return xml.OuterXml;
        }

        private string getServiceName(string service)
        {
            if (service.Equals(REGISTER_END_USER))
            {
                return REGISTER_END_USER_NAME;
            }
            return null;
        }
    }
}
