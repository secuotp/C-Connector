using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace C_Connector
{
    public class ServiceCodeHttps
    {
        private static readonly string REGISTER_END_USER = "M-01";
        private static readonly string REGISTER_END_USER_NAME = "Register End-User";
        private static readonly string REGISTER_END_USER_URI = "https://secure.secuotp.co.th/SecuOTP-Service/manage/register/end-user";

        private static readonly string DISABLE_END_USER = "M-02";
        private static readonly string DISABLE_END_USER_NAME = "Disable End-User";
        private static readonly string DISABLE_END_USER_URI = "https://secure.secuotp.co.th/SecuOTP-Service/manage/disable/end-user";

        private static readonly string GENERATE_ONE_TIME_PASSWORD = "G-01";
        private static readonly string GENERATE_ONE_TIME_PASSWORD_NAME = "Generate One-Time Password";
        private static readonly string GENERATE_ONE_TIME_PASSWORD_URI = "https://secure.secuotp.co.th/SecuOTP-Service/otp/generate";

        private static readonly string AUTHENTICATE_ONE_TIME_PASSWORD = "A-01";
        private static readonly string AUTHENTICATE_ONE_TIME_PASSWORD_NAME = "Authenticate One-Time Password";
        private static readonly string AUTHENTICATE_ONE_TIME_PASSWORD_URI = "https://secure.secuotp.co.th/SecuOTP-Service/otp/authenticate";

        private static readonly string MIGRATE_ONE_TIME_PASSWORD_CHANNEL = "O-01";
        private static readonly string MIGRATE_ONE_TIME_PASSWORD_CHANNEL_NAME = "Migrate One-Time Password Channel";
        private static readonly string MIGRATE_ONE_TIME_PASSWORD_CHANNEL_URI = "https://secure.secuotp.co.th/SecuOTP-Service/otp/migrate";

        private static readonly string TIME_SYNC = "O-02";
        private static readonly string TIME_SYNC_NAME = "Time Sync";
        private static readonly string TIME_SYNC_URI = "https://secure.secuotp.co.th/SecuOTP-Service/manage/end-user/" + DateTime.Now.Millisecond;

        private static readonly string GET_END_USER_DATA = "U-01";
        private static readonly string GET_END_USER_DATA_NAME = "Get End-User Data";
        private static readonly string GET_END_USER_DATA_URI = "https://secure.secuotp.co.th/SecuOTP-Service/user/end-user";

        private static readonly string PUT_END_USER_DATA = "U-02";
        private static readonly string PUT_END_USER_DATA_NAME = "Set End-User Data";
        private static readonly string PUT_END_USER_DATA_URI = "https://secure.secuotp.co.th/SecuOTP-Service/user/end-user";

        public static string getServiceName(string service)
        {
            if (service.Equals(REGISTER_END_USER))
            {
                return REGISTER_END_USER_NAME;
            }
            else if (service.Equals(DISABLE_END_USER))
            {
                return DISABLE_END_USER_NAME;
            }
            else if (service.Equals(GENERATE_ONE_TIME_PASSWORD))
            {
                return GENERATE_ONE_TIME_PASSWORD_NAME;
            }
            else if (service.Equals(AUTHENTICATE_ONE_TIME_PASSWORD))
            {
                return AUTHENTICATE_ONE_TIME_PASSWORD_NAME;
            }
            else if (service.Equals(MIGRATE_ONE_TIME_PASSWORD_CHANNEL))
            {
                return MIGRATE_ONE_TIME_PASSWORD_CHANNEL_NAME;
            }
            else if (service.Equals(TIME_SYNC))
            {
                return TIME_SYNC_NAME;
            }
            else if (service.Equals(GET_END_USER_DATA))
            {
                return GET_END_USER_DATA_NAME;
            }
            else if (service.Equals(PUT_END_USER_DATA))
            {
                return PUT_END_USER_DATA_NAME;
            }

            return null;
        }

        public static string getServiceUri(string service)
        {
            if (service.Equals(REGISTER_END_USER))
            {
                return REGISTER_END_USER_URI;
            }
            else if (service.Equals(DISABLE_END_USER))
            {
                return DISABLE_END_USER_URI;
            }
            else if (service.Equals(GENERATE_ONE_TIME_PASSWORD))
            {
                return GENERATE_ONE_TIME_PASSWORD_URI;
            }
            else if (service.Equals(AUTHENTICATE_ONE_TIME_PASSWORD))
            {
                return AUTHENTICATE_ONE_TIME_PASSWORD_URI;
            }
            else if (service.Equals(MIGRATE_ONE_TIME_PASSWORD_CHANNEL))
            {
                return MIGRATE_ONE_TIME_PASSWORD_CHANNEL_URI;
            }
            else if (service.Equals(TIME_SYNC))
            {
                return TIME_SYNC_URI;
            }
            else if (service.Equals(GET_END_USER_DATA))
            {
                return GET_END_USER_DATA_URI;
            }
            else if (service.Equals(PUT_END_USER_DATA))
            {
                return PUT_END_USER_DATA_URI;
            }

            return null;
        }
    }
}
