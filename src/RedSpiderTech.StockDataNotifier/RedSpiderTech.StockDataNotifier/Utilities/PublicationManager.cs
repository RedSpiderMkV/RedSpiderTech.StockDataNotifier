using System.Collections.Generic;
using RedSpiderTech.StockDataNotifier.Data.Model.Interface;
using Serilog;

namespace RedSpiderTech.StockDataNotifier.Host
{
    public class PublicationManager : IPublicationManager
    {
        #region Private Data

        private readonly ILogger _logger;

        #endregion

        #region Public Methods

        public PublicationManager(ILogger logger)
        {
            _logger = logger;

            _logger.Information("PublicationManager: Instantiation successful.");
        }

        public void Publish(IMarketData marketData)
        {
            // Publish
        }

        public void Publish(IEnumerable<IMarketData> marketDataCollection)
        {
            // Publish
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
