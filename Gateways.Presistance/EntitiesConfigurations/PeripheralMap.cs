using Gateways.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gateways.Presistance.EntitiesConfigurations
{
    public class PeripheralMap : IEntityTypeConfiguration<Peripheral>
    {
        public void Configure(EntityTypeBuilder<Peripheral> builder)
        {
            builder.HasKey(t => t.UID).IsClustered();
            builder.Property(t => t.Vendor).IsRequired();
            builder.Property(t => t.CreateAt);
        }
    }
}
