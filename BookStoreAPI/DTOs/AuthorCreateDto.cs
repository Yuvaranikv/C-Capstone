using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.DTOs
{
    public class AuthorCreateDto
    {
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Name { get; set; }

        public string Biography { get; set; }
    }
}
