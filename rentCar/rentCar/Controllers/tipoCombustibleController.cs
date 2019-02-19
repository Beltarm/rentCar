using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using rentCar.Models;

namespace rentCar.Controllers
{
    public class tipoCombustibleController : Controller
    {
        private RentCarDBEntities db = new RentCarDBEntities();

        // GET: tipoCombustible
        public ActionResult Index()
        {
            return View(db.TIPO_COMBUSTIBLE.ToList());
        }

        // GET: tipoCombustible/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_COMBUSTIBLE tIPO_COMBUSTIBLE = db.TIPO_COMBUSTIBLE.Find(id);
            if (tIPO_COMBUSTIBLE == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_COMBUSTIBLE);
        }

        // GET: tipoCombustible/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipoCombustible/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TIPO_COMBUSTIBLE,NOMBRE_TIPO_COMBUSTIBLE,ESTADO")] TIPO_COMBUSTIBLE tIPO_COMBUSTIBLE)
        {
            if (ModelState.IsValid)
            {
                db.TIPO_COMBUSTIBLE.Add(tIPO_COMBUSTIBLE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPO_COMBUSTIBLE);
        }

        // GET: tipoCombustible/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_COMBUSTIBLE tIPO_COMBUSTIBLE = db.TIPO_COMBUSTIBLE.Find(id);
            if (tIPO_COMBUSTIBLE == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_COMBUSTIBLE);
        }

        // POST: tipoCombustible/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TIPO_COMBUSTIBLE,NOMBRE_TIPO_COMBUSTIBLE,ESTADO")] TIPO_COMBUSTIBLE tIPO_COMBUSTIBLE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPO_COMBUSTIBLE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPO_COMBUSTIBLE);
        }

        // GET: tipoCombustible/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_COMBUSTIBLE tIPO_COMBUSTIBLE = db.TIPO_COMBUSTIBLE.Find(id);
            if (tIPO_COMBUSTIBLE == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_COMBUSTIBLE);
        }

        // POST: tipoCombustible/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPO_COMBUSTIBLE tIPO_COMBUSTIBLE = db.TIPO_COMBUSTIBLE.Find(id);
            db.TIPO_COMBUSTIBLE.Remove(tIPO_COMBUSTIBLE);
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
