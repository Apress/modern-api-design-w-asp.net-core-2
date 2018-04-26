using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        new WebHostBuilder()
        .UseKestrel()
        .UseStartup<Startup>()
        .UseContentRoot(Directory.GetCurrentDirectory())
        .ConfigureAppConfiguration((context, config) =>
            config.AddJsonFile("config.json"))
        .ConfigureLogging((context, logging) =>
            {
                var config = context.Configuration.GetSection("Logging");
                logging.AddConfiguration(config);
                logging.AddConsole();
            })
        .Build()
        .Run();
    }
    public class Startup
    {
        private readonly ILoggerFactory loggerFactory;
        public Startup(ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
            var constructorLogger = loggerFactory.CreateLogger("Startup.ctor");
            constructorLogger.LogInformation("Logging from constructor!");
        }

        public void Configure(IApplicationBuilder app)
        {
            var configureLogger = loggerFactory.CreateLogger("Startup.Configure");
            configureLogger.LogInformation("Logging from Configure!");
            app.Run(async (context) =>
            {
                var logger = loggerFactory.CreateLogger("Startup.Configure.Run");
                configureLogger.LogInformation("Logging from app.Run!");
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}