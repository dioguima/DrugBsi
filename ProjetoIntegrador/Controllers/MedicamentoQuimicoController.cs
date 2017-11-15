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
    public class MedicamentoQuimicoController : Controller
    {
        private DrugBsiDb db = new DrugBsiDb();

        // GET: MedicamentoQuimicoes
        public ActionResult Index()
        {
            var medicamentosQuimicos = db.MedicamentosQuimicos.Include(m => m.Medicamento).Include(m => m.Quimico);
            return View(medicamentosQuimicos.ToList());
        }

        // GET: MedicamentoQuimicoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicamentoQuimico medicamentoQuimico = db.MedicamentosQuimicos.Find(id);
            if (medicamentoQuimico == null)
            {
                return HttpNotFound();
            }
            return View(medicamentoQuimico);
        }

        // GET: MedicamentoQuimicoes/Create
        public ActionResult Create()
        {
            ViewBag.MedicamentoId = new SelectList(db.Medicamentos, "ID", "Nome");
            ViewBag.QuimicoId = new SelectList(db.Quimicos, "ID", "Nome");
            return View();
        }

        // POST: MedicamentoQuimicoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MedicamentoId,QuimicoId,Quantidade")] MedicamentoQuimico medicamentoQuimico)
        {
            if (ModelState.IsValid)
            {
                db.MedicamentosQuimicos.Add(medicamentoQuimico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MedicamentoId = new SelectList(db.Medicamentos, "ID", "Nome", medicamentoQuimico.MedicamentoId);
            ViewBag.QuimicoId = new SelectList(db.Quimicos, "ID", "Nome", medicamentoQuimico.QuimicoId);
            return View(medicamentoQuimico);
        }

        // GET: MedicamentoQuimicoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicamentoQuimico medicamentoQuimico = db.MedicamentosQuimicos.Find(id);
            if (medicamentoQuimico == null)
            {
                return HttpNotFound();
            }
            ViewBag.MedicamentoId = new SelectList(db.Medicamentos, "ID", "Nome", medicamentoQuimico.MedicamentoId);
            ViewBag.QuimicoId = new SelectList(db.Quimicos, "ID", "Nome", medicamentoQuimico.QuimicoId);
            return View(medicamentoQuimico);
        }

        // POST: MedicamentoQuimicoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MedicamentoId,QuimicoId,Quantidade")] MedicamentoQuimico medicamentoQuimico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicamentoQuimico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MedicamentoId = new SelectList(db.Medicamentos, "ID", "Nome", medicamentoQuimico.MedicamentoId);
            ViewBag.QuimicoId = new SelectList(db.Quimicos, "ID", "Nome", medicamentoQuimico.QuimicoId);
            return View(medicamentoQuimico);
        }

        // GET: MedicamentoQuimicoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicamentoQuimico medicamentoQuimico = db.MedicamentosQuimicos.Find(id);
            if (medicamentoQuimico == null)
            {
                return HttpNotFound();
            }
            return View(medicamentoQuimico);
        }

        // POST: MedicamentoQuimicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicamentoQuimico medicamentoQuimico = db.MedicamentosQuimicos.Find(id);
            db.MedicamentosQuimicos.Remove(medicamentoQuimico);
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
