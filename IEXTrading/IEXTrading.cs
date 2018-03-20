using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAbc.IEXTrading
{
    public static class WebApi_V1
    {
        private const string URI = "https://api.iextrading.com/1.0/";
        public static string Chart(string symbol, string range = "" )
        {
            string full_uri = URI + "stock/"+symbol+"/chart/"+ range;
            return Library.HttpRequestUtility.GetRequest(full_uri);
        }

        public static string Book(string symbol)
        {
            string full_uri = URI + "stock/" + symbol + "/book";
            return Library.HttpRequestUtility.GetRequest(full_uri);
        }
        public static string Company(string symbol)
        {
            string full_uri = URI + "stock/" + symbol + "/company";
            return Library.HttpRequestUtility.GetRequest(full_uri);
        }
        public static string Logo(string symbol)
        {
            string full_uri = URI + "stock/" + symbol + "/logo";
            return Library.HttpRequestUtility.GetRequest(full_uri);
        }
        public static string News(string symbol)
        {
            string full_uri = URI + "stock/" + symbol + "/news";
            return Library.HttpRequestUtility.GetRequest(full_uri);
        }
        public static string Peers(string symbol)
        {
            string full_uri = URI + "stock/" + symbol + "/peers";
            return Library.HttpRequestUtility.GetRequest(full_uri);
        }
    }
}
