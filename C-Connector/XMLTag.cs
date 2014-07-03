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
        private String tagName;
        private String value;
        private ArrayList childNode;
        private int pointer = 0;

        public XMLTag(String tagName, String value)
        {
            this.tagName = tagName;
            this.value = value;
        }

        public XMLTag(String tagName, ArrayList childNode)
        {
            this.tagName = tagName;
            this.childNode = childNode;
        }

        public String getTagName()
        {
            return tagName;
        }

        public void setTagName(String tagName)
        {
            this.tagName = tagName;
        }

        public String getValue()
        {
            return value;
        }

        public void setValue(String value)
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
                string[] valueString = new string[2];
                foreach (String i in childNode.GetRange(pointer, 0))
                    valueString[0] = i;
                foreach (String i in childNode.GetRange(pointer, 1))
                    valueString[1] = i;
                pointer++;
                return valueString;
            }
            catch (IndexOutOfRangeException e)
            {
                System.Console.WriteLine(e.ToString());
            }
            return null;
        }

        public void addChildTag(String tagName, String value)
        {
            this.childNode.Add(new XMLTag(tagName, value));
        }

        public XMLTag addChildTag(String tagName)
        {
            this.childNode.Add(new XMLTag(tagName, new ArrayList()));
            return childNode.IndexOf(childNode.Count - 1);
        }
    }
}
