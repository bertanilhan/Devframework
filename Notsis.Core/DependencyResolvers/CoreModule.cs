using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Notsis.Core.CrossCuttingConcerns.Caching;
using Notsis.Core.CrossCuttingConcerns.Caching.Microsoft;
using Notsis.Core.Utilities.IoC;

namespace Notsis.Core.DependencyResolvers
{
    public class CoreModule:IModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<Stopwatch>();
            services.AddTransient<ClaimsPrincipal>(x => x.GetService<IHttpContextAccessor>().HttpContext.User);

        }
    }
}
