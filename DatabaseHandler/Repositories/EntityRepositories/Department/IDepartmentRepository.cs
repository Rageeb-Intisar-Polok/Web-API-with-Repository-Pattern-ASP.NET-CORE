using DatabaseHandler.Models.EntityModels;
using DatabaseHandler.Repositories.CommonGenericRepository;

namespace DatabaseHandler.Repositories.EntityRepositories.DepartmentRepository

{
    public interface IDepartmentRepository : ICommonGenericRepository<Department>
    {
        public Task<Department?> GetDepartmentById(int Id);
        public Task<Department?> GetDepartmentByName(string Name);
        public Task<Department?> GetDepartmentByShortForm(string ShortForm);
        public new Task<string> Add(Department Departments);
    }
}
