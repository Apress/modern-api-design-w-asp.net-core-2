using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace AwesomeSauce.Api
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/foo")
                {
                    await context.Response.WriteAsync($"Welcome to Foo");
                }
                else
                {
                    await next();
                }
            });
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/bar")
                {
                    await context.Response.WriteAsync($"Welcome to Bar");
                }
                else
                {
                    await next();
                }
            });
            app.Run(async (context) =>
                await context.Response.WriteAsync($"Welcome to the default")
            );
        }

    }
}
