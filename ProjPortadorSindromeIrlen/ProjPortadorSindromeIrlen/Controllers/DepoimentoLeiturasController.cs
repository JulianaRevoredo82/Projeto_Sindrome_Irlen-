using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjPortadorSindromeIrlen;

namespace ProjPortadorSindromeIrlen.Controllers
{
    public class DepoimentoLeiturasController : Controller
    {
        private SindromeIrlenEntities5 db = new SindromeIrlenEntities5();

        // GET: DepoimentoLeituras
        public ActionResult Index()
        {
            var depoimentoLeitura = db.DepoimentoLeitura.Include(d => d.Cidade1).Include(d => d.Estado1).Include(d => d.TipoDepoimento);
            return View(depoimentoLeitura.ToList());
        } // GET: DepoimentoLeituras
        public ActionResult LeiaDepoimentos()
        {
            var depoimentoLeitura = db.DepoimentoLeitura.Include(d => d.Cidade1).Include(d => d.Estado1).Include(d => d.TipoDepoimento);
            return View(depoimentoLeitura.ToList());
        }

        // GET: DepoimentoLeituras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepoimentoLeitura depoimentoLeitura = db.DepoimentoLeitura.Find(id);
            if (depoimentoLeitura == null)
            {
                return HttpNotFound();
            }
            return View(depoimentoLeitura);
        }

        // GET: DepoimentoLeituras/Create
        public ActionResult Create()
        {
            ViewBag.Cidade = new SelectList(db.Cidade, "IdCidade", "Cidade1");
            ViewBag.Estado = new SelectList(db.Estado, "IdEstado", "Estado1");
            ViewBag.Tipo = new SelectList(db.TipoDepoimento, "IdCategDepoimento", "Tipo");
            return View();
        }

        // POST: DepoimentoLeituras/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDepEscrito,Nome,Tipo,Idade,Cidade,Estado,Titulo,Historia")] DepoimentoLeitura depoimentoLeitura)
        {
            if (ModelState.IsValid)
            {
                db.DepoimentoLeitura.Add(depoimentoLeitura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cidade = new SelectList(db.Cidade, "IdCidade", "Cidade1", depoimentoLeitura.Cidade);
            ViewBag.Estado = new SelectList(db.Estado, "IdEstado", "Estado1", depoimentoLeitura.Estado);
            ViewBag.Tipo = new SelectList(db.TipoDepoimento, "IdCategDepoimento", "Tipo", depoimentoLeitura.Tipo);
            return View(depoimentoLeitura);
        }

        // GET: DepoimentoLeituras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepoimentoLeitura depoimentoLeitura = db.DepoimentoLeitura.Find(id);
            if (depoimentoLeitura == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cidade = new SelectList(db.Cidade, "IdCidade", "Cidade1", depoimentoLeitura.Cidade);
            ViewBag.Estado = new SelectList(db.Estado, "IdEstado", "Estado1", depoimentoLeitura.Estado);
            ViewBag.Tipo = new SelectList(db.TipoDepoimento, "IdCategDepoimento", "Tipo", depoimentoLeitura.Tipo);
            return View(depoimentoLeitura);
        }

        // POST: DepoimentoLeituras/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDepEscrito,Nome,Tipo,Idade,Cidade,Estado,Titulo,Historia")] DepoimentoLeitura depoimentoLeitura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(depoimentoLeitura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cidade = new SelectList(db.Cidade, "IdCidade", "Cidade1", depoimentoLeitura.Cidade);
            ViewBag.Estado = new SelectList(db.Estado, "IdEstado", "Estado1", depoimentoLeitura.Estado);
            ViewBag.Tipo = new SelectList(db.TipoDepoimento, "IdCategDepoimento", "Tipo", depoimentoLeitura.Tipo);
            return View(depoimentoLeitura);
        }

        // GET: DepoimentoLeituras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepoimentoLeitura depoimentoLeitura = db.DepoimentoLeitura.Find(id);
            if (depoimentoLeitura == null)
            {
                return HttpNotFound();
            }
            return View(depoimentoLeitura);
        }

        // POST: DepoimentoLeituras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DepoimentoLeitura depoimentoLeitura = db.DepoimentoLeitura.Find(id);
            db.DepoimentoLeitura.Remove(depoimentoLeitura);
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
