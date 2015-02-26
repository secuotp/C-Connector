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
		
		/* Constructor with XML Reader function and call every function in XMLResponse. */
		
        public XMLResponse(String xml)
        {
            parameter = new XMLParameter();
            XMLParser parse = new XMLParser(xml);
            status = int.Parse(parse.getAttibuteFromTag("secuotp", "status", 0));
            message = parse.getDataFromTag("message", 0);

            for (int i = 0; i < parse.getChildItem("response", 0); i++)
            {
                String[] data = XMLParser.getChildData(parse.getNodeFromTag("response"), i);
                parameter.Add(data[0], data[1]);
            }
        }

		/* Return XML status value. */
		
        public int getStatus()
        {
            return status;
        }

		/* Set XML status after response form server. */
		
        public void setStatus(int status)
        {
            this.status = status;
        }

		/* Return XML message value. */
		
        public String getMessage()
        {
            return message;
        }

		/* Set XML message from server response. */
		
        public void setMessage(String message)
        {
            this.message = message;
        }

		/* Return XML parameter value. */
		
        public XMLParameter getParameter()
        {
            return parameter;
        }

		/* Set XML parameter from server response. */
		
        public void setParameter(XMLParameter parameter)
        {
            this.parameter = parameter;
        }
    }
}
