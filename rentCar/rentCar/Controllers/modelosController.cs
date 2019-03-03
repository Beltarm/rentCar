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
    public class modelosController : Controller
    {
        private RentCarDBEntities db = new RentCarDBEntities();

        // GET: modelos
        public ActionResult Index()
        {
            var mODELO = db.MODELO.Include(m => m.MARCA);
            return View(mODELO.ToList());
        }

        // GET: modelos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MODELO mODELO = db.MODELO.Find(id);
            if (mODELO == null)
            {
                return HttpNotFound();
            }
            return View(mODELO);
        }

        // GET: modelos/Create
        public ActionResult Create()
        {
            ViewBag.ID_MARCA = new SelectList(db.MARCA, "ID_MARCA", "NOMBRE_MARCA");
            return View();
        }

        // POST: modelos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_MODELO,NOMBRE_MODELO,ID_MARCA,ESTADO")] MODELO mODELO)
        {
            if (ModelState.IsValid)
            {
                db.MODELO.Add(mODELO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_MARCA = new SelectList(db.MARCA, "ID_MARCA", "NOMBRE_MARCA", mODELO.ID_MARCA);
            return View(mODELO);
        }

        // GET: modelos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MODELO mODELO = db.MODELO.Find(id);
            if (mODELO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_MARCA = new SelectList(db.MARCA, "ID_MARCA", "NOMBRE_MARCA", mODELO.ID_MARCA);
            return View(mODELO);
        }

        // POST: modelos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_MODELO,NOMBRE_MODELO,ID_MARCA,ESTADO")] MODELO mODELO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mODELO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_MARCA = new SelectList(db.MARCA, "ID_MARCA", "NOMBRE_MARCA", mODELO.ID_MARCA);
            return View(mODELO);
        }

        // GET: modelos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MODELO mODELO = db.MODELO.Find(id);
            if (mODELO == null)
            {
                return HttpNotFound();
            }
            return View(mODELO);
        }

        // POST: modelos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MODELO mODELO = db.MODELO.Find(id);
            db.MODELO.Remove(mODELO);
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
