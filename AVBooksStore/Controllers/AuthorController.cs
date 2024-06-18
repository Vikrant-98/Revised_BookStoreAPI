using BusinessLayer.IBusinessServices.AuthoService;
using CommonLibrary.ValidationServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary.Models.RequestModel;
using ModelsLibrary.Models.ResponseModel;

namespace AVBooksStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorBusiness _authorBusiness;
        public AuthorController(IAuthorBusiness authorBusiness)
        {
            _authorBusiness = authorBusiness;
        }

        [HttpPost]
        public async Task<Response<CommonResponse>> AddAuthorDetails(RegisterAuthor author) 
        {
            var result = await _authorBusiness.RegisterAuthor(author).ConfigureAwait(false);
            return new Response<CommonResponse>()
            {
                Message = ValidationMessages.Success,
                Status = ValidationMessages.GetExternalCode(ValidationMessages.Success),
                Data = result
            };
        }

    }
}
