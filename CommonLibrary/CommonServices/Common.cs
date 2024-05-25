using System.Text;

namespace CommonLibrary.CommonServices
{
    public class Common
    {

        public const string RegistedUser = "spAddUserDetail";
        public static string EncodePasswordToBase64(string Password)
        {
            try
            {
                byte[] encData_byte = new byte[Password.Length];
                encData_byte = Encoding.UTF8.GetBytes(Password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
    }

     

    enum GenderEnum
    {
        Male,
        Femail,
        TransGender
    }
}
