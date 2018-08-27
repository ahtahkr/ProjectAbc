using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Library
{
    public static class HttpRequestUtility
    {
        public static string GetRequest(String uri, string username = "", string password = "", Dictionary<string, string> headers = null)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Method = "GET";
            httpWebRequest.MaximumAutomaticRedirections = 3;
            httpWebRequest.Timeout = 5000;

            if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password))
            {
                httpWebRequest.Credentials = new NetworkCredential(username, password);
            }

            if (headers != null && headers.Count > 0)
            {
                foreach (KeyValuePair<string, string> pair in headers)
                {
                    httpWebRequest.Headers[pair.Key.ToString()] = pair.Value.ToString();
                }
            }

            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            HttpStatusCode a = httpWebResponse.StatusCode;
            var responseStream = httpWebResponse.GetResponseStream();
            string response = "";
            if (responseStream != null)
            {
                var streamReader = new StreamReader(responseStream);
                //Console.WriteLine("HTTP Response is: ");
                //Console.WriteLine(streamReader.ReadToEnd());
                response += streamReader.ReadToEnd();
            }
            if (responseStream != null) { responseStream.Close(); }

            return response;
        }

        public static string GetRequestApiKey(String uri, string apiKey)
        {
            HttpWebRequest GETRequest = (HttpWebRequest)WebRequest.Create(uri);
            GETRequest.Method = "GET";
            GETRequest.Headers.Add("api-key", apiKey);
            
            var httpWebResponse = (HttpWebResponse) GETRequest.GetResponse();
            HttpStatusCode a = httpWebResponse.StatusCode;
            var responseStream = httpWebResponse.GetResponseStream();
            string response = "";
            if (responseStream != null)
            {
                var streamReader = new StreamReader(responseStream);
                //Console.WriteLine("HTTP Response is: ");
                //Console.WriteLine(streamReader.ReadToEnd());
                response += streamReader.ReadToEnd();
            }
            if (responseStream != null) { responseStream.Close(); }

            return response;
        }
    }
}
