using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mgrprojekt.Models
{
    public class Wizyta
    {
        [Key]
        public int IdWizyty { get; set; }

        public string DataWizyty { get; set; }
        public string GodzinaWizyty { get; set; }

        public virtual Pacjent Pacjent { get; set; }

        public virtual Lekarz Lekarz { get; set; }
    }
}