using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAbc.Classes.Intrinio
{
    public class CompanyNews
    {
        public List<Datum> Data { get; set; }
        public int Result_Count { get; set; }
        public int Page_Size { get; set; }
        public int Current_Page { get; set; }
        public int Total_Pages { get; set; }
        public int Api_Call_Credits { get; set; }
        public CompanyNews()
        {
            this.Data = new List<Datum>();
        }
    }
    public class Datum
    {
        public string Ticker { get; set; }
        public string Figi_Ticker { get; set; }
        public string Figi { get; set; }
        public string Title { get; set; }
        public DateTime Publication_Date { get; set; }
        public string Summary { get; set; }
        public string Url { get; set; }
        public Datum()
        {
            this.Ticker = "";
            this.Figi_Ticker = "";
            this.Figi = "";
            this.Title = "";
            this.Publication_Date = DateTime.UtcNow;
            this.Summary = "";
            this.Url = "";
        }
    }
}
