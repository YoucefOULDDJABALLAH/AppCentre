using AppCentre.API.DTOs.InComing;
using AppCentre.API.DTOs.OutGoing;
using System.Threading.Tasks;

namespace AppCentre.API.Services
{
    public interface IRolesRepository
    {
        Task<AuthenticatedModelDTO> AddUserToRole(AddUserToRoleModelDTO model);
        Task<CreatedRoleModelDTO> CreateNewRole(CreateNewRoleModelDTO model);
    }
}
