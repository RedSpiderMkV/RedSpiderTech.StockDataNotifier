using RedSpiderTech.StockDataNotifier.Data.Filter.Interface;
using RedSpiderTech.StockDataNotifier.Data.Model.Interface;
using RedSpiderTech.StockDataNotifier.Data.Reader.Interface;
using Serilog;
using System.Collections.Generic;
using System.Linq;

namespace RedSpiderTech.StockDataNotifier.Data.Filter.Implementation
{
    public class TrackedDataFilter : ITrackedDataFilter
    {
        #region Private Data

        private readonly ILogger _logger;
        private readonly IInputFileReader _inputFileReader;

        #endregion

        #region Public Methods

        public TrackedDataFilter(ILogger logger, IInputFileReader inputFileReader)
        {
            _logger = logger;
            _inputFileReader = inputFileReader;

            _logger.Information("TrackedDataFilter: Instantiation successful.");
        }

        public IEnumerable<IMarketData> GetMarketDataForPublishing(IEnumerable<IMarketData> marketDataCollection)
        {
            IEnumerable<IMarketData> dataCollectionForPublishing = marketDataCollection.Where(ShouldPublish);
            return dataCollectionForPublishing;
        }

        #endregion

        #region Private Methods

        private bool ShouldPublish(IMarketData marketData)
        {
            ITrackedData trackedData = _inputFileReader.TrackedDataCollection.First(x => x.Symbol.Equals(marketData.Symbol));
            bool shouldPublish = false;
            if(trackedData.ChangePercentageThreshold > 0)
            {
                shouldPublish = marketData.CurrentPriceChangePercentage >= trackedData.ChangePercentageThreshold;
            }
            if(trackedData.ChangePercentageThreshold < 0)
            {
                shouldPublish = marketData.CurrentPriceChangePercentage <= trackedData.ChangePercentageThreshold;
            }

            shouldPublish = shouldPublish || trackedData.ChangePercentageThreshold == 0;
            if (shouldPublish)
            {
                _logger.Information($"TrackedDataFilter: {trackedData.Symbol} has breached threshold and will be published.");
            }

            return shouldPublish;
        }

        #endregion
    }
}
