using System;
using System.Collections.Generic;
using System.Text;
using NLog;

namespace Notsis.Core.CrossCuttingConcerns.Logging.NLog
{
    public class NLogLoggerService:ILoggerService
    {
        private readonly ILogger _logger;

        public NLogLoggerService(ILogger logger)
        {
            _logger = logger;
        }

        public bool IsInfoEnabled => _logger.IsInfoEnabled;
        public bool IsDebugEnabled => _logger.IsInfoEnabled;
        public bool IsWarnEnabled => _logger.IsInfoEnabled;
        public bool IsErrorEnabled => _logger.IsInfoEnabled;
        public bool IsFatalEnabled => _logger.IsInfoEnabled;

        public void Info(object logMessage)
        {
            if (IsInfoEnabled)
            {
                _logger.Info(logMessage);
            }
        }

        public void Debug(object logMessage)
        {
            if (IsDebugEnabled)
            {
                _logger.Debug(logMessage);
            }
        }

        public void Warn(object logMessage)
        {
            if (IsWarnEnabled)
            {
                _logger.Warn(logMessage);
            }
        }

        public void Error(object logMessage)
        {
            if (IsErrorEnabled)
            {
                _logger.Error(logMessage);
            }
        }

        public void Fatal(object logMessage)
        {
            if (IsFatalEnabled)
            {
                _logger.Fatal(logMessage);
            }
        }
    }
}
