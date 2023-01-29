using DatabaseHandler.Context;
using DatabaseHandler.Models.EntityModels;
using DatabaseHandler.Repositories.CommonGenericRepository;
using Microsoft.EntityFrameworkCore;

namespace DatabaseHandler.Repositories.EntityRepositories.TeacherRepository
{
    public class TeacherRepository : CommonGenericRepository<Teachers>, ITeacherRepository
    {
        private readonly ApplicationDbContext _context;
        public TeacherRepository(ApplicationDbContext Context) : base(Context)
        {
            _context = Context;
        }

        public async Task<Teachers?> GetTeacherByUniqueId(int individualId)
        {
            Teachers? User = await _context.Teachers.Where(x => x.IndividualId == individualId).FirstOrDefaultAsync();
            return User;
        }

    }
}
