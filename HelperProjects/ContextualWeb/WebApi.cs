using System;
using System.Collections.Generic;
using System.Text;

namespace ContextualWeb
{
    public static class WebApi
    {
        public static string NewsSearchRequest(string searchString)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("X-Mashape-Key", "4TDBm756AwmshmjGYnS9vcY79qTrp1n9qROjsndeolyrDRNgsT");
            headers.Add("X-Mashape-Host", "contextualwebsearch-websearch-v1.p.mashape.com");

            return Library.HttpRequestUtility.GetRequest("https://contextualwebsearch-websearch-v1.p.mashape.com/api/Search/NewsSearchAPI?q=" + searchString + "&autocorrect=true", "", "", headers);
        }
    }
}
