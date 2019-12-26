using System;
using RedSpiderTech.StockDataNotifier.Data.Model.Interface;

namespace RedSpiderTech.StockDataNotifier.Data.Model.Implementation
{
    public class TrackedData : ITrackedData
    {
        #region Properties

        public string Symbol { get; }
        public float ChangePercentageUpperThreshold { get; }
        public float ChangePercentageLowerThreshold { get; }

        #endregion

        #region Public Methods

        public TrackedData(string symbol, float upperThreshold, float lowerThreshold)
        {
            if(upperThreshold < lowerThreshold)
            {
                throw new ArgumentException($"Error generating tracker for {symbol}... Upper threshold must be lower than lower threshold");
            }

            Symbol = symbol;
            ChangePercentageUpperThreshold = upperThreshold;
            ChangePercentageLowerThreshold = lowerThreshold;
        }

        #endregion
    }
}
