using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChessRatingService.Migrations
{
    /// <inheritdoc />
    public partial class AddPlayerRatingFloor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_Player_CurrentRating_Min100",
                table: "Players",
                sql: "CurrentRating >= 100");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Player_CurrentRating_Min100",
                table: "Players");
        }
    }
}
