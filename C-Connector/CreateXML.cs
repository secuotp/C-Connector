using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace C_Connector
{
    public class CreateXML
    {
        public static readonly string REGISTER_END_USER = "M-01";
        private static readonly string REGISTER_END_USER_NAME = "Register End-User";

        public static readonly string DISABLE_END_USER = "M-02";
        private static readonly string DISABLE_END_USER_NAME = "Disable End-User";

        public static readonly string GENERATE_ONE_TIME_PASSWORD = "G-01";
        private static readonly string GENERATE_ONE_TIME_PASSWORD_NAME = "Generate One-Time Password";

        public static readonly string AUTHENTICATE_ONE_TIME_PASSWORD = "A-01";
        private static readonly string AUTHENTICATE_ONE_TIME_PASSWORD_NAME = "Authenticate One-Time Password";

        public static readonly string MIGRATE_ONE_TIME_PASSWORD_CHANNEL = "?";
        private static readonly string MIGRATE_ONE_TIME_PASSWORD_CHANNEL_NAME = "Migrate One-Time Password Channel";

        public static readonly string TIME_SYNC = "?";
        private static readonly string TIME_SYNC_NAME = "Time Sync";

        public static readonly string GET_END_USER_DATA = "?";
        private static readonly string GET_END_USER_DATA_NAME = "Get End-User Data";

        public static readonly string PUT_END_USER_DATA = "?";
        private static readonly string PUT_END_USER_DATA_NAME = "Set End-User Data";
        
        public string createRequest(string service, XMLParameter siteAuthentication, XMLParameter userInfo)
        {
            XmlDocument xml = new XmlDocument();
            XmlDeclaration dec = xml.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = xml.DocumentElement;
            xml.InsertBefore(dec, root);

            XmlElement rootNode = xml.CreateElement(string.Empty, "secuotp", string.Empty);
            xml.AppendChild(rootNode);

            XmlElement serviceNode = xml.CreateElement(string.Empty, "service", string.Empty);
            serviceNode.SetAttribute("sid", service);
            XmlText servicename = xml.CreateTextNode(getServiceName(service));
            serviceNode.AppendChild(servicename);
            rootNode.AppendChild(serviceNode);

            XmlElement authenticationNode = xml.CreateElement(string.Empty, "authentication", string.Empty);
            rootNode.AppendChild(authenticationNode);

            while (siteAuthentication.hasNext())
            {
                string[] text = siteAuthentication.pop();
                XmlElement node = xml.CreateElement(string.Empty, text[0], string.Empty);
                XmlText value = xml.CreateTextNode(text[1]);
                authenticationNode.AppendChild(node);
                node.AppendChild(value);
            }

            XmlElement parameterNode = xml.CreateElement(string.Empty, "parameter", string.Empty);
            rootNode.AppendChild(parameterNode);

            while (userInfo.hasNext())
            {
                string[] text = userInfo.pop();
                XmlElement node = xml.CreateElement(string.Empty, text[0], string.Empty);
                XmlText value = xml.CreateTextNode(text[1]);
                parameterNode.AppendChild(node);
                node.AppendChild(value);
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
            else if (service.Equals(DISABLE_END_USER))
            {
                return DISABLE_END_USER_NAME;
            }
            else if (service.Equals(GENERATE_ONE_TIME_PASSWORD))
            {
                return GENERATE_ONE_TIME_PASSWORD_NAME;
            }
            else if (service.Equals(AUTHENTICATE_ONE_TIME_PASSWORD))
            {
                return AUTHENTICATE_ONE_TIME_PASSWORD_NAME;
            }
            else if (service.Equals(MIGRATE_ONE_TIME_PASSWORD_CHANNEL))
            {
                return MIGRATE_ONE_TIME_PASSWORD_CHANNEL_NAME;
            }
            else if (service.Equals(TIME_SYNC))
            {
                return TIME_SYNC_NAME;
            }
            else if (service.Equals(GET_END_USER_DATA))
            {
                return GET_END_USER_DATA_NAME;
            }
            else if (service.Equals(PUT_END_USER_DATA))
            {
                return PUT_END_USER_DATA_NAME;
            }

            return null;
        }
    }
}
