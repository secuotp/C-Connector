using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Connector
{
    public class XMLResponse
    {
        private int status;
        private String message;
        private XMLParameter parameter;

        public XMLResponse(String xml)
        {
            XMLParser parse = new XMLParser(xml);
            status = int.Parse(parse.getAttibuteFromTag("secuotp", "status", 0));
            message = parse.getDataFromTag("message", 0);

            for (int i = 0; i < parse.getChildItem("response", 0); i++)
            {
                String[] data = XMLParser.getChildData(parse.getNodeFromTag("response"), i);
                parameter.Add(data[0], data[1]);
            }
        }

        public int getStatus()
        {
            return status;
        }

        public void setStatus(int status)
        {
            this.status = status;
        }

        public String getMessage()
        {
            return message;
        }

        public void setMessage(String message)
        {
            this.message = message;
        }


        public XMLParameter getParameter()
        {
            return parameter;
        }

        public void setParameter(XMLParameter parameter)
        {
            this.parameter = parameter;
        }
    }
}
