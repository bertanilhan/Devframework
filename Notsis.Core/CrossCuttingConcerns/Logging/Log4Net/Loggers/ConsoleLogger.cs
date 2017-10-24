using log4net;

namespace Notsis.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    //jhon sönmez eğitimleri var çokgüzel log4net için
    public class ConsoleLogger:LoggerService
    {
        public ConsoleLogger() : base(LogManager.GetLogger(typeof(ConsoleLogger)))
        {
        }
    }
}
