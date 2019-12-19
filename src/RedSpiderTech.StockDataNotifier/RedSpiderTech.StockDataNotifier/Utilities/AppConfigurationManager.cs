using System.Configuration;
using System.IO;

namespace RedSpiderTech.StockDataNotifier.Host.Utilities
{
    public class AppConfigurationManager : IAppConfigurationManager
    {
        #region Properties

        public string InputFile => ConfigurationManager.AppSettings["InputFile"];
        public string OutputFile => ConfigurationManager.AppSettings["OutputFile"];
        public string LogFile
        {
            get
            {
                string logFileDirectory = ConfigurationManager.AppSettings["logFileDirectory"];
                string logFileName = ConfigurationManager.AppSettings["logFileName"];
                string logFile = Path.Combine(logFileDirectory, logFileName);

                return logFile;
            }
        }

        #endregion
    }
}
