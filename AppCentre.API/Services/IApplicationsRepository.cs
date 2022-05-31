using AppCentre.API.DTOs.InComing;
using AppCentre.API.DTOs.OutGoing;
using System.Threading.Tasks;

namespace AppCentre.API.Services
{
    public interface IApplicationsRepository
    {
        Task<CreatedApplicationModelDTO> CreatedApplication(CreateApplicationModelDTO model);
    }
}
