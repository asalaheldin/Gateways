using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gateways.Presistance.DBContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Gateways.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    using (var concreteContext = (GatewaysContext)scope.ServiceProvider.GetService<GatewaysContext>())
                    {
                        concreteContext.Database.Migrate();
                        GatewaysContextSeed.Initialize(concreteContext);
                    }
                }
                catch (Exception ex)
                {
                    //To Do, log exception and send email that the migration and seed data has failed for a run manually
                }
            }

            host.Run();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
