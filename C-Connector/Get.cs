using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Connector
{
    class Get
    {
        public string createGetRequest(string username, string type){
            if(type.Equals("full") || type.Equals("default")){
                string service = "U-01";
                
            }
            else
            {
                return "Get user error. Wrong request type.";
            }
            return null;
        }
    }
}
