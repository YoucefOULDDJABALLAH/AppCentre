using AppCentre.API.DTOs.InComing;
using AppCentre.API.DTOs.OutGoing;
using AppCentre.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace AppCentre.API.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager; 
        private readonly IMapper _mapper;
        public AuthRepository(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<AuthenticatedModelDTO> RegisterUser(RegisterationModelDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user is not null) return new AuthenticatedModelDTO { Message = "UserName Already Exist !",IsSuccess=false };
            user = _mapper.Map<ApplicationUser>(model);
            var result = await _userManager.CreateAsync(user,model.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;
                foreach (var err in result.Errors)
                {
                    errors += $"{ err}, ";
                }
                return new AuthenticatedModelDTO { Errors = errors, Message = "Registration failed !", IsSuccess = false };
            }

        }
    }
}
