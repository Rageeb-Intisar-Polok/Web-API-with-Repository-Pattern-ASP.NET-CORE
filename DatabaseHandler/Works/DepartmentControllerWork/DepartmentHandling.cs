using DatabaseHandler.Context;
using DatabaseHandler.Models.EntityModels;
using DatabaseHandler.Models.NonEntityModels.VisibleUserTypesEntityModels;
using DatabaseHandler.Repositories.EntityRepositories.DepartmentRepository;

namespace DatabaseHandler.Works.DepartmentControllerWork
{
    public class DepartmentHandling : IDepartmentHandling
    {
        private readonly ApplicationDbContext _context;
        private readonly IDepartmentRepository _repository;
        public DepartmentHandling(ApplicationDbContext context, IDepartmentRepository repository)
        {
            _context = context;
            _repository = repository;
        }
        public async Task<string> AddDepartments(IEnumerable<VisibleDepartment> departments)
        {
            try
            {
                foreach(var VisibleInformation in departments)
                {
                    Department department = new()
                    {
                        DepartmentNameShortForm = VisibleInformation.DepartmentNameShortForm,
                        DepartmentName = VisibleInformation.DepartmentName
                    };

                    string Response = await _repository.Add(department);
                    if(Response != "Added")
                    {
                        throw new Exception(Response);
                    }
                }
                await _context.SaveChangesAsync();
                return "Departments Added Successfully.";
            }
            catch (Exception ex)
            {
                await _context.DisposeAsync();
                return ex.Message;
            }
        }
    }
}
