namespace RedSpiderTech.StockDataNotifier.Host.Utilities
{
    public interface IAppConfigurationManager
    {
        string InputFile { get; }
        string LogFile { get; }
        string OutputFile { get; }
    }
}