using BlazorForum.Data;

namespace BlazorForum.Database
{
    public interface IDatabaseCalls
    {
        Task<List<Topic>> GetTopicListAsync();
        Task<List<Comment>> GetCommentListAsync(int Id);
    }
}
