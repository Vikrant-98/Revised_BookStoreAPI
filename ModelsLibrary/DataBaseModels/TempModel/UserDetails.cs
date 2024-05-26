
namespace ModelsLibrary.DataBaseModels.TempModel
{
    public class UserDetails
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Role { get; set; }
        public string? Gender { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
    }

    public class RetriveUserDetails 
    {
        public UserDetails? userDetails { get; set; }
        public string? responseMessage { get; set; }
        public bool status { get; set; }
    }

}
