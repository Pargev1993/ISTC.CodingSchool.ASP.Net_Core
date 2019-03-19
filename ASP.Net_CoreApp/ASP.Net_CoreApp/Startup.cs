using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ASP.Net_CoreApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            int a = 2;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Use(async (context, next) =>
            //{
            //    a = a + 2;
            //    await context.Response.WriteAsync("a=" + a);
            //    await next();
            //});

            //Maping
            app.Map("/Main",(MainAppBilder)=>
            {
                MainAppBilder.Map("/Index", (appbilder) =>
                {
                    appbilder.Run(async (context) =>
                    {
                        await context.Response.WriteAsync("Hi Pargev");
                    });

                });

                MainAppBilder.Map("/Home", (appbilder) =>
                {
                    appbilder.Run(async (context) =>
                    {
                        await context.Response.WriteAsync("Hello Pargev");
                    });
                });

            });
            //Use Midleware

            app.UseMiddleware<MainMiddelware>();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
