using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections; 

namespace C_Connector
{
    public class XMLParameter
    {
        private ArrayList keylist;
        private ArrayList valuelist;
        private int pointer = 0;
		
		/* Basic Constructor. */
		
        public XMLParameter()
        {
            keylist = new ArrayList();
            valuelist = new ArrayList();
        }

		/* Add XML key and value in XMLParameter. */
		
        public void Add(string key, string value)
        {
            keylist.Add(key);
            valuelist.Add(value);
        }
		
		/* Get data in array to display or utilize. */
		
        public string[] get()
        {
            try
            {
                string[] valueString = new string[2];
                foreach (String i in keylist.GetRange(pointer, 1))
                    valueString[0] = i;
                foreach (String i in valuelist.GetRange(pointer, 1))
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
		
		/* Get latest data in array. */
		
        public string[] peek()
        {
            try
            {
                string[] valueString = new string[2];
                foreach (String i in keylist.GetRange(pointer, 1))
                    valueString[0] = i;
                foreach (String i in valuelist.GetRange(pointer, 1))
                    valueString[1] = i;
                return valueString;
            }
            catch (IndexOutOfRangeException e)
            {
                System.Console.WriteLine(e.ToString());
            }
            return null;
        }

		/* Check the exist of next data in array. */
		
        public Boolean hasNext()
        {
            return pointer < keylist.Count;
        }

		/* Fix first number of data in all array. */
		
        public void first()
        {
            pointer = 0;
        }
		
		/* Fix last number of data in each array. */
		
        public void last()
        {
            pointer = keylist.Count;
        }

		/* Get value (key in XML) from array. */
		
        public string getValue(string key)
        {
            int p = 0;
            while (p < keylist.Count)
            {
                string value = "";
                foreach (String i in keylist.GetRange(p, 1))
                {
                    value = i;
                }
                if (value.Equals(key))
                {
                    return valuelist[p].ToString();
                }
                else
                {
                    p++;
                }
            }
            return null;
        }
		
		/* Clear every data in array. */
		
        public void clear()
        {
            keylist = new ArrayList();
            valuelist = new ArrayList();
            this.first();
        }
    }
}