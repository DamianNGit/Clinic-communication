using mgrprojekt.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mgrprojekt.Models
{
    public class AccountsPracownikOb
    {
        private static List<PracownikObslugi> konta = new List<PracownikObslugi>();
        PrzychodniaContext db = new PrzychodniaContext();

        public AccountsPracownikOb()
        {
            konta = db.Pracownik.ToList();
        }

        public PracownikObslugi find(string l)
        {
            return konta.Where(k => k.Login.ToLower().Equals(l.ToLower())).FirstOrDefault();
        }

        public PracownikObslugi login(string l, string p)
        {
            return konta.Where(k => k.Login.ToLower() == l.ToLower() && k.Haslo ==p).FirstOrDefault();
        }
    }
}