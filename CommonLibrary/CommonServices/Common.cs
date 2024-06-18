using System.Text;

namespace CommonLibrary.CommonServices
{
    public class Common
    {
        private const string registerUser = "spAddUserDetail";
        private const string registerAuthor = "spAddAuthorDetails";
        private const string registerPublisher = "spAddPublisherDetails";
        private const string validateUser = "spValidateUser";

        public const string RegistedUser = registerUser;
        public const string RegistedAuthor = registerAuthor;
        public const string RegisterPublisher = registerPublisher;
        public const string ValidateUser = validateUser;
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
