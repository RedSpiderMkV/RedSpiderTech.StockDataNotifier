namespace RedSpiderTech.StockDataNotifier.Data.Model.Interface
{
    public interface ITrackedData
    {
        float ChangePercentageUpperThreshold { get; }
        float ChangePercentageLowerThreshold { get; }
        string Symbol { get; }
    }
}