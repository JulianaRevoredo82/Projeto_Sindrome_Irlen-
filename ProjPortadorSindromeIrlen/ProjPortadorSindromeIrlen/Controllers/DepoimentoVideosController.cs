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
    public class DepoimentoVideosController : Controller
    {
        private SindromeIrlenEntities5 db = new SindromeIrlenEntities5();

        // GET: DepoimentoVideos
        public ActionResult Index()
        {
            var depoimentoVideo = db.DepoimentoVideo.Include(d => d.TipoDepoimento);
            return View(depoimentoVideo.ToList());
        }

        // GET: DepoimentoVideos
        public ActionResult DepoimentoVideo()
        {
            var depoimentoVideo = db.DepoimentoVideo.Include(d => d.TipoDepoimento);
            return View(depoimentoVideo.ToList());
        }

        // GET: DepoimentoVideos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepoimentoVideo depoimentoVideo = db.DepoimentoVideo.Find(id);
            if (depoimentoVideo == null)
            {
                return HttpNotFound();
            }
            return View(depoimentoVideo);
        }

        // GET: DepoimentoVideos/Create
        public ActionResult Create()
        {
            ViewBag.Tipo = new SelectList(db.TipoDepoimento, "IdCategDepoimento", "Tipo");
            return View();
        }

        // POST: DepoimentoVideos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDepVideo,Nome,Tipo,Titulo,Video")] DepoimentoVideo depoimentoVideo)
        {
            if (ModelState.IsValid)
            {
                db.DepoimentoVideo.Add(depoimentoVideo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Tipo = new SelectList(db.TipoDepoimento, "IdCategDepoimento", "Tipo", depoimentoVideo.Tipo);
            return View(depoimentoVideo);
        }

        // GET: DepoimentoVideos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepoimentoVideo depoimentoVideo = db.DepoimentoVideo.Find(id);
            if (depoimentoVideo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tipo = new SelectList(db.TipoDepoimento, "IdCategDepoimento", "Tipo", depoimentoVideo.Tipo);
            return View(depoimentoVideo);
        }

        // POST: DepoimentoVideos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDepVideo,Nome,Tipo,Titulo,Video")] DepoimentoVideo depoimentoVideo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(depoimentoVideo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tipo = new SelectList(db.TipoDepoimento, "IdCategDepoimento", "Tipo", depoimentoVideo.Tipo);
            return View(depoimentoVideo);
        }

        // GET: DepoimentoVideos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepoimentoVideo depoimentoVideo = db.DepoimentoVideo.Find(id);
            if (depoimentoVideo == null)
            {
                return HttpNotFound();
            }
            return View(depoimentoVideo);
        }

        // POST: DepoimentoVideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DepoimentoVideo depoimentoVideo = db.DepoimentoVideo.Find(id);
            db.DepoimentoVideo.Remove(depoimentoVideo);
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
