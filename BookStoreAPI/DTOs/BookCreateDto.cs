using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.DTOs
{
    public class BookCreateDto
    {
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string title { get; set; }

        [Required]
        public int author_id { get; set; }

        [Required]
        public int genre_id { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        public decimal price { get; set; }

        public DateTime? publication_date { get; set; }

        [StringLength(20)]
        public string ISBN { get; set; }

        public string imageURL { get; set; }

        public string description { get; set; }
    }
}
