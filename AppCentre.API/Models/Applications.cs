using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppCentre.API.Models
{
    public class Applications
    {
        public string ApplicationsID { get; set; }
        public string ApplicationsName { get; set; }
        public string ShortName { get; set; }
    }
}
