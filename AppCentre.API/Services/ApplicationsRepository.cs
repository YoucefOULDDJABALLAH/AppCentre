using AppCentre.API.DTOs.InComing;
using AppCentre.API.DTOs.OutGoing;
using AppCentre.API.Models;
using System;
using System.Threading.Tasks;

namespace AppCentre.API.Services
{
    public class ApplicationsRepository: IApplicationsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ApplicationsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CreatedApplicationModelDTO> CreatedApplication(CreateApplicationModelDTO model)
        {
            try
            {
                var ApplicationID = Guid.NewGuid().ToString();
                model.ApplicationShortName = model.ApplicationShortName == string.Empty ? model.ApplicationName : model.ApplicationShortName;
                var result = _dbContext.AspNetApplications
                    .Add(new Applications
                    {
                        ApplicationsID = ApplicationID,
                        ApplicationsName = model.ApplicationName,
                        ShortName = model.ApplicationShortName
                    });
                await _dbContext.SaveChangesAsync();
                return new CreatedApplicationModelDTO
                {
                    ApplicationID = ApplicationID,
                    ApplicationName = model.ApplicationName,
                    ApplicationShortName = model.ApplicationShortName,
                    Message = $"{model.ApplicationName} was created successfuly !",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new CreatedApplicationModelDTO { Errors=ex.Message, IsSuccess =false};
            }
            
        }
    }
}
