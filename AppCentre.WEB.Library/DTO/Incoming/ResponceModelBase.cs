using System.Collections.Generic;

namespace AppCentre.WEB.Library.DTO.Incoming
{
    public class ResponceModelBase
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public string Errors { get; set; }
    }
}
