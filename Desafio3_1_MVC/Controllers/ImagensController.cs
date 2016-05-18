using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Desafio3_1_MVC.Models;

namespace Desafio3_1_MVC.Content
{
    public class ImagensController : Controller
    {
        private Desafio3_1_MVCContext db = new Desafio3_1_MVCContext();

        // GET: Imagens
        public ActionResult Index()
        {
            return View(db.Imagens.ToList());
        }

        // GET: Imagens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagen imagen = db.Imagens.Find(id);
            if (imagen == null)
            {
                return HttpNotFound();
            }
            return View(imagen);
        }

        // GET: Imagens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Imagens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FormatoImagen,Nombre,Patch,TamanoWidth,TamanoHeight")] Imagen imagen)
        {
            if (ModelState.IsValid)
            {
                db.Imagens.Add(imagen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(imagen);
        }

        // GET: Imagens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagen imagen = db.Imagens.Find(id);
            if (imagen == null)
            {
                return HttpNotFound();
            }
            return View(imagen);
        }

        // POST: Imagens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FormatoImagen,Nombre,Patch,TamanoWidth,TamanoHeight")] Imagen imagen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imagen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(imagen);
        }

        // GET: Imagens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagen imagen = db.Imagens.Find(id);
            if (imagen == null)
            {
                return HttpNotFound();
            }
            return View(imagen);
        }

        // POST: Imagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Imagen imagen = db.Imagens.Find(id);
            db.Imagens.Remove(imagen);
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
