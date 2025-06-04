using BlazorForum.Data;

namespace BlazorForum.Database
{
    public interface IDatabaseCalls
    {
        Task<int> GetNumOfTopicsAsync(bool showAll);
        Task<List<Topic>> GetTopicListAsync(bool showAll, int pageNo, int pageLimit);
        Task<List<Comment>> GetCommentListAsync(int topicId);
        Task IncTopicViewsAsync(int topicId);
        Task<bool> IsBannedIP(string ip);
        Task<bool> IsDuplicatedComment(string text);
        Task<bool> TopicExists(int topicId);
        Task<bool> UserExists(string name, string ip);
    }
}
