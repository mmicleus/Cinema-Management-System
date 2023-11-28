using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorCinemaMS.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedNrOfRows : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NrOfColumns",
                table: "Venues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NrOfRows",
                table: "Venues",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NrOfColumns",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "NrOfRows",
                table: "Venues");
        }
    }
}
