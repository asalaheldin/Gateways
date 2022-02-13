using Gateways.Data.Entities;
using Gateways.Presistance.EntitiesConfigurations;
using Gateways.Presistance.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gateways.Presistance.DBContext
{
    /// <summary>
    /// Used to override any desired behavior in default EntityFrameWorkCore DBContext 
    /// </summary>
    public class GatewaysContext : DbContext
    {
        public GatewaysContext(DbContextOptions<GatewaysContext> options)
            : base(options)
        {
           
        }
        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken) > 0; 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GatewayMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PeripheralMap).Assembly);
        }
        #region DbSets
        public virtual DbSet<Gateway> Gateways { get; set; }
        public virtual DbSet<Peripheral> Peripherals { get; set; }
        #endregion
    }
}
