using System.Collections.Generic;
using System.Linq;
using Autofac;
using RedSpiderTech.StockDataNotifier.Common.Utilities;
using RedSpiderTech.StockDataNotifier.Data.Factory.Implementation;
using RedSpiderTech.StockDataNotifier.Data.Factory.Interface;
using RedSpiderTech.StockDataNotifier.Data.Filter.Implementation;
using RedSpiderTech.StockDataNotifier.Data.Filter.Interface;
using RedSpiderTech.StockDataNotifier.Data.Model.Interface;
using RedSpiderTech.StockDataNotifier.Data.Model.XML;
using RedSpiderTech.StockDataNotifier.Data.Reader.Implementation;
using RedSpiderTech.StockDataNotifier.Data.Reader.Interface;
using RedSpiderTech.StockDataNotifier.Host.Utilities;
using RedSpiderTech.StockDataNotifier.SecurityDataRetrieval;
using Serilog;
using YahooFinanceApi;

namespace RedSpiderTech.StockDataNotifier.Host
{
    public class Program
    {
        private static IContainer _container;
        private static ILogger _logger;

        public static void Main(string[] args)
        {
            InitialiseContainer();

            var appConfigurationManager = _container.Resolve<IAppConfigurationManager>();
            _logger = _container.Resolve<ILogger>();

            _logger.Information("RedSpiderTech.StockDataNotifier - Stock Data Monitoring");
            _logger.Information("--------------------------------------");

            ISecurityDataRetriever securityDataRetriever = _container.Resolve<ISecurityDataRetriever>();
            IMarketDataFactory marketDataFactory = _container.Resolve<IMarketDataFactory>();
            IInputFileReader inputFileReader = _container.Resolve<IInputFileReader>();
            ITrackedDataFilter trackedDataFilter = _container.Resolve<ITrackedDataFilter>();
            IPublicationManager publicationManager = _container.Resolve<IPublicationManager>();

            IEnumerable<Security> securityDataCollection = securityDataRetriever.GetSecurityData(inputFileReader.Symbols);
            IEnumerable<IMarketData> marketDataCollection = securityDataCollection.Select(marketDataFactory.GetMarketData);
            IEnumerable<IMarketData> marketDataForPublishing = trackedDataFilter.GetMarketDataForPublishing(marketDataCollection);
            IEnumerable<bool> publishSuccess = marketDataForPublishing.Select(publicationManager.Publish);

            if(publishSuccess.Any(x => !x))
            {
                _logger.Warning("Not all data was published successfully...");
            }

            _logger.Information("RedSpiderTech.StockDataNotifier - Stock Data Monitoring ended");
            _logger.Information("--------------------------------------");
        }

        private static void InitialiseContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<LogInitialiser>().As<ILogInitialiser>().SingleInstance();
            builder.Register(x => x.Resolve<ILogInitialiser>().GetLogger()).As<ILogger>().SingleInstance();
            builder.RegisterType<SecurityDataRetriever>().As<ISecurityDataRetriever>().SingleInstance();
            builder.RegisterType<InputFileReader>().As<IInputFileReader>().SingleInstance();
            builder.RegisterType<AppConfigurationManager>().As<IAppConfigurationManager>();
            builder.RegisterType<MarketDataFactory>().As<IMarketDataFactory>();
            builder.RegisterType<TrackedDataFactory>().As<ITrackedDataFactory>();
            builder.RegisterType<TrackedDataFilter>().As<ITrackedDataFilter>();
            builder.RegisterType<PublicationManager>().As<IPublicationManager>();
            builder.RegisterType<XmlDeserialiser<StockAlerts>>().As<IXmlDeserialiser<StockAlerts>>();

            _container = builder.Build();
        }
    }
}
