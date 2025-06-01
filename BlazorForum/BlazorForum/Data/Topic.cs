namespace BlazorForum.Data
{
    public class Topic
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
        public bool Active { get; set; }
        public bool Moderator { get; set; }
        public bool Hidden { get; set; }
        public int NumOfComments { get; set; }
    }
}