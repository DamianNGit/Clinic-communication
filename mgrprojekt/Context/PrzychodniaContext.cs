using mgrprojekt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mgrprojekt.Context
{
    public class PrzychodniaContext : DbContext
    {
        public PrzychodniaContext() :base("PrzychodniaContext")
        {

        }
        public DbSet<Lekarz> Lekarz { get; set; }
        public DbSet<Pacjent> Pacjent { get; set; }
        public DbSet<Wizyta> Wizyta { get; set; }
        public DbSet<PracownikObslugi> Pracownik { get; set; }
    }
}