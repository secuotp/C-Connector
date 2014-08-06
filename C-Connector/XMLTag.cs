using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace C_Connector
{
    public class XMLTag
    {
        private string tagName;
        private string value;
        private ArrayList childNode;
        private int pointer = 0;

        public XMLTag(string tagName, string value)
        {
            this.tagName = tagName;
            this.value = value;
        }

        public XMLTag(string tagName, ArrayList childNode)
        {
            this.tagName = tagName;
            this.childNode = childNode;
        }

        public string getTagName()
        {
            return tagName;
        }

        public void setTagName(string tagName)
        {
            this.tagName = tagName;
        }

        public string getValue()
        {
            return value;
        }

        public void setValue(string value)
        {
            this.value = value;
        }

        public ArrayList getChildNode()
        {
            return childNode;
        }

        public void setChildNode(ArrayList childNode)
        {
            this.childNode = childNode;
        }

        public Boolean haveChildNode()
        {
            return childNode != null;
        }

        public XMLTag getChildTag(int item)
        {
            try
            {
                ArrayList valueString = new ArrayList();
                foreach (string i in childNode.GetRange(pointer, 1))
                    valueString[0] = i;
                foreach (string i in childNode.GetRange(pointer, 1))
                    valueString[1] = i;
                pointer++;
                return new XMLTag(tagName, valueString) ;
            }
            catch (IndexOutOfRangeException e)
            {
                System.Console.WriteLine(e.ToString());
            }
            return null;
        }

        public void addChildValue(string tagName, string value)
        {
            this.childNode.Add(new XMLTag(tagName, value));
        }

        public XMLTag addChildTag(string tagName)
        {
            this.childNode.Add(new XMLTag(tagName, new ArrayList()));
            XMLTag tag = (XMLTag)childNode[childNode.Count - 1];
            return tag;
        }
    }
}
