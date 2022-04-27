using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AppCentre.API.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required,MaxLength(5)]
        public string Matricule { get; set; }
        [Required]
        public int NN { get; set; }
        [Required, MaxLength]
        public int Grade { get; set; }
        [Required, MaxLength(50)]
        public string Service { get; set; }
        [Required, MaxLength(50)]
        public string Nom { get; set; }
        [Required, MaxLength(50)]
        public string Prenom { get; set; }
        [Required, MaxLength(50)]
        public string ApplicationName { get; set; }

    }
}
