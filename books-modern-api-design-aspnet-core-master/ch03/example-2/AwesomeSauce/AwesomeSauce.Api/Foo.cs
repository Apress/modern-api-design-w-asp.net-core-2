using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeSauce.Api
{
    public class Foo
    {
        //optional
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IComponent, ComponentB>();
        }

        //required
        public void Configure(IApplicationBuilder app, IComponent component)
        {
            app.Run(async (context) =>
                await context.Response.WriteAsync($"Name is {component.Name}")
            );
        }
    }
}
