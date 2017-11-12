using log4net.Core;

namespace Notsis.Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class Log4NetSerializableLogEvent:ISerializableLogEvent
    {
        //Buarada dışardan değerler alarak uygulamamıza özel değerleride loga yazıdrabiliriz.
        //Örneğin Asp.net session id yi tutmak gibi.
        private readonly LoggingEvent _loggingEvent;
        public Log4NetSerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }

        public string UserName => _loggingEvent.UserName;
        public object MessageObject => _loggingEvent.MessageObject;

    }
}
