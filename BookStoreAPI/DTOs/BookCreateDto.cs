using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.DTOs
{
    public class BookCreateDto
    {
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        public decimal Price { get; set; }

        public DateTime? PublicationDate { get; set; }

        [StringLength(20)]
        public string ISBN { get; set; }

        public string ImageURL { get; set; }

        public string Description { get; set; }
    }
}
