using System;
using System.IO;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using log4net;
using log4net.Config;
using Microsoft.Extensions.DependencyInjection;
using NLog.Config;
using NLog.LayoutRenderers;
using Notsis.Core.CrossCuttingConcerns.Logging.NLog.Layouts;
using Notsis.Core.Utilities.IoC;
using IModule = Notsis.Core.Utilities.IoC.IModule;
using Module = Autofac.Module;

namespace Notsis.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private static IContainer _container;

        public static IServiceCollection AddDependencyResolvers(this IServiceCollection service, IModule[] modules)
        {
            //Her katmanın çözümleme modülleri IServiceCollection'a ekleniyor.
            foreach (var module in modules)
            {
                module.Load(service);
            }
            return ServiceTool.Create(service);
        }

        public static IServiceCollection AddAutofacDependencyResolvers(this IServiceCollection services, Module[] modules)
        {

            var builder = new ContainerBuilder();
            //Daha önce IServiceCollection tarafında yapılan çözümlemeleri dolduruyor.
            builder.Populate(services);

            foreach (var module in modules)
            {
                builder.RegisterModule(module);
            }

            _container = builder.Build();

            return services;
        }

        public static IServiceProvider CreateAutofacServiceProvider(this IServiceCollection services)
        {
            return new AutofacServiceProvider(_container);
        }
        public static IServiceCollection AddLog4Net(this IServiceCollection services, string configFile = "log4net.config")
        {
            //Dikkat => Log4Net 2.0.5 sürümde çalışaktadır. Üst sürümlerde hata vermektedir.
            var assembly = Assembly.GetEntryAssembly();
            var logRepository = LogManager.GetRepository(assembly);
            XmlConfigurator.Configure(logRepository, new FileInfo(configFile));
            

            return services;
        }

        public static IServiceCollection AddNlog(this IServiceCollection services, string configFile="nlog.config")
        {
            //Config'den önce olmalıdır.
            LayoutRenderer.Register<JsonLogDetailLayout>("json-log-detail");

            var rootPath = AppContext.BaseDirectory;
            var configPath = Path.Combine(rootPath, configFile);
            var config = new XmlLoggingConfiguration(configPath);
            var logger = NLog.LogManager.Configuration = config;

            return services;
        }
    }
}
