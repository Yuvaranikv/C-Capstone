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
                    author_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.author_id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    genreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    genre_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.genreId);
                });

            migrationBuilder.CreateTable(
                name: "Userstest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userstest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    book_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    author_id = table.Column<int>(type: "int", nullable: false),
                    genre_id = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    publication_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    imageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.book_id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_author_id",
                        column: x => x.author_id,
                        principalTable: "Authors",
                        principalColumn: "author_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Genres_genre_id",
                        column: x => x.genre_id,
                        principalTable: "Genres",
                        principalColumn: "genreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "author_id", "Biography", "CreatedAt", "IsActive", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "British author, best known for the Harry Potter series.", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "J.K. Rowling", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "American novelist and short story writer, known for A Song of Ice and Fire series.", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "George R.R. Martin", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "English writer, poet, and philologist, author of The Lord of the Rings.", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "J.R.R. Tolkien", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "British writer known for her detective novels, especially those revolving around Hercule Poirot.", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Agatha Christie", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "American author of horror, supernatural fiction, suspense, and fantasy novels.", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Stephen King", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "American writer and professor of biochemistry, known for his works of science fiction.", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Isaac Asimov", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "American writer, humorist, entrepreneur, publisher, and lecturer.", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Mark Twain", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "American journalist, novelist, and short-story writer, won the Nobel Prize in Literature in 1954.", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Ernest Hemingway", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "English novelist known for her six major novels including Pride and Prejudice.", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Jane Austen", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "English writer and social critic, created some of the world’s best-known fictional characters.", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Charles Dickens", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "American novelist, known for The Great Gatsby.", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "F. Scott Fitzgerald", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "genreId", "created_at", "genre_name", "is_active", "updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fantasy", true, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Science Fiction", true, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mystery", true, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thriller", true, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Romance", true, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Horror", true, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Historical Fiction", true, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Non-Fiction", true, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adventure", true, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Young Adult", true, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Classics", true, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Literary Fiction", true, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dystopian", true, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Magical Realism", true, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Graphic Novel", true, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Short Stories", true, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Biography", true, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Self-Help", true, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poetry", true, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Drama", true, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Userstest",
                columns: new[] { "Id", "CreatedAt", "IsActive", "Password", "UpdatedAt", "Username" },
                values: new object[] { 1, new DateTime(2024, 8, 5, 11, 4, 5, 0, DateTimeKind.Unspecified), true, "admin123", new DateTime(2024, 8, 5, 11, 4, 5, 0, DateTimeKind.Unspecified), "shreena" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "book_id", "ISBN", "author_id", "createdAt", "description", "genre_id", "imageURL", "isActive", "price", "publication_date", "title", "updatedAt" },
                values: new object[,]
                {
                    { 1, "9780590353427", 1, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "The first book in the Harry Potter series by J.K. Rowling.", 1, "https://example.com/harry_potter.jpg", true, 19.99m, new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Sorcerer's Stone", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "9780553381689", 2, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "The first book in the A Song of Ice and Fire series by George R.R. Martin.", 1, "https://example.com/game_of_thrones.jpg", true, 25.99m, new DateTime(1996, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Game of Thrones", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "9780061120084", 3, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "A novel by Harper Lee published in 1960, instantly successful and has become a classic of modern American literature.", 2, "https://example.com/to_kill_a_mockingbird.jpg", true, 14.99m, new DateTime(1960, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "To Kill a Mockingbird", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "9780451524935", 4, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "A dystopian social science fiction novel and cautionary tale, written by the English writer George Orwell.", 3, "https://example.com/1984.jpg", true, 15.99m, new DateTime(1949, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "1984", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "9780141439518", 5, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "A romantic novel of manners written by Jane Austen in 1813.", 4, "https://example.com/pride_and_prejudice.jpg", true, 12.99m, new DateTime(1813, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pride and Prejudice", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "9780547928227", 6, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "A children's fantasy novel by English author J.R.R. Tolkien.", 1, "https://example.com/the_hobbit.jpg", true, 18.99m, new DateTime(1937, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Hobbit", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "9780316769488", 7, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "A novel by J.D. Salinger, partially published in serial form in 1945-1946 and as a novel in 1951.", 5, "https://example.com/the_catcher_in_the_rye.jpg", true, 13.99m, new DateTime(1951, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Catcher in the Rye", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "9780743273565", 8, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "A 1925 novel written by American author F. Scott Fitzgerald that follows a cast of characters living in the fictional towns of West Egg and East Egg on prosperous Long Island in the summer of 1922.", 5, "https://example.com/the_great_gatsby.jpg", true, 10.99m, new DateTime(1925, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Great Gatsby", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "9781503280786", 9, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "A novel by Herman Melville, in which Ishmael narrates the monomaniacal quest of Ahab, captain of the whaler Pequod, for revenge on Moby Dick.", 6, "https://example.com/moby_dick.jpg", true, 11.99m, new DateTime(1851, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moby Dick", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "9780544003415", 10, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "An epic high-fantasy novel written by English author and scholar J.R.R. Tolkien.", 1, "https://example.com/the_lord_of_the_rings.jpg", true, 35.99m, new DateTime(1954, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_author_id",
                table: "Books",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_Books_genre_id",
                table: "Books",
                column: "genre_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Userstest");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
