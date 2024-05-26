using ModelsLibrary.DataBaseModels.TempModel;
using ModelsLibrary.Models.RequestModel;
using ModelsLibrary.Models.ResponseModel;

namespace RepositoryLayer.IRepositoryServices
{
    public interface IUserRepoServices
    {
        Task<RetriveUserDetails> ValidateUser(SignIn User);
        Task<CommonResponse> RegisterUser(SignupRequest User);
    }
}
