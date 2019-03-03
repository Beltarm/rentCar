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
    [Authorize(Roles = "Admin")]
    public class marcasController : Controller
    {
        private RentCarDBEntities db = new RentCarDBEntities();

        // GET: marcas
        public ActionResult Index()
        {
            return View(db.MARCA.ToList());
        }

        // GET: marcas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MARCA mARCA = db.MARCA.Find(id);
            if (mARCA == null)
            {
                return HttpNotFound();
            }
            return View(mARCA);
        }

        // GET: marcas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: marcas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_MARCA,NOMBRE_MARCA,ESTADO")] MARCA mARCA)
        {
            if (ModelState.IsValid)
            {
                db.MARCA.Add(mARCA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mARCA);
        }

        // GET: marcas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MARCA mARCA = db.MARCA.Find(id);
            if (mARCA == null)
            {
                return HttpNotFound();
            }
            return View(mARCA);
        }

        // POST: marcas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_MARCA,NOMBRE_MARCA,ESTADO")] MARCA mARCA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mARCA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mARCA);
        }

        // GET: marcas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MARCA mARCA = db.MARCA.Find(id);
            if (mARCA == null)
            {
                return HttpNotFound();
            }
            return View(mARCA);
        }

        // POST: marcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MARCA mARCA = db.MARCA.Find(id);
            db.MARCA.Remove(mARCA);
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
