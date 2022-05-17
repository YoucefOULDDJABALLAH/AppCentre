using AppCentre.API.DTOs.InComing;
using AppCentre.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AppCentre.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public UserRegistrationController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser(RegisterationModelDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authRepository.RegisterUser(model);
            if (!result.IsSuccess)
            {
                BadRequest(result.Errors);
            }
            return Ok(result);
        }
    }
}
