using Serilog;
using Serilog.Events;

namespace RedSpiderTech.StockDataNotifier.Host.Utilities
{
    public class LogInitialiser : ILogInitialiser
    {
        #region Private Data

        private readonly string _logFile;

        #endregion

        #region Public Methods

        public LogInitialiser(IAppConfigurationManager appConfigurationManager)
        {
            _logFile = appConfigurationManager.LogFile;
        }

        public ILogger GetLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(LogEventLevel.Verbose)
                .WriteTo.File(_logFile, rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: LogEventLevel.Verbose)
                .CreateLogger();

            return Log.Logger;
        }

        #endregion
    }
}
