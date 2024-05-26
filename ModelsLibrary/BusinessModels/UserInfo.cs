using ModelsLibrary.DataBaseModels.TempModel;

namespace ModelsLibrary.BusinessModels
{
    public class UserInfo
    {
        public UserDetails? UserDetails { get; set; }
        public string? ResponseMessage { get; set; }
        public bool Status { get; set; }
        public string? Token { get; set; }
        public string? TokenValidTill { get; set; }
    }
}
