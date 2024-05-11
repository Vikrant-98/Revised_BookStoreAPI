using BusinessLayer.IBusinessServices.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary.Models.RequestModel;
using ModelsLibrary.Models.ResponseModel;

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
        {
            var result = await _userServices.UserDetails(Request);

            return Ok( new Response<SignInResponse>()
            {
                Message = "success",
                Status = 0,
                Data = new SignInResponse() 
                { 
                    UserName = result.UserName,
                    EmailId = Request.UserId,
                    Token = "" 
                }
            });
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("SignUp")]
        public Response<object> Post([FromBody] SignupRequest Request)
        {
            return new Response<object>()
            {
                Message = "User Registered Succesfully",
                Status = 0
            };
        }        
    }
}
