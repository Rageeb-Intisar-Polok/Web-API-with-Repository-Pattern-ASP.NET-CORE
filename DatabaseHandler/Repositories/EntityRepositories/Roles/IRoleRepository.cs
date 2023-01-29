
using DatabaseHandler.Models.EntityModels;
using DatabaseHandler.Repositories.CommonGenericRepository;

namespace DatabaseHandler.Repositories.EntityRepositories.RolesRepository
{
    public interface IRoleRepository : ICommonGenericRepository<Role>
    {
        public Task<Role?> GetByName(string name);
        public Task<Role?> GetRoleId(int id);
    }
}
