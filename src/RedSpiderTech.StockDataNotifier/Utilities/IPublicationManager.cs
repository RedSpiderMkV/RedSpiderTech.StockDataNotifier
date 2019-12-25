using System;
using System.Collections.Generic;
using RedSpiderTech.StockDataNotifier.Data.Model.Interface;

namespace RedSpiderTech.StockDataNotifier.Host
{
    public interface IPublicationManager : IDisposable
    {
        bool Publish(IMarketData marketData);
    }
}