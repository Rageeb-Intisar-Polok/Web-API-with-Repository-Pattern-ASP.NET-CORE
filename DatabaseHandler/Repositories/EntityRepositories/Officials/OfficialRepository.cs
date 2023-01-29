using DatabaseHandler.Context;
using DatabaseHandler.Models.EntityModels;
using DatabaseHandler.Repositories.CommonGenericRepository;
using Microsoft.EntityFrameworkCore;

namespace DatabaseHandler.Repositories.EntityRepositories.StudentRepository
{
    public class OfficialRepository : CommonGenericRepository<Officials> ,IOfficialRepository
    {
        private readonly ApplicationDbContext _context;
        public OfficialRepository(ApplicationDbContext Context) : base(Context)
        {
            _context= Context;
        }
        public async Task<Officials?> GetOfficialByUniqueId(int IndividualId)
        {
            Officials? User = await _context.Officials.Where(x => x.IndividualId == IndividualId).FirstOrDefaultAsync();
            return User;
        }
    }
}
