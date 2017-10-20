using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Http.Extensions;

namespace MvcWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.Use(async (context, next) =>
            //{
            //    var sw = new Stopwatch();
            //    sw.Start();
            //    await next();
            //    sw.Stop();
            //    await File.AppendAllTextAsync("logs/log.txt", $"request {context.Request.GetDisplayUrl()} was processed in {sw.ElapsedMilliseconds} ms\n");
            //});

            app.UseMiddleware<StopwatchMiddleware>();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

    public class StopwatchMiddleware
    {
        private readonly RequestDelegate next;

        public StopwatchMiddleware(RequestDelegate next) => this.next = next;

        public async Task Invoke(HttpContext context)
        {
            var sw = new Stopwatch();
            sw.Start();
            await next(context);
            sw.Stop();
            await File.AppendAllTextAsync("logs/log.txt", $"request {context.Request.GetDisplayUrl()} was processed in {sw.ElapsedMilliseconds} ms\n");
        }
    }
}
