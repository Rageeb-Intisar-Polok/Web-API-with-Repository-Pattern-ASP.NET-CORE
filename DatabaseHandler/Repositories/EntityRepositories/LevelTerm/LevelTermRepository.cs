using DatabaseHandler.Context;
using DatabaseHandler.Models.EntityModels;
using DatabaseHandler.Repositories.CommonGenericRepository;
using Microsoft.EntityFrameworkCore;

namespace DatabaseHandler.Repositories.EntityRepositories.LevelTermRepository
{
    public class LevelTermRepository : CommonGenericRepository<LevelTerm>, ILevelTermRepository
    {
        private readonly ApplicationDbContext _context;
        public LevelTermRepository(ApplicationDbContext Context) : base(Context)
        {
            _context = Context;
        }

        public async Task<LevelTerm?> GetLevelTermEntity(int Level, string Term)
        {
            LevelTerm? LevelTerm = await _context.LevelTerm.Where(a => (a.Level == Level && a.Term == Term)).FirstOrDefaultAsync();
            return LevelTerm;
        }
        public async Task<LevelTerm?> GetLevelTermById(int id)
        {
            LevelTerm? LevelTerm = await _context.LevelTerm.FindAsync(id);
            return LevelTerm;
        }
    }
}
