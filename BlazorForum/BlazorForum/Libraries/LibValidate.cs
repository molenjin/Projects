using BlazorForum.Data;
using BlazorForum.Database;

namespace BlazorForum.Libraries
{
    public class LibValidate(IDatabaseCalls DatabaseCalls)
    {
        public async Task<(bool, string)> IsCommentValidAsync(Comment comment)
        {
            //------ If comment is null
            if (comment == null)
                throw new ArgumentNullException("Comment cannot be null");

            //------ If not new topic and Title length > 0
            if (!IsNewTopic(comment.TopicId) && !string.IsNullOrWhiteSpace(comment.Title))
                throw new Exception("Title not allowed for comments");

            //------ If not new topic and TopicExists(TopicID) = FALSE
            if ((!IsNewTopic(comment.TopicId)) && !(await DatabaseCalls.TopicExistsAsync(comment.TopicId ?? 0)))
                throw new Exception("TopicID not found among existing topics");

            //------ Banned IP            
            if (await DatabaseCalls.IsBannedIpAsync(comment.IP))
                return (false, "You are not allowed to post on this forum");

            //------ If Name length = 0
            if (string.IsNullOrWhiteSpace(comment.Name))
                return (false, "User name is missing");

            //------ Name min length (2)
            if (comment.Name.Length < 2)
                return (false, "User name is too short (min. 2 characters required)");

            //------ Name max length (20)
            if (comment.Name.Length > 20)
                return (false, "User name is too long (max. 20 characters allowed)");

            //------ Invalid characters in Name
            if (!IsValidString(comment.Name))
                return (false, "User name contains invalid characters");

            //------ Improper content in Name
            if (IsImproperContent(comment.Name))
                return (false, "User name contains improper content");

            //------ If new topic and Title length = 0
            if (IsNewTopic(comment.TopicId) && string.IsNullOrWhiteSpace(comment.Title))
                return (false, "Topic title is missing");

            //------ Title min length (2)
            if ((IsNewTopic(comment.TopicId) && comment.Title.Length < 2))
                return (false, "Topic title is too short (min. 2 characters required)");

            //------ Title max length (60)
            if (comment.Title.Length > 60)
                return (false, "Topic title is too long (max. 60 characters allowed)");

            //------ Invalid characters in Title
            if (!IsValidString(comment.Title))
                return (false, "Topic title contains invalid characters");

            //------ Improper content in Title
            if (IsImproperContent(comment.Title))
                return (false, "Topic title contains improper content");

            //------ If Text length = 0
            if (string.IsNullOrWhiteSpace(comment.Text))
                return (false, "Comment text is missing");

            //------ Text min length (2)
            if (comment.Text.Length < 2)
                return (false, "Comment text is too short (min. 2 characters allowed)");

            //------ Text max length (5000)
            if (comment.Text.Length > 5000)
                return (false, "Comment text is too long (max. 5000 characters allowed)");

            //------ Invalid characters in Text
            if (!IsValidString(comment.Text))
                return (false, "Comment text contains invalid characters");

            //------ Improper content in Text
            if (IsImproperContent(comment.Text))
                return (false, "Comment text contains improper content");

            return (true, string.Empty);
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

        private static bool IsNewTopic(int? topicId)
        {
            return (topicId == null || topicId == 0);
        }
    }
}
