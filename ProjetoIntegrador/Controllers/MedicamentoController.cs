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
using System.Web.Services;

namespace ProjetoIntegrador.Controllers
{
    public class MedicamentoController : Controller
    {
        private DrugBsiDb db = new DrugBsiDb();

        // GET: Medicamentos
        public ActionResult Index()
        {
            var medicamentos = db.Medicamentos.Include(m => m.Fabricante);
            return View(medicamentos.ToList());
        }

        // GET: Medicamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicamento medicamento = db.Medicamentos.Find(id);
            if (medicamento == null)
            {
                return HttpNotFound();
            }
            return View(medicamento);
        }

        // GET: Medicamentos/Create
        public ActionResult Create()
        {
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "ID", "Cnpj");
            return View();
        }

        // POST: Medicamentos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Descricao,Conteudo,Conservacao,Indicacao,Contraindicacao,ModoUtilizacao,Tipo,FaixaEtaria,Bula,QuantidadeEstoque,FabricanteID")] Medicamento medicamento)
        {
            if (ModelState.IsValid)
            {
                db.Medicamentos.Add(medicamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "ID", "Cnpj", medicamento.FabricanteID);
            return View(medicamento);
        }

        // GET: Medicamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicamento medicamento = db.Medicamentos.Find(id);
            if (medicamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "ID", "Cnpj", medicamento.FabricanteID);
            return View(medicamento);
        }

        // POST: Medicamentos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Descricao,Conteudo,Conservacao,Indicacao,Contraindicacao,ModoUtilizacao,Tipo,FaixaEtaria,Bula,QuantidadeEstoque,FabricanteID")] Medicamento medicamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "ID", "Cnpj", medicamento.FabricanteID);
            return View(medicamento);
        }

        // GET: Medicamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicamento medicamento = db.Medicamentos.Find(id);
            if (medicamento == null)
            {
                return HttpNotFound();
            }
            return View(medicamento);
        }

        // POST: Medicamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medicamento medicamento = db.Medicamentos.Find(id);
            db.Medicamentos.Remove(medicamento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [WebMethod]
        public JsonResult Exportar()
        {
            return Json(db.Medicamentos.ToList(), JsonRequestBehavior.AllowGet);
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
