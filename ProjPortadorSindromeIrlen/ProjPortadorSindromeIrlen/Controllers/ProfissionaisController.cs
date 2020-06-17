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
    public class ProfissionaisController : Controller
    {
        private SindromeIrlenEntities5 db = new SindromeIrlenEntities5();

        // GET: Profissionais
        public ActionResult Index()
        {
            var profissionais = db.Profissionais.Include(p => p.CategoriaProfissionais).Include(p => p.Cidade1).Include(p => p.Estado1);
            return View(profissionais.ToList());
        }
        // GET: Profissionais
        public ActionResult Profissionais()
        {
            var profissionais = db.Profissionais.Include(p => p.CategoriaProfissionais).Include(p => p.Cidade1).Include(p => p.Estado1);
            return View(profissionais.ToList());
        }

        // GET: Profissionais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profissionais profissionais = db.Profissionais.Find(id);
            if (profissionais == null)
            {
                return HttpNotFound();
            }
            return View(profissionais);
        }

        // GET: Profissionais/Create
        public ActionResult Create()
        {
            ViewBag.Categoria = new SelectList(db.CategoriaProfissionais, "IdCategoriaProfissionais", "Categoria");
            ViewBag.Cidade = new SelectList(db.Cidade, "IdCidade", "Cidade1");
            ViewBag.Estado = new SelectList(db.Estado, "IdEstado", "Estado1");
            return View();
        }

        // POST: Profissionais/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProfissionais,Nome,Categoria,Estado,Cidade,Titulo,Video")] Profissionais profissionais)
        {
            if (ModelState.IsValid)
            {
                db.Profissionais.Add(profissionais);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categoria = new SelectList(db.CategoriaProfissionais, "IdCategoriaProfissionais", "Categoria", profissionais.Categoria);
            ViewBag.Cidade = new SelectList(db.Cidade, "IdCidade", "Cidade1", profissionais.Cidade);
            ViewBag.Estado = new SelectList(db.Estado, "IdEstado", "Estado1", profissionais.Estado);
            return View(profissionais);
        }

        // GET: Profissionais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profissionais profissionais = db.Profissionais.Find(id);
            if (profissionais == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categoria = new SelectList(db.CategoriaProfissionais, "IdCategoriaProfissionais", "Categoria", profissionais.Categoria);
            ViewBag.Cidade = new SelectList(db.Cidade, "IdCidade", "Cidade1", profissionais.Cidade);
            ViewBag.Estado = new SelectList(db.Estado, "IdEstado", "Estado1", profissionais.Estado);
            return View(profissionais);
        }

        // POST: Profissionais/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProfissionais,Nome,Categoria,Estado,Cidade,Titulo,Video")] Profissionais profissionais)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profissionais).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categoria = new SelectList(db.CategoriaProfissionais, "IdCategoriaProfissionais", "Categoria", profissionais.Categoria);
            ViewBag.Cidade = new SelectList(db.Cidade, "IdCidade", "Cidade1", profissionais.Cidade);
            ViewBag.Estado = new SelectList(db.Estado, "IdEstado", "Estado1", profissionais.Estado);
            return View(profissionais);
        }

        // GET: Profissionais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profissionais profissionais = db.Profissionais.Find(id);
            if (profissionais == null)
            {
                return HttpNotFound();
            }
            return View(profissionais);
        }

        // POST: Profissionais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profissionais profissionais = db.Profissionais.Find(id);
            db.Profissionais.Remove(profissionais);
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
