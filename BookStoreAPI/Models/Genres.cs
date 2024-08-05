using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.Models
{
    public class Genres
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenreId { get; set; }

        [Required]
        [Column("genre_name")]
        public string GenreName { get; set; }

        [Required]
        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        // Navigation property
        public ICollection<Book> Books { get; set; }
    }
}
