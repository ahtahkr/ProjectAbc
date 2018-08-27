using System;
using System.Collections.Generic;

namespace ContextualWeb
{
    public class Provider
    {
        public string Name { get; set; }
    }

    public class Image
    {
        public string Url { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string Base64Encoding { get; set; }
    }

    public class Value
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Language { get; set; }
        public bool IsSafe { get; set; }
        public DateTime DatePublished { get; set; }
        public Provider Provider { get; set; }
        public Image Image { get; set; }
    }

    public class NewsSearch
    {
        public string _type { get; set; }
        public string DidUMean { get; set; }
        public int TotalCount { get; set; }
        public List<string> RelatedSearch { get; set; }
        public List<Value> Value { get; set; }
    }
}
