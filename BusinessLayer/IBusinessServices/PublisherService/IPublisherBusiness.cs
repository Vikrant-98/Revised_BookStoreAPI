using ModelsLibrary.Models.RequestModel;
using ModelsLibrary.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IBusinessServices.PublisherService
{
    public interface IPublisherBusiness
    {
        Task<CommonResponse> RegisterPublisher(RegisterPublisher Author);
    }
}
