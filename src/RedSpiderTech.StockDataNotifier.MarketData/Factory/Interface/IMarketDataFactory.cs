using RedSpiderTech.StockDataNotifier.Data.Model.Interface;
using YahooFinanceApi;

namespace RedSpiderTech.StockDataNotifier.Data.Factory.Interface
{
    public interface IMarketDataFactory
    {
        IMarketData GetMarketData(Security securityData);
    }
}