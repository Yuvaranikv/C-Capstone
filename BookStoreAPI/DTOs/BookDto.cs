using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.DTOs
{
    public class BookDto
    {
        [Required]
        public int book_id { get; set; } // Maps to `books.book_id`

        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string title { get; set; } // Maps to `books.title`

        [Required]
        public int author_id { get; set; } // Maps to `books.author_id`

        [Required]
        public int genre_id { get; set; } // Maps to `books.genre_id`

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        public decimal price { get; set; } // Maps to `books.price`

        public DateTime? publication_date { get; set; } // Maps to `books.publication_date`

        [StringLength(20)]
        public string ISBN { get; set; } // Maps to `books.ISBN`

        public string imageURL { get; set; } // Maps to `books.imageURL`

        public string description { get; set; } // Maps to `books.description`

        [Required]
        public bool isActive { get; set; } // Maps to `books.isActive`

        [Required]
        public DateTime createdAt { get; set; } // Maps to `books.createdAt`

        [Required]
        public DateTime updatedAt { get; set; } // Maps to `books.updatedAt`
        public AuthorCreateDto Author { get; set; }
        public GenreCreateDto Genre { get; set; }

    }
}
