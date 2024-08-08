using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.Models
{
    /// <summary>
    /// Represents a book in the bookstore.
    /// </summary>
    public class books
    {
        /// <summary>
        /// Gets or sets the unique identifier for the book.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int book_id { get; set; } // Matches books.book_id

        /// <summary>
        /// Gets or sets the title of the book.
        /// </summary>
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string title { get; set; } // Matches books.title

        /// <summary>
        /// Gets or sets the identifier for the author of the book.
        /// </summary>
        [ForeignKey("Author")]
        public int author_id { get; set; } // Matches books.author_id

        /// <summary>
        /// Gets or sets the identifier for the genre of the book.
        /// </summary>
        [ForeignKey("Genres")]
        public int genre_id { get; set; }

        /// <summary>
        /// Gets or sets the price of the book.
        /// </summary>
        [Column(TypeName = "decimal(10, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        public decimal price { get; set; } 

        /// <summary>
        /// Gets or sets the publication date of the book.
        /// </summary>
        public DateTime? publication_date { get; set; } 

        /// <summary>
        /// Gets or sets the ISBN number of the book.
        /// </summary>
        [StringLength(20)]
        public string ISBN { get; set; } 

        /// <summary>
        /// Gets or sets the URL of the book's cover image.
        /// </summary>
        public string imageURL { get; set; } 

        /// <summary>
        /// Gets or sets the description of the book.
        /// </summary>
        public string description { get; set; } 

        /// <summary>
        /// Gets or sets the status indicating whether the book is active.
        /// </summary>
        [Required]
        public bool isActive { get; set; } = true; 

        /// <summary>
        /// Gets or sets the date and time when the book was created.
        /// </summary>
        public DateTime createdAt { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the book was last updated.
        /// </summary>
        public DateTime updatedAt { get; set; } 

        // Navigation properties
        /// <summary>
        /// Navigation property for the author of the book.
        /// </summary>
        public authors Author { get; set; }

        /// <summary>
        /// Navigation property for the genre of the book.
        /// </summary>
        public Genres Genres { get; set; }
    }
}