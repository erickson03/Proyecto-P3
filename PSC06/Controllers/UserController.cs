using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PSC06.Models;
using PSC06.Models.ViewModels;

namespace PSC06.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Query()
        {
            List<QueryViewModels> lst = null; // Creamos un objeto List llamado lst, que contendrá la data según el script de SQL

            using(DBMVCEntities db = new DBMVCEntities())
            {
                // SELECT * FROM USERS WHERE IDESTATUS = 1 ORDER BY EMAIL

                lst = (from d in db.USERS 
                       where d.idEstatus == 1 
                       orderby d.Email
                       
                       // Seleccionamos el modelo a usar como interprete
                       select new QueryViewModels
                       {
                           // Asignamos los valores de cada columnda de la tabla a las columnas del modelo
                         _Email = d.Email,
                         _Edad = d.Edad,
                         _Id = d.ID
                       }).ToList();
            }
            return View(lst); // Aqui enviamos la data a la vista
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddUserViewModels model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new DBMVCEntities())
            {
                USER ou = new USER();

                ou.idEstatus = 1;
                ou.Edad = model._Edad;
                ou.Password = model._Clave;
                ou.Nombre = model._Nombre;
                ou.Email = model._Correo;

                db.USERS.Add(ou);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/User/Query"));
        }

        [HttpGet]
        public ActionResult Edit(int _Id)
        {
            EditUserViewModels model = new EditUserViewModels();

            using (var db = new DBMVCEntities())
            {
                var ou = db.USERS.Find(_Id);

                model._Nombre = ou.Nombre;
                model._Clave = ou.Password;
                model._Correo = ou.Email;
                model._Edad = ou.Edad;
                model._Id = ou.ID;

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(EditUserViewModels model)
        {
            using (var db = new DBMVCEntities())
            {
                var ou = db.USERS.Find(model._Id);

                ou.Nombre = model._Nombre;
                ou.Email = model._Correo;
                ou.Edad = model._Edad;

                if (model._Clave != null || model._Clave != "")
                {
                    ou.Password = model._Clave;
                }

                db.Entry(ou).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/Query"));
        }

        [HttpPost]
        public ActionResult BorrarRegistro(int ID)
        {
            using (var db = new DBMVCEntities())
            {
                var ou = db.USERS.Find(ID);

                ou.idEstatus = 3;

                db.Entry(ou).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
        }
    }
}