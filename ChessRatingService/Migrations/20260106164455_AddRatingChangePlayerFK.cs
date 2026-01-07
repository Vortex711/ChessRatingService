using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChessRatingService.Migrations
{
    /// <inheritdoc />
    public partial class AddRatingChangePlayerFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RatingChanges_PlayerId",
                table: "RatingChanges",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_RatingChanges_Players_PlayerId",
                table: "RatingChanges",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RatingChanges_Players_PlayerId",
                table: "RatingChanges");

            migrationBuilder.DropIndex(
                name: "IX_RatingChanges_PlayerId",
                table: "RatingChanges");
        }
    }
}
