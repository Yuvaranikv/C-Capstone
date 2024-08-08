using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookStoreAPI.Models
{
    public class Genres
    {
        /// <summary>
        /// Gets or sets the unique identifier for the genre.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("genre_id")]
        public int genre_id { get; set; }

        /// <summary>
        /// Gets or sets the name of the genre.
        /// </summary>
        /// <value>
        /// The name of the genre.
        /// </value>
        [Required]
        [Column("genre_name")]
        public string genre_name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the genre is active.
        /// </summary>
        /// <value>
        /// <c>true</c> if the genre is active; otherwise, <c>false</c>.
        /// </value>
        [Required]
        [Column("isActive")]
        public bool isActive { get; set; } = true;

        /// <summary>
        /// Gets or sets the date and time when the genre was created.
        /// </summary>
        /// <value>
        /// The date and time of genre creation.
        /// </value>
        [Column("createdAt")]
        public DateTime createdAt { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the genre was last updated.
        /// </summary>
        /// <value>
        /// The date and time of the last update to the genre.
        /// </value>
        [Column("updatedAt")]
        public DateTime updatedAt { get; set; }

        /// <summary>
        /// Gets or sets the collection of books associated with this genre.
        /// </summary>
        /// <value>
        /// The collection of books belonging to the genre.
        /// </value>
        public ICollection<books> Books { get; set; }
    }
}
