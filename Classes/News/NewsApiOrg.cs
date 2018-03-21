using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAbc.Classes.News.NewsApiOrg
{
    public static class V2
    {
        public const string URI = "https://newsapi.org/v2/";

        public static string Top_Headlines(string Api_Key = "24763003c86c4c439e53ccd7014a1a80", string Country = "us")
        {
            string full_uri = URI + "top-headlines?country=" + Country + "&apiKey=" + Api_Key;
            return Library.HttpRequestUtility.GetRequest(full_uri);
        }

        public static string Everything(string Api_Key = "24763003c86c4c439e53ccd7014a1a80", string KeyWord = "us")
        {
            string full_uri = URI + "everything?q=" + KeyWord + "&apiKey=" + Api_Key;
            return Library.HttpRequestUtility.GetRequest(full_uri);
        }

        public static string Sources(string Api_Key = "24763003c86c4c439e53ccd7014a1a80")
        {
            string full_uri = URI + "sources?apiKey=" + Api_Key;
            return Library.HttpRequestUtility.GetRequest(full_uri);
        }
    }
}
