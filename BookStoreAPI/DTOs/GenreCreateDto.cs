using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.DTOs
{
    public class GenreCreateDto
    {
        [Required]
        [StringLength(100)]
        public string GenreName { get; set; }
    }
}
