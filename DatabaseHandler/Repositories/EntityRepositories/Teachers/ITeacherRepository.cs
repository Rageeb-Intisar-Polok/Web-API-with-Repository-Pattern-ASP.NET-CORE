
using DatabaseHandler.Models.EntityModels;
using DatabaseHandler.Repositories.CommonGenericRepository;

namespace DatabaseHandler.Repositories.EntityRepositories.TeacherRepository
{
    public interface ITeacherRepository : ICommonGenericRepository<Teachers>
    {
        public Task<Teachers?> GetTeacherByUniqueId(int IndividualId);

    }
}
