using mgrprojekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mgrprojekt.ViewModel
{
    public class RezerwacjaWizyty
    {
        public Lekarz Lekarz { get; set; }
        public List<Wizyta> Wizyty { get; set; }

        public string SelectedDate { get; set; }
        
        
    }
    
}