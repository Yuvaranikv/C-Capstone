using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.Models
{
    /// <summary>
    /// Represents a user in the system.
    /// </summary>
    public class userstest
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        [Required]
        [StringLength(255, MinimumLength = 1)] // Adjust length as needed based on security requirements
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user is active.
        /// </summary>
        [Required]
        public bool IsActive { get; set; } = true; // Default value is true

        /// <summary>
        /// Gets or sets the date and time when the user was created.
        /// </summary>
        [Required]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the user was last updated.
        /// </summary>
        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}
