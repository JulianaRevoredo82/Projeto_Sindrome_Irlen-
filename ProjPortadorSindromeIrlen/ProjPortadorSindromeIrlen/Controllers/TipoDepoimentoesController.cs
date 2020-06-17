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
    public class TipoDepoimentoesController : Controller
    {
        private SindromeIrlenEntities5 db = new SindromeIrlenEntities5();

        // GET: TipoDepoimentoes
        public ActionResult Index()
        {
            return View(db.TipoDepoimento.ToList());
        }

        // GET: TipoDepoimentoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDepoimento tipoDepoimento = db.TipoDepoimento.Find(id);
            if (tipoDepoimento == null)
            {
                return HttpNotFound();
            }
            return View(tipoDepoimento);
        }

        // GET: TipoDepoimentoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDepoimentoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCategDepoimento,Tipo")] TipoDepoimento tipoDepoimento)
        {
            if (ModelState.IsValid)
            {
                db.TipoDepoimento.Add(tipoDepoimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoDepoimento);
        }

        // GET: TipoDepoimentoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDepoimento tipoDepoimento = db.TipoDepoimento.Find(id);
            if (tipoDepoimento == null)
            {
                return HttpNotFound();
            }
            return View(tipoDepoimento);
        }

        // POST: TipoDepoimentoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCategDepoimento,Tipo")] TipoDepoimento tipoDepoimento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDepoimento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoDepoimento);
        }

        // GET: TipoDepoimentoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDepoimento tipoDepoimento = db.TipoDepoimento.Find(id);
            if (tipoDepoimento == null)
            {
                return HttpNotFound();
            }
            return View(tipoDepoimento);
        }

        // POST: TipoDepoimentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDepoimento tipoDepoimento = db.TipoDepoimento.Find(id);
            db.TipoDepoimento.Remove(tipoDepoimento);
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
