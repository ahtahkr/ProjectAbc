﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAbc.IEXTrading
{
    public static class IEXTrading
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
    }
}