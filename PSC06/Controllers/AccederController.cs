using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PSC06.Models;

namespace PSC06.Controllers
{
    public class AccederController : Controller
    {
        // GET: Acceder
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Enter(string _usuario, string _password)
        {
            // abrimos la entidad, se refiere a la base de datos
            using (DBMVCEntities db = new DBMVCEntities())
            {
                // SELECT * FROM USERS WHERE EMAIL = _USUARIO AND PASSWORD = _PASSWORD AND IDESTATUS = 1
                var _read = from d in db.USERS
                            where d.Email == _usuario
                            && d.Password == _password
                            && d.idEstatus == 1
                            select d;

                if(_read.Count() >0 ) // verifica si tiene data el contenedor 
                {
                    Session["Usuario"] = _read.First(); // creamos la sesion
                    return Content("1"); // retorna que la sesion está activa a la vista
                }
                else
                {
                    return Content("Revisa el usuario y la clave de usuario :("); // enviamos un mensaje a la vista
                }
            }
        }
    }
}