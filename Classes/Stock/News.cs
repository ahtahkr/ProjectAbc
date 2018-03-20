using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAbc.Classes.Stock.Model
{
    public class News
    {
        public DateTime Datetime { get; set; }
        public string Headline { get; set; }
        public string Source { get; set; }
        public string Url { get; set; }
        public string Summary { get; set; }
        public string Related { get; set; }

        public string[] Related_ { get; set; }

        public void Split_Related()
        {
            this.Related_ = this.Related.Split(',');
        }
    }
}
