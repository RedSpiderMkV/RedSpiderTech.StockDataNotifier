using Serilog;

namespace RedSpiderTech.StockDataNotifier.Host.Utilities
{
    public interface ILogInitialiser
    {
        ILogger GetLogger();
    }
}