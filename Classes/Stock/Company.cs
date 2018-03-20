using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAbc.Classes.Stock.Model
{
    public class Organization
    {
        public Company Company { get; set; }
        public List<Stock> Stocks { get; set; }
        public List<Stock> Stocks_Today { get; set; }
        public Book Book { get; set; }
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
}
