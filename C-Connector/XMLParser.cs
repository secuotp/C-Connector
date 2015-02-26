using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml; 

namespace C_Connector
{
    public class XMLParser
    {
        private XmlDocument doc;
        private XmlNodeList list;
        private XmlElement e;

		/* Constructor. */
		
        public XMLParser(String xml) {
            this.doc = new XmlDocument();
            this.doc.LoadXml(xml);
        }
		
		/* Get data from XML tag with specific tag name and item number. */
		
        public String getDataFromTag(String tagName, int numberItem) {
            list = doc.GetElementsByTagName(tagName);
            if (list.Count > 0) {
                XmlNode n = list.Item(numberItem);
                return n.InnerText.ToString();
            } else {
                return null;
            }
        }
		
		/* Get child data of XML with specific node list and item number. */
		
        public static String[] getChildData(XmlNodeList nList, int numberItem) {
            String[] data = new String[2];
            XmlNode node = nList.Item(0).FirstChild;
            for (int i = 0; i < numberItem; i++)
            {
                node = node.NextSibling;
            }
            data[0] = node.LocalName;
            data[1] = node.InnerText;
            return data;
        }
		
		/* Get node from XML tag with specific tag name. */
		
        public XmlNodeList getNodeFromTag(String tagname) {
            return doc.GetElementsByTagName(tagname);
        }
		
		/* Get attribute from XML tag with specific tag name, attribute name and item number. */
		
        public String getAttibuteFromTag(String tagName, String attibuteName, int numberItem) {
            list = doc.GetElementsByTagName(tagName);
            if (list.Count > 0) {
                e = (XmlElement) list.Item(numberItem);
                return e.GetAttribute(attibuteName);
            } else {
                return null;
            }
        }
		
		/* Get child item form XML with specific tag name and item Number. */

        public int getChildItem(String tagName, int numberItem) {
            list = doc.GetElementsByTagName(tagName);
            if (list.Count > 0)
            {
                e = (XmlElement)list.Item(numberItem);
                return e.ChildNodes.Count;
            }
            else
            {
                return 0;
            }
        }

		/* Get item number from element in XML with specific tag name. */
		
        public int getNumberItem(String tagName) {
            list = doc.GetElementsByTagName(tagName);
            return list.Count;
        }
    }
}
