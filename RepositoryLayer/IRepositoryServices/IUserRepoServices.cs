using ModelsLibrary.DataBaseModels.TempModel;
using ModelsLibrary.Models.RequestModel;
using ModelsLibrary.Models.ResponseModel;

namespace RepositoryLayer.IRepositoryServices
{
    public interface IUserRepoServices
    {
        Task<UserDetails> GetUserDetails(int id);
        Task<CommonResponse> RegisterUser(SignupRequest User);
    }
}
