using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace C_Connector
{
    public class CertificateCheck
    {
        public static bool MyCertValidationCb(
            object sender,
            X509Certificate certificate,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateChainErrors)
                      == SslPolicyErrors.RemoteCertificateChainErrors)
            {
                return true;
            }
            else if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateNameMismatch)
                            == SslPolicyErrors.RemoteCertificateNameMismatch)
            {
                Zone z;
                z = Zone.CreateFromUrl(((HttpWebRequest)sender).RequestUri.ToString());
                if (z.SecurityZone == System.Security.SecurityZone.Intranet
                  || z.SecurityZone == System.Security.SecurityZone.MyComputer)
                {
                    return true;
                }
                return false;
            }
            return false;
        } 
    }
}
