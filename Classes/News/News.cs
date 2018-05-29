using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAbc.Classes.News
{
    public class News
    {
        public string Title { get; set; }
        public List<Article> Articles { get; set; }
    }
    public class Article
    {
        public Source Source { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        public DateTime PublishedAt { get; set; }
    }
    public class Source
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string ImageUrl { get; set; }
    }
    public class Publisher
    {
        public List<Source> Sources { get; set; }
    }
}
