using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Middleware
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.Map("/skip", (skipApp) => skipApp.Run(async (context) =>
                await context.Response.WriteAsync($"Skip the line!")));
            app.Use(async (context, next) =>
            {
                var value = context.Request.Query["value"].ToString();
                if (int.TryParse(value, out int intValue))
                {
                    await context.Response.WriteAsync($"You entered a number: {intValue}");
                }
                else
                {
                    context.Items["value"] = value;
                    await next();
                }
            });

            app.Use(async (context, next) =>
            {
                var value = context.Items["value"].ToString(); if (int.TryParse(value, out int intValue))
                {
                    await context.Response.WriteAsync($"You entered a number: {intValue}");
                }
                else
                {
                    await next();
                }
            });

            app.Use(async (context, next) =>
            {
                var value = context.Items["value"].ToString();
                context.Items["value"] = value.ToUpper();
                await next();
            });

            app.Use(async (context, next) =>
            {
                var value = context.Items["value"].ToString();
                context.Items["value"] = Regex.Replace(value, "(?<!^)[AEUI](?!$)", "*");
                await next();
            });

            app.Run(async (context) =>
            {
                var value = context.Items["value"].ToString();
                await context.Response.WriteAsync($"You entered a string: {value}");
            });

        }
    }
}
