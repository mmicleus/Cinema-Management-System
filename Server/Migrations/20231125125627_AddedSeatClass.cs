using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorCinemaMS.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeatClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeatClass",
                table: "Seats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatClass",
                table: "Seats");
        }
    }
}
