using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAbc.Intrinio
{
    public static class WebApi
    {
        private const string URI = "https://api.intrinio.com/";
        public static string CompanyNews(string identifier, string username, string password)
        {
            string full_uri = URI + "news?identifier=" + identifier;
            return Library.HttpRequestUtility.GetRequest(full_uri, username, password);
        }
    }
}
