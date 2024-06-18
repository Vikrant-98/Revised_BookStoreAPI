using ModelsLibrary.Models.RequestModel;
using ModelsLibrary.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepositoryServices
{
    public interface IAuthor
    {
        Task<CommonResponse> RegisterAuthor(RegisterAuthor Author);
    }
}
