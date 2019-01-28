using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mgrprojekt.Models
{
    public class Pacjent
    {
        [Key]
        public int IdPacjenta { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Imie { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public string NrPSEL { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public string NrTel { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public string AdresZameldowania { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        public virtual List<Wizyta> Wizyta { get; set; } 
    }
}