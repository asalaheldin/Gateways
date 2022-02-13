using Gateways.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gateways.Presistance.EntitiesConfigurations
{
    public class GatewayMap : IEntityTypeConfiguration<Gateway>
    {
        public void Configure(EntityTypeBuilder<Gateway> builder)
        {
            builder.HasKey(t => t.SerialNumber).IsClustered(false);
            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.IPv4).IsRequired().HasMaxLength(100);
            builder
              .HasMany(c => c.AssociatedPeripherals)
              .WithOne(c => c.Gateway)
              .HasForeignKey(a => a.GatewaySerialNumber)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
