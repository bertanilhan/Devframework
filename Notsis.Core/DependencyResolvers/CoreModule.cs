using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Notsis.Core.CrossCuttingConcerns.Caching;
using Notsis.Core.CrossCuttingConcerns.Caching.Microsoft;
using Notsis.Core.Utilities.IoC;

namespace Notsis.Core.DependencyResolvers
{
    public class CoreModule:IModule
    {
        public void Load(IServiceCollection service)
        {
            service.AddMemoryCache();
            service.AddSingleton<ICacheManager, MemoryCacheManager>();
            service.AddSingleton<Stopwatch>();
        }
    }
}
