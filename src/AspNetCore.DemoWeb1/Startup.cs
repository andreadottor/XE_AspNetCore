using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AspNetCore.DemoWeb1
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            // services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.Run(async context => {
                context.Response.Headers.Add("content-type", "text/plain");
                await context.Response.WriteAsync("<h1>Hello World</h1>");
            });

            /*loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseDeveloperExceptionPage();

            var routeBuilder = new RouteBuilder(app);
            routeBuilder.MapGet("", context =>
            {
                context.Response.Headers.Add("content-type", "text/plain");
                return context.Response.WriteAsync("<h1>Hello World</h1>");
            });

            var routes = routeBuilder.Build();
            app.UseRouter(routes);*/


        }
    }
}
