using AwesomeConfiguration;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace AwesomeConfiguration
{
    public class Program
    {
        public static IConfigurationRoot Configuration { get; set; }
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddLegacyXmlConfiguration("web.config");
            Configuration = builder.Build();
            foreach (var item in Configuration.AsEnumerable())
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }
            Console.ReadKey();
        }
    }
}
