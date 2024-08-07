using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.Models
{
    public class books
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int book_id { get; set; } // Matches books.book_id

        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string title { get; set; } // Matches books.title

        [ForeignKey("Author")]
        public int author_id { get; set; } // Matches books.author_id

        [ForeignKey("Genres")]
        public int genre_id { get; set; } // Matches books.genre_id

        [Column(TypeName = "decimal(10, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        public decimal price { get; set; } // Matches books.price

        public DateTime? publication_date { get; set; } // Matches books.publication_date

        [StringLength(20)]
        public string ISBN { get; set; } // Matches books.ISBN

        public string imageURL { get; set; } // Matches books.imageURL

        public string description { get; set; } // Matches books.description

        [Required]
        public bool isActive { get; set; } = true; // Matches books.isActive

        public DateTime createdAt { get; set; } // Matches books.createdAt

        public DateTime updatedAt { get; set; } // Matches books.updatedAt

        // Navigation properties
        public authors Author { get; set; }
        public Genres Genres { get; set; }
    }
}
