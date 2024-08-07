using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.DTOs
{
    public class GenreCreateDto
    {
        [Required]
        public int genre_id { get; set; }

        [Required]
        [StringLength(100)]
        public string genre_name { get; set; }
    }
}
