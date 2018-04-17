using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAbc.Intrinio
{
    public static class WebApi
    {
        private const string URI = "https://api.intrinio.com/";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identifier"> Stock Ticker Symbol</param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="page_number"> (optional, default page size is 100) - An integer greater than 1 for specifying the number of results on each page.</param>
        /// <param name="page_size">(optional, default page number is 1) - An integer greater than or equal to 1 for specifying the page number for the return values.</param>
        /// <returns></returns>
        public static string CompanyNews(string identifier, string username, string password, int page_number = 1, int page_size = 10)
        {
            string full_uri = URI + "news?identifier=" + identifier + "&page_number=" + page_number + "&page_size=" + page_size;

            return Library.HttpRequestUtility.GetRequest(full_uri, username, password);
        }
    }
}
