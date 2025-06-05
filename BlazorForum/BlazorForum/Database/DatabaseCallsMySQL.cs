using BlazorForum.Data;
using System.Data;
using Dapper;
using MySql.Data.MySqlClient;

namespace BlazorForum.Database
{
    public class DatabaseCallsMySQL : IDatabaseCalls
    {
        private readonly MySqlConnection Connection;

        public DatabaseCallsMySQL(IConfiguration configuration)
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

        public async Task<List<Comment>> GetCommentListAsync(int topicId)
        {
            var param = new { TopicId = topicId, ShowAll = true }; ;
            return await GetStoredProcResultListAsync<Comment>("GetCommentList", param);
        }

        //--- Task<int> -----------------------------------------------------------------------------------------

        private async Task<int> GetStoredProcResultIntAsync(string mrpStoredProc, object? param = null)
        {
            int result = 0;
            try
            {
                result = (await Connection.QueryAsync<int>(mrpStoredProc, param, commandType: CommandType.StoredProcedure)).First();
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
            var param = new {};
            return await GetStoredProcResultIntAsync("GetNextCommentId", param);
        }

        public async Task<bool> IsBannedIpAsync(string ip)
        {
            var param = new { IP = ip };
            return await GetStoredProcResultIntAsync("IsBannedIP", param) != 0;
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

        public async Task<bool> UserExistsAsync(string name, string ip)
        {
            var param = new { Name = name, IP = ip };
            return await GetStoredProcResultIntAsync("IsDuplicatedComment", param) != 0;
        }

        //--- Task ----------------------------------------------------------------------------------------------

        public async Task SaveStoredProcAsync<T>(string mrpStoredProc, T record)
        {
            try
            {
                await Connection.QueryAsync<T>(mrpStoredProc, record, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public async Task IncTopicViewsAsync(int topicId)
        {
            await SaveStoredProcAsync<int>("IncTopicViews", topicId);
        }

        public async Task SaveCommentAsync(Comment comment)
        {
            await SaveStoredProcAsync<Comment>("SaveComment", comment);
        }

        public async Task SaveUserAsync(User user)
        {
            await SaveStoredProcAsync<User>("SaveUser", user);
        }
    }
}
