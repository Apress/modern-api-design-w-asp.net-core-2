using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AwesomeHostedService
{
    public class AwesomeHostedService : IHostedService
    {
        private readonly IHostingEnvironment env;

        public AwesomeHostedService(IHostingEnvironment env)
        {
            this.env = env;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var client = new HttpClient();
            var file = $@"{env.ContentRootPath}\wwwroot\comments.json";
            while (true)
            {
                var response = await client.GetAsync("https://api.external.com/comments");
                using (var output = File.OpenWrite(file))
                using (var content = await response.Content.ReadAsStreamAsync())
                {
                    content.CopyTo(output);
                }
                Thread.Sleep(60000);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }

}
