using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace AwesomeSauce.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder()
                .ConfigureServices(services =>
                    services.AddSingleton<IComponent, ComponentB>()
                )
                .Configure(app =>
                {
                    var component = app.ApplicationServices.GetRequiredService<IComponent>();
                    app.Run(async (context) =>
                       await context.Response.WriteAsync($"Name is {component.Name}")
                    );
                })
                .Build();
    }
}
