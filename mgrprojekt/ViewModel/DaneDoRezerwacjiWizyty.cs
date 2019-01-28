using mgrprojekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace mgrprojekt.ViewModel
{
    public class DaneDoRezerwacjiWizyty
    {
        public Pacjent Pacjent { get; set; }
        public Wizyta Wizyta { get; set; }
        public int IDLekarz { get; set; }
    }
}