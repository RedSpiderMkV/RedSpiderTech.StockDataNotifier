﻿using System.Collections.Generic;
using System.Linq;
using RedSpiderTech.StockDataNotifier.Data.Factory.Interface;
using RedSpiderTech.StockDataNotifier.Data.Model.Interface;
using RedSpiderTech.StockDataNotifier.Data.Model.XML;
using RedSpiderTech.StockDataNotifier.Data.Reader.Interface;
using Serilog;

namespace RedSpiderTech.StockDataNotifier.Data.Reader.Implementation
{
    public class InputFileReader : IInputFileReader
    {
        #region Private Data

        private readonly ILogger _logger;
        private readonly IEnumerable<ITrackedData> _trackedDataCollection;

        #endregion

        #region Properties

        public IEnumerable<string> Symbols => _trackedDataCollection.Select(x => x.Symbol);

        #endregion

        #region Public Methods

        public InputFileReader(ILogger logger, ITrackedDataFactory trackedDataFactory, IXmlDeserialiser<StockAlerts> xmlDeserialiser)
        {
            _logger = logger;
            _trackedDataCollection = xmlDeserialiser.GetDeserialised().Stock.Select(trackedDataFactory.GetTrackedData);

            _logger.Information("InputFileReader: TrackedDataCollection initialised.");
            _logger.Information("InputFileReader: InputFileReader instantiated successfully.");
        }

        #endregion
    }
}
