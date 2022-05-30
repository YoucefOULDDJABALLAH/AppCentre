using AppCentre.API.DTOs.InComing;
using AppCentre.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AppCentre.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesRepository _rolesRepository;
        public RolesController(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }
        [HttpPost]
        [Route("AddUsertoRole")]
        public async Task<IActionResult> AddUserToRole(AddUserToRoleModelDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _rolesRepository.AddUserToRole(model);
            if (!result.IsSuccess)
            {
                BadRequest(result.Errors);
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("CreateNewRole")]
        public async Task<IActionResult> CreateNewRole(CreateNewRoleModelDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _rolesRepository.CreateNewRole(model);
            if (!result.IsSuccess)
            {
                BadRequest(result.Errors);
            }
            return Ok(result);
        }
    }
}
