using AppCentre.WEB.Library.Helpers;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppCentre.WEB
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("AppCentre.Api", client => { client.BaseAddress = new Uri("https://localhost:44366/"); })
                            .AddHttpMessageHandler<AuthorizationMessageHandler>();
            builder.Services.AddTransient<AuthorizationMessageHandler>();
            builder.Services.AddScoped(sp=>sp.GetService<IHttpClientFactory>().CreateClient("AppCentre.Api"));
            builder.Services.AddMudServices();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthenticationStateProvider>();
            await builder.Build().RunAsync();
        }
    }
}
