using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAbc.Classes.Stock.Model
{
    public enum Organization_Stock:int { Stocks, Stocks_Today };

    public class Organization
    {
        public Company Company { get; set; }
        public List<Stock> Stocks { get; set; }
        public List<Stock> Stocks_Today { get; set; }
        public Book Book { get; set; }
        public Logo Logo { get; set; }
        public List<News> News { get; set; }

        public string Get_Stock_DateTime_Price(int OrganizationStock)
        {
            List<KeyValuePair<object, object>> Return = new List<KeyValuePair<object, object>>();
            if (OrganizationStock == (int)Organization_Stock.Stocks)
            {
                for (int a = 0; a < this.Stocks.Count; a++)
                {
                   // KeyValuePair<object, object> dic = new KeyValuePair<object, object>();
                    //dic.Add(this.Stocks[a].Date, (object)this.Stocks[a].Close);
                    Return.Add(new KeyValuePair<object, object>(this.Stocks[a].Date, (object)this.Stocks[a].Close));
                }
            } else if (OrganizationStock == (int)Organization_Stock.Stocks_Today)
            {
                for (int a = 0; a < this.Stocks_Today.Count; a++)
                {
                    if (this.Stocks_Today[a].Average != 0)
                    {
                        DateTime dt = new DateTime(
                            this.Stocks_Today[a].Date.Year
                            , this.Stocks_Today[a].Date.Month
                            , this.Stocks_Today[a].Date.Day
                            , this.Stocks_Today[a].Minute.Hours
                            , this.Stocks_Today[a].Minute.Minutes
                            , this.Stocks_Today[a].Minute.Seconds
                        );

                        Return.Add(new KeyValuePair<object, object>(dt, this.Stocks_Today[a].Average));
                    }
                }
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(Return);
        }
    }
    public class Company
    {
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public string Exchange { get; set; }
        public string Industry { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public string CEO { get; set; }
        public string IssueType { get; set; }
        public string Sector { get; set; }        
    }

    public class Logo
    {
        public string Url { get; set; }
    }
}
