using ModelsLibrary.Models.ResponseModel;
using System.Data.SqlClient;

namespace MapObjectLibrary.DBMapping.IMapping
{
    public interface IDatabaseMapper
    {
        CommonResponse AddUpdateDeleteResponse(SqlDataReader dataReader);
    }
}
