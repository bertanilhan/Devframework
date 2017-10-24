using Microsoft.Extensions.DependencyInjection;

namespace Notsis.Core.Utilities.IoC
{
    public interface IModule
    {
        void Load(IServiceCollection service);
    }
}
