using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAbc.Classes.Stock.Model
{
    public class Quote
    {
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public string PrimaryExchange { get; set; }
        public string Sector { get; set; }
        public string CalculationPrice { get; set; }
        public double? Open { get; set; }
        public long OpenTime { get; set; }
        public double? Close { get; set; }
        public long CloseTime { get; set; }
        public double? High { get; set; }
        public double? Low { get; set; }
        public double? LatestPrice { get; set; }
        public string LatestSource { get; set; }
        public string LatestTime { get; set; }
        public long LatestUpdate { get; set; }
        public int? LatestVolume { get; set; }
        public double? IexRealtimePrice { get; set; }
        public int? IexRealtimeSize { get; set; }
        public long IexLastUpdated { get; set; }
        public double? DelayedPrice { get; set; }
        public long DelayedPriceTime { get; set; }
        public double? PreviousClose { get; set; }
        public double? Change { get; set; }
        public double? ChangePercent { get; set; }
        public double? IexMarketPercent { get; set; }
        public int? IexVolume { get; set; }
        public int? AvgTotalVolume { get; set; }
        public double? IexBidPrice { get; set; }
        public int? IexBidSize { get; set; }
        public double? IexAskPrice { get; set; }
        public int? IexAskSize { get; set; }
        public long MarketCap { get; set; }
        public double? PeRatio { get; set; }
        public double? Week52High { get; set; }
        public double? Week52Low { get; set; }
        public double? YtdChange { get; set; }
    }
    public class Bid
    {
        public double? Price { get; set; }
        public int? Size { get; set; }
        public object Timestamp { get; set; }
    }

    public class Ask
    {
        public double? price { get; set; }
        public int? Size { get; set; }
        public long Timestamp { get; set; }
    }

    public class Trade
    {
        public double? Price { get; set; }
        public int? Size { get; set; }
        public int? TradeId { get; set; }
        public bool IsISO { get; set; }
        public bool IsOddLot { get; set; }
        public bool IsOutsideRegularHours { get; set; }
        public bool IsSinglePriceCross { get; set; }
        public bool IsTradeThroughExempt { get; set; }
        public long Timestamp { get; set; }
    }

    public class SystemEvent
    {
        public string systemEvent { get; set; }
        public long Timestamp { get; set; }
    }
    public class Book
    {
        public Quote quote { get; set; }
        public List<Bid> bids { get; set; }
        public List<Ask> asks { get; set; }
        public List<Trade> trades { get; set; }
        public SystemEvent systemEvent { get; set; }
    }
}
