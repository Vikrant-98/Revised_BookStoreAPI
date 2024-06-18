using ModelsLibrary.Models.RequestModel;
using ModelsLibrary.Models.ResponseModel;

namespace BusinessLayer.IBusinessServices.AuthoService
{
    public interface IAuthorBusiness
    {
        Task<CommonResponse> RegisterAuthor(RegisterAuthor Author);
    }
}
