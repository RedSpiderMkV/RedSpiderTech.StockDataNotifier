using RedSpiderTech.StockDataNotifier.Data.Model.Interface;

namespace RedSpiderTech.StockDataNotifier.Data.Model.Implementation
{
    public class TrackedData : ITrackedData
    {
        #region Properties

        public string Symbol { get; }
        public float ChangePercentageThreshold { get; }

        #endregion

        #region Public Methods

        public TrackedData(string symbol, float threshold)
        {
            Symbol = symbol;
            ChangePercentageThreshold = threshold;
        }

        #endregion
    }
}
