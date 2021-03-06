// <auto-generated />
using System;
using Gateways.Presistance.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gateways.Presistance.Migrations
{
    [DbContext(typeof(GatewaysContext))]
    [Migration("20220208181726_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Gateways.Data.Entities.Gateway", b =>
                {
                    b.Property<string>("SerialNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IPv4")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SerialNumber")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("Gateway");
                });

            modelBuilder.Entity("Gateways.Data.Entities.Peripheral", b =>
                {
                    b.Property<int>("UID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("GatewaySerialNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Vendor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UID")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("GatewaySerialNumber");

                    b.ToTable("Peripheral");
                });

            modelBuilder.Entity("Gateways.Data.Entities.Peripheral", b =>
                {
                    b.HasOne("Gateways.Data.Entities.Gateway", "Gateway")
                        .WithMany("AssociatedPeripherals")
                        .HasForeignKey("GatewaySerialNumber")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
