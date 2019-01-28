using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mgrprojekt.Models
{
    public class PracownikObslugi
    {
        [Key]
        public int IdPracownika { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }
        public string Role { get; set; }
    }
}