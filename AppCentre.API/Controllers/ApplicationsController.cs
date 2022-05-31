using AppCentre.API.DTOs.InComing;
using AppCentre.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AppCentre.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationsRepository _applicationsRepository;
        public ApplicationsController(IApplicationsRepository applicationsRepository)
        {
            _applicationsRepository = applicationsRepository;
        }
        [HttpPost]
        [Route("CreatedApplication")]
        public async Task<IActionResult> CreatedApplication(CreateApplicationModelDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _applicationsRepository.CreatedApplication(model);
            if (!result.IsSuccess)
            {
                BadRequest(result.Errors);
            }
            return Ok(result);
        }
    }
}
