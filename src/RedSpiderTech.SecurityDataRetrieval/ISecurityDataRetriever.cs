using System.Collections.Generic;
using YahooFinanceApi;

namespace RedSpiderTech.StockDataNotifier.SecurityDataRetrieval
{
    public interface ISecurityDataRetriever
    {
        IEnumerable<Security> GetSecurityData(IEnumerable<string> symbols);
    }
}