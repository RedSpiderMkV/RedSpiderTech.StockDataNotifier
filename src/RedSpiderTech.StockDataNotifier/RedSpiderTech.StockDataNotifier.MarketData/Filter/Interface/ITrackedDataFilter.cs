using System.Collections.Generic;
using RedSpiderTech.StockDataNotifier.Data.Model.Interface;

namespace RedSpiderTech.StockDataNotifier.Data.Filter.Interface
{
    public interface ITrackedDataFilter
    {
        IEnumerable<IMarketData> GetMarketDataForPublishing(IEnumerable<IMarketData> marketDataCollection);
    }
}