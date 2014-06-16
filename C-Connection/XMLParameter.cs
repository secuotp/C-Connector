﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using C_Connection;

namespace C_Connection
{
    class XMLParameter
    {
        private ArrayList keylist;
        private ArrayList valuelist;
        private int pointer = 0;

        public XMLParameter()
        {
            keylist = new ArrayList();
            valuelist = new ArrayList();
        }

        public void Add(string key, string value)
        {
            keylist.Add(key);
            valuelist.Add(value);
        }

        public string[] pop()
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
            }catch(IndexOutOfRangeException e){
                System.Console.WriteLine(e.ToString());
            }
            return null;
        }

        public string[] peek()
        {
            try
            {
                string[] valueString = new string[2];
                valueString[0] = keylist.GetRange(pointer,1).ToString();
                valueString[1] = valuelist.GetRange(pointer,1).ToString();
                return valueString;
            }catch(IndexOutOfRangeException e){
                System.Console.WriteLine(e.ToString());
            }
            return null;
        }

        public Boolean hasNext()
        {
            return pointer < keylist.Count;
        }

        public void first()
        {
            pointer = 0;
        }

        public void last()
        {
            pointer = keylist.Count;
        }


    }
}
