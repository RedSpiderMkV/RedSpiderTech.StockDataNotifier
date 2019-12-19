﻿using System.Collections.Generic;
using System.Linq;
using Autofac;
using RedSpiderTech.StockDataNotifier.Data.Factory.Implementation;
using RedSpiderTech.StockDataNotifier.Data.Factory.Interface;
using RedSpiderTech.StockDataNotifier.Data.Model.Interface;
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

            string[] symbols = new string[] { "AAPL", "MCRO.L" };
            IEnumerable<Security> securityDataCollection = securityDataRetriever.GetSecurityData(symbols);
            IEnumerable<IMarketData> marketDataCollection = securityDataCollection.Select(marketDataFactory.GetMarketData);

            _logger.Information("RedSpiderTech.StockDataNotifier - Stock Data Monitoring ended");
            _logger.Information("--------------------------------------");
        }

        private static void InitialiseContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<LogInitialiser>().As<ILogInitialiser>().SingleInstance();
            builder.Register(x => x.Resolve<ILogInitialiser>().GetLogger()).As<ILogger>().SingleInstance();
            builder.RegisterType<SecurityDataRetriever>().As<ISecurityDataRetriever>().SingleInstance();
            builder.RegisterType<AppConfigurationManager>().As<IAppConfigurationManager>();
            builder.RegisterType<MarketDataFactory>().As<IMarketDataFactory>();

            _container = builder.Build();
        }
    }
}
