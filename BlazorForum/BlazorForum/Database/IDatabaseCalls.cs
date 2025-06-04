using BlazorForum.Data;

namespace BlazorForum.Database
{
    public interface IDatabaseCalls
    {        
        Task<List<Topic>> GetTopicListAsync(bool showAll, int pageNo, int pageLimit);
        Task<List<Comment>> GetCommentListAsync(int topicId);
        Task<int> GetNumOfTopicsAsync(bool showAll);
        Task<int> GetNextCommentIdAsync();
        Task<bool> IsBannedIpAsync(string ip);
        Task<bool> IsDuplicatedCommentAsync(string text);
        Task<bool> TopicExistsAsync(int topicId);
        Task<bool> UserExistsAsync(string name, string ip);
        Task IncTopicViewsAsync(int topicId);
        Task SaveCommentAsync(Comment comment);
        Task SaveUserAsync(User user);
    }
}
