namespace BlazorForum.Data
{
    public class Comment
    {
        public int Id { get; set; }
        public int? TopicId { get; set; } = null;
        public string? Title { get; set; } = null;
        public string Text { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
        public bool Active { get; set; }
        public bool Moderator { get; set; }
        public bool Hidden { get; set; }
        public bool Closed { get; set; }
        public int Views { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
