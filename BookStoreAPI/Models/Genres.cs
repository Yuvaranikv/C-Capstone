using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookStoreAPI.Models
{
    public class Genres
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("genre_id")]
        public int genre_id { get; set; }

        [Required]
        [Column("genre_name")]
        public string genre_name { get; set; }

        [Required]
        [Column("isActive")]
        public bool isActive { get; set; } = true;

        [Column("createdAt")]
        public DateTime createdAt { get; set; }

        [Column("updatedAt")]
        public DateTime updatedAt { get; set; }

        // Navigation property
        public ICollection<books> Books { get; set; }
    }
}
