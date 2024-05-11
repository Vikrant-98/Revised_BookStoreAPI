using BusinessLayer.IBusinessServices.UserService;
using ModelsLibrary.BusinessModels;
using ModelsLibrary.Models.RequestModel;

namespace BusinessLayer.BusinessServices.UserService
{
    public class UserServices : IUserServices
    {
        public UserServices()
        {

        }

        public async Task<UserInfo> UserDetails(SignIn Request)
        {
            return new UserInfo()
            {
                UserName = "User Name",
                Role = "User"
            };
        }

    }
}
