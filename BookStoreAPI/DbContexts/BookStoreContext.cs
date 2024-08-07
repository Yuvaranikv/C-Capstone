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

        public DbSet<authors> Authors { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<books> Books { get; set; }
        public DbSet<userstest> Userstest { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            // Seed data
            modelBuilder.Entity<authors>().HasData(
     new authors { author_id = 1, Name = "J.K. Rowling", Biography = "British author, best known for the Harry Potter series.", IsActive = true, CreatedAt = new DateTime(2024, 8, 5), UpdatedAt = new DateTime(2024, 8, 5) },
     new authors { author_id = 2, Name = "George R.R. Martin", Biography = "American novelist and short story writer, known for A Song of Ice and Fire series.", IsActive = true, CreatedAt = new DateTime(2024, 8, 5), UpdatedAt = new DateTime(2024, 8, 5) },
     new authors { author_id = 3, Name = "J.R.R. Tolkien", Biography = "English writer, poet, and philologist, author of The Lord of the Rings.", IsActive = true, CreatedAt = new DateTime(2024, 8, 5), UpdatedAt = new DateTime(2024, 8, 5) },
     new authors { author_id = 4, Name = "Agatha Christie", Biography = "British writer known for her detective novels, especially those revolving around Hercule Poirot.", IsActive = true, CreatedAt = new DateTime(2024, 8, 5), UpdatedAt = new DateTime(2024, 8, 5) },
     new authors { author_id = 5, Name = "Stephen King", Biography = "American author of horror, supernatural fiction, suspense, and fantasy novels.", IsActive = true, CreatedAt = new DateTime(2024, 8, 5), UpdatedAt = new DateTime(2024, 8, 5) },
     new authors { author_id = 6, Name = "Isaac Asimov", Biography = "American writer and professor of biochemistry, known for his works of science fiction.", IsActive = true, CreatedAt = new DateTime(2024, 8, 5), UpdatedAt = new DateTime(2024, 8, 5) },
     new authors { author_id = 7, Name = "Mark Twain", Biography = "American writer, humorist, entrepreneur, publisher, and lecturer.", IsActive = true, CreatedAt = new DateTime(2024, 8, 5), UpdatedAt = new DateTime(2024, 8, 5) },
     new authors { author_id = 8, Name = "Ernest Hemingway", Biography = "American journalist, novelist, and short-story writer, won the Nobel Prize in Literature in 1954.", IsActive = true, CreatedAt = new DateTime(2024, 8, 5), UpdatedAt = new DateTime(2024, 8, 5) },
     new authors { author_id = 9, Name = "Jane Austen", Biography = "English novelist known for her six major novels including Pride and Prejudice.", IsActive = true, CreatedAt = new DateTime(2024, 8, 5), UpdatedAt = new DateTime(2024, 8, 5) },
     new authors { author_id = 10, Name = "Charles Dickens", Biography = "English writer and social critic, created some of the world’s best-known fictional characters.", IsActive = true, CreatedAt = new DateTime(2024, 8, 5), UpdatedAt = new DateTime(2024, 8, 5) },
     new authors { author_id = 11, Name = "F. Scott Fitzgerald", Biography = "American novelist, known for The Great Gatsby.", IsActive = true, CreatedAt = new DateTime(2024, 8, 5), UpdatedAt = new DateTime(2024, 8, 5) }
 );
            modelBuilder.Entity<Genres>().HasData(
     new Genres { genre_id = 1, genre_name = "Fantasy", isActive = true, createdAt = new DateTime(2024, 8, 5), updatedAt = new DateTime(2024, 8, 5) },
     new Genres { genre_id = 2, genre_name = "Science Fiction", isActive = true, createdAt = new DateTime(2024, 8, 5), updatedAt = new DateTime(2024, 8, 5) },
     new Genres { genre_id = 3, genre_name = "Mystery", isActive = true, createdAt = new DateTime(2024, 8, 5), updatedAt = new DateTime(2024, 8, 5) },
     new Genres { genre_id = 4, genre_name = "Thriller", isActive = true, createdAt = new DateTime(2024, 8, 5), updatedAt = new DateTime(2024, 8, 5) },
     new Genres { genre_id = 5, genre_name = "Romance", isActive = true, createdAt = new DateTime(2024, 8, 5), updatedAt = new DateTime(2024, 8, 5) },
     new Genres { genre_id = 6, genre_name = "Horror", isActive = true, createdAt = new DateTime(2024, 8, 5), updatedAt = new DateTime(2024, 8, 5) },
     new Genres { genre_id = 7, genre_name = "Historical Fiction", isActive = true, createdAt = new DateTime(2024, 8, 5), updatedAt = new DateTime(2024, 8, 5) },
     new Genres { genre_id = 8, genre_name = "Non-Fiction", isActive = true, createdAt = new DateTime(2024, 8, 5), updatedAt = new DateTime(2024, 8, 5) },
     new Genres { genre_id = 9, genre_name = "Adventure", isActive = true, createdAt = new DateTime(2024, 8, 5), updatedAt = new DateTime(2024, 8, 5) },
     new Genres { genre_id = 10, genre_name = "Young Adult", isActive = true, createdAt = new DateTime(2024, 8, 5), updatedAt = new DateTime(2024, 8, 5) },
     new Genres { genre_id = 11, genre_name = "Classics", isActive = true, createdAt = new DateTime(2024, 8, 5), updatedAt = new DateTime(2024, 8, 5) },
     new Genres { genre_id = 12, genre_name = "Literary Fiction", isActive = true, createdAt = new DateTime(2024, 8, 5), updatedAt = new DateTime(2024, 8, 5) },
     new Genres { genre_id = 13, genre_name = "Dystopian", isActive = true, createdAt = new DateTime(2024, 8, 5), updatedAt = new DateTime(2024, 8, 5) },
     new Genres { genre_id = 14, genre_name = "Magical Realism", isActive = true, createdAt = new DateTime(2024, 8, 5), updatedAt = new DateTime(2024, 8, 5) },
     new Genres { genre_id = 15, genre_name = "Graphic Novel", isActive = true, createdAt = new DateTime(2024, 8, 5), updatedAt = new DateTime(2024, 8, 5) },
     new Genres { genre_id = 16, genre_name = "Short Stories", isActive = true, createdAt = new DateTime(2024, 8, 5), updatedAt = new DateTime(2024, 8, 5) },
     new Genres { genre_id = 17, genre_name = "Biography", isActive = true, createdAt = new DateTime(2024, 8, 5), updatedAt = new DateTime(2024, 8, 5) },
     new Genres { genre_id = 18, genre_name = "Self-Help", isActive = true, createdAt = new DateTime(2024, 8, 5), updatedAt = new DateTime(2024, 8, 5) },
     new Genres { genre_id = 19, genre_name = "Poetry", isActive = true, createdAt = new DateTime(2024, 8, 5), updatedAt = new DateTime(2024, 8, 5) },
     new Genres { genre_id = 20, genre_name = "Drama", isActive = true, createdAt = new DateTime(2024, 8, 5), updatedAt = new DateTime(2024, 8, 5) }
 );

            modelBuilder.Entity<books>().HasData(
      new books
      {
          book_id = 1,
          title = "Harry Potter and the Sorcerer's Stone",
          author_id = 1,
          genre_id = 1,
          price = 19.99M,
          publication_date = new DateTime(1997, 6, 26),
          ISBN = "9780590353427",
          imageURL = "https://example.com/harry_potter.jpg",
          description = "The first book in the Harry Potter series by J.K. Rowling.",
          createdAt = new DateTime(2024, 8, 5),
          updatedAt = new DateTime(2024, 8, 5),
          isActive = true
      },
      new books
      {
          book_id = 2,
          title = "A Game of Thrones",
          author_id = 2,
          genre_id = 1,
          price = 25.99M,
          publication_date = new DateTime(1996, 8, 6),
          ISBN = "9780553381689",
          imageURL = "https://example.com/game_of_thrones.jpg",
          description = "The first book in the A Song of Ice and Fire series by George R.R. Martin.",
          createdAt = new DateTime(2024, 8, 5),
          updatedAt = new DateTime(2024, 8, 5),
          isActive = true
      },
      new books
      {
          book_id = 3,
          title = "To Kill a Mockingbird",
          author_id = 3,
          genre_id = 2,
          price = 14.99M,
          publication_date = new DateTime(1960, 7, 11),
          ISBN = "9780061120084",
          imageURL = "https://example.com/to_kill_a_mockingbird.jpg",
          description = "A novel by Harper Lee published in 1960, instantly successful and has become a classic of modern American literature.",
          createdAt = new DateTime(2024, 8, 5),
          updatedAt = new DateTime(2024, 8, 5),
          isActive = true
      },
      new books
      {
          book_id = 4,
          title = "1984",
          author_id = 4,
          genre_id = 3,
          price = 15.99M,
          publication_date = new DateTime(1949, 6, 8),
          ISBN = "9780451524935",
          imageURL = "https://example.com/1984.jpg",
          description = "A dystopian social science fiction novel and cautionary tale, written by the English writer George Orwell.",
          createdAt = new DateTime(2024, 8, 5),
          updatedAt = new DateTime(2024, 8, 5),
          isActive = true
      },
      new books
      {
          book_id = 5,
          title = "Pride and Prejudice",
          author_id = 5,
          genre_id = 4,
          price = 12.99M,
          publication_date = new DateTime(1813, 1, 28),
          ISBN = "9780141439518",
          imageURL = "https://example.com/pride_and_prejudice.jpg",
          description = "A romantic novel of manners written by Jane Austen in 1813.",
          createdAt = new DateTime(2024, 8, 5),
          updatedAt = new DateTime(2024, 8, 5),
          isActive = true
      },
      new books
      {
          book_id = 6,
          title = "The Hobbit",
          author_id = 6,
          genre_id = 1,
          price = 18.99M,
          publication_date = new DateTime(1937, 9, 21),
          ISBN = "9780547928227",
          imageURL = "https://example.com/the_hobbit.jpg",
          description = "A children's fantasy novel by English author J.R.R. Tolkien.",
          createdAt = new DateTime(2024, 8, 5),
          updatedAt = new DateTime(2024, 8, 5),
          isActive = true
      },
      new books
      {
          book_id = 7,
          title = "The Catcher in the Rye",
          author_id = 7,
          genre_id = 5,
          price = 13.99M,
          publication_date = new DateTime(1951, 7, 16),
          ISBN = "9780316769488",
          imageURL = "https://example.com/the_catcher_in_the_rye.jpg",
          description = "A novel by J.D. Salinger, partially published in serial form in 1945-1946 and as a novel in 1951.",
          createdAt = new DateTime(2024, 8, 5),
          updatedAt = new DateTime(2024, 8, 5),
          isActive = true
      },
      new books
      {
          book_id = 8,
          title = "The Great Gatsby",
          author_id = 8,
          genre_id = 5,
          price = 10.99M,
          publication_date = new DateTime(1925, 4, 10),
          ISBN = "9780743273565",
          imageURL = "https://example.com/the_great_gatsby.jpg",
          description = "A 1925 novel written by American author F. Scott Fitzgerald that follows a cast of characters living in the fictional towns of West Egg and East Egg on prosperous Long Island in the summer of 1922.",
          createdAt = new DateTime(2024, 8, 5),
          updatedAt = new DateTime(2024, 8, 5),
          isActive = true
      },
      new books
      {
          book_id = 9,
          title = "Moby Dick",
          author_id = 9,
          genre_id = 6,
          price = 11.99M,
          publication_date = new DateTime(1851, 10, 18),
          ISBN = "9781503280786",
          imageURL = "https://example.com/moby_dick.jpg",
          description = "A novel by Herman Melville, in which Ishmael narrates the monomaniacal quest of Ahab, captain of the whaler Pequod, for revenge on Moby Dick.",
          createdAt = new DateTime(2024, 8, 5),
          updatedAt = new DateTime(2024, 8, 5),
          isActive = true
      },
      new books
      {
          book_id = 10,
          title = "The Lord of the Rings",
          author_id = 10,
          genre_id = 1,
          price = 35.99M,
          publication_date = new DateTime(1954, 7, 29),
          ISBN = "9780544003415",
          imageURL = "https://example.com/the_lord_of_the_rings.jpg",
          description = "An epic high-fantasy novel written by English author and scholar J.R.R. Tolkien.",
          createdAt = new DateTime(2024, 8, 5),
          updatedAt = new DateTime(2024, 8, 5),
          isActive = true
      }
  );

            modelBuilder.Entity<userstest>().HasData(
                new userstest
                {
                    Id = 1,
                    Username = "shreena",
                    Password = "admin123",
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 8, 5, 11, 4, 5),
                    UpdatedAt = new DateTime(2024, 8, 5, 11, 4, 5)
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}