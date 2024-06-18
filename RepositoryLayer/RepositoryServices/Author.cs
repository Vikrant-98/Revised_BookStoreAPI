using CommonLibrary.CommonServices;
using ModelsLibrary.Models.RequestModel;
using ModelsLibrary.Models.ResponseModel;
using RepositoryLayer.DatabaseServices;
using RepositoryLayer.IRepositoryServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapObjectLibrary.DBMapping.IMapping;

namespace RepositoryLayer.RepositoryServices
{
    public class Author : IAuthor
    {
        private readonly DBService _dbService;
        private readonly IDatabaseMapper _IDatabaseMapper;

        public Author(DBService dbService, IDatabaseMapper IDatabaseMapper) 
        {
            _dbService = dbService;
            _IDatabaseMapper = IDatabaseMapper;
        }

        public async Task<CommonResponse> RegisterAuthor(RegisterAuthor Author)
        {

            SqlDataReader dataReader;
            CommonResponse? response = new CommonResponse();
            try
            {
                using (SqlCommand command = new SqlCommand(Common.RegistedAuthor, _dbService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@inp_author_name", Author.AuthorName);
                    command.Parameters.AddWithValue("@inp_author_number", Author.AuthorNumber);
                    command.Parameters.AddWithValue("@inp_about_author", Author.AboutAuthor);
                    command.Parameters.AddWithValue("@inp_rating", Author.Rating);
                    _dbService.Connection.Open();
                    dataReader = await command.ExecuteReaderAsync();
                    response = _IDatabaseMapper.AddUpdateDeleteResponse(dataReader);
                };

                return response;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _dbService.Connection.Close();
            }

        }
    }
}
