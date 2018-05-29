using System;

namespace NYTimes.WebApi
{
    public static class V2
    {
        public static string TopStories(string apiKey)
        {
            string fullUri = "https://api.nytimes.com/svc/topstories/v2/home.json";
            return Library.HttpRequestUtility.GetRequestApiKey(fullUri, apiKey);
        }
    }    
}
