using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gateways.Presistance.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gateway",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    IPv4 = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gateway", x => x.SerialNumber)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Peripheral",
                columns: table => new
                {
                    UID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vendor = table.Column<string>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    GatewaySerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peripheral", x => x.UID)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Peripheral_Gateway_GatewaySerialNumber",
                        column: x => x.GatewaySerialNumber,
                        principalTable: "Gateway",
                        principalColumn: "SerialNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Peripheral_GatewaySerialNumber",
                table: "Peripheral",
                column: "GatewaySerialNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Peripheral");

            migrationBuilder.DropTable(
                name: "Gateway");
        }
    }
}
