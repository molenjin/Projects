using BlazorForum.Data;
using BlazorForum.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlazorForum.Libraries
{
    public class LibValidate(IDatabaseCalls DatabaseCalls)
    {
        public async Task<string> ValidateCommentAsync(Comment comment)
        {
            //------ Banned IP            
            if (await DatabaseCalls.IsBannedIpAsync(comment.IP))
                return "You are not allowed to post on this forum";          

            //------ If not new topic and TopicExists(TopicID) = FALSE
            if ((!IsNewTopic(comment.TopicId)) && !(await DatabaseCalls.TopicExistsAsync(comment.TopicId)))
                return "SYSTEM ERROR: TopicID not found among existing topics";

            //------ If Name length = 0
            if (string.IsNullOrEmpty(comment.Name.Trim()))
                return "User name is missing";

            //------ If new topic and Title length = 0
            if (IsNewTopic(comment.TopicId) && string.IsNullOrEmpty(comment.Title.Trim()))
                return "Topic title is missing";

            //------ If not new topic and Title length > 0
            if (!IsNewTopic(comment.TopicId) && !string.IsNullOrEmpty(comment.Title.Trim()))
                return "SYSTEM ERROR: Title not allowed for comments";

            //------ If Text length = 0
            if (string.IsNullOrEmpty(comment.Text.Trim()))
                return "Comment text is missing";

            //------ UserName min length (2)
            if (comment.Name.Length < 2)
                return "User name is too short (min. 2 characters required)";

            //------ UserName max length (20)
            if (comment.Name.Length > 20)
                return "User name is too long (max. 20 characters allowed)";

            //------ Title min length (2)
            if ((IsNewTopic(comment.TopicId) && comment.Title.Length < 2))
                return "Topic title is too short (min. 2 characters required)";

            //------ Title max length (60)
            if (comment.Title.Length > 60)
                return "Topic title is too long (max. 60 characters allowed)";

            //------ Text min length (2)
            if (comment.Text.Length < 2)
                return "Comment text is too short (min. 2 characters allowed)";

            //------ Text max length (5000)
            if (comment.Text.Length > 5000)
                return "Comment text is too long (max. 5000 characters allowed)";

            //------ Invalid characters in UserName
            if (!IsValidString(comment.Name))
                return "User name contains invalid characters";

            //------ Invalid characters in Title
            if (!IsValidString(comment.Title))
                return "Topic title contains invalid characters";

            //------ Invalid characters in Text
            if (!IsValidString(comment.Text))
                return "Comment text contains invalid characters";

            //------ Improper content in UserName
            if (IsImproperContent(comment.Name))
                return "User name contains improper content";

            //------ Improper content in Title
            if (IsImproperContent(comment.Title))
                return "Topic title contains improper content";

            //------ Improper content in Text
            if (IsImproperContent(comment.Text))
                 return "Comment text contains improper content";

            return string.Empty;
        }

        private static bool IsValidString(string content)
        {
            return System.Text.RegularExpressions.Regex.Matches(content, "/[^A-Za-z0-9.,?!<>@#?/+_$%&*|~`:;(){}[]]/").Count == 0;
        }

        private static bool IsImproperContent(string content)
        {
            string[] words = { "olenjin", "miroslav", "viagra", "cialis", "fuck", "shit", "bitch", "jerk" };
            return words.Any(word => content.ToLower().Contains(word));
        }

        private static bool IsNewTopic(int topicId)
        {
            return (topicId == 0);
        }
    }
}
