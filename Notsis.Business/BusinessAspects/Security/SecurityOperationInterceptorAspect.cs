using System.Linq;
using System.Security;
using System.Security.Claims;
using Castle.DynamicProxy;
using Notsis.Core.Utilities.Interceptors;
using Microsoft.Extensions.DependencyInjection;
using Notsis.Core.Utilities.IoC;

namespace Notsis.Business.BusinessAspects.Security
{
    public class SecurityOperationInterceptorAspect:MethodInterception
    {
        private readonly string _operation;
        private readonly ClaimsPrincipal _claimsPrincipal;
        public SecurityOperationInterceptorAspect(string operation)
        {
            _operation = operation;
            _claimsPrincipal = ServiceTool.ServiceProvider.GetService<ClaimsPrincipal>();
        }
        
        protected override void OnBefore(IInvocation invocation)
        {
            //DİKKAT => .Net Core tamamen asenkron bir yapıda oluduğu için,
            //Ui tarafında set ettiğimiz Thread.CurrentPrincipal çoğu zaman null gelmektedir.
            //Bu sebeble IHttpContextAccessor kullanılmalıdır.
            //Fakat bu yötem AspNetCore'a bağımlılık getirmektedir.
            //Bu sebep ile dependency injection ile ClaimsPrincipal çekilerek bağımlılık ortadan kaldırılır.
            //IIdentity için ServiceTool.ServiceProvider.GetService<IIdentity>(); tercih edilebilir.
            //Dbden gerekli kontroller,
            if (!_claimsPrincipal.Claims.Any(x=> x.Type == ClaimTypes.AuthorizationDecision && x.Value == _operation))
            {
                throw new SecurityException("You are not authorized");
            }
            //Claims ile uğraşmak istemiyorsanız, ClaimsToIdentity yapabilirsiniz.
        }
    }
}
