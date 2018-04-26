using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeConventions
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
             .AddSingleton<IPeopleRepository, PeopleRepository>()
             .AddMvc((o) =>
             {
                 o.Conventions.Add(new AwesomeApiControllerConvention());
             });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
