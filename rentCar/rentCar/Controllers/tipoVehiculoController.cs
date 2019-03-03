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
    public class tipoVehiculoController : Controller
    {
        private RentCarDBEntities db = new RentCarDBEntities();

        // GET: tipoVehiculo
        public ActionResult Index()
        {
            return View(db.TIPO_VEHICULO.ToList());
        }

        // GET: tipoVehiculo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_VEHICULO tIPO_VEHICULO = db.TIPO_VEHICULO.Find(id);
            if (tIPO_VEHICULO == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_VEHICULO);
        }

        // GET: tipoVehiculo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipoVehiculo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TIPO_VEHICULO,NOMBRE_TIPO_VEHICULO,ESTADO")] TIPO_VEHICULO tIPO_VEHICULO)
        {
            if (ModelState.IsValid)
            {
                db.TIPO_VEHICULO.Add(tIPO_VEHICULO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPO_VEHICULO);
        }

        // GET: tipoVehiculo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_VEHICULO tIPO_VEHICULO = db.TIPO_VEHICULO.Find(id);
            if (tIPO_VEHICULO == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_VEHICULO);
        }

        // POST: tipoVehiculo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TIPO_VEHICULO,NOMBRE_TIPO_VEHICULO,ESTADO")] TIPO_VEHICULO tIPO_VEHICULO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPO_VEHICULO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPO_VEHICULO);
        }

        // GET: tipoVehiculo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_VEHICULO tIPO_VEHICULO = db.TIPO_VEHICULO.Find(id);
            if (tIPO_VEHICULO == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_VEHICULO);
        }

        // POST: tipoVehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPO_VEHICULO tIPO_VEHICULO = db.TIPO_VEHICULO.Find(id);
            db.TIPO_VEHICULO.Remove(tIPO_VEHICULO);
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
