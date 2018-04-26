using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OptionsExample
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile(config =>
                {
                    config.Path = "awesomeConfig.json";
                    config.ReloadOnChange = true;
                });
            Configuration = builder.Build();
        }
        public IConfigurationRoot Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.Configure<AwesomeOptions>(Configuration);
            services.Configure<AwesomeOptions.BazOptions>(Configuration.GetSection("baz"));
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
