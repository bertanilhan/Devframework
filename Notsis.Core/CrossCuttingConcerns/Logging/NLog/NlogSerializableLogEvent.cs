using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;

namespace Notsis.Core.CrossCuttingConcerns.Logging.NLog
{
    public class NlogSerializableLogEvent:ISerializableLogEvent
    {
        private readonly LogEventInfo _logEvent;
        public NlogSerializableLogEvent(LogEventInfo logEvent)
        {
            _logEvent = logEvent;
        }

        public string UserName => Environment.UserName;
        public object MessageObject => _logEvent.Parameters.Select(x => x);
    }
}
