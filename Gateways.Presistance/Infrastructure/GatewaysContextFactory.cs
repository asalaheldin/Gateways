using Gateways.Presistance.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gateways.Presistance.Infrastructure
{
    public class GatewaysContextFactory : DesignTimeDbContextFactoryBase<GatewaysContext>
    {
        public GatewaysContextFactory()
        {
        }
        protected override GatewaysContext CreateNewInstance(DbContextOptions<GatewaysContext> options)
        {
            return new GatewaysContext(options);
        }
    }
}
