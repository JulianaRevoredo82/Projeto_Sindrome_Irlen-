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
    public class ScrennersController : Controller
    {
        private SindromeIrlenEntities5 db = new SindromeIrlenEntities5();

        // GET: Screnners
        public ActionResult Index()
        {
            var screnner = db.Screnner.Include(s => s.CategoriaProfissionais).Include(s => s.Cidade1).Include(s => s.Estado1);
            return View(screnner.ToList());
        }
        // GET: Screnners
        public ActionResult Screnner()
        {
            var screnner = db.Screnner.Include(s => s.CategoriaProfissionais).Include(s => s.Cidade1).Include(s => s.Estado1);
            return View(screnner.ToList());
        }

        // GET: Screnners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Screnner screnner = db.Screnner.Find(id);
            if (screnner == null)
            {
                return HttpNotFound();
            }
            return View(screnner);
        }

        // GET: Screnners/Create
        public ActionResult Create()
        {
            ViewBag.Categoria = new SelectList(db.CategoriaProfissionais, "IdCategoriaProfissionais", "Categoria");
            ViewBag.Cidade = new SelectList(db.Cidade, "IdCidade", "Cidade1");
            ViewBag.Estado = new SelectList(db.Estado, "IdEstado", "Estado1");
            return View();
        }

        // POST: Screnners/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdScrenner,Nome,Categoria,Estado,Cidade,Titulo,Video")] Screnner screnner)
        {
            if (ModelState.IsValid)
            {
                db.Screnner.Add(screnner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categoria = new SelectList(db.CategoriaProfissionais, "IdCategoriaProfissionais", "Categoria", screnner.Categoria);
            ViewBag.Cidade = new SelectList(db.Cidade, "IdCidade", "Cidade1", screnner.Cidade);
            ViewBag.Estado = new SelectList(db.Estado, "IdEstado", "Estado1", screnner.Estado);
            return View(screnner);
        }

        // GET: Screnners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Screnner screnner = db.Screnner.Find(id);
            if (screnner == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categoria = new SelectList(db.CategoriaProfissionais, "IdCategoriaProfissionais", "Categoria", screnner.Categoria);
            ViewBag.Cidade = new SelectList(db.Cidade, "IdCidade", "Cidade1", screnner.Cidade);
            ViewBag.Estado = new SelectList(db.Estado, "IdEstado", "Estado1", screnner.Estado);
            return View(screnner);
        }

        // POST: Screnners/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdScrenner,Nome,Categoria,Estado,Cidade,Titulo,Video")] Screnner screnner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(screnner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categoria = new SelectList(db.CategoriaProfissionais, "IdCategoriaProfissionais", "Categoria", screnner.Categoria);
            ViewBag.Cidade = new SelectList(db.Cidade, "IdCidade", "Cidade1", screnner.Cidade);
            ViewBag.Estado = new SelectList(db.Estado, "IdEstado", "Estado1", screnner.Estado);
            return View(screnner);
        }

        // GET: Screnners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Screnner screnner = db.Screnner.Find(id);
            if (screnner == null)
            {
                return HttpNotFound();
            }
            return View(screnner);
        }

        // POST: Screnners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Screnner screnner = db.Screnner.Find(id);
            db.Screnner.Remove(screnner);
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
