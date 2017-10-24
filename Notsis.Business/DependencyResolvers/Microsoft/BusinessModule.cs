using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Notsis.Business.Abstract;
using Notsis.Business.Concrete;
using Notsis.Core.Utilities.IoC;

namespace Notsis.Business.DependencyResolvers.Microsoft
{
    public class BusinessModule:IModule
    {
        public void Load(IServiceCollection service)
        {
            service.AddSingleton<IProductService, ProductManager>();

            //foreach (var fluentValidationType in FluentValidationTypes())
            //{
            //    service.AddSingleton(fluentValidationType);
            //}


        }

        private static IEnumerable<Type> FluentValidationTypes()
        {
            var types = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IValidator).IsAssignableFrom(p));

            return types;
        }
    }
}
