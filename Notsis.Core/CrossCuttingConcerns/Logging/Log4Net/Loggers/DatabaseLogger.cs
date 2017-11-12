using log4net;

namespace Notsis.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class DatabaseLogger:Log4NetLoggerService
    {
        public DatabaseLogger() : base(LogManager.GetLogger(typeof(DatabaseLogger)))
        {
        }
    }
}
