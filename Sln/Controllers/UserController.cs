using Sln.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sln.Controllers
{
    public class UserController : Controller
    {
        private EntidadSistema db = new EntidadSistema();

        [HttpPost]
        public ActionResult Login(string user, string psw)
        {
            var usuario = db.Usuarios.Where(p => p.Usuario1 == user && p.Clave == psw).SingleOrDefault();
            if (usuario != null)
            {
                Session["UsuarioLogin"] = usuario;
                Session["UsuarioNombre"] = usuario.Nombre.ToUpper() + " " + usuario.Apellido.ToUpper();
                Session["UsuarioRol"] = usuario.IdRol;
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logoff()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        
    }
}