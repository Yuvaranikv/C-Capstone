namespace BookStoreAPI.Models
{
    public class User
    {
        public int Id { get; set; } // Assuming Id is the primary key
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = true; // Default value
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
