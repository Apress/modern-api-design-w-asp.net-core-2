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
            app.Map("/skip", (skipApp) => skipApp.UseSkipApp());
            app.UseNumberChecker();
            app.UseUpperValue();
            app.UseVowelMasker();
            app.Run(async (context) =>
            {
                var value = context.Items["value"].ToString();
                await context.Response.WriteAsync($"You entered a string: {value}");
            });
        }

    }
}
