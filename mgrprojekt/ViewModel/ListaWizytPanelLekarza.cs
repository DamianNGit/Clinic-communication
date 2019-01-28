using mgrprojekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mgrprojekt.ViewModel
{
    public class ListaWizytPanelLekarza
    {
        public List<Wizyta> listaWizytLekarza { get; set; }

        public ListaWizytPanelLekarza()
        {
            listaWizytLekarza = new List<Wizyta>();
        }
    }
}