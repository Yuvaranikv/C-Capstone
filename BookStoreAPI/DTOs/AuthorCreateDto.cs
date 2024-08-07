using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.DTOs
{
    public class AuthorCreateDto
    {
        [Required]
        public int author_id { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Name { get; set; }

        public string Biography { get; set; }
    }
}
