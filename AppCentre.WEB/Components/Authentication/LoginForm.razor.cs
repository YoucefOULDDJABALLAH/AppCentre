using AppCentre.WEB.Library.DTO.Incoming;
using AppCentre.WEB.Library.DTO.Outgoing;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AppCentre.WEB.Components
{
    public partial class LoginForm:ComponentBase
    {

        [Inject] public HttpClient httpClient { get; set; }
        [Inject] public NavigationManager navigationManager { get; set; }
        [Inject] public AuthenticationStateProvider authenticationStateProvider { get; set; }
        [Inject] public ILocalStorageService localStorage { get; set; }

        private bool _LogingIn;
        private string _errorMessage =string.Empty;
        LoginRequestModelDTO model = new LoginRequestModelDTO();
        bool success;
        private async Task OnValidSubmit(EditContext context)
        {
            _errorMessage = string.Empty;
            _LogingIn = true;

            try
            {
                var responce = await httpClient.PostAsJsonAsync("/api/Users/LoginUser", model);
                if (responce.IsSuccessStatusCode)
                {
                    var result = await responce.Content.ReadFromJsonAsync<LoginResponceModelDTO>();
                    success = true;
                    await localStorage.SetItemAsStringAsync("access_token", result.Token);
                    await authenticationStateProvider.GetAuthenticationStateAsync();
                    navigationManager.NavigateTo("/"); ShowSuccess = true;
                }
                else
                {
                    var errors = await responce.Content.ReadFromJsonAsync<LoginResponceModelDTO>();
                    _errorMessage = errors.Message;
                    success = false; ShowWarning = true;
                }
            }
            catch (System.Exception ex)
            {
                ShowWarning = true;
                success = false;
                _errorMessage = ex.Message;
            }
            
            _LogingIn = false;
            StateHasChanged();
        }
        private bool ShowWarning = false;
        private bool ShowSuccess = false;

        private void CloseMe(bool value,int type)
        {
            if (type == 1)
            {
                ShowWarning = !value;
            }
            if (type == 2)
            {
                ShowSuccess = !value;
            }
        }
    }
}
