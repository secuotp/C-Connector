﻿using System;
using System.IO;
using System.Net;
using System.Text;

namespace C_Connector
{
    public class Service
    {
		/* Function for request data with POST method. */

        public StreamReader httpPost(String sCode, XMLRequest req)
        {
            string uri = ServiceCodeHttps.getServiceUri(sCode);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.ContentType = "application/xml";
            string data = "request=" + req.toString();
            byte[] dataSize = Encoding.Default.GetBytes(data);
            request.ContentLength = dataSize.Length;

            request.Method = "POST";
            Stream sw = request.GetRequestStream();
            sw.Write(dataSize, 0, dataSize.Length);
            sw.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            return sr;
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