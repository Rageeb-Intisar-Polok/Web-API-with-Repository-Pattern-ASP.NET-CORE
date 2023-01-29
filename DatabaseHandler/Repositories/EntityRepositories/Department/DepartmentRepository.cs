using DatabaseHandler.Context;
using DatabaseHandler.Models.EntityModels;
using DatabaseHandler.Repositories.CommonGenericRepository;
using Microsoft.EntityFrameworkCore;
namespace DatabaseHandler.Repositories.EntityRepositories.DepartmentRepository
{
    public class DepartmentRepository : CommonGenericRepository<Department> , IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext Context) : base(Context)
        {
            _context = Context;
        }

        public async Task<Department?> GetDepartmentById(int Id)
        {
            Department? Department;
            Department = await _context.Departments.FindAsync(Id);
            return Department;
        }
        public async Task<Department?> GetDepartmentByName(string Name)
        {
            Department? Department = await _context.Departments.Where(x => x.DepartmentName == Name).FirstOrDefaultAsync();
            return Department;
        }
        public async Task<Department?> GetDepartmentByShortForm(string ShortForm)
        {
            Department? Department = await _context.Departments.Where(x=> x.DepartmentNameShortForm == ShortForm).FirstOrDefaultAsync();
            return Department;
        }

        public new async Task<string> Add(Department Department)
        {
            Department? DepartmentFromDatabase = await GetDepartmentByName(Department.DepartmentName);
            if(DepartmentFromDatabase != null)
            {
                return "Department Name duplication.";
            }
            DepartmentFromDatabase = await GetDepartmentByShortForm(Department.DepartmentNameShortForm);
            if(DepartmentFromDatabase != null)
            {
                return "Department Short Form duplication.";
            }

            await _context.Departments.AddAsync(Department);

            return "Added";
        }
    }
}
