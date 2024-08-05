using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    genre_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: true),
                    GenreId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId");
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId");
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Biography", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, "British author, best known for the Harry Potter series.", true, "J.K. Rowling" },
                    { 2, "American novelist and short story writer, known for A Song of Ice and Fire series.", true, "George R.R. Martin" },
                    { 3, "English writer, poet, and philologist, author of The Lord of the Rings.", true, "J.R.R. Tolkien" },
                    { 4, "British writer known for her detective novels, especially those revolving around Hercule Poirot.", true, "Agatha Christie" },
                    { 5, "American author of horror, supernatural fiction, suspense, and fantasy novels.", true, "Stephen King" },
                    { 6, "American writer and professor of biochemistry, known for his works of science fiction.", true, "Isaac Asimov" },
                    { 7, "American writer, humorist, entrepreneur, publisher, and lecturer.", true, "Mark Twain" },
                    { 8, "American journalist, novelist, and short-story writer, won the Nobel Prize in Literature in 1954.", true, "Ernest Hemingway" },
                    { 9, "English novelist known for her six major novels including Pride and Prejudice.", true, "Jane Austen" },
                    { 10, "English writer and social critic, created some of the world’s best-known fictional characters.", true, "Charles Dickens" },
                    { 11, "American novelist, known for The Great Gatsby.", true, "F. Scott Fitzgerald" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "genre_name", "is_active" },
                values: new object[,]
                {
                    { 1, "Fantasy", true },
                    { 2, "Science Fiction", true },
                    { 3, "Mystery", true },
                    { 4, "Thriller", true },
                    { 5, "Romance", true },
                    { 6, "Horror", true },
                    { 7, "Historical Fiction", true },
                    { 8, "Non-Fiction", true },
                    { 9, "Adventure", true },
                    { 10, "Young Adult", true },
                    { 11, "Classics", true },
                    { 12, "Literary Fiction", true },
                    { 13, "Dystopian", true },
                    { 14, "Magical Realism", true },
                    { 15, "Graphic Novel", true },
                    { 16, "Short Stories", true },
                    { 17, "Biography", true },
                    { 18, "Self-Help", true },
                    { 19, "Poetry", true },
                    { 20, "Drama", true }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Description", "GenreId", "ISBN", "ImageURL", "IsActive", "Price", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, "The first book in the Harry Potter series by J.K. Rowling.", 1, "9780590353427", "https://example.com/harry_potter.jpg", true, 19.99m, new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Sorcerer's Stone" },
                    { 2, 2, "The first book in the A Song of Ice and Fire series by George R.R. Martin.", 1, "9780553381689", "https://example.com/game_of_thrones.jpg", true, 25.99m, new DateTime(1996, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Game of Thrones" },
                    { 3, 3, "A novel by Harper Lee published in 1960, instantly successful and has become a classic of modern American literature.", 2, "9780061120084", "https://example.com/to_kill_a_mockingbird.jpg", true, 14.99m, new DateTime(1960, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "To Kill a Mockingbird" },
                    { 4, 4, "A dystopian social science fiction novel and cautionary tale, written by the English writer George Orwell.", 3, "9780451524935", "https://example.com/1984.jpg", true, 15.99m, new DateTime(1949, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "1984" },
                    { 5, 5, "A romantic novel of manners written by Jane Austen in 1813.", 4, "9780141439518", "https://example.com/pride_and_prejudice.jpg", true, 12.99m, new DateTime(1813, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pride and Prejudice" },
                    { 6, 6, "A children's fantasy novel by English author J.R.R. Tolkien.", 1, "9780547928227", "https://example.com/the_hobbit.jpg", true, 18.99m, new DateTime(1937, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Hobbit" },
                    { 7, 7, "A novel by J.D. Salinger, partially published in serial form in 1945-1946 and as a novel in 1951.", 5, "9780316769488", "https://example.com/the_catcher_in_the_rye.jpg", true, 13.99m, new DateTime(1951, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Catcher in the Rye" },
                    { 8, 8, "A 1925 novel written by American author F. Scott Fitzgerald that follows a cast of characters living in the fictional towns of West Egg and East Egg on prosperous Long Island in the summer of 1922.", 5, "9780743273565", "https://example.com/the_great_gatsby.jpg", true, 10.99m, new DateTime(1925, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Great Gatsby" },
                    { 9, 9, "A novel by Herman Melville, in which Ishmael narrates the monomaniacal quest of Ahab, captain of the whaler Pequod, for revenge on Moby Dick.", 6, "9781503280786", "https://example.com/moby_dick.jpg", true, 11.99m, new DateTime(1851, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moby Dick" },
                    { 10, 10, "An epic high-fantasy novel written by English author and scholar J.R.R. Tolkien.", 1, "9780544003415", "https://example.com/the_lord_of_the_rings.jpg", true, 35.99m, new DateTime(1954, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
