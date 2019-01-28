using mgrprojekt.Context;
using mgrprojekt.Models;
using mgrprojekt.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mgrprojekt.Controllers
{
    public class PlanowanieWizytController : Controller
    {
        PrzychodniaContext db = new PrzychodniaContext();
        static List<Lekarz> listaLekarzy;

        // GET: PlanowanieWizyt
        public ActionResult ListaLekarzy()
        {

            listaLekarzy = db.Lekarz.ToList();
            db.Dispose();
            return PartialView("ListaLekarzy", listaLekarzy);
        }

        public ActionResult KalendarzRezerwacji(int id)
        {
            Lekarz lekarz = db.Lekarz.Where(a => a.IdLekarz == id).Single();//listaLekarzy.Where(a => a.IdLekarz == id).Single();
            
            return View(lekarz);
        }

        public ActionResult PanelRezerwacjiGodz(string selectedDate, int lekarz, string selectedDay)
        {
            Lekarz lekarzSingle = listaLekarzy.Where(a => a.IdLekarz == lekarz).Single();
            string[] tmp;
            string tmpOK;
            List<Wizyta> wizyty=null;
 
            wizyty = db.Wizyta.Where(w => w.Lekarz.IdLekarz == lekarz && w.DataWizyty==selectedDate).Select(w => w).ToList();
            
            string dayOfWeek = DateTime.Parse(selectedDate).DayOfWeek.ToString();
            RezerwacjaWizyty rw = new RezerwacjaWizyty()
            {
                Lekarz = lekarzSingle,
                Wizyty = wizyty,
                SelectedDate = selectedDate + " " + dayOfWeek
            };
            return View(rw);
        }

        //Get        
        public ActionResult PlanerWizyt()
        {
            return View();
        }
        


        //Get
        public ActionResult RezerwujWizyte(string date, string godzina, int? idLekarza)
        {
            //Lekarz lekarz = db.Lekarz.Where(a => a.IdLekarz == idLekarza).Single();
            Lekarz lekarz = listaLekarzy.Where(a => a.IdLekarz == idLekarza).Single();
            ViewData["Imie"] = lekarz.Imie;
            ViewData["Nazwisko"] = lekarz.Nazwisko;
            ViewData["Id"] = lekarz.IdLekarz;
            ViewData["date"] = date;
            ViewData["godzina"] = godzina;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RezerwujWizyte(DaneDoRezerwacjiWizyty dane)
        {
            if(dane.Wizyta.Lekarz==null)
            {
                dane.Wizyta.Lekarz = db.Lekarz.Where(a => a.IdLekarz == dane.IDLekarz).Single();
            }

            if (dane.Pacjent.Imie!=null && dane.Pacjent.Nazwisko!=null && dane.Pacjent.NrPSEL!=null && dane.Pacjent.NrTel!=null && dane.Pacjent.AdresZameldowania!=null)//ModelState.IsValid)
            {               
                dane.Wizyta.Pacjent = dane.Pacjent;
                db.Pacjent.Add(dane.Pacjent);
                db.Wizyta.Add(dane.Wizyta);
                db.SaveChanges();
                db.Dispose();
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View(dane);
            }
        }      
    }
}