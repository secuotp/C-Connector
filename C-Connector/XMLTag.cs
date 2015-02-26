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
		
		/* Constructor for normal XML tag. */
		
        public XMLTag(string tagName, string value)
        {
            this.tagName = tagName;
            this.value = value;
        }
		
		/* Constructor for inner XML contents. */
		
        public XMLTag(string tagName, ArrayList childNode)
        {
            this.tagName = tagName;
            this.childNode = childNode;
        }

		/* Return XML tag name. */
		
        public string getTagName()
        {
            return tagName;
        }
		
		/* Set XML tag name. */
		
        public void setTagName(string tagName)
        {
            this.tagName = tagName;
        }

		/* Return XML value. */
		
        public string getValue()
        {
            return value;
        }

		/* Set XML value. */
		
        public void setValue(string value)
        {
            this.value = value;
        }

		/* Return child node in XML. */
		
        public ArrayList getChildNode()
        {
            return childNode;
        }

		/* Set child node in XML. */
		
        public void setChildNode(ArrayList childNode)
        {
            this.childNode = childNode;
        }

		/* Check value of child node. */
		
        public Boolean haveChildNode()
        {
            return childNode != null;
        }

		/* Return child tag from item number by select array and pull tag name and value into child tag format. */
		
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

		/* Add child value with tag name and value to XML format. */
		
        public void addChildValue(string tagName, string value)
        {
            this.childNode.Add(new XMLTag(tagName, value));
        }

		/* Return child tag with tag name. */
		
        public XMLTag addChildTag(string tagName)
        {
            this.childNode.Add(new XMLTag(tagName, new ArrayList()));
            XMLTag tag = (XMLTag)childNode[childNode.Count - 1];
            return tag;
        }
    }
}
