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
            logging.AddConsole(options => options.IncludeScopes = true);
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
                using (logger.BeginScope("This is an awesome group"))
                {
                    logger.LogInformation("Log entry 1");
                    logger.LogWarning("Log entry 2");
                    logger.LogError("Log entry 3");
                }
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}