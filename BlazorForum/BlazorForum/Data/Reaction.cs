namespace BlazorForum.Data
{
    public class Reaction
    {
        public char Type { get; set; }
        public int CommentId { get; set; }
        public string Ip { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
