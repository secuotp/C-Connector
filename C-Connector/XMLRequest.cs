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
        private string domainName;
        private string serialNumber;
        private ArrayList paramTag;
        private int pointer = 0;

        public XMLRequest() {
            this.setSid("");
            this.domainName = "";
            this.serialNumber = "";
            this.paramTag = new ArrayList();
        }

        public ArrayList getParamTag() {
            return paramTag;
        }

        public void setParamTag(ArrayList paramTag) {
            this.paramTag = paramTag;
        }

        public string getDomainName() {
            return domainName;
        }

        public void setDomainName(string domainName) {
            this.domainName = domainName;
        }

        public string getSerialNumber() {
            return serialNumber;
        }

        public void setSerialNumber(string serialNumber) {
            this.serialNumber = serialNumber;
        }

        public XMLTag getChildTag(int item) {
            try
            {
                string[] valueString = new string[2];
                foreach (string i in paramTag.GetRange(pointer, 1))
                    valueString[0] = i;
                foreach (string i in paramTag.GetRange(pointer, 1))
                    valueString[1] = i;
                pointer++;
                return new XMLTag(valueString[0], valueString[1]);
            }
            catch (IndexOutOfRangeException ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public void addChildTag(string tagName, string value) {
            this.paramTag.Add(new XMLTag(tagName, value));
        }

        public XMLTag addChildTag(string tagName) {
            this.paramTag.Add(new XMLTag(tagName, new ArrayList()));
            return new XMLTag(tagName,paramTag);
        }

        private void setParameter(XmlDocument doc, XmlElement parentNode, XMLTag tag) {
            XmlDocument xml = doc;
            XmlElement e = xml.CreateElement(tag.getTagName());
            System.Console.WriteLine(parentNode.ChildNodes.Count);
            if (tag.getValue() == null) {
                XmlElement element = null;
                XmlText text = null;
                for (int i = 0; i < tag.getChildNode().Count; i++)
                {
                    try
                    {
                        string[] valueString = new string[2];
                        foreach (XMLTag j in paramTag.GetRange(pointer, 1))
                            valueString[0] = j.getTagName();
                        foreach (XMLTag j in paramTag.GetRange(pointer, 1))
                            valueString[1] = j.getValue();
                        pointer++;
                        element = doc.CreateElement(valueString[0]);
                        text = doc.CreateTextNode(valueString[1]);
                        element.AppendChild(text);
                        e.AppendChild(element);
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        System.Console.WriteLine(ex.ToString());
                    }
                    parentNode.AppendChild(e);
                }
            } else {
                XmlText text = xml.CreateTextNode(tag.getValue());
                e.AppendChild(text);
                parentNode.AppendChild(e);
            }
        }

        public string toString() {
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
            root.AppendChild(authenNode);

            XmlElement paramNode = doc.CreateElement("parameter");
            for (int i = 0; i < this.paramTag.Count; i++) {
                XMLTag tag = null;
                try
                {
                    string[] valueString = new string[2];
                    foreach (XMLTag j in paramTag.GetRange(pointer, 1))
                        valueString[0] = j.getTagName();
                    foreach (XMLTag j in paramTag.GetRange(pointer, 1))
                        valueString[1] = j.getValue();
                    pointer++;
                    tag = new XMLTag(valueString[0], valueString[1]);
                }
                catch (IndexOutOfRangeException e)
                {
                    System.Console.WriteLine(e.ToString());
                }
                setParameter(doc, paramNode, tag);
            }
            root.AppendChild(paramNode);

            doc.Normalize();
            return doc.InnerXml;
        }
    }
}
