using DatabaseHandler.Context;
using DatabaseHandler.Models.EntityModels;
using DatabaseHandler.Repositories.CommonGenericRepository;
using Microsoft.EntityFrameworkCore;

namespace DatabaseHandler.Repositories.EntityRepositories.UserRepository
{
    public class UserRepository : CommonGenericRepository<Users>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext Context) : base(Context)
        {
            _context = Context;
        }

        public async Task<Users?> GetById(string Id)
        {
            Users? Users = await _context.Users.Where(x => x.ID == Id).FirstOrDefaultAsync();
            return Users;
        }
        
    }
}
