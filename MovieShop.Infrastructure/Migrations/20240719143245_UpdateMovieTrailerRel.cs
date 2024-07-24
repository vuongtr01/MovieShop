using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMovieTrailerRel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Trailers_MovieId",
                table: "Trailers");

            migrationBuilder.CreateIndex(
                name: "IX_Trailers_MovieId",
                table: "Trailers",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Trailers_MovieId",
                table: "Trailers");

            migrationBuilder.CreateIndex(
                name: "IX_Trailers_MovieId",
                table: "Trailers",
                column: "MovieId",
                unique: true);
        }
    }
}
