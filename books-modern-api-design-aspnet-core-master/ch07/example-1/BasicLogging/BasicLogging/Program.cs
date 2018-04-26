using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
public class Program
{
    public static void Main(string[] args)
    {
        new WebHostBuilder()
        .UseKestrel()
        .UseStartup<Startup>()
        .ConfigureLogging(logging =>
        {
            logging.AddConsole();
        })
        .Build()
        .Run();
    }
    public class Startup
    {
        public void Configure(IApplicationBuilder app, ILogger<Startup>
        logger)
        {
            app.Run(async (context) =>
            {
                logger.LogInformation("This is awesome!");
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}