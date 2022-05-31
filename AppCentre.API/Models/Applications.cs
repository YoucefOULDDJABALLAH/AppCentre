using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppCentre.API.Models
{
    [Index(nameof(ApplicationsName), IsUnique = true)]
    [Index(nameof(ShortName), IsUnique = true)]
    public class Applications
    {
        [Key]
        public string ApplicationsID { get; set; }
       public string ApplicationsName { get; set; }
        public string ShortName { get; set; }
    }
}
