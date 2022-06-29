using AppCentre.WEB.Library.DTO.Outgoing;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Threading.Tasks;

namespace AppCentre.WEB.Components
{
    public partial class LoginForm:ComponentBase
    {
        private bool _LogingIn;
        LoginRequestModelDTO model = new LoginRequestModelDTO();
        bool success;
        private async Task OnValidSubmit(EditContext context)
        {
            _LogingIn = true;
            await Task.Delay(5000);
            success = true;
            _LogingIn = false;
            StateHasChanged();
        }
    }
}
