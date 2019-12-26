using System.Collections.Generic;
using RedSpiderTech.StockDataNotifier.SecurityDataRetrieval.DTO;

namespace RedSpiderTech.StockDataNotifier.SecurityDataRetrieval
{
    public interface ISecurityDataRetriever
    {
        IEnumerable<Security> GetSecurityData(IEnumerable<string> symbols);
    }
}