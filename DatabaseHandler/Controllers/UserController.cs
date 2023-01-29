using CoreApiResponse;
using DatabaseHandler.Models.NonEntityModels.VisibleUserTypesEntityModels;
using DatabaseHandler.Works.UserControllerWork.AddNewUserWork;
using DatabaseHandler.Works.UserControllerWork.GetUserInformationWork;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseHandler.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IAddNewUser _addNewUser;
        private readonly IGetUserInformation _getUserInformation;
        public UserController(IAddNewUser addNewUser, IGetUserInformation getUserInformation)
        {
            _addNewUser = addNewUser;
            _getUserInformation = getUserInformation;
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] VisibleStudent student)
        {
            try
            {
                string message = await _addNewUser.AddStudent(student);
                return CustomResult(message);
            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, System.Net.HttpStatusCode.BadRequest);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddTeacher([FromBody] VisibleTeacher teacher)
        {
            try
            {
                string message = await _addNewUser.AddTeacher(teacher);
                return CustomResult(message);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, System.Net.HttpStatusCode.BadRequest);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddOfficial([FromBody] VisibleOfficial official)
        {
            try
            {
                string message = await _addNewUser.AddOfficial(official);
                return CustomResult(message);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, System.Net.HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUserInformation(string id)
        {
            try
            {
                var details = await _getUserInformation.AboutUser(id);
                return CustomResult(details);
            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}
