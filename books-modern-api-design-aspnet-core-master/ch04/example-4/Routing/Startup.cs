using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Routing
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouter(builder =>
            {
                builder.MapRoute(string.Empty, context =>
                {
                    return context.Response.WriteAsync($"Welcome to the default route!");
                });


                builder.MapGet("foo/{name}/{surname?}", (request, response, routeData) =>
                {
                    return response.WriteAsync($"Welcome to Foo, {routeData.Values["name"]} {routeData.Values["surname"]}");
                });

                builder.MapPost("bar/{number:int}", (request, response, routeData) =>
                {
                    return response.WriteAsync($"Welcome to Bar, number is {routeData.Values["number"]}");
                });
            });
        }

    }
}
