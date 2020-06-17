﻿using System;
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
    public class CategoriaProfissionaisController : Controller
    {
        private SindromeIrlenEntities5 db = new SindromeIrlenEntities5();

        // GET: CategoriaProfissionais
        public ActionResult Index()
        {
            return View(db.CategoriaProfissionais.ToList());
        }

        // GET: CategoriaProfissionais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaProfissionais categoriaProfissionais = db.CategoriaProfissionais.Find(id);
            if (categoriaProfissionais == null)
            {
                return HttpNotFound();
            }
            return View(categoriaProfissionais);
        }

        // GET: CategoriaProfissionais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaProfissionais/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCategoriaProfissionais,Categoria")] CategoriaProfissionais categoriaProfissionais)
        {
            if (ModelState.IsValid)
            {
                db.CategoriaProfissionais.Add(categoriaProfissionais);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriaProfissionais);
        }

        // GET: CategoriaProfissionais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaProfissionais categoriaProfissionais = db.CategoriaProfissionais.Find(id);
            if (categoriaProfissionais == null)
            {
                return HttpNotFound();
            }
            return View(categoriaProfissionais);
        }

        // POST: CategoriaProfissionais/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCategoriaProfissionais,Categoria")] CategoriaProfissionais categoriaProfissionais)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriaProfissionais).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriaProfissionais);
        }

        // GET: CategoriaProfissionais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaProfissionais categoriaProfissionais = db.CategoriaProfissionais.Find(id);
            if (categoriaProfissionais == null)
            {
                return HttpNotFound();
            }
            return View(categoriaProfissionais);
        }

        // POST: CategoriaProfissionais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriaProfissionais categoriaProfissionais = db.CategoriaProfissionais.Find(id);
            db.CategoriaProfissionais.Remove(categoriaProfissionais);
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
