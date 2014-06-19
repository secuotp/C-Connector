using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;

namespace C_Connector
{
    class XMLConnector
    {

        public static void connector(string xml)
        {
            XmlDocument xmld = new XmlDocument();
            xmld.LoadXml(string.Format("<root>{0}</root>",xml));
            //runasync(xmld).Wait();


        }

        /*public static async Task runasync(XmlDocument xml)
        {
            using(var client = new HttpClient()){
                client.BaseAddress = new Uri("https://secuotp.sit.kmutt.ac.th/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                var send = xml;
                HttpResponseMessage response = await client.GetAsync("SecuOTP-Service/manage/register/end-user");
                response = await client.PostAsync();

            }
        }*/
    }
}
