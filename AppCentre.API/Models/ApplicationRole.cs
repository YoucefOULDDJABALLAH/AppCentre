using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AppCentre.API.Models
{
    public class ApplicationRole:IdentityRole
    {
        [Required,MaxLength(50),Display(Name = "Application Name")]
        public string ApplicationName { get; set; }
    }
}
