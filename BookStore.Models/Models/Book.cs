namespace BookStore.Models.Models
{
    public record Book
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public int AuthorId { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
