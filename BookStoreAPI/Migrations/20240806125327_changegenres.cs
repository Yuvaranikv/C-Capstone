using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class changegenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Genres",
                newName: "updatedAt");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "Genres",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Genres",
                newName: "createdAt");

            migrationBuilder.RenameColumn(
                name: "genreId",
                table: "Genres",
                newName: "genre_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updatedAt",
                table: "Genres",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Genres",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "Genres",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "genre_id",
                table: "Genres",
                newName: "genreId");
        }
    }
}
