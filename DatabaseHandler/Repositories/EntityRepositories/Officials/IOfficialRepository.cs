
using DatabaseHandler.Models.EntityModels;
using DatabaseHandler.Repositories.CommonGenericRepository;

namespace DatabaseHandler.Repositories.EntityRepositories.StudentRepository
{
    public interface IOfficialRepository :ICommonGenericRepository<Officials>
    {
        public Task<Officials?> GetOfficialByUniqueId(int IndividualId);
    }
}
