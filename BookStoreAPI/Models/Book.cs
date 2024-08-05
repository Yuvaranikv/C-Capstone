using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Title { get; set; }

        [ForeignKey("Author")]
        public int? AuthorId { get; set; }

        [ForeignKey("Genres")]
        public int? GenreId { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        public decimal? Price { get; set; }

        public DateTime? PublicationDate { get; set; }

        [StringLength(20)]
        public string ISBN { get; set; }

        public string ImageURL { get; set; }

        public string Description { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public Author Author { get; set; }
        public Genres Genres { get; set; }
    }
}
