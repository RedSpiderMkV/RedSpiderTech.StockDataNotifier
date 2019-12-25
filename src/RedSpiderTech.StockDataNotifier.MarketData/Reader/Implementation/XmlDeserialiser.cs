using System.IO;
using System.Xml.Serialization;
using RedSpiderTech.StockDataNotifier.Common.Utilities;
using RedSpiderTech.StockDataNotifier.Data.Reader.Interface;
using Serilog;

namespace RedSpiderTech.StockDataNotifier.Data.Reader.Implementation
{
    public class XmlDeserialiser<T> : IXmlDeserialiser<T>
    {
        #region Private Data

        private readonly ILogger _logger;
        private readonly XmlSerializer _serialiser;
        private readonly string _fileName;

        #endregion

        #region Public Methods

        public XmlDeserialiser(ILogger logger, IAppConfigurationManager appConfigurationManager)
        {
            _logger = logger;
            _fileName = appConfigurationManager.InputFile;
            _serialiser = new XmlSerializer(typeof(T));

            _logger.Information("XmlDeserialiser: Instantiation successful.");
        }

        public T GetDeserialised()
        {
            using (Stream reader = new FileStream(_fileName, FileMode.Open))
            {
                _logger.Information($"XmlDeserialiser: Extracting xml data from filename: {_fileName}");
                return (T)_serialiser.Deserialize(reader);
            }
        }

        #endregion
    }
}
