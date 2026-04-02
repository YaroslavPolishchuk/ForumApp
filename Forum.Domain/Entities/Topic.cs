namespace Forum.Domain.Entities
{
    public class Topic
    {
        public int Id { get; set; }
        public int ForumId { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
