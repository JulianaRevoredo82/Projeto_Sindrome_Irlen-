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
    public class QuemSomosController : Controller
    {
        private SindromeIrlenEntities5 db = new SindromeIrlenEntities5();

        // GET: QuemSomos
        public ActionResult Index()
        {
             return View(db.QuemSomos.ToList());
        }

        public ActionResult QuemSomosSite()
        {
            return View(db.QuemSomos.ToList());
        }

        // GET: QuemSomos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuemSomos quemSomos = db.QuemSomos.Find(id);
            if (quemSomos == null)
            {
                return HttpNotFound();
            }
            return View(quemSomos);
        }

        // GET: QuemSomos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuemSomos/Create
        //// Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        //// obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdQuemSomos,Historia,Objetivos,Valores,Foto")] QuemSomos quemSomos)
        {
           if (ModelState.IsValid)
            {
                db.QuemSomos.Add(quemSomos);
               db.SaveChanges();
                return RedirectToAction("Index");
           }

            return View(quemSomos);
        }

        





        // GET: QuemSomos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuemSomos quemSomos = db.QuemSomos.Find(id);
            if (quemSomos == null)
            {
                return HttpNotFound();
            }
            return View(quemSomos);
        }

        // POST: QuemSomos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdQuemSomos,Historia,Objetivos,Valores,Foto")] QuemSomos quemSomos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quemSomos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quemSomos);
        }

        // GET: QuemSomos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuemSomos quemSomos = db.QuemSomos.Find(id);
            if (quemSomos == null)
            {
                return HttpNotFound();
            }
            return View(quemSomos);
        }

        // POST: QuemSomos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuemSomos quemSomos = db.QuemSomos.Find(id);
            db.QuemSomos.Remove(quemSomos);
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
