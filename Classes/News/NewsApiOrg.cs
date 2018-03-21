﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAbc.Classes.News.NewsApiOrg
{
    public static class V2
    {
        public const string URI = "https://newsapi.org/v2/";

        public static string Top_Headlines(string Api_Key, string Country = "us")
        {
            string full_uri = URI + "top-headlines?country=" + Country + "&apiKey=" + Api_Key;
            return Library.HttpRequestUtility.GetRequest(full_uri);
        }

        public static string Everything(string Api_Key, string KeyWord = "us")
        {
            string full_uri = URI + "everything?q=" + KeyWord + "&sortBy=popularity&apiKey=" + Api_Key;
            return Library.HttpRequestUtility.GetRequest(full_uri);
        }

        public static string Sources(string Api_Key)
        {
            string full_uri = URI + "sources?language=en&apiKey=" + Api_Key;
            return Library.HttpRequestUtility.GetRequest(full_uri);
        }

        public static string Everything_Sources(string Api_Key, string Source_Id)
        {
            string full_uri = URI + "everything?sources=" + Source_Id + "&apiKey=" + Api_Key;
            return Library.HttpRequestUtility.GetRequest(full_uri);
        }
    }
}
