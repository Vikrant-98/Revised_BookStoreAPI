using ModelsLibrary.DataBaseModels.TempModel;

namespace RepositoryLayer.DatabaseServices
{
    public class DBService
    {
        public DBService()
        {

        }

        public async Task<List<UserDetails>> GetAllUserDetails() 
        {
            UserDetails user = new UserDetails() {FirstName = "Vikrant",Gender = "Male",Email = "vikrant@gmail.com",Id = 1,Role = "Admin"};
            List<UserDetails> userDetails = new List<UserDetails>() 
            {
                new UserDetails() {FirstName = "Vikrant",Gender = "Male",Email = "vikrant@gmail.com",Id = 0,Role = "Admin"},
                new UserDetails() {FirstName = "Vikrant1",Gender = "Male",Email = "vikrant1@gmail.com",Id = 1,Role = "User"},
                new UserDetails() {FirstName = "Vikrant2",Gender = "Male",Email = "vikrant2@gmail.com",Id = 2,Role = "User"},
                new UserDetails() {FirstName = "Vikrant3",Gender = "Male",Email = "vikrant3@gmail.com",Id = 3,Role = "User"},
                new UserDetails() {FirstName = "Vikrant4",Gender = "Male",Email = "vikrant4@gmail.com",Id = 4,Role = "User"},
                new UserDetails() {FirstName = "Vikrant5",Gender = "Male",Email = "vikrant5@gmail.com",Id = 5,Role = "User"},
                new UserDetails() {FirstName = "Vikrant6",Gender = "Male",Email = "vikrant6@gmail.com",Id = 6,Role = "User"},
                new UserDetails() {FirstName = "Vikrant7",Gender = "Male",Email = "vikrant7@gmail.com",Id = 7,Role = "User"},
                new UserDetails() {FirstName = "Vikrant8",Gender = "Male",Email = "vikrant8@gmail.com",Id = 8,Role = "User"},
                new UserDetails() {FirstName = "Vikrant9",Gender = "Male",Email = "vikrant9@gmail.com",Id = 9,Role = "User"},
                new UserDetails() {FirstName = "Vikrant10",Gender = "Male",Email = "vikrant10@gmail.com",Id = 10,Role = "User"}
            };
            return userDetails;
        }

    }
}
