﻿using log4net;

namespace Notsis.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class DatabaseLogger:LoggerService
    {
        public DatabaseLogger() : base(LogManager.GetLogger(typeof(DatabaseLogger)))
        {
        }
    }
}
