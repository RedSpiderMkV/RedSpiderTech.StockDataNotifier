using RedSpiderTech.StockDataNotifier.Data.Factory.Interface;
using RedSpiderTech.StockDataNotifier.Data.Model.Implementation;
using RedSpiderTech.StockDataNotifier.Data.Model.Interface;
using RedSpiderTech.StockDataNotifier.Data.Model.XML;
using Serilog;

namespace RedSpiderTech.StockDataNotifier.Data.Factory.Implementation
{
    public class TrackedDataFactory : ITrackedDataFactory
    {
        #region Private Data

        private readonly ILogger _logger;

        #endregion

        #region Public Methods

        public TrackedDataFactory(ILogger logger)
        {
            _logger = logger;

            _logger.Information("TrackedDataFactory: Instantiation successful.");
        }

        public ITrackedData GetTrackedData(Stock stock)
        {
            _logger.Information($"TrackedDataFactory: Generating TrackedData for {stock.Symbol}");
            return new TrackedData(stock.Symbol, float.Parse(stock.PercentageChangeThresholdUpper), float.Parse(stock.PercentageChangeThresholdLower));
        }

        #endregion
    }
}
