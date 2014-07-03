using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;

namespace C_Connector
{
    public class XMLRequest : XMLReqRes
    {
        private String domainName;
        private String serialNumber;
        private ArrayList paramTag;
        private int pointer = 0;

        public XMLRequest() {
            this.setSid("");
            domainName = "";
            serialNumber = "";
            paramTag = new ArrayList();
        }

        public ArrayList getParamTag() {
            return paramTag;
        }

        public void setParamTag(ArrayList patamTag) {
            this.paramTag = patamTag;
        }

        public String getDomainName() {
            return domainName;
        }

        public void setDomainName(String domainName) {
            this.domainName = domainName;
        }

        public String getSerialNumber() {
            return serialNumber;
        }

        public void setSerialNumber(String serialNumber) {
            this.serialNumber = serialNumber;
        }

        public XMLTag getChildTag(int item) {
            try
            {
                string[] valueString = new string[2];
                foreach (String i in paramTag.GetRange(pointer, 0))
                    valueString[0] = i;
                foreach (String i in paramTag.GetRange(pointer+1, 1))
                    valueString[1] = i;
                pointer++;
                return new XMLTag(valueString[0],valueString[1]);
            }
            catch (IndexOutOfRangeException e)
            {
                System.Console.WriteLine(e.ToString());
            }
            return null;
        }

        public void addChildTag(String tagName, String value) {
            this.paramTag.Add(new XMLTag(tagName, value));
        }

        public XMLTag addChildTag(String tagName) {
            this.paramTag.Add(new XMLTag(tagName, new ArrayList()));
            return paramTag.IndexOf(paramTag.Count - 1);
        }

        private void setParameter(XmlElement parentNode, XMLTag tag) {
            XmlElement e = parentNode.(tag.getTagName());
            if (tag.haveChildNode()) {
                for (int i = 0; i < tag.getChildNode().Count; i++) {
                    setParameter(e, tag.getChildNode().);
                }
            } else {
                e.(tag.getValue());
            }
        }

        public String toString() {
            XmlDocument doc = new XmlDocument();

            XmlElement root = doc.CreateElement("secuotp");
            doc.AppendChild(root);

            XmlElement serviceNode = doc.CreateElement("service");
            serviceNode.SetAttribute("sid", getSid());
            XmlText servicename = doc.CreateTextNode(ServiceCode.getServiceName(getSid()));
            serviceNode.AppendChild(servicename);
            root.AppendChild(serviceNode);

            XmlElement authenNode = doc.CreateElement("authentication");
            XmlElement domain = doc.CreateElement("domain");
            XmlText domainname = doc.CreateTextNode(domainName);
            XmlElement serial = doc.CreateElement("serial");
            XmlText serialnumber = doc.CreateTextNode(serialNumber);
            domain.AppendChild(domainname);
            serial.AppendChild(serialnumber);
            authenNode.AppendChild(domain);
            authenNode.AppendChild(serial);

            XmlElement paramNode = doc.CreateElement("parameter");
            for (int i = 0; i < this.paramTag.Count; i++) {
                string[] value;
                try
                {
                    string[] valueString = new string[2];
                    foreach (String i in paramTag.GetRange(pointer, 0))
                        valueString[0] = i;
                    foreach (String i in paramTag.GetRange(pointer+1, 1))
                        valueString[1] = i;
                    pointer++;
                    value = valueString;
                }
                catch (IndexOutOfRangeException e)
                {
                    System.Console.WriteLine(e.ToString());
                }
                return null;
                setParameter(paramNode,value.);
            }
            doc.Normalize();
            return doc.InnerXml;
        }
    }
}
