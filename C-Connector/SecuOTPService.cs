using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Connector
{
    public class SecuOTPService
    {
        private string domain;
        private string serialNumber;
        private object data;

        public SecuOTPService(string domain, string serialNumber)
        {
            this.domain = domain;
            this.serialNumber = serialNumber;
        }

        public String getDomain()
        {
            return domain;
        }

        public void setDomain(String domain)
        {
            this.domain = domain;
        }

        public String getSerialNumber()
        {
            return serialNumber;
        }

        public void setSerialNumber(String serialNumber)
        {
            this.serialNumber = serialNumber;
        }

        public ServiceStatus registerEndUser(String username, String email, String firstName, String lastName, String phone)
        {
            XMLRequest req = new XMLRequest();
            req.setSid("M-01");
            req.setDomainName(this.domain);
            req.setSerialNumber(this.serialNumber);
            req.setParamTag(new ArrayList());
            req.addChildValue("username", username);
            req.addChildValue("email", email);
            req.addChildValue("fname", firstName);
            req.addChildValue("lname", lastName);
            req.addChildValue("phone", phone);

            Service ser = new Service();
            string res = ser.httpPost("M-01", req).ReadToEnd().ToString();

            XMLResponse result = new XMLResponse(res);
            if (result != null)
            {
                return new ServiceStatus(result.getStatus(), result.getMessage());
            }
            return null;
        }

        public ServiceStatus disableEndUser(String username, String removalCode)
        {
            XMLRequest req = new XMLRequest();
            req.setSid("M-02");
            req.setDomainName(this.domain);
            req.setSerialNumber(this.serialNumber);
            req.setParamTag(new ArrayList());
            req.addChildValue("username", username);
            req.addChildValue("code", removalCode);


            Service ser = new Service();
            string res = ser.httpPost("M-02", req).ReadToEnd().ToString();

            XMLResponse result = new XMLResponse(res);
            if (result != null)
            {
                return new ServiceStatus(result.getStatus(), result.getMessage());
            }
            return null;
        }

        public ServiceStatus generateOneTimePassword(String username)
        {
            XMLRequest req = new XMLRequest();
            req.setSid("G-01");
            req.setDomainName(this.domain);
            req.setSerialNumber(this.serialNumber);
            req.setParamTag(new ArrayList());
            req.addChildValue("username", username);


            Service ser = new Service();
            string res = ser.httpPost("G-01", req).ReadToEnd().ToString();

            XMLResponse result = new XMLResponse(res);
            if (result != null)
            {
                return new ServiceStatus(result.getStatus(), result.getMessage());
            }
            return null;
        }

        public ServiceStatus authenticateOneTimePassword(String username, String otp)
        {
            XMLRequest req = new XMLRequest();
            req.setSid("A-01");
            req.setDomainName(this.domain);
            req.setSerialNumber(this.serialNumber);
            req.setParamTag(new ArrayList());
            req.addChildValue("username", username);
            req.addChildValue("password", otp);


            Service ser = new Service();
            string res = ser.httpPost("A-01", req).ReadToEnd().ToString();

            XMLResponse result = new XMLResponse(res);
            if (result != null)
            {
                return new ServiceStatus(result.getStatus(), result.getMessage());
            }
            return null;
        }

        public ServiceStatus getUserData(String username, int type)
        {
            XMLRequest req = new XMLRequest();
            req.setSid("U-01");
            req.setDomainName(this.domain);
            req.setSerialNumber(this.serialNumber);
            req.setParamTag(new ArrayList());
            req.addChildValue("username", username);

            String typeString = "default";
            if (type == 0) {
    
            } else if (type == 1) {
                typeString = "full";
            }

            req.addChildValue("type", typeString);

            Service ser = new Service();
            string res = ser.httpPost("U-01", req).ReadToEnd().ToString();

            XMLResponse result = new XMLResponse(res);
            if (result != null)
            {
                XMLParameter data = result.getParameter();
                User u = new User();
                u.setUsername(data.getValue("username"));
                u.setEmail(data.getValue("email"));
                u.setFirstName(data.getValue("fname"));
                u.setLastName(data.getValue("lname"));
                u.setPhone(data.getValue("phone"));
                if (type == 1)
                {
                    u.setSerialNumber(data.getValue("serial"));
                    u.setRemovalCode(data.getValue("removal"));
                }

                ServiceStatus status = new ServiceStatus(result.getStatus(), result.getMessage());
                status.setData(u);

                return status;
            }
            return null;
        }
    }
}
