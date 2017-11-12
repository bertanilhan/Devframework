using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Notsis.Core.Utilities.Interceptors;
using Notsis.Core.Utilities.IoC;

namespace Notsis.Core.Aspects.Autofac.Performance
{
    public class PerformanceInterception:MethodInterception
    {
        private readonly int _interval;
        private readonly Stopwatch _stopwatch;
        public PerformanceInterception(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                Debug.WriteLine("Performans : {0}.{1} ->> {2}", invocation.Method.DeclaringType.FullName, invocation.Method.Name, _stopwatch.Elapsed.TotalSeconds);

            }
            _stopwatch.Reset();
        }
    }
}
