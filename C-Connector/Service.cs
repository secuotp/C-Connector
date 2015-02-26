using System;
using System.IO;
using System.Net;
using System.Text;

namespace C_Connector
{
    public class Service
    {

        /* Validate certificate for connection to secure channel (HTTPS) 
         * (In this case, for use with our self signed SSL.) */

        public bool AcceptAllCertifications
            (object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, 
            System.Security.Cryptography.X509Certificates.X509Chain chain, 
            System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

		/* Function for request data with POST method. */
		
        public StreamReader httpPost(String sCode, XMLRequest req)
        {
            string uri = ServiceCodeHttps.getServiceUri(sCode);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.ContentType = "application/xml";
            string data = "request=" + req.toString();
            byte[] dataSize = Encoding.Default.GetBytes(data);
            request.ContentLength = dataSize.Length;
            if (req.getSid().Equals("U-02"))
            {
                return httpPut(sCode, req);
            }
            else
            {
                ServicePointManager.ServerCertificateValidationCallback = 
                    new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

                request.Method = "POST";
                Stream sw = request.GetRequestStream();
                sw.Write(dataSize, 0, dataSize.Length);
                sw.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                return sr;
            }
        }

		/* Function for request data with PUT method. */
		
        public StreamReader httpPut(String sCode, XMLRequest req)
        {
            string uri = ServiceCodeHttps.getServiceUri(sCode);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.ContentType = "application/xml";
            string data = "request=" + req.toString();
            byte[] dataSize = Encoding.Default.GetBytes(data);
            request.ContentLength = dataSize.Length;
            if (!req.getSid().Equals("U-02"))
            {
                return httpPost(uri, req);
            }
            else
            {
                ServicePointManager.ServerCertificateValidationCallback = 
                    new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

                request.Method = "PUT";
                Stream sw = request.GetRequestStream();
                sw.Write(dataSize, 0, dataSize.Length);
                sw.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                return sr;
            }
        }
    }
}