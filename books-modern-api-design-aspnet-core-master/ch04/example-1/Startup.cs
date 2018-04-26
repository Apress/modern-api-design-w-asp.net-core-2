using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace AwesomeServer
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {

            app.MapWhen(c => c.Request.Path == "/foo/bar", config =>
            {
                config.Run(async (context) =>
                {
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("Hello World!");
                });
            })
            .Run(async (context) =>
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Not Found");
            });
        }
    }
}
