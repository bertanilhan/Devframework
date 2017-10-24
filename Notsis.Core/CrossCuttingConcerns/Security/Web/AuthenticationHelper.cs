using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using Notsis.Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;

namespace Notsis.Core.CrossCuttingConcerns.Security.Web
{
    public class AuthenticationHelper
    {
        //Aspecte CookieValidatePrincipalContext context ile sağlanacak
        //ClaimsPrincipil oluşturulacak
        //SecurityExtensions.CookieName
        public string CreateAuthCookie()
        {
           // var context = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

           //var builder = new CookieBuilder();
           // //var x = builder.Domain => datamız

            return null;
        }
    }
}
