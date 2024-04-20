using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon_2024_API.Migrations
{
    /// <inheritdoc />
    public partial class initialRdxUaq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserStatus",
                table: "ApplicationUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Shipings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdPacket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IdCarrier = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shipings_ApplicationUsers_IdCarrier",
                        column: x => x.IdCarrier,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    Width = table.Column<float>(type: "real", nullable: false),
                    Lenghth = table.Column<float>(type: "real", nullable: false),
                    EntranceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SendDateEstimated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClientAddress = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    ClientFullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ClientPhone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PackageStatus = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Coordinates = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdShiping = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PackagePictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PackageDeliveredPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Packages_Shipings_IdShiping",
                        column: x => x.IdShiping,
                        principalTable: "Shipings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Packages_IdShiping",
                table: "Packages",
                column: "IdShiping");

            migrationBuilder.CreateIndex(
                name: "IX_Shipings_IdCarrier",
                table: "Shipings",
                column: "IdCarrier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Shipings");

            migrationBuilder.DropColumn(
                name: "UserStatus",
                table: "ApplicationUsers");
        }
    }
}
