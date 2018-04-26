using GraphQLSample.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IPersonRepository, PersonRepository>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<AwesomeGraphQLMiddleware>();        }
    }
}
