using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using Castle.DynamicProxy;
using Notsis.Core.CrossCuttingConcerns.Security;
using Notsis.Core.Utilities.Interceptors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Notsis.Core.Utilities.IoC;

namespace Notsis.Business.BusinessAspects.Security
{
    public class SecurityOperationInterceptorAspect:MethodInterception
    {
        private readonly string _operation;
        private readonly IHttpContextAccessor _context;
        public SecurityOperationInterceptorAspect(string operation)
        {
            _operation = operation;
            _context = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            //DİKKAT => .Net Core tamamen asenkron bir yapıda oluduğu için,
            //Ui tarafında set ettiğimiz Thread.CurrentPrincipal çoğu zaman null gelmektedir.
            //Bu sebeble IHttpContextAccessor kullanılmalıdır.

            var claimsPrincipal = _context.HttpContext.User;
            //Dbden gerekli kontroller,
            if (!claimsPrincipal.Claims.Any(x=> x.Type == ClaimTypes.AuthorizationDecision && x.Value == _operation))
            {
                throw new SecurityException("You are not authorized");
            }
            
        }
    }
}
