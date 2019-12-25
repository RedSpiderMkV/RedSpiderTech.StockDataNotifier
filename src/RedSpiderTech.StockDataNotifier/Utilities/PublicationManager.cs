using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using NetMQ;
using NetMQ.Sockets;
using RedSpiderTech.StockDataNotifier.Common.Utilities;
using RedSpiderTech.StockDataNotifier.Data.Model.Interface;
using Serilog;

namespace RedSpiderTech.StockDataNotifier.Host
{
    public class PublicationManager : IPublicationManager
    {
        #region Private Data

        private readonly ILogger _logger;
        private readonly PublisherSocket _publisher;
        private readonly string _publicationTopic;
        private readonly string _connectionString;

        #endregion

        #region Public Methods

        public PublicationManager(IAppConfigurationManager appConfigurationManager, ILogger logger)
        {
            _logger = logger;
            _connectionString = appConfigurationManager.MessageQueueConnectionString;
            _publicationTopic = appConfigurationManager.MessageQueueTopic;
            
            _publisher = new PublisherSocket();
            _publisher.Bind(_connectionString);
            Thread.Sleep(1000);

            _logger.Information("PublicationManager: Instantiation successful.");
        }

        public bool Publish(IMarketData marketData)
        {
            try
            {
                string dataFrame = ObjectToByteArray(marketData);
                _publisher.SendMoreFrame(_publicationTopic) // Topic
                          .SendFrame(dataFrame); // Message
            }
            catch(Exception exception)
            {
                _logger.Error("PublicationManager: Error publishing message.");
                _logger.Error(exception.ToString());
                return false;
            }

            return true;
        }

        public void Dispose()
        {
            _publisher.Dispose();
        }

        #endregion

        #region Private Methods

        private static string ObjectToByteArray(object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        #endregion
    }
}
