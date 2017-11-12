using NLog;

namespace Notsis.Core.CrossCuttingConcerns.Logging.NLog.Loggers
{
    public class NLogFileLogger:NLogLoggerService
    {
        public NLogFileLogger() : base(LogManager.GetLogger("File"))
        {
            
            
        }
    }
}
