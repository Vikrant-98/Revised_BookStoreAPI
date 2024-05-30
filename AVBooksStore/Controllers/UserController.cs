using BusinessLayer.IBusinessServices.UserService;
using CommonLibrary.ValidationServices;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary.BusinessModels;
using ModelsLibrary.Models.RequestModel;
using ModelsLibrary.Models.ResponseModel;
using Poppins.POS.Api.Resources.Middlewares.CustomJWTMiddleware;
using static Poppins.POS.Api.Resources.Middlewares.CustomJWTMiddleware.AuthorizeAttribute;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AVBooksStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [AllowAnonymous]
        [HttpPost]        
        [Route("SignIn")]
        public async Task<ActionResult> SignIn([FromBody] SignIn Request)
        {//login logic
            var result = await _userServices.ValidateUserDetails(Request);

            return Ok(new Response<UserInfo>()
            {
                Message = ValidationMessages.GetExternalMessage(result.ResponseMessage),
                Status = ValidationMessages.GetExternalCode(result.ResponseMessage),
                Data = result
            });

        }

        //[Authorize]
        [HttpPost]
        [Route("SignUp")]
        public async Task<Response<CommonResponse>> SignUp([FromBody] SignupRequest Request)
        {
            var result = await _userServices.RegisterUser(Request).ConfigureAwait(false);
            return new Response<CommonResponse>()
            {
                Message = ValidationMessages.Success,
                Status = ValidationMessages.GetExternalCode(ValidationMessages.Success),
                Data = result
            };
        }

        [Authorize]
        //[AllowAnonymous]
        [HttpPost("PostTest")]
        public async Task<Response<string>> PostTest([FromBody] SignupRequest Request)
        {
            return new Response<string>()
            {
                Message = ValidationMessages.Success,
                Status = ValidationMessages.GetExternalCode(ValidationMessages.Success),
                Data = string.Empty
            };
        }
    }
}
