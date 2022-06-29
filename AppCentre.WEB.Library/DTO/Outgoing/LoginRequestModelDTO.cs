using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCentre.WEB.Library.DTO.Outgoing
{
    public class LoginRequestModelDTO
    {
        [Required(ErrorMessage = "Nom d'utilisateur est nécessaire")]
        [Display(Name ="Utilisateur")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Le mot de passe est requis")]
        [Display(Name = "Mots de passe")]
        [StringLength(30,ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
        public string Password { get; set; }   
    }
}
