namespace CommonLibrary.ValidationServices
{
    public class ValidationMessages
    {

        private static readonly Dictionary<string, long> externalCodes = new();
        private static readonly Dictionary<string, string> externalMessage = new();

        private const string _success = "Success";
        private const string _userSuccess = "User Succesfully Registered";
        private const string _firstNameEmptyOrNull = "First Name is Invalid or Empty";
        private const string _firstNameMinimum = "First Name Must Contain at Least 3 Character";
        private const string _userPassInvalid = "User Id or Password is Invalid";
        private const string _invalidUser = "Invalid User Id";

        public const string Success = _success;
        public const string UserSuccess = _userSuccess;
        public const string FirstNameEmptyOrNull = _firstNameEmptyOrNull;
        public const string FirstNameMinimum = _firstNameMinimum;
        public const string UserPasswordInvalid = _userPassInvalid;
        public const string InvalidUser = _invalidUser;

        static ValidationMessages() 
        {
            SetExternalCode();
            SetExternalMessage();
        }

        private static void SetExternalCode() 
        {
            externalCodes.Add(Success, 0);
            externalCodes.Add(UserPasswordInvalid, 103);
            externalCodes.Add(InvalidUser, 104);
            externalCodes.Add(FirstNameEmptyOrNull, 101);
            externalCodes.Add(FirstNameMinimum, 102);
        }

        private static void SetExternalMessage()
        {
            externalMessage.Add(Success, _success);
            externalMessage.Add(FirstNameEmptyOrNull, _firstNameEmptyOrNull);
            externalMessage.Add(FirstNameMinimum, _firstNameMinimum);
            externalMessage.Add(UserPasswordInvalid, _userPassInvalid);
            externalMessage.Add(InvalidUser, _invalidUser);
        }

        public static long GetExternalCode(string? key) 
        {
            if (key != null)
            {
                if (externalCodes.ContainsKey(key))
                return externalCodes[key];
            }
            return -1;
        }

        public static string GetExternalMessage(string? key)
        {
            if (key != null)
            {
                if (externalMessage.ContainsKey(key))
                    return externalMessage[key];
            }
            return string.Empty;
        }
    }
}
