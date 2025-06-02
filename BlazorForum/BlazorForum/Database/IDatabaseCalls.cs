using BlazorForum.Data;

namespace BlazorForum.Database
{
    public interface IDatabaseCalls
    {
        Task<int> GetNumOfTopicsAsync(bool showAll);
        Task<List<Topic>> GetTopicListAsync(bool showAll, int pageNo, int pageLimit);
        Task<List<Comment>> GetCommentListAsync(int Id);
    }
}
