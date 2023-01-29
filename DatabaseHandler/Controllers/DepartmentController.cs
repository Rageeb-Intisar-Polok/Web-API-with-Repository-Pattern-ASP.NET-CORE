using CoreApiResponse;
using DatabaseHandler.Models.NonEntityModels.VisibleUserTypesEntityModels;
using DatabaseHandler.Works.DepartmentControllerWork;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseHandler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentHandling _work;
        public DepartmentController(IDepartmentHandling work)
        {
            _work = work;
        }
        [HttpPost]
        public async Task<IActionResult> AddDepartment(IEnumerable<VisibleDepartment> Departments)
        {
            try
            {
                string Reply = await _work.AddDepartments(Departments);
                return CustomResult(Reply, System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}
