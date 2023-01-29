
using DatabaseHandler.Models.EntityModels;
using DatabaseHandler.Repositories.CommonGenericRepository;

namespace DatabaseHandler.Repositories.EntityRepositories.LevelTermRepository
{
    public interface ILevelTermRepository : ICommonGenericRepository<LevelTerm>
    {
        public Task<LevelTerm?> GetLevelTermEntity(int Level, string Term);
        public Task<LevelTerm?> GetLevelTermById(int id);
    }

}
