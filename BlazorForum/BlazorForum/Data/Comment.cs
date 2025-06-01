namespace BlazorForum.Data
{
    public class Comment
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Text { get; set; } = String.Empty;
        public int UserId { get; set; }
        public string Name { get; set; } = String.Empty;
        public string CountryCode { get; set; } = String.Empty;
        public string IP { get; set; } = String.Empty;
        public bool Active { get; set; }
        public bool Moderator { get; set; }
        public bool Hidden { get; set; }
        public bool Closed { get; set; }
        public int Views { get; set; }
    }
}
