using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreAPI.Models
{
    /// <summary>
    /// Represents an author in the bookstore.
    /// </summary>
    public class authors
    {
        /// <summary>
        /// Gets or sets the unique identifier for the author.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("author_id")]
        public int author_id { get; set; }

        /// <summary>
        /// Gets or sets the name of the author.
        /// </summary>
        /// <remarks>
        /// This field is required and has a maximum length of 255 characters.
        /// </remarks>
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the biography of the author.
        /// </summary>
        /// <remarks>
        /// This field is optional.
        /// </remarks>
        public string Biography { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the author is active.
        /// </summary>
        /// <remarks>
        /// This field is required and defaults to true.
        /// </remarks>
        [Required]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Gets or sets the date and time when the author was created.
        /// </summary>
        /// <remarks>
        /// This field is automatically set to the current date and time when the author is created.
        /// </remarks>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the author was last updated.
        /// </summary>
        /// <remarks>
        /// This field is automatically updated to the current date and time when the author is modified.
        /// </remarks>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Navigation property for the books associated with the author.
        /// </summary>
        /// <remarks>
        /// This property represents a collection of books written by the author.
        /// </remarks>
        public ICollection<books> Books { get; set; }

    }
}
