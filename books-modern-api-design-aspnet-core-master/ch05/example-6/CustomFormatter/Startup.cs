using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CustomFormatter
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.OutputFormatters.Add(new CsvOutputFormatter());
            });
        }
        public void Configure(IApplicationBuilder app) => app.UseMvc();
    }
}
