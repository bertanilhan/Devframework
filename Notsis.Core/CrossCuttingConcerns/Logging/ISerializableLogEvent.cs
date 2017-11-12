using System;
using System.Collections.Generic;
using System.Text;

namespace Notsis.Core.CrossCuttingConcerns.Logging
{

    internal interface ISerializableLogEvent
    {
         string UserName { get; }
         object MessageObject { get; }
    }
}
