using ModelsLibrary.BusinessModels;
using ModelsLibrary.Models.RequestModel;

namespace BusinessLayer.IBusinessServices.UserService
{
    public interface IUserServices
    {
        Task<UserInfo> UserDetails(SignIn Request);

    }
}
