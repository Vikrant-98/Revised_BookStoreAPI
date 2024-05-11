using ModelsLibrary.DataBaseModels.TempModel;
using RepositoryLayer.DatabaseServices;
using RepositoryLayer.IRepositoryServices;

namespace RepositoryLayer.RepositoryServices
{
    public class UserRepoServices : IUserRepoServices
    {
        private readonly DBService _dbService;
        public UserRepoServices(DBService dbService)
        {
            _dbService = dbService;
        }

        public async Task<UserDetails> GetUserDetails(int id) 
        {
            var result =  await _dbService.GetAllUserDetails().ConfigureAwait(false);
            return result.Where(x => x.Id == id).First();
        }

    }
}
