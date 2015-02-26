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

		/* Constructor. */
		
        public XMLRequest() {
            this.setSid("");
            this.domainName = "";
            this.serialNumber = "";
            this.paramTag = new ArrayList();
        }

		/* Return service ID value. */
		
        public String getSid()
        {
            return sid;
        }

		/* Set service ID value. */
		
        public void setSid(String sid)
        {
            this.sid = sid;
        }

		/* Return service name value. */
		
        public String getServiceName()
        {
            return serviceName;
        }

		/* Set service name value. */
		
        public void setServiceName(String serviceName)
        {
            this.serviceName = serviceName;
        }

		/* Return parameter tag value. */
		
        public ArrayList getParamTag() {
            return paramTag;
        }
		
		/* Set parameter tag value. */

        public void setParamTag(ArrayList paramTag) {
            this.paramTag = paramTag;
        }

		/* Return domain name value. */
		
        public string getDomainName() {
            return domainName;
        }

		/* Set domain name value. */
		
        public void setDomainName(string domainName) {
            this.domainName = domainName;
        }

		/* Return serial number of domain name value. */
		
        public string getSerialNumber() {
            return serialNumber;
        }

		/* Set serial number of domain name value. */
		
        public void setSerialNumber(string serialNumber) {
            this.serialNumber = serialNumber;
        }

		/* Return child tag value. */
		
        public XMLTag getChildTag(int item) {
            XMLTag tag = (XMLTag)paramTag[item];
            return tag;
        }

		/* Set child value of XML (Key and value). */
		
        public void addChildValue(string tagName, string value) {
            this.paramTag.Add(new XMLTag(tagName, value));
        }
		
		/* Set child tag if inner XML is avaliable. */

        public XMLTag addChildTag(string tagName) {
            this.paramTag.Add(new XMLTag(tagName, new ArrayList()));
            XMLTag tag = (XMLTag)paramTag[paramTag.Count - 1];
            return tag;
        }
		
		/* Set parameter of XML format for each tag. */

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

		/* Return well-form of XML from raw value. */
		
        public string toString() {
            string xml = "<?xml version=\"1.0\"?>"+
                "<secuotp>"+
                    "<service sid=\""+getSid()+"\">"+ServiceCodeHttps.getServiceName(getSid())+"</service>"+
                    "<authentication>"+
                        "<domain>"+domainName+"</domain>"+
                        "<serial>"+serialNumber+"</serial>"+
                    "</authentication>"+
                "<parameter>";

            string param = null;

            for (int i = 0; i < this.paramTag.Count; i++) {
                try
                {
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
