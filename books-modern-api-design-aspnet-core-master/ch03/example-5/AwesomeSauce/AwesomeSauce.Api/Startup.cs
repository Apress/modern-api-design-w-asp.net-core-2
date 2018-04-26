using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace AwesomeSauce.Api
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Map("/foo",
                config =>
                    config.Use(async (context, next) =>
                        await context.Response.WriteAsync("Welcome to /foo")
                    )
                );
            app.MapWhen(
                context =>
                    context.Request.Method == "POST" &&
                    context.Request.Path == "/bar",
                config =>
                    config.Use(async (context, next) =>
                        await context.Response.WriteAsync("Welcome to POST /bar")
                    )
                );
        }
    }
}
