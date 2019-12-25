namespace RedSpiderTech.StockDataNotifier.Data.Model.Interface
{
    public interface ITrackedData
    {
        float ChangePercentageThreshold { get; }
        string Symbol { get; }
    }
}