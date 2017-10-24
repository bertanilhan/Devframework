using Microsoft.Extensions.DependencyInjection;
using Notsis.Core.Utilities.IoC;
using Notsis.DataAccess.Abstract;
using Notsis.DataAccess.Concrete.EntityFramework;

namespace Notsis.DataAccess.DependencyResolvers.Microsoft
{
    public class DataAccessModule:IModule
    {
        public void Load(IServiceCollection service)
        {
            service.AddSingleton<IProductDal, EfProductDal>();
        }
    }
}
