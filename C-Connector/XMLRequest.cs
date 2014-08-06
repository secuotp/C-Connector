using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;  

namespace C_Connector
{
    public class XMLRequest
    {
        private string domainName;
        private string serialNumber;
        private ArrayList paramTag;
        private int pointer = 0;
        private String sid;
        private String serviceName;

        public XMLRequest() {
            this.setSid("");
            this.domainName = "";
            this.serialNumber = "";
            this.paramTag = new ArrayList();
        }

        public String getSid()
        {
            return sid;
        }

        public void setSid(String sid)
        {
            this.sid = sid;
        }

        public String getServiceName()
        {
            return serviceName;
        }

        public void setServiceName(String serviceName)
        {
            this.serviceName = serviceName;
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
            XMLTag tag = (XMLTag)paramTag[item];
            return tag;
        }

        public void addChildTag(string tagName, string value) {
            this.paramTag.Add(new XMLTag(tagName, value));
        }

        public XMLTag addChildTag(string tagName) {
            this.paramTag.Add(new XMLTag(tagName, new ArrayList()));
            XMLTag tag = (XMLTag)paramTag[paramTag.Count - 1];
            return tag;
        }

        private string setParameter(XMLTag tag) {
            if (tag.haveChildNode()) {
                ArrayList item = tag.getChildNode();
                string subTag1 = "<" + tag.getTagName() + ">";
                string values = "";
                for (int i = 0; i < tag.getChildNode().Count; i++)
                {
                    try
                    {
                        XMLTag item2 = (XMLTag)item[i];
                        pointer++;
                        values = values + setParameter(item2);
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        System.Console.WriteLine(ex.ToString());
                    }
                }
                string subTag2 = "</" + tag.getTagName() + ">";
                return subTag1 + values + subTag2;
            } else {
                return "<" + tag.getTagName() + ">" + tag.getValue() + "</" + tag.getTagName() + ">";
            }
        }

        public string toString() {
            string xml = "<?xml version=\"1.0\"?>"+
                "<secuotp>"+
                    "<service sid=\""+getSid()+"\">"+ServiceCode.getServiceName(getSid())+"</service>"+
                    "<authentication>"+
                        "<domain>"+domainName+"</domain>"+
                        "<serial>"+serialNumber+"</serial>"+
                    "</authentication>"+
                "<parameter>";

            string param = null;

            for (int i = 0; i < this.paramTag.Count; i++) {
                try
                {
                    string[] valueString = new string[2];
                    foreach (XMLTag j in paramTag.GetRange(pointer, 1))
                        valueString[0] = j.getTagName();
                    foreach (XMLTag j in paramTag.GetRange(pointer, 1))
                        valueString[1] = j.getValue();
                    pointer++;
                    XMLTag tag = (XMLTag)paramTag[i];
                    param = param + setParameter(tag);
                }
                catch (IndexOutOfRangeException e)
                {
                    System.Console.WriteLine(e.ToString());
                }
            }

            string buttomXml = "</parameter></secuotp>";
            string combine = xml + param + buttomXml;
            
            return combine;
        }
    }
}
