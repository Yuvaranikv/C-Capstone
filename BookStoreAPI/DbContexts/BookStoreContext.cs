using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreAPI.DbContexts
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            // Seed data
            modelBuilder.Entity<Author>().HasData(
                 new Author { AuthorId = 1, Name = "J.K. Rowling", Biography = "British author, best known for the Harry Potter series.", IsActive = true },
                 new Author { AuthorId = 2, Name = "George R.R. Martin", Biography = "American novelist and short story writer, known for A Song of Ice and Fire series.", IsActive = true },
                 new Author { AuthorId = 3, Name = "J.R.R. Tolkien", Biography = "English writer, poet, and philologist, author of The Lord of the Rings.", IsActive = true },
                 new Author { AuthorId = 4, Name = "Agatha Christie", Biography = "British writer known for her detective novels, especially those revolving around Hercule Poirot.", IsActive = true },
                 new Author { AuthorId = 5, Name = "Stephen King", Biography = "American author of horror, supernatural fiction, suspense, and fantasy novels.", IsActive = true },
                 new Author { AuthorId = 6, Name = "Isaac Asimov", Biography = "American writer and professor of biochemistry, known for his works of science fiction.", IsActive = true },
                 new Author { AuthorId = 7, Name = "Mark Twain", Biography = "American writer, humorist, entrepreneur, publisher, and lecturer.", IsActive = true },
                 new Author { AuthorId = 8, Name = "Ernest Hemingway", Biography = "American journalist, novelist, and short-story writer, won the Nobel Prize in Literature in 1954.", IsActive = true },
                 new Author { AuthorId = 9, Name = "Jane Austen", Biography = "English novelist known for her six major novels including Pride and Prejudice.", IsActive = true },
                 new Author { AuthorId = 10, Name = "Charles Dickens", Biography = "English writer and social critic, created some of the world’s best-known fictional characters.", IsActive = true },
                 new Author { AuthorId = 11, Name = "F. Scott Fitzgerald", Biography = "American novelist, known for The Great Gatsby.", IsActive = true }
             );

            modelBuilder.Entity<Genres>().HasData(
                new Genres { GenreId = 1, GenreName = "Fantasy", IsActive = true },
                new Genres { GenreId = 2, GenreName = "Science Fiction", IsActive = true },
                new Genres { GenreId = 3, GenreName = "Mystery", IsActive = true },
                new Genres { GenreId = 4, GenreName = "Thriller", IsActive = true },
                new Genres { GenreId = 5, GenreName = "Romance", IsActive = true },
                new Genres { GenreId = 6, GenreName = "Horror", IsActive = true },
                new Genres { GenreId = 7, GenreName = "Historical Fiction", IsActive = true },
                new Genres { GenreId = 8, GenreName = "Non-Fiction", IsActive = true },
                new Genres { GenreId = 9, GenreName = "Adventure", IsActive = true },
                new Genres { GenreId = 10, GenreName = "Young Adult", IsActive = true },
                new Genres { GenreId = 11, GenreName = "Classics", IsActive = true },
                new Genres { GenreId = 12, GenreName = "Literary Fiction", IsActive = true },
                new Genres { GenreId = 13, GenreName = "Dystopian", IsActive = true },
                new Genres { GenreId = 14, GenreName = "Magical Realism", IsActive = true },
                new Genres { GenreId = 15, GenreName = "Graphic Novel", IsActive = true },
                new Genres { GenreId = 16, GenreName = "Short Stories", IsActive = true },
                new Genres { GenreId = 17, GenreName = "Biography", IsActive = true },
                new Genres { GenreId = 18, GenreName = "Self-Help", IsActive = true },
                new Genres { GenreId = 19, GenreName = "Poetry", IsActive = true },
                new Genres { GenreId = 20, GenreName = "Drama", IsActive = true }
            );
            modelBuilder.Entity<Book>().HasData(
               new Book { BookId = 1, Title = "Harry Potter and the Sorcerer's Stone", AuthorId = 1, GenreId = 1, Price = 19.99M, PublicationDate = new DateTime(1997, 6, 26), ISBN = "9780590353427", ImageURL = "https://example.com/harry_potter.jpg", Description = "The first book in the Harry Potter series by J.K. Rowling." },
               new Book { BookId = 2, Title = "A Game of Thrones", AuthorId = 2, GenreId = 1, Price = 25.99M, PublicationDate = new DateTime(1996, 8, 6), ISBN = "9780553381689", ImageURL = "https://example.com/game_of_thrones.jpg", Description = "The first book in the A Song of Ice and Fire series by George R.R. Martin." },
               new Book { BookId = 3, Title = "To Kill a Mockingbird", AuthorId = 3, GenreId = 2, Price = 14.99M, PublicationDate = new DateTime(1960, 7, 11), ISBN = "9780061120084", ImageURL = "https://example.com/to_kill_a_mockingbird.jpg", Description = "A novel by Harper Lee published in 1960, instantly successful and has become a classic of modern American literature." },
               new Book { BookId = 4, Title = "1984", AuthorId = 4, GenreId = 3, Price = 15.99M, PublicationDate = new DateTime(1949, 6, 8), ISBN = "9780451524935", ImageURL = "https://example.com/1984.jpg", Description = "A dystopian social science fiction novel and cautionary tale, written by the English writer George Orwell." },
               new Book { BookId = 5, Title = "Pride and Prejudice", AuthorId = 5, GenreId = 4, Price = 12.99M, PublicationDate = new DateTime(1813, 1, 28), ISBN = "9780141439518", ImageURL = "https://example.com/pride_and_prejudice.jpg", Description = "A romantic novel of manners written by Jane Austen in 1813." },
               new Book { BookId = 6, Title = "The Hobbit", AuthorId = 6, GenreId = 1, Price = 18.99M, PublicationDate = new DateTime(1937, 9, 21), ISBN = "9780547928227", ImageURL = "https://example.com/the_hobbit.jpg", Description = "A children's fantasy novel by English author J.R.R. Tolkien." },
               new Book { BookId = 7, Title = "The Catcher in the Rye", AuthorId = 7, GenreId = 5, Price = 13.99M, PublicationDate = new DateTime(1951, 7, 16), ISBN = "9780316769488", ImageURL = "https://example.com/the_catcher_in_the_rye.jpg", Description = "A novel by J.D. Salinger, partially published in serial form in 1945-1946 and as a novel in 1951." },
               new Book { BookId = 8, Title = "The Great Gatsby", AuthorId = 8, GenreId = 5, Price = 10.99M, PublicationDate = new DateTime(1925, 4, 10), ISBN = "9780743273565", ImageURL = "https://example.com/the_great_gatsby.jpg", Description = "A 1925 novel written by American author F. Scott Fitzgerald that follows a cast of characters living in the fictional towns of West Egg and East Egg on prosperous Long Island in the summer of 1922." },
               new Book { BookId = 9, Title = "Moby Dick", AuthorId = 9, GenreId = 6, Price = 11.99M, PublicationDate = new DateTime(1851, 10, 18), ISBN = "9781503280786", ImageURL = "https://example.com/moby_dick.jpg", Description = "A novel by Herman Melville, in which Ishmael narrates the monomaniacal quest of Ahab, captain of the whaler Pequod, for revenge on Moby Dick." },
               new Book { BookId = 10, Title = "The Lord of the Rings", AuthorId = 10, GenreId = 1, Price = 35.99M, PublicationDate = new DateTime(1954, 7, 29), ISBN = "9780544003415", ImageURL = "https://example.com/the_lord_of_the_rings.jpg", Description = "An epic high-fantasy novel written by English author and scholar J.R.R. Tolkien." }
           );
            base.OnModelCreating(modelBuilder);
        }
    }
}