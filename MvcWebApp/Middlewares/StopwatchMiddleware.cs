using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace MvcWebApp.Middlewares
{
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
            await File.AppendAllTextAsync("logs/log.txt", $"request {context.Request.GetDisplayUrl()} was processed in {sw.ElapsedMilliseconds} ms {Environment.NewLine}");
        }
    }
}