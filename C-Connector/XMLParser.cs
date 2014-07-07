using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace C_Connector
{
    public class XMLParser
    {
        private XmlDocument doc;
        private XmlNodeList list;
        private XmlElement e;
        public XMLParser(String xml) {
            StringBuilder output = new StringBuilder();
            
            using(XmlReader reader = XmlReader.Create(new StringReader(xml))){
                XmlWriterSettings ws = new XmlWriterSettings();
                ws.Indent = true;
                using(XmlWriter writer = XmlWriter.Create(output, ws)){
                    while(reader.Read()){
                        doc = new XmlDocument();
                        doc.LoadXml(reader.ToString());
                    }
                }
            }
        }

        public String getDataFromTag(String tagName, int numberItem) {
            list = doc.GetElementsByTagName(tagName);
            if (list.Count > 0) {
                XmlNode n = list.Item(numberItem);
                return n.InnerText.ToString();
            } else {
                return null;
            }
        }
    
        public static String[] getChildData(XmlNodeList nList, int numberItem) {
            String[] data = new String[2];
            data[0] = nList.Item(numberItem).Name;
            data[1] = nList.Item(numberItem).InnerText;
            return data;
        }

        public XmlNodeList getNodeFromTag(String tagname) {
            return doc.GetElementsByTagName(tagname);

        }

        public String getAttibuteFromTag(String tagName, String attibuteName, int numberItem) {
            list = doc.GetElementsByTagName(tagName);
            if (list.Count > 0) {
                e = (XmlElement) list.Item(numberItem);
                return e.GetAttribute(attibuteName);
            } else {
                return null;
            }
        }

        public int getChildItem(String tagName, int numberItem) {
            list = doc.GetElementsByTagName(tagName);
            e = (XmlElement) list.Item(numberItem);
            return e.ChildNodes.Count;
        }

        public int getNumberItem(String tagName) {
            list = doc.GetElementsByTagName(tagName);
            return list.Count;
        }
    }
}
