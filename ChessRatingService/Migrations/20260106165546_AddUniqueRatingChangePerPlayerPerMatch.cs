using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChessRatingService.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueRatingChangePerPlayerPerMatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RatingChanges_MatchId",
                table: "RatingChanges");

            migrationBuilder.CreateIndex(
                name: "IX_RatingChanges_MatchId_PlayerId",
                table: "RatingChanges",
                columns: new[] { "MatchId", "PlayerId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RatingChanges_MatchId_PlayerId",
                table: "RatingChanges");

            migrationBuilder.CreateIndex(
                name: "IX_RatingChanges_MatchId",
                table: "RatingChanges",
                column: "MatchId");
        }
    }
}
