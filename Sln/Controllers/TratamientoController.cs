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
    public class TratamientoController : Controller
    {
        private EntidadSistema db = new EntidadSistema();

        // GET: /Tratamiento/
        public ActionResult Index()
        {
            return View(db.Tratamientoes.ToList());
        }

        // GET: /Tratamiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tratamiento tratamiento = db.Tratamientoes.Find(id);
            if (tratamiento == null)
            {
                return HttpNotFound();
            }
            return View(tratamiento);
        }

        // GET: /Tratamiento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Tratamiento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nombre,Descripcion,Estado,FechaCreacion,UsuarioCreacion,FechaModificacion,UsuarioModificacion")] Tratamiento tratamiento)
        {
            if (ModelState.IsValid)
            {
                db.Tratamientoes.Add(tratamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tratamiento);
        }

        // GET: /Tratamiento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tratamiento tratamiento = db.Tratamientoes.Find(id);
            if (tratamiento == null)
            {
                return HttpNotFound();
            }
            return View(tratamiento);
        }

        // POST: /Tratamiento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nombre,Descripcion,Estado,FechaCreacion,UsuarioCreacion,FechaModificacion,UsuarioModificacion")] Tratamiento tratamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tratamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tratamiento);
        }

        // GET: /Tratamiento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tratamiento tratamiento = db.Tratamientoes.Find(id);
            if (tratamiento == null)
            {
                return HttpNotFound();
            }
            return View(tratamiento);
        }

        // POST: /Tratamiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tratamiento tratamiento = db.Tratamientoes.Find(id);
            db.Tratamientoes.Remove(tratamiento);
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
