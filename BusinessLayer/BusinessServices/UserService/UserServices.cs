using BusinessLayer.IBusinessServices.UserService;
using ModelsLibrary.BusinessModels;
using ModelsLibrary.Models.RequestModel;
using RepositoryLayer.IRepositoryServices;

namespace BusinessLayer.BusinessServices.UserService
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepoServices _userRepoServices;
        public UserServices(IUserRepoServices userRepoServices)
        {
            _userRepoServices = userRepoServices;
        }

        public async Task<UserInfo> UserDetails(SignIn Request, int id)
        {
            var result = await _userRepoServices.GetUserDetails(id).ConfigureAwait(false);
            return new UserInfo()
            {
                UserName = result.FirstName,
                Role = result.Role
            };
        }

    }
}
