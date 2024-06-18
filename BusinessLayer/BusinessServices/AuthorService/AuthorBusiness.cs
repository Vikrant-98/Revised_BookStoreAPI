using BusinessLayer.IBusinessServices.AuthoService;
using ModelsLibrary.Models.RequestModel;
using ModelsLibrary.Models.ResponseModel;
using RepositoryLayer.IRepositoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessServices.AuthorService
{
    public class AuthorBusiness : IAuthorBusiness
    {
        private readonly IAuthor _author;
        public AuthorBusiness(IAuthor author)
        {
            _author = author;
        }

        public async Task<CommonResponse> RegisterAuthor(RegisterAuthor Author) 
        {
            var result = await _author.RegisterAuthor(Author).ConfigureAwait(false);
            return  result;
        }

    }
}
