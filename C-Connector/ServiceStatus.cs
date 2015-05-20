using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Connector //
{
    public class ServiceStatus
    {
        private int statusId;
        private String statusText;
        private object data;

        public ServiceStatus(int statusId, String statusText)
        {
            this.statusId = statusId;
            this.statusText = statusText;
        }

        public int getStatusId()
        {
            return statusId;
        }

        public void setStatusId(int statusId)
        {
            this.statusId = statusId;
        }

        public String getStatusText()
        {
            return statusText;
        }

        public void setStatusText(String statusText)
        {
            this.statusText = statusText;
        }

        public object getData()
        {
            return data;
        }

        public void setData(object data)
        {
            this.data = data;
        }
    }
}
