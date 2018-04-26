using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

public class Program
{
    public static void Main(string[] args)
    {
        new WebHostBuilder()
        .UseKestrel()
        .UseStartup<Startup>()
        .ConfigureLogging(logging =>
        {
            logging
                .SetMinimumLevel(LogLevel.None)
                .AddFilter("Default", LogLevel.Error)
                .AddFilter<ConsoleLoggerProvider>("Program.Startup", LogLevel.Critical);
        })
        .Build()
        .Run();
    }
    public class Startup
    {
        private readonly ILogger logger;
        public Startup(ILogger<Startup> logger)
        {
            this.logger = logger;
        }
        public void Configure(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                logger.LogInformation("Log entry 1");
                logger.LogWarning("Log entry 2");
                logger.LogError("Log entry 3");
                logger.LogCritical("Log entry 4");

                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}