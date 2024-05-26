using ModelsLibrary.BusinessModels;
using ModelsLibrary.Models.RequestModel;
using ModelsLibrary.Models.ResponseModel;

namespace BusinessLayer.IBusinessServices.UserService
{
    public interface IUserServices
    {
        Task<UserInfo> ValidateUserDetails(SignIn Request);
        Task<CommonResponse> RegisterUser(SignupRequest User);

    }
}
