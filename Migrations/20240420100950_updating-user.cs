using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon_2024_API.Migrations
{
    /// <inheritdoc />
    public partial class updatinguser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPacket",
                table: "Shipings");

            migrationBuilder.DropColumn(
                name: "Coordinates",
                table: "Packages");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Packages",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Packages",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "UserStatus",
                table: "ApplicationUsers",
                type: "int",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Packages");

            migrationBuilder.AddColumn<string>(
                name: "IdPacket",
                table: "Shipings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Coordinates",
                table: "Packages",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserStatus",
                table: "ApplicationUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 20);
        }
    }
}
