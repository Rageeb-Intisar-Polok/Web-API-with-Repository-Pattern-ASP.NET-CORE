using DatabaseHandler.Context;
using DatabaseHandler.Models.EntityModels;
using DatabaseHandler.Repositories.CommonGenericRepository;
using Microsoft.EntityFrameworkCore;

namespace DatabaseHandler.Repositories.EntityRepositories.StudentRepository
{
    public class StudentRepository : CommonGenericRepository<Students>, IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext Context) : base(Context)
        {
            _context = Context;
        }

        public async Task<Students?> GetStudentByUniqueId(int IndividualId)
        {
            Students? User = await _context.Students.Where(x => x.IndividualId == IndividualId).FirstOrDefaultAsync();
            return User;
        }
    }
}
