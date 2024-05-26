using BusinessLayer.BusinessServices.Validation;
using BusinessLayer.IBusinessServices.UserService;
using CommonLibrary.CommonServices;
using CommonLibrary.ValidationServices;
using ModelsLibrary.BusinessModels;
using ModelsLibrary.Models.RequestModel;
using ModelsLibrary.Models.ResponseModel;
using RepositoryLayer.IRepositoryServices;
using System.ComponentModel.DataAnnotations;

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

        public async Task<UserInfo> ValidateUserDetails(SignIn Request)
        {
            try
            {
                Request.Password = Common.EncodePasswordToBase64(Request.Password);
                var result = await _userRepoServices.ValidateUser(Request).ConfigureAwait(false);

                if (result.status)
                {
                    var TokenResult = TokenService.GenerateJwtToken(result.userDetails);
                    return new UserInfo()
                    {
                        ResponseMessage = ValidationMessages.Success,
                        Status = true,
                        UserDetails = result.userDetails,
                        Token = TokenResult.Item1,
                        TokenValidTill = TokenResult.Item2.ToString()
                    };
                }

                return new UserInfo()
                {
                    ResponseMessage = ValidationMessages.GetExternalMessage(result?.responseMessage),
                    Status = false,
                    UserDetails = result?.userDetails
                };
            }
            catch (Exception)
            {
                throw;
            }
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
