using System.Configuration;
using System.IO;

namespace RedSpiderTech.StockDataNotifier.Common.Utilities
{
    public class AppConfigurationManager : IAppConfigurationManager
    {
        #region Properties

        public string InputFile => ConfigurationManager.AppSettings["inputFile"];
        
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

        public string MessageQueueConnectionString 
        { 
            get
            {
                string port = ConfigurationManager.AppSettings["messageQueuePort"];
                string hostname = ConfigurationManager.AppSettings["messageQueueHost"];

                return $"tcp://{hostname}:{port}";
            } 
        }

        public string MessageQueueTopic => ConfigurationManager.AppSettings["messageQueueTopic"];

        #endregion
    }
}
