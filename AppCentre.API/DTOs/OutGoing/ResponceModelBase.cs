using System.Collections.Generic;

namespace AppCentre.API.DTOs.OutGoing
{
    public class ResponceModelBase
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }
    }
}
