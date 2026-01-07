using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChessRatingService.Migrations
{
    /// <inheritdoc />
    public partial class AddRatingChangeMatchFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RatingChanges_MatchId",
                table: "RatingChanges",
                column: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_RatingChanges_Matches_MatchId",
                table: "RatingChanges",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RatingChanges_Matches_MatchId",
                table: "RatingChanges");

            migrationBuilder.DropIndex(
                name: "IX_RatingChanges_MatchId",
                table: "RatingChanges");
        }
    }
}
