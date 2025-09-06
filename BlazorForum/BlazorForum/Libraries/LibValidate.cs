using BlazorForum.Data;
using BlazorForum.Database;

namespace BlazorForum.Libraries
{
    public class LibValidate(IDatabaseCalls DatabaseCalls)
    {
        public async Task<(bool, string)> IsCommentValidAsync(PostType postType, Comment comment)
        {
            //------ If comment is null
            if (comment == null)
                throw new ArgumentNullException("Comment cannot be null");


            //------ If Id != 0 but PostType = CommentNew
            if ((comment.Id != 0) && postType == PostType.CommentNew)
                throw new Exception("New comment should not have Id");

            //------ If Id = 0 but PostType = CommentUpdate
            if ((comment.Id == 0) && postType == PostType.CommentUpdate)
                throw new Exception("Comment update but missing Id");

            //------ If TopicId exists but PostType = TopicNew
            if (!IsNewTopic(comment.TopicId) && postType == PostType.TopicNew)
                throw new Exception("New topic should not have TopicId");

            //------ If TopicId exists but PostType = TopicUpdate
            if (!IsNewTopic(comment.TopicId) && postType == PostType.TopicUpdate)
                throw new Exception("Topic update should not have TopicId");

            //------ If not new topic and Title length > 0
            if (!IsNewTopic(comment.TopicId) && !string.IsNullOrWhiteSpace(comment.Title))
                throw new Exception("Title not allowed for comments");

            //------ If not new topic and TopicExists(TopicID) = FALSE
            if ((!IsNewTopic(comment.TopicId)) && !(await DatabaseCalls.TopicExistsAsync(comment.TopicId ?? 0)))
                throw new Exception("TopicID not found among existing topics");

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

            //------ Improper use of Moderator Name
            if (comment.Name.ToLower() == "Moderator".ToLower() && !comment.Moderator)
                return (false, "User name cannot be Moderator");

            //------ If new topic and Title length = 0
            if (IsNewTopic(comment.TopicId) && string.IsNullOrWhiteSpace(comment.Title))
                return (false, "Topic title is missing");

            //------ Title min length (2)
            if ((IsNewTopic(comment.TopicId) && comment.Title?.Length < 2))
                return (false, "Topic title is too short (min. 2 characters required)");

            //------ Title max length (60)
            if (IsNewTopic(comment.TopicId) && comment.Title?.Length > 60)
                return (false, "Topic title is too long (max. 60 characters allowed)");

            //------ Invalid characters in Title
            if (IsNewTopic(comment.TopicId) && !IsValidString(comment.Title ?? string.Empty))
                return (false, "Topic title contains invalid characters");

            //------ Improper content in Title
            if (IsNewTopic(comment.TopicId) && IsImproperContent(comment.Title ?? string.Empty))
                return (false, "Topic title contains improper content");

            //------ Title already exist
            if (IsNewTopic(comment.TopicId) && postType == PostType.TopicNew && await DatabaseCalls.IsDuplicatedTitleAsync(comment.Title))
                return (false, "Topic title already exists");

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

            //------ Comment already exist
            if (postType != PostType.TopicUpdate && await DatabaseCalls.IsDuplicatedCommentAsync(comment.Text))
                return (false, "Comment already exists");

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
