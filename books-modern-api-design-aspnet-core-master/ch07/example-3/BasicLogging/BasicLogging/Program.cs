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
        private readonly ILogger logger;
        public Startup(ILogger<Startup> logger)
        {
            this.logger = logger;
            logger.LogInformation(1000, "Logging from constructor!");
        }
        public void Configure(IApplicationBuilder app)
        {
            logger.LogInformation(1001, "Logging from Configure!");
            app.Run(async (context) =>
            {
                logger.LogInformation(1002, "Logging from app.Run!");
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}