using BlazorForum.Data;

namespace BlazorForum.Database
{
    public interface IDatabaseCalls
    {        
        Task<List<Topic>> GetTopicListAsync(bool showAll, int pageNo, int pageLimit);
        Task<List<Comment>> GetCommentListAsync(int topicId);
        Task<int> GetNumOfTopicsAsync(bool showAll);
        Task<int> GetNextCommentIdAsync();
        Task<int> GetNextUserIdAsync();
        Task<int> GetUserIdAsync(string name, string ip);
        Task<bool> IsBannedIpAsync(string ip);
        Task<bool> IsDuplicatedTitleAsync(string? title);
        Task<bool> IsDuplicatedCommentAsync(string text);
        Task<bool> TopicExistsAsync(int topicId);                
        Task SaveCommentAsync(Comment comment);
        Task DeleteCommentAsync(int commentId);
        Task SaveUserAsync(User user);
        Task IncTopicViewsAsync(int topicId);
    }
}
