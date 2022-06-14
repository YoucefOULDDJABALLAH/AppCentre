using AppCentre.API.DTOs.InComing;
using AppCentre.API.DTOs.OutGoing;
using AppCentre.API.Helpers;
using AppCentre.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
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
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly JWT _jwt;
        public UserRepository(UserManager<ApplicationUser> userManager, IMapper mapper, IOptions<JWT> jwt)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwt = jwt.Value;
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
                    errors += $"{err.Description}, ";
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


        public async Task<AuthenticatedModelDTO> LoginUser(LoginUserModelDTO model)
        {
            model.UserName += "@AppCentre.DRH";
            var user = await _userManager.FindByEmailAsync(model.UserName);
            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return new AuthenticatedModelDTO
                {
                    IsSuccess = false,
                    Message = "UserName or Password is incorrect !"
                };
            }
            var jwtSecurityToken = await CreateJwtToken(user);
            var roles = await _userManager.GetRolesAsync(user);
            return new AuthenticatedModelDTO
            {
                IsSuccess = true,
                Message = "Login user is success!",
                UserName = user.UserName,
                Matricule = user.Matricule,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Roles = roles.ToList()
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

