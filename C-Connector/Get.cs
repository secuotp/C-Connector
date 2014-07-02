using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Connector
{
    class Get
    {
        public string createGetRequest(string domain, string serial, string username, string type){
            if(type.Equals("full") || type.Equals("default")){
                string service = "U-01";

                XMLParameter authen = new XMLParameter();
                XMLParameter param = new XMLParameter();
                CreateXML doc = new CreateXML();

                authen.Add("domain", domain);
                authen.Add("serial", serial);
                param.Add("username",username);
                param.Add("type",type);

                string result = doc.createRequest(service,authen,param);

                return result;
            }
            else
            {
                return "Get user error. Wrong request type.";
            }
        }
    }
}
