using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoIntegrador.Data;
using ProjetoIntegrador.Models;

namespace ProjetoIntegrador.Controllers
{
    public class QuimicoController : Controller
    {
        private DrugBsiDb db = new DrugBsiDb();

        // GET: Quimicoes
        public ActionResult Index()
        {
            return View(db.Quimicos.ToList());
        }

        // GET: Quimicoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quimico quimico = db.Quimicos.Find(id);
            if (quimico == null)
            {
                return HttpNotFound();
            }
            return View(quimico);
        }

        // GET: Quimicoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quimicoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome")] Quimico quimico)
        {
            if (ModelState.IsValid)
            {
                db.Quimicos.Add(quimico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quimico);
        }

        // GET: Quimicoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quimico quimico = db.Quimicos.Find(id);
            if (quimico == null)
            {
                return HttpNotFound();
            }
            return View(quimico);
        }

        // POST: Quimicoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome")] Quimico quimico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quimico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quimico);
        }

        // GET: Quimicoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quimico quimico = db.Quimicos.Find(id);
            if (quimico == null)
            {
                return HttpNotFound();
            }
            return View(quimico);
        }

        // POST: Quimicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quimico quimico = db.Quimicos.Find(id);
            db.Quimicos.Remove(quimico);
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
