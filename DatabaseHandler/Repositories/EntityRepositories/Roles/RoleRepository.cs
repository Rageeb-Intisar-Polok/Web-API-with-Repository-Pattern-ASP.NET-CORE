using DatabaseHandler.Context;
using DatabaseHandler.Models.EntityModels;
using DatabaseHandler.Repositories.CommonGenericRepository;
using Microsoft.EntityFrameworkCore;

namespace DatabaseHandler.Repositories.EntityRepositories.RolesRepository
{
    public class RoleRepository : CommonGenericRepository<Role>, IRoleRepository
    {
        ApplicationDbContext _context;
        public RoleRepository(ApplicationDbContext Context) : base(Context)
        {
            _context = Context;
        }
        public async Task<Role?> GetByName(string Name)
        {
            Role? Role = await _context.Roles.Where(x => x.RoleName == Name).FirstOrDefaultAsync();
            return Role;
        }
        public async Task<Role?> GetRoleId(int Id)
        {
            Role? Role = await _context.Roles.FindAsync(Id);
            return Role;
           // return _context.roles.Find(id);
        }
    }
}
