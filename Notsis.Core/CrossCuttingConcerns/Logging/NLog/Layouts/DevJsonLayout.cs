using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using NLog;
using NLog.LayoutRenderers;
using NLog.Layouts;
using Notsis.Core.CrossCuttingConcerns.Logging.Log4Net;

namespace Notsis.Core.CrossCuttingConcerns.Logging.NLog.Layouts
{

    public class JsonLogDetailLayout : LayoutRenderer
    {
        protected override void Append(StringBuilder builder, LogEventInfo logEventInfo)
        {

            var logEvent = new NlogSerializableLogEvent(logEventInfo);

            var json = JsonConvert.SerializeObject(logEvent, Formatting.Indented);

            builder.Append(json);

        }
    }
}
