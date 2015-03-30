using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Connector
{
    public class OTPMigration
    {
        private string username;
        private string migration;

        public string getUsername(){
            return username;
        }

        public void setUsername(string username){
            this.username = username;
        }

        public string getMigration()
        {
            return migration;
        }

        public void setMigration(string migration)
        {
            this.migration = migration;
        }
    }
}
