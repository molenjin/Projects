namespace BlazorForum.Libraries
{
    public class LibValidate
    {
        public static bool IsImproperContent(string content)
        {
            string[] words = { "olenjin", "miroslav", "viagra", "cialis", "fuck", "shit", "bitch", "jerk" };
            return words.Any(word => content.ToLower().Contains(word));
        }
    }
}
