using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Connector
{
    class XMLReqRes
    {
        private String sid;
        private String serviceName;

        public String getSid()
        {
            return sid;
        }

        public void setSid(String sid)
        {
            this.sid = sid;
        }

        public String getServiceName()
        {
            return serviceName;
        }

        public void setServiceName(String serviceName)
        {
            this.serviceName = serviceName;
        }
    }
}
