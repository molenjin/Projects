using BlazorForum.Data;
using System.Data;
using Dapper;
using MySql.Data.MySqlClient;




using System.Collections.Generic;
using System.Linq;
using Google.Protobuf.WellKnownTypes;


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
                var values = new { ShowAll = showAll };
                numOfTopics = (await Connection.QueryAsync<int>("GetNumOfTopics", values, commandType: CommandType.StoredProcedure)).FirstOrDefault(0);
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
                var values = new { TopicId = topicId };
                await Connection.QueryAsync("IncTopicViews", values, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
