using System.Collections.Generic;

namespace AppCentre.API.DTOs.OutGoing
{
    public class AuthenticatedModelDTO:ResponceModelBase
    {
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
        public List<string> Claims { get; set; }
    }
}
