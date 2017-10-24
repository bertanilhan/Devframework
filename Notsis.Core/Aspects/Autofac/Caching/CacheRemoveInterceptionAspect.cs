using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Notsis.Core.CrossCuttingConcerns.Caching;
using Notsis.Core.Utilities.Interceptors;
using Notsis.Core.Utilities.IoC;

namespace Notsis.Core.Aspects.Autofac.Caching
{
    public class CacheRemoveInterceptionAspect:MethodInterception
    {
        private readonly string _pattern;
        private readonly ICacheManager _cacheManager;
        public CacheRemoveInterceptionAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public CacheRemoveInterceptionAspect(string pattern, Type cacheManagerType)
        {
            _pattern = pattern;
            _cacheManager = (ICacheManager)ServiceTool.ServiceProvider.GetService(cacheManagerType);
        }

        protected override void OnSuccess(IInvocation invocation)
        {          
            _cacheManager.RemoveByPattern(_pattern);
            //_cacheManager.RemoveByPattern(string.IsNullOrEmpty(_pattern)
            //    ? $"{invocation.Method.ReflectedType.Namespace}.{invocation.Method.ReflectedType.Name}.*"
            //    : _pattern);
        }
    }
}
