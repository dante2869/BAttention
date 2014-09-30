using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sln.Models;

namespace Sln.Controllers
{
    public class ReportesController : Controller
    {
        private EntidadSistema db = new EntidadSistema();

        // GET: /Reportes/
        public ActionResult Index()
        {
            ViewBag.Tratamiento = db.Tratamientoes.ToDictionary(p => p.Id, p => p.Nombre);
            ViewBag.Actividad = db.Actividads.ToDictionary(p => p.Id, p => p.Nombre);
            ViewBag.Usuario = db.Usuarios.ToList().Where(p => p.IdRol == 1 && p.Estado == true).OrderBy(p=>p.Apellido).ToDictionary(p => p.Id, p => p.Apellido + " " + p.Nombre);
            return View(db.VResultadoes.ToList());
        }

        [HttpPost]
        public ActionResult ListaFiltros([Bind(Include = "TRATAMIENTO,ACTIVIDAD,PACIENTE")] VResultado vresultado)
        {
            ViewBag.Tratamiento = db.Tratamientoes.ToDictionary(p => p.Id, p => p.Nombre);
            ViewBag.Actividad = db.Actividads.ToDictionary(p => p.Id, p => p.Nombre);
            ViewBag.Usuario = db.Usuarios.ToList().Where(p => p.IdRol == 1 && p.Estado == true).OrderBy(p => p.Apellido).ToDictionary(p => p.Id, p => p.Apellido + " " + p.Nombre);
            var lista = db.VResultadoes.ToList().Where(p => p.TRATAMIENTO.Contains((vresultado.TRATAMIENTO != null) ? vresultado.TRATAMIENTO : "") && p.ACTIVIDAD.Contains((vresultado.ACTIVIDAD != null) ? vresultado.ACTIVIDAD : "") && p.PACIENTE.Contains((vresultado.PACIENTE!=null)?vresultado.PACIENTE:""));
            return View(lista);
        }

        // GET: /Reportes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VResultado vresultado = db.VResultadoes.Find(id);
            if (vresultado == null)
            {
                return HttpNotFound();
            }
            return View(vresultado);
        }

        // GET: /Reportes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Reportes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TRATAMIENTO,ACTIVIDAD,PACIENTE,EDAD,SEXO,ACIERTOS,ERRORES")] VResultado vresultado)
        {
            if (ModelState.IsValid)
            {
                db.VResultadoes.Add(vresultado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vresultado);
        }

        // GET: /Reportes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VResultado vresultado = db.VResultadoes.Find(id);
            if (vresultado == null)
            {
                return HttpNotFound();
            }
            return View(vresultado);
        }

        // POST: /Reportes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TRATAMIENTO,ACTIVIDAD,PACIENTE,EDAD,SEXO,ACIERTOS,ERRORES")] VResultado vresultado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vresultado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vresultado);
        }

        // GET: /Reportes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VResultado vresultado = db.VResultadoes.Find(id);
            if (vresultado == null)
            {
                return HttpNotFound();
            }
            return View(vresultado);
        }

        // POST: /Reportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            VResultado vresultado = db.VResultadoes.Find(id);
            db.VResultadoes.Remove(vresultado);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
