using DatabaseHandler.Models.NonEntityModels.VisibleUserTypesEntityModels;

namespace DatabaseHandler.Works.DepartmentControllerWork
{
    public interface IDepartmentHandling
    {
        public Task<string> AddDepartments(IEnumerable<VisibleDepartment> departments);
    }
}
