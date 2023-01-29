
using DatabaseHandler.Models.EntityModels;
using DatabaseHandler.Repositories.CommonGenericRepository;

namespace DatabaseHandler.Repositories.EntityRepositories.UserRepository
{
    public interface IUserRepository : ICommonGenericRepository<Users>
    {
        public Task<Users?> GetById(string Id);
    }
}
