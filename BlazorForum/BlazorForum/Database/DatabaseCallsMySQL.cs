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

        public async Task<int> GetNumOfTopicsAsync(bool showAll)
        {
            int numOfTopics = 0;

            try
            {
                var param = new { ShowAll = showAll };
                numOfTopics = (await Connection.QueryAsync<int>("GetNumOfTopics", param, commandType: CommandType.StoredProcedure)).FirstOrDefault(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return numOfTopics;
        }

        public async Task IncTopicViewsAsync(int topicId)
        {
            try
            {
                var param = new { TopicId = topicId };
                await Connection.QueryAsync("IncTopicViews", param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private async Task<bool> GetStoredProcResultBoolAsync(string mrpStoredProc, object? param = null)
        {
            bool result = false;
            try
            {
                result = (await Connection.QueryAsync<int>(mrpStoredProc, param, commandType: CommandType.StoredProcedure)).First() != 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return result;
        }

        public async Task<bool> IsBannedIP(string ip)
        {
            var param = new { IP = ip };
            return await GetStoredProcResultBoolAsync("IsBannedIP", param);
        }

        public async Task<bool> IsDuplicatedComment(string text)
        {
            var param = new { Text = text };
            return await GetStoredProcResultBoolAsync("IsDuplicatedComment", param);
        }

        public async Task<bool> TopicExists(int topicId)
        {
            var param = new { TopicID = topicId };
            return await GetStoredProcResultBoolAsync("TopicExists", param);
        }

        public async Task<bool> UserExists(string name, string ip)
        {
            var param = new { Name = name, IP = ip };
            return await GetStoredProcResultBoolAsync("IsDuplicatedComment", param);
        }
    }
}
