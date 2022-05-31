using AppCentre.API.DTOs.InComing;
using AppCentre.API.DTOs.OutGoing;
using System.Threading.Tasks;

namespace AppCentre.API.Services
{
    public interface IUserRepository
    {
        Task<AuthenticatedModelDTO> AddUserToRole(AddUserToRoleModelDTO model);
        Task<AuthenticatedModelDTO> RegisterUser(RegisterationModelDTO model);
    }
}
