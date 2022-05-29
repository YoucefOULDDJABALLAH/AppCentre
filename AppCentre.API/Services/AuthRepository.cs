using AppCentre.API.DTOs.InComing;
using AppCentre.API.DTOs.OutGoing;
using AppCentre.API.Helpers;
using AppCentre.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AppCentre.API.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly JWT _jwt;
        public AuthRepository(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<AuthenticatedModelDTO> RegisterUser(RegisterationModelDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user is not null)
                return new AuthenticatedModelDTO { Message = "UserName Already Exist !", IsSuccess = false };

            user = _mapper.Map<ApplicationUser>(model);
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;
                foreach (var err in result.Errors)
                {
                    errors += $"{ err.Description}, ";
                }
                return new AuthenticatedModelDTO { Errors = errors, Message = "Registration failed !", IsSuccess = false };
            }

            var jwtSecurityToken = await CreateJwtToken(user);

            return new AuthenticatedModelDTO
            {
                Message = "User created successfuly !",
                IsSuccess = true,
                UserName = user.UserName,
                Matricule = user.Matricule,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
            };

        }

        public async Task<AuthenticatedModelDTO> AddUserToRole(AddUserToRoleModelDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            var result = await _userManager.AddToRoleAsync(user, model.RoleName);
            if (!result.Succeeded)
            {
                var errors = string.Empty;
                foreach (var err in result.Errors)
                {
                    errors += $"{err}, ";
                }
                return new AuthenticatedModelDTO
                {
                    Errors = errors,
                    Message = $"Adding {model.UserName} to {model.RoleName}"
                };
            }
            var roles = await _userManager.GetRolesAsync(user);
            var claims = (await _userManager.GetClaimsAsync(user)).Select(e => e.Value).ToList();


            return new AuthenticatedModelDTO
            {
                UserName = model.UserName,
                Roles = roles.ToList(),
                Claims = claims,
                Message = "User add to Role successfuly!"
            };
        }

        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
