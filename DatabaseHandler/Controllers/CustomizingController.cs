using CoreApiResponse;
using DatabaseHandler.Models.NonEntityModels.CustomizingDetailsModels;
using DatabaseHandler.Works.InitializationControllerWork;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseHandler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomizingController : BaseController
    {
        private readonly IInitialization _Initialize;
        public CustomizingController(IInitialization Initialize)
        {
            _Initialize= Initialize;
        }
        [HttpPost]
        public async Task<IActionResult> Initial([FromBody]InitializingModel Model)
        {
            try
            {
                string Message = await _Initialize.Initialize(Model);

                return CustomResult(Message);
            }
            catch (Exception Ex)
            {
                return CustomResult(Ex.Message, System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}
