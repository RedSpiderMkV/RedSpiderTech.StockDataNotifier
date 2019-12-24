using System.Collections.Generic;
using RedSpiderTech.StockDataNotifier.Data.Model.Interface;

namespace RedSpiderTech.StockDataNotifier.Host
{
    public interface IPublicationManager
    {
        void Publish(IEnumerable<IMarketData> marketDataCollection);
        bool Publish(IMarketData marketData);
    }
}