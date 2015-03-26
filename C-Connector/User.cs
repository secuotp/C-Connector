using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Connector
{
    public class User
    {
        private string username;
        private string email;
        private string firstName;
        private string lastName;
        private string phone;
        private string serialNumber;
        private string removalCode;
    
        public string getUsername() {
            return username;
        }
    
        public void setUsername(string username) {
            this.username = username;
        }
    
        public string getEmail() {
            return email;
        }
    
        public void setEmail(string email) {
            this.email = email;
        }
    
        public string getFirstName() {
            return firstName;
        }
    
        public void setFirstName(string firstName) {
            this.firstName = firstName;
        }
    
        public string getLastName() {
            return lastName;
        }
    
        public void setLastName(string lastName) {
            this.lastName = lastName;
        }
    
        public string getPhone() {
            return phone;
        }
    
        public void setPhone(string phone) {
            this.phone = phone;
        }

        public string getSerialNumber()
        {
            return serialNumber;
        }

        public void setSerialNumber(string serialNumber)
        {
            this.serialNumber = serialNumber;
        }

        public string getRemovalCode()
        {
            return removalCode;
        }

        public void setRemovalCode(string removalCode)
        {
            this.removalCode = removalCode;
        }
    }
}
