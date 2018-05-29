using System;
using System.Collections.Generic;
using System.Text;

namespace NYTimes
{
    public class Multimedia
    {
        public string Url { get; set; }
        public string Format { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string Type { get; set; }
        public string Subtype { get; set; }
        public string Caption { get; set; }
        public string Copyright { get; set; }
    }

    public class Result
    {
        public string Section { get; set; }
        public string Subsection { get; set; }
        public string Title { get; set; }
        public string @Abstract { get; set; }
        public string Url { get; set; }
        public string Byline { get; set; }
        public string Item_type { get; set; }
        public DateTime Updated_date { get; set; }
        public DateTime Created_date { get; set; }
        public DateTime Published_date { get; set; }
        public string Material_type_facet { get; set; }
        public string Kicker { get; set; }
        public List<object> Des_facet { get; set; }
        public List<object> Org_facet { get; set; }
        public List<object> Per_facet { get; set; }
        public List<object> Geo_facet { get; set; }
        public List<Multimedia> Multimedia { get; set; }
        public string Short_url { get; set; }
    }

    public class TopStories
    {
        public string Status { get; set; }
        public string Copyright { get; set; }
        public string Section { get; set; }
        public DateTime Last_Updated { get; set; }
        public int Num_Results { get; set; }
        public List<Result> Results { get; set; }
    }
}
