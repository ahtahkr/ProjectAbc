using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAbc.Classes.Stock.Model
{
    public class Stock
    {
        public DateTime Date { get; set; }
        public TimeSpan Minute { get; set; }
        public double? Open { get; set; }
        public double? High { get; set; }
        public double? Average { get; set; }
        public double? Low { get; set; }
        public double? Close { get; set; }
        public int? Volume { get; set; }
        public int? UnadjustedVolume { get; set; }
        public double? Change { get; set; }
        public double? ChangePercent { get; set; }
        public double? Vwap { get; set; }
        public string Label { get; set; }
        public double? ChangeOverTime { get; set; }
    }
}
