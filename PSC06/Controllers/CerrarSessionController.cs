using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PSC06.Controllers
{
    public class CerrarSessionController : Controller
    {
        // GET: CerrarSession
        public ActionResult Logoff()
        {
            Session["Usuario"] = null; // cierra la sesion
            return RedirectToAction("Login", "Acceder");
        }
    }
}