using BusinessLayer.BusinessServices.Validation;
using BusinessLayer.IBusinessServices.UserService;
using CommonLibrary.CommonServices;
using ModelsLibrary.BusinessModels;
using ModelsLibrary.Models.RequestModel;
using ModelsLibrary.Models.ResponseModel;
using RepositoryLayer.IRepositoryServices;

namespace BusinessLayer.BusinessServices.UserService
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepoServices _userRepoServices;
        private readonly SignupValidator _signupValidator;
        public UserServices(IUserRepoServices userRepoServices, SignupValidator signupValidator)
        {
            _userRepoServices = userRepoServices;
            _signupValidator = signupValidator;
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

        public async Task<CommonResponse> RegisterUser(SignupRequest User) 
        {
            var validationResult = _signupValidator.Validate(User);
            if (validationResult.IsValid)
            {
                User.Password = Common.EncodePasswordToBase64(User.Password);
                var result = await _userRepoServices.RegisterUser(User).ConfigureAwait(false);
                return result;
            }
            return new CommonResponse() 
            {
                IsSuccess = false,
                Message = ""
            };
        }

    }
}
