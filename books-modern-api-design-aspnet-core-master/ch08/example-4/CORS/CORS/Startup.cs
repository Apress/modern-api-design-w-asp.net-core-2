using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CORS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AwesomeGlobalPolicy", builder => builder.WithOrigins("http://awesome.com"));
                options.AddPolicy("AwesomePolicy1", builder => builder.WithOrigins("http://app1.awesome.com"));
                options.AddPolicy("AwesomePolicy2", builder => builder.WithOrigins("http://app2.awesome.com"));
                options.AddPolicy("AnotherAwesomePolicy1", builder => builder.WithOrigins("http://app3.awesome.com"));
            });
            services.AddMvc(options => options.Filters.Add(new CorsAuthorizationFilterFactory("AwesomePolicy1")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AwesomeGlobalPolicy");
            app.UseMvc();

        }
    }
}
