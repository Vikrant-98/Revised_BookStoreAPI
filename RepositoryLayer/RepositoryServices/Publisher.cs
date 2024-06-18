using CommonLibrary.CommonServices;
using MapObjectLibrary.DBMapping.IMapping;
using ModelsLibrary.Models.RequestModel;
using ModelsLibrary.Models.ResponseModel;
using RepositoryLayer.DatabaseServices;
using RepositoryLayer.IRepositoryServices;
using System.Data.SqlClient;
using System.Data;

namespace RepositoryLayer.RepositoryServices
{
    public class Publisher : IPublisher
    {
        private readonly DBService _dbService;
        private readonly IDatabaseMapper _IDatabaseMapper;
        public Publisher(DBService dbService, IDatabaseMapper IDatabaseMapper) 
        {
            _dbService = dbService;
            _IDatabaseMapper = IDatabaseMapper;
        }

        public async Task<CommonResponse> RegisterPublisher(RegisterPublisher publisher) 
        {
            SqlDataReader dataReader;
            CommonResponse? response = new CommonResponse();
            try
            {
                using (SqlCommand command = new SqlCommand(Common.RegisterPublisher, _dbService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@inp_agency_name", publisher.AgencyName);
                    command.Parameters.AddWithValue("@inp_contact_name", publisher.ContactName);
                    command.Parameters.AddWithValue("@inp_contact_number", publisher.ContactNumber);
                    command.Parameters.AddWithValue("@inp_offer_id", publisher.OfferId);
                    command.Parameters.AddWithValue("@inp_admin_id", publisher.AdminId);
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
