using BlazorForum.Data;
using System.Data;
using Dapper;
using MySql.Data.MySqlClient;
using BlazorForum.Pages;

namespace BlazorForum.Database
{
    public class DatabaseCallsMySQL : IDatabaseCalls
    {
        private readonly MySqlConnection Connection;

        public DatabaseCallsMySQL(IConfiguration configuration)
        {
            Connection = new MySqlConnection(configuration["ConnectionString"]);
        }

        public async Task<List<Topic>> GetTopicListAsync()
        {
            var topicList = new List<Topic>();

            try
            {
                var values = new { ShowAll = true, PageNo = 1, PageLimit = 500, PageOffset = 0 };
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
