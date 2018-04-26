using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeServer
{
    namespace Microsoft.AspNetCore.Hosting
    {
        public static class ServerExtensions
        {
            public static IWebHostBuilder UseAwesomeServer(this IWebHostBuilder hostBuilder, Action<AwesomeServerOptions> options)
            {
                return hostBuilder.ConfigureServices(services =>
                {
                    services.Configure(options);
                    services.AddSingleton<IServer, AwesomeServer>();
                });
            }
        }
    }

}
