using RedSpiderTech.Securities.DataRetriever.Model;
using RedSpiderTech.StockDataNotifier.Data.Model.Interface;

namespace RedSpiderTech.StockDataNotifier.Data.Factory.Interface
{
    public interface IMarketDataFactory
    {
        IMarketData GetMarketData(ISecurityData securityData);
    }
}