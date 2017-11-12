using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Notsis.Core.CrossCuttingConcerns.Logging;
using Notsis.Core.CrossCuttingConcerns.Logging.Log4Net;
using Notsis.Core.Utilities.Interceptors;

namespace Notsis.Core.Aspects.Autofac.Logging
{
    public class LogInterception:MethodInterception
    {
        private readonly ILoggerService _loggerService;

        public LogInterception(Type loggerType)
        {
            if (!typeof(ILoggerService).IsAssignableFrom(loggerType))
            {
                throw new Exception("Wrong Logger Type");
            }
            _loggerService = (ILoggerService)Activator.CreateInstance(loggerType);
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var logParameters = invocation.Method.GetParameters()
                .Select((t, i) => new LogParameter
                {
                    Name = t.Name,
                    Type = t.ParameterType.Name,
                    Value = invocation.Arguments[i]
                }).ToList();

            var logDetail = new LogDetail
            {
                FullName = invocation.Method.DeclaringType == null ? null : invocation.Method.DeclaringType.Name,
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };

            _loggerService.Debug(logDetail);
        }
    }
}
