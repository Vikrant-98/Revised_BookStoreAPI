using ModelsLibrary.DataBaseModels.TempModel;

namespace RepositoryLayer.IRepositoryServices
{
    public interface IUserRepoServices
    {
        Task<UserDetails> GetUserDetails(int id);
    }
}
