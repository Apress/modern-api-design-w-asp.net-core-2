using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AwesomeSauce.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration(config =>
                    config.AddJsonFile("appSettings.json", true)
                )
                .ConfigureLogging(logging =>
                    logging
                        .AddConsole()
                        .AddDebug()
                )
                .UseIISIntegration()
                .UseStartup<Foo>()
                .Build();

    }
}
