namespace RedSpiderTech.StockDataNotifier.Common.Utilities
{
    public interface IAppConfigurationManager
    {
        string InputFile { get; }
        string LogFile { get; }
    }
}