using System.Net.Http;
using AwesomeApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AwesomeApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCaching();
            services.TryAddSingleton(new HttpClient());
            services.TryAddSingleton<IPeopleRepository, PeopleRepository>();
            services.AddMvc().AddXmlSerializerFormatters();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseResponseCaching();
            app.UseMvc();
        }
    }
}
