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
        private List<XMLTag> paramTag;
        private int pointer = 0;

        public XMLRequest() {
            this.setSid("");
            domainName = "";
            serialNumber = "";
            paramTag = new List<XMLTag>();
        }

        public List<XMLTag> getParamTag() {
            return paramTag;
        }

        public void setParamTag(List<XMLTag> patamTag) {
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
                foreach (XMLTag i in paramTag.GetRange(pointer, 1))
                    valueString[0] = i.ToString();
                foreach (XMLTag i in paramTag.GetRange(pointer, 1))
                    valueString[1] = i.ToString();
                pointer++;
                return new XMLTag(valueString[0],valueString[1]);
            }
            catch (IndexOutOfRangeException ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public void addChildTag(String tagName, String value) {
            this.paramTag.Add(new XMLTag(tagName, value));
        }

        public XMLTag addChildTag(String tagName) {
            this.paramTag.Add(new XMLTag(tagName, new ArrayList()));
            try
            {
                string[] valueString = new string[1];
                foreach (XMLTag i in paramTag.GetRange(pointer, 1))
                    valueString[0] = i.ToString();
                foreach (XMLTag i in paramTag.GetRange(pointer, 1))
                    valueString[1] = i.ToString();
                pointer++;
                return new XMLTag(valueString[0], valueString[1]);
            }
            catch (IndexOutOfRangeException ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
            return null;
        }

        private void setParameter(XmlElement parentNode, XMLTag tag) {
            XmlDocument xml = new XmlDocument();
            XmlElement e = xml.CreateElement(tag.getTagName());
            if (tag.haveChildNode()) {
                for (int i = 0; i < tag.getChildNode().Count; i++) {
                    try
                    {
                        ArrayList valueString = new ArrayList();
                        String tagname = null;
                        foreach (XMLTag j in paramTag.GetRange(pointer, 1))
                        {
                            valueString[0] = j.ToString();
                            tagname = j.ToString();
                        }
                        foreach (XMLTag j in paramTag.GetRange(pointer, 1))
                            valueString[1] = j.ToString();
                        pointer++;
                        tag = new XMLTag(tagname, valueString);
                        setParameter(e, tag);
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        System.Console.WriteLine(ex.ToString());
                    }
                }
            } else {
                XmlText text = xml.CreateTextNode(tag.getValue());
                e.AppendChild(text);
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
            root.AppendChild(authenNode);

            XmlElement paramNode = doc.CreateElement("parameter");
            for (int i = 0; i < this.paramTag.Count; i++) {
                XMLTag tag = null;
                try
                {
                    ArrayList valueString = new ArrayList();
                    String tagname = null;
                    foreach (XMLTag j in paramTag.GetRange(pointer, 1))
                    {
                        valueString[0] = j.ToString();
                        tagname = j.ToString();
                    }

                    foreach (XMLTag k in paramTag.GetRange(pointer, 1))
                        valueString[1] = k.ToString();

                    pointer++;
                    tag = new XMLTag(tagname, valueString);
                }
                catch (IndexOutOfRangeException e)
                {
                    System.Console.WriteLine(e.ToString());
                }
                setParameter(paramNode, tag);
            }
            root.AppendChild(paramNode);

            doc.Normalize();
            return doc.InnerXml;
        }
    }
}
