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

        public async Task<List<Topic>> GetTopicListAsync(bool showAll, int pageNo, int pageLimit)
        {
            var topicList = new List<Topic>();

            try
            {
                int pageOffset = (pageNo - 1) * pageLimit;
                var values = new { ShowAll = showAll, PageNo = pageNo, PageLimit = pageLimit, PageOffset = pageOffset };
                topicList = (await Connection.QueryAsync<Topic>("GetTopicList", values, commandType: CommandType.StoredProcedure)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return topicList ?? [];
        }

        public async Task<List<Comment>> GetCommentListAsync(int Id)
        {
            var commentList = new List<Comment>();

            try
            {
                var values = new { TopicId = Id, ShowAll = true};
                commentList = (await Connection.QueryAsync<Comment>("GetCommentList", values, commandType: CommandType.StoredProcedure)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return commentList ?? [];
        }
    }
}
