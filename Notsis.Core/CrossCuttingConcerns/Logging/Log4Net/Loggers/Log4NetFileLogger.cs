using log4net;

namespace Notsis.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class Log4NetFileLogger:Log4NetLoggerService
    {
        public Log4NetFileLogger() : base(LogManager.GetLogger(typeof(Log4NetFileLogger)))
        {
        }
    }
}
