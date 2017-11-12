using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Notsis.Business.DependencyResolvers.Autofac;
using Notsis.Core.DependencyResolvers;
using Notsis.Core.Extensions;
using Notsis.Core.Utilities.IoC;
using Notsis.DataAccess.DependencyResolvers.Autofac;
using Module = Autofac.Module;

namespace Notsis.NetCoreMvcUi
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddLog4Net();

            services.AddNlog();


            services.AddAuthentication(options =>
                {
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie();


            services.AddDependencyResolvers(new IModule[]
                {
                new CoreModule(),
                    //new DataAccessModule(),
                    //new BusinessModule()
                });

            services.AddAutofacDependencyResolvers(new Module[]
            {
                new AutofacDataAccessModule(),
                new AutofacBusinessModule()
            });

            return services.CreateAutofacServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //Dikkat => UseAuthentication, UseMvc'den önce çağrılmalıdır.
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Product}/{action=Index}/{id?}");
            });




        }
    }
}
