using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mgrprojekt.Models
{
    public class Lekarz
    {
        [Key]
        public int IdLekarz { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public string NrTel { get; set; }
        public string GodzinyPrzyjmowania { get; set; }

        public string DniPrzyjowania { get; set; }

        public int NrGabinetu { get; set; }

        public string Specjalizacja { get; set; }

        public virtual List<Wizyta> ListaWizyt { get; set; }
    }
}