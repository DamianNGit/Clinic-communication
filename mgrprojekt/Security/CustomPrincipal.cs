using mgrprojekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace mgrprojekt.Security
{
    public class CustomPrincipal : IPrincipal
    {
        public PracownikObslugi Acc { get; set; }
        public AccountsPracownikOb apo = new AccountsPracownikOb();
        public IIdentity Identity { get; set; }

        public CustomPrincipal(PracownikObslugi account)
        {
            this.Acc = account;
            this.Identity = new GenericIdentity(account.Login);
        }
        public bool IsInRole(string role)
        {
            var rol = role.Split(',');
            return rol.Any(r=>this.Acc.Role.Contains(r));
        }
    }
}