using AppCentre.API.DTOs.InComing;
using AppCentre.API.DTOs.OutGoing;
using AppCentre.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCentre.API.Services
{
    public class RolesRepository: IRolesRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;

        public RolesRepository(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }


        public async Task<AuthenticatedModelDTO> AddUserToRole(AddUserToRoleModelDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            var role = await _roleManager.FindByNameAsync(model.RoleName);
            if (user == null || role == null) { return new AuthenticatedModelDTO { IsSuccess = false, Message = $"Role or user not found !" }; }
            var result = await _userManager.AddToRoleAsync(user, model.RoleName);
            if (! result.Succeeded)
            {
                string errors = string.Empty;
                foreach (var err in result.Errors)
                {
                    errors += err.Description;
                }
                return new AuthenticatedModelDTO { IsSuccess = false, Message = errors };
            }
            return new AuthenticatedModelDTO
            {
                IsSuccess = true,
                Message = $"{model.UserName} is added as {model.RoleName} successfuly !",
                Roles = (List<string>)await _userManager.GetRolesAsync(user),
                UserName = model.UserName,
                Matricule= user.Matricule,
                Claims = (await _userManager.GetClaimsAsync(user)).Select(e => e.Value).ToList()
            };
           
        }

        public async Task<CreatedRoleModelDTO> CreateNewRole(CreateNewRoleModelDTO model)
        {
            var role = await _roleManager.FindByNameAsync(model.RoleName);
            if (role is not null && role.ApplicationsID == model.ApplicationID)
            {
                return new CreatedRoleModelDTO { Message=$"{model.RoleName} already exists in {model.ApplicationID}"};
            }
            var newRole = new ApplicationRole
            {
                ApplicationsID = model.ApplicationID,
                Name = model.RoleName,
                NormalizedName = model.RoleName,
                Id = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };
            var result = await _roleManager.CreateAsync(newRole);
            if (!result.Succeeded)
            {
                string error=string.Empty;
                foreach (var err in result.Errors)
                {
                    error += $"{err.Description}, ";
                }
                return new CreatedRoleModelDTO
                {
                    Message = "Errors Occured !",
                    Errors = error,
                    IsSuccess = false,
                    ApplicationID = model.ApplicationID,
                    RoleName = model.RoleName
                };
            }
            var output = _mapper.Map<CreatedRoleModelDTO>(newRole);
            output.IsSuccess = true;
            output.Message = "Role Created successfuly !";
            return output;
        }
    }
}
