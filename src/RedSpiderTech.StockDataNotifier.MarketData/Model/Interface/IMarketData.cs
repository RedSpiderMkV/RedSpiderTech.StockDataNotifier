using System;

namespace RedSpiderTech.StockDataNotifier.Data.Model.Interface
{
    public interface IMarketData
    {
        double CurrentPrice { get; }
        double CurrentVolume { get; }
        string ExchangeName { get; }
        string LongName { get; }
        double MarketCapital { get; }
        string ShortName { get; }
        string Symbol { get; }
        DateTime TimeStamp { get; }
        double CurrentPriceChange { get; }
        double CurrentPriceChangePercentage { get; }

        string ToString();
    }
}