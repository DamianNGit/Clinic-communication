using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace mgrprojekt.Security
{
    public static class SessionPersiter
    {
        static string sessionUserNameVar = "username";

        public static string Username
        {
            get
            {
                if(HttpContext.Current == null)
                {
                    return string.Empty;
                }
                else
                {
                    var sessionVar = HttpContext.Current.Session[sessionUserNameVar];
                    if (sessionVar != null)
                    {
                        return sessionVar as string;
                    }
                    else
                        return null;
                }
            }
            set
            {
                HttpContext.Current.Session[sessionUserNameVar] = value;
            }
        }
    }
}