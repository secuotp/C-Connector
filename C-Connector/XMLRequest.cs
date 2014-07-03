using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;

namespace C_Connector
{
    class XMLRequest : XMLReqRes
    {
        private String domainName;
        private String serialNumber;
        private ArrayList paramTag;

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
            return paramTag.;
        }

        public void addChildTag(String tagName, String value) {
            this.paramTag.add(new XMLTag(tagName, value));
        }

        public XMLTag addChildTag(String tagName) {
            this.paramTag.add(new XMLTag(tagName, new ArrayList()));
            return paramTag.(paramTag.Count - 1);
        }

        private void setParameter(XmlElement parentNode, XMLTag tag) {
            XmlElement e = parentNode.addElement(tag.getTagName());
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
            XmlElement serviceNode = root.CreateElement("service");
            serviceNode.SetAttribute("sid", getSid());
            serviceNode.WriteContentTo(StringText.getServiceName(getSid()));
            XmlElement authenNode = root.addElement("authentication");
            authenNode.addElement("domain").setText(domainName);
            authenNode.addElement("serial").setText(serialNumber);
            XmlElement paramNode = root.addElement("parameter");
            for (int i = 0; i < this.paramTag.size(); i++) {
                setParameter(paramNode, this.paramTag.get(i));
            }
            doc.normalize();
            return doc.asXML();
        }
    }
}
