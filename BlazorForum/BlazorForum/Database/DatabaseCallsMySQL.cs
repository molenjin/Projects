using BlazorForum.Data;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

namespace BlazorForum.Database
{
    public class DatabaseCallsMySql : IDatabaseCalls
    {
        private readonly MySqlConnection Connection;

        public DatabaseCallsMySql(IConfiguration configuration)
        {
            Connection = new MySqlConnection(configuration["ConnectionString"]);
        }

        //--- Task<List<T>> --------------------------------------------------------------------------------------

        private async Task<List<T>> GetStoredProcResultListAsync<T>(string mrpStoredProc, object? param = null)
        {
            var resultList = new List<T>();
            try
            {
                resultList = (await Connection.QueryAsync<T>(mrpStoredProc, param, commandType: CommandType.StoredProcedure)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return resultList ?? new List<T>();
        }

        public async Task<List<Topic>> GetTopicListAsync(bool showAll, int pageNo, int pageLimit)
        {
            var param = new { ShowAll = showAll, PageNo = pageNo, PageLimit = pageLimit, PageOffset = (pageNo - 1) * pageLimit };
            return await GetStoredProcResultListAsync<Topic>("GetTopicList", param);
        }

        public async Task<List<Comment>> GetCommentListAsync(int topicId, bool showAll)
        {
            var param = new { TopicId = topicId, ShowAll = showAll };
            return await GetStoredProcResultListAsync<Comment>("GetCommentList", param);
        }

        //--- Task<int> -----------------------------------------------------------------------------------------

        private async Task<int> GetStoredProcResultIntAsync(string mrpStoredProc, object? param = null)
        {
            int result = 0;
            try
            {
                result = (await Connection.QueryAsync<int>(mrpStoredProc, param, commandType: CommandType.StoredProcedure)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return result;
        }

        //--- Task<string> ---------------------------------------------------------------------------------------

        private async Task<string> GetStoredProcResultStringAsync(string mrpStoredProc, object? param = null)
        {
            string result = string.Empty;
            try
            {
                result = (await Connection.QueryAsync<string?>(mrpStoredProc, param, commandType: CommandType.StoredProcedure)).FirstOrDefault() ?? string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return result;
        }

        public async Task<int> GetNumOfTopicsAsync(bool showAll)
        {
            var param = new { ShowAll = showAll };
            return await GetStoredProcResultIntAsync("GetNumOfTopics", param);
        }

        public async Task<int> GetNextCommentIdAsync()
        {
            var param = new { };
            return await GetStoredProcResultIntAsync("GetNextCommentID", param);
        }

        public async Task<int> GetNextUserIdAsync()
        {
            var param = new { };
            return await GetStoredProcResultIntAsync("GetNextUserID", param);
        }

        public async Task<int> GetUserIdAsync(string name, string ip)
        {
            var param = new { Name = name, IP = ip };
            return await GetStoredProcResultIntAsync("GetUserId", param);
        }

        public async Task<string> GetUserNameAsync(string ip)
        {
            var param = new { IP = ip };
            return await GetStoredProcResultStringAsync("GetUserName", param);
        }

        public async Task<bool> IsBannedIpAsync(string ip)
        {
            var param = new { IP = ip };
            return await GetStoredProcResultIntAsync("IsBannedIP", param) != 0;
        }

        public async Task<bool> IsDuplicatedTitleAsync(string? title)
        {
            var param = new { Title = title };
            return await GetStoredProcResultIntAsync("IsDuplicatedTitle", param) != 0;
        }

        public async Task<bool> IsDuplicatedCommentAsync(string text)
        {
            var param = new { Text = text };
            return await GetStoredProcResultIntAsync("IsDuplicatedComment", param) != 0;
        }

        public async Task<bool> TopicExistsAsync(int topicId)
        {
            var param = new { TopicID = topicId };
            return await GetStoredProcResultIntAsync("TopicExists", param) != 0;
        }

        public async Task SaveCommentAsync(Comment comment)
        {
            var param = new { CommentID = comment.Id, TopicID = comment.TopicId, comment.Title, comment.Text, UserID = comment.UserId, comment.Hidden, comment.Closed };
            await GetStoredProcResultIntAsync("SaveComment", param);
        }

        public async Task UpdateCommentAsync(Comment comment)
        {
            var param = new { CommentID = comment.Id, comment.Title, comment.Text };
            await GetStoredProcResultIntAsync("UpdateComment", param);
        }

        public async Task DeleteCommentAsync(int commentId)
        {
            var param = new { CommentID = commentId };
            await GetStoredProcResultIntAsync("DeleteComment", param);
        }

        public async Task HideCommentAsync(int commentId)
        {
            var param = new { CommentID = commentId };
            await GetStoredProcResultIntAsync("HideComment", param);
        }

        public async Task UnhideCommentAsync(int commentId)
        {
            var param = new { CommentID = commentId };
            await GetStoredProcResultIntAsync("UnhideComment", param);
        }

        public async Task SaveUserAsync(User user)
        {
            var param = new { ID = user.Id, user.Name, user.CountryCode, user.IP, Active = user.Active, Moderator = user.Moderator };
            await GetStoredProcResultIntAsync("SaveUser", param);
        }

        public async Task IncTopicViewsAsync(int topicId)
        {
            await GetStoredProcResultIntAsync("IncTopicViews", topicId);
        }

        public async Task<List<Setting>> GetSettingAsync(string key)
        {
            var param = new { SearchKey = key };
            return await GetStoredProcResultListAsync<Setting>("GetSettingValueList", param);
        }

        public async Task SaveSettingAsync(string key, string value)
        {
            var param = new { SearchKey = key, Value = value };
            await GetStoredProcResultIntAsync("SaveSettingValue ", param);
        }

        public async Task SaveReactionAsync(Reaction reaction)
        {
            var param = new { Type = reaction.Type, CommentID = reaction.CommentId, IP = reaction.Ip };
            await GetStoredProcResultIntAsync("SaveReaction ", param);
        }

        public async Task UpdateCommentReactionsAsync(int commentId)
        {
            var param = new { CommentId = commentId };
            await GetStoredProcResultIntAsync("UpdateCommentReactions ", param);
        }
    }
}
