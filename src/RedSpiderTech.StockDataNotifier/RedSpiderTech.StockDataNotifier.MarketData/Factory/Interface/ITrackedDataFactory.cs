using RedSpiderTech.StockDataNotifier.Data.Model.Interface;
using RedSpiderTech.StockDataNotifier.Data.Model.XML;

namespace RedSpiderTech.StockDataNotifier.Data.Factory.Interface
{
    public interface ITrackedDataFactory
    {
        ITrackedData GetTrackedData(Stock stock);
    }
}