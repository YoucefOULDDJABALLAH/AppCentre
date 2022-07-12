using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCentre.WEB.Library.DTO.Incoming
{
    public class LoginResponceModelDTO : ResponceModelBase
    {
        public string UserName { get; set; }
        public string Matricule { get; set; }
        public string Token { get; set; }
        public List<string> Roles { get; set; }
        public List<string> Claims { get; set; }
    }
}
