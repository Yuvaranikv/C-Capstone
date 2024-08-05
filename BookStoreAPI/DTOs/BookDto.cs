namespace BookStoreAPI.DTOs
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string GenreName { get; set; }
        public decimal Price { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string ISBN { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
