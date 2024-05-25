using ModelsLibrary.BusinessModels;
using ModelsLibrary.Models.RequestModel;
using ModelsLibrary.Models.ResponseModel;

namespace BusinessLayer.IBusinessServices.UserService
{
    public interface IUserServices
    {
        Task<UserInfo> UserDetails(SignIn Request,int id);
        Task<CommonResponse> RegisterUser(SignupRequest User);

    }
}
