
using DatabaseHandler.Models.EntityModels;
using DatabaseHandler.Repositories.CommonGenericRepository;

namespace DatabaseHandler.Repositories.EntityRepositories.StudentRepository
{
    public interface IStudentRepository : ICommonGenericRepository<Students>
    {
        public Task<Students?> GetStudentByUniqueId(int IndividualId);
    }
}
