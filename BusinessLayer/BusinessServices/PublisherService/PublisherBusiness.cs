using BusinessLayer.IBusinessServices.PublisherService;
using ModelsLibrary.Models.RequestModel;
using ModelsLibrary.Models.ResponseModel;
using RepositoryLayer.IRepositoryServices;

namespace BusinessLayer.BusinessServices.PublisherService
{
    public class PublisherBusiness : IPublisherBusiness
    {
        private readonly IPublisher _publisher;

        public PublisherBusiness(IPublisher publisher)
        {
            _publisher = publisher;
        }

        public Task<CommonResponse> RegisterPublisher(RegisterPublisher Author)
        {
            return _publisher.RegisterPublisher(Author);
        }
    }
}
