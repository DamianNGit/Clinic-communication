using mgrprojekt.Context;
using mgrprojekt.Models;
using mgrprojekt.Security;
using mgrprojekt.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mgrprojekt.Controllers
{
    public class PanelPracownikaController : Controller
    {
        PrzychodniaContext db = new PrzychodniaContext();


        // GET: PanelPracownika
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            ViewData["Msg"] = string.Empty;
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account user)
        {
            AccountsPracownikOb acc = new AccountsPracownikOb();
            
                if (string.IsNullOrEmpty(user.Login) || string.IsNullOrEmpty(user.Haslo) || acc.login(user.Login, user.Haslo) == null)
                {
                    ViewData["Msg"] = "true";
                    return View("Index");
                }
                else
                {
                    ViewData["Msg"] = "false";
                    SessionPersiter.Username = user.Login;
                return RedirectToAction("ListaWizyt");
                }
        }

        [CustomAutorizeAtt(Roles = "Doctor")]
        public ActionResult ListaWizyt(string date)
        {
            string[] imie_nazwisko = SessionPersiter.Username.Split('.');
            string imie = imie_nazwisko[0];
            string nazwisko =imie_nazwisko[1];
            Lekarz lekarz = db.Lekarz.Where(p => p.Imie.Equals(imie) && p.Nazwisko.Equals(nazwisko)).Single();
            if (date == null)
            {
                date = DateTime.Now.ToShortDateString();
                if (date.Contains('.'))
                {
                    string[] splitDate = date.Split('.');
                    date = string.Format("{0}-{1}-{2}", splitDate[2], splitDate[1], splitDate[0]);
                }
            }

            List<Wizyta> listaWizyt = lekarz.ListaWizyt.Where(p => p.DataWizyty == date).Select(p => p).ToList();
            ViewData["date"] = date;
            ListaWizytPanelLekarza viewmodel = new ListaWizytPanelLekarza();
            if (listaWizyt.Count==0)
            {
                return View(viewmodel);
            }
            else
            {               
                foreach (Wizyta w in listaWizyt)
                {
                    if (w.Pacjent.Imie != null && w.Pacjent.Nazwisko != null && w.Pacjent.NrPSEL != null && w.Pacjent.NrTel != null && w.Pacjent.AdresZameldowania != null)
                        viewmodel.listaWizytLekarza.Add(w);
                }
                return View(viewmodel);
            }
            
        }

        public ActionResult Logout()
        {
            SessionPersiter.Username = string.Empty;
            return RedirectToAction("Index", "Home");
        }

    }
}