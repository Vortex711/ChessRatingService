using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChessRatingService.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueExternalMatchId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ExternalMatchId",
                table: "Matches",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_ExternalMatchId",
                table: "Matches",
                column: "ExternalMatchId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Matches_ExternalMatchId",
                table: "Matches");

            migrationBuilder.AlterColumn<string>(
                name: "ExternalMatchId",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
