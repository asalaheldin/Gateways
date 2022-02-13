using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gateways.Api.Filters;
using Gateways.Presistance.DBContext;
using Gateways.Presistance.DependencyResolution;
using Gateways.Service.DependencyResolution;
using Gateways.UseCases.DependencyResolution;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Gateways.Api
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
            services.AddControllers(options => {
                options.Filters.Add(new ExceptionFilter());
            });
            ConfigureIoC(services);
        }
        public void ConfigureIoC(IServiceCollection services)
        {
            services.AddDbContext<GatewaysContext>(o => o.UseSqlServer(Configuration.GetConnectionString("GatewayConnectionString")));
            services.AddCoreService();
            services.AddInfrastructure();
            services.AddUseCases();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
           
        }
    }
}
