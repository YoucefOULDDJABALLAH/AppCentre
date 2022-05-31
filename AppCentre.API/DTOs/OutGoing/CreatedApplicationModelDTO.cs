namespace AppCentre.API.DTOs.OutGoing
{
    public class CreatedApplicationModelDTO:ResponceModelBase
    {
        public string ApplicationID { get; set; }
        public string ApplicationName { get; set; }
        public string ApplicationShortName { get; set; }
        
    }
}
