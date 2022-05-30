using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AppCentre.API.Models
{
    public class ApplicationRole:IdentityRole
    {
        public string ApplicationsID { get; set; }
        public Applications App { get; set; }
    }
}
