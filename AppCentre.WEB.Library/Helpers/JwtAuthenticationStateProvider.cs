using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AppCentre.WEB.Library.Helpers
{
    public class JwtAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;

        public JwtAuthenticationStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (await _localStorage.ContainKeyAsync("access_token"))
            {
                var tokenAsString = await _localStorage.GetItemAsStringAsync("access_token");
                var tokenHandler = new JwtSecurityTokenHandler();

                var token = tokenHandler.ReadJwtToken(tokenAsString);
                var identity = new ClaimsIdentity(token.Claims,"Bearer");
                var user= new ClaimsPrincipal(identity);
                var authstate = new AuthenticationState(user);
                NotifyAuthenticationStateChanged(Task.FromResult(authstate));
                return authstate;
            }
            return new AuthenticationState(new ClaimsPrincipal());
        }
    }
}
