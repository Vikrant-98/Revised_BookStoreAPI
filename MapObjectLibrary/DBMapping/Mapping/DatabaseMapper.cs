using MapObjectLibrary.DBMapping.IMapping;
using ModelsLibrary.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
