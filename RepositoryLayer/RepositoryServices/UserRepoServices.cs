using ModelsLibrary.DataBaseModels.TempModel;
using ModelsLibrary.Models.ResponseModel;
using RepositoryLayer.DatabaseServices;
using RepositoryLayer.IRepositoryServices;
using System.Data.SqlClient;
using System.Data;
using MapObjectLibrary.DBMapping.IMapping;
using ModelsLibrary.Models.RequestModel;
using CommonLibrary.CommonServices;

namespace RepositoryLayer.RepositoryServices
{
    public class UserRepoServices : IUserRepoServices
    {
        private readonly DBService _dbService;
        private readonly IDatabaseMapper _IDatabaseMapper;
        public UserRepoServices(DBService dbService, IDatabaseMapper databaseMapper)
        {
            _dbService = dbService;
            _IDatabaseMapper = databaseMapper;
        }

        public async Task<CommonResponse> RegisterUser(SignupRequest User) 
        {

            SqlDataReader dataReader;
            CommonResponse? response = new CommonResponse();
            try
            {
                using (SqlCommand command = new SqlCommand(Common.RegistedUser, _dbService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", User.FirstName);
                    command.Parameters.AddWithValue("@LastName", User.LastName);
                    command.Parameters.AddWithValue("@Role", User.Role);
                    command.Parameters.AddWithValue("@EmailId", User.EmailId);
                    command.Parameters.AddWithValue("@Gender", User.Gender);
                    command.Parameters.AddWithValue("@Password", User.Password);
                    command.Parameters.AddWithValue("@MobileNumber", User.Mobile);
                   
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


        public async Task<RetriveUserDetails> ValidateUser(SignIn User) 
        {
            SqlDataReader dataReader;
            CommonResponse? response = new CommonResponse();
            try
            {
                using (SqlCommand command = new SqlCommand(Common.ValidateUser, _dbService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Password", User.Password);
                    command.Parameters.AddWithValue("@UserId", User.UserId);

                    _dbService.Connection.Open();
                    dataReader = await command.ExecuteReaderAsync();
                    response = _IDatabaseMapper.AddUpdateDeleteResponse(dataReader);

                };

                if (response.IsSuccess)
                {
                    var splitResponse = response.Message.Split(" ");
                    var mapDetails = _IDatabaseMapper.MapUserDetails(splitResponse);
                    return new RetriveUserDetails()
                    {
                        userDetails = mapDetails,
                        status = true
                    };
                }
                
                return new RetriveUserDetails()
                {
                    userDetails = null,
                    responseMessage = response.Message,
                    status = false
                };
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
