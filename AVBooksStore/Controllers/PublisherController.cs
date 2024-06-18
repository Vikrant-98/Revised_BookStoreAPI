using BusinessLayer.IBusinessServices.PublisherService;
using CommonLibrary.ValidationServices;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary.Models.RequestModel;
using ModelsLibrary.Models.ResponseModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AVBooksStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherBusiness _publisherBusiness;
        public PublisherController(IPublisherBusiness publisherBusiness)
        {
            _publisherBusiness = publisherBusiness;
        }

        // POST api/<PublisherController>
        [HttpPost]
        public async Task<Response<CommonResponse>> RegisterPublisher([FromBody] RegisterPublisher publisher)
        {
            var result = await _publisherBusiness.RegisterPublisher(publisher).ConfigureAwait(false);
            return new Response<CommonResponse>()
            {
                Message = ValidationMessages.Success,
                Status = ValidationMessages.GetExternalCode(ValidationMessages.Success),
                Data = result
            };
        }

        
    }
}
