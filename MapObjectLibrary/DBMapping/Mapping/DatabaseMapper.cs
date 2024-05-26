using MapObjectLibrary.DBMapping.IMapping;
using ModelsLibrary.DataBaseModels.TempModel;
using ModelsLibrary.Models.ResponseModel;
using System.Data.SqlClient;

namespace MapObjectLibrary.DBMapping.Mapping
{
    public class DatabaseMapper : IDatabaseMapper
    {
        public CommonResponse AddUpdateDeleteResponse(SqlDataReader dataReader)
        {
            CommonResponse addResponse = new CommonResponse();
            while (dataReader.Read())
            {
                addResponse = new CommonResponse()
                {
                    Message = Convert.ToString(dataReader["ResponseMessage"]),
                    IsSuccess = Convert.ToBoolean(dataReader["ResponseStatus"])
                };
            }
            return addResponse;
        }

        public UserDetails MapUserDetails(string[] UserDetails) 
        { 
            return new UserDetails() 
            {
                FirstName = UserDetails[0],
                LastName = UserDetails[1],
                Mobile = UserDetails[2],
                Email = UserDetails[3],
                Gender = UserDetails[4],
                Role = UserDetails[5]
            }; 
        }

    }
}
