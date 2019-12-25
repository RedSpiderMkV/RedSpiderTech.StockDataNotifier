using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using YahooFinanceApi;

namespace RedSpiderTech.StockDataNotifier.SecurityDataRetrieval
{
    public class SecurityDataRetriever : ISecurityDataRetriever
    {
        #region Private Data

        private readonly ILogger _logger;

        #endregion

        #region Public Methods

        public SecurityDataRetriever(ILogger logger)
        {
            _logger = logger;
        }

        public IEnumerable<Security> GetSecurityData(IEnumerable<string> symbols)
        {
            _logger.Information("SecurityDataRetriever: Retrieving security data for symbols:");
            foreach (string symbol in symbols)
            {
                _logger.Information($"SecurityDataRetriever: {symbol}");
            }

            Task<IReadOnlyDictionary<string, Security>> retrievalTask = Yahoo.Symbols(symbols.ToArray())
                .Fields(Field.ShortName, Field.LongName, Field.RegularMarketTime, Field.MarketCap, Field.RegularMarketChange,
                    Field.RegularMarketPrice, Field.RegularMarketChangePercent, Field.RegularMarketVolume)
                .QueryAsync();
            retrievalTask.Wait();

            IReadOnlyDictionary<string, Security> retrievedData = retrievalTask.Result;
            return retrievedData.Values;
        }

        #endregion
    }
}
