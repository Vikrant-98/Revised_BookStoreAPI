using System.Reflection;

namespace ModelsLibrary.Models.RequestModel
{
    public class SignupRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }

     

    }
}
