using log4net;

namespace Notsis.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class EventLogger:Log4NetLoggerService
    {
        public EventLogger() : base(LogManager.GetLogger(typeof(EventLogger)))
        {
        }
    }
}
