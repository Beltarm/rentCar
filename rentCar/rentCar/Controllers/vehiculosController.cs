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
    public class vehiculosController : Controller
    {
        private RentCarDBEntities db = new RentCarDBEntities();

        // GET: vehiculos
        public ActionResult Index()
        {
            var vEHICULO = db.VEHICULO.Include(v => v.MARCA).Include(v => v.MODELO).Include(v => v.PAGINA).Include(v => v.TIPO_COMBUSTIBLE).Include(v => v.TIPO_VEHICULO);
            return View(vEHICULO.ToList());
        }

        // GET: vehiculos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VEHICULO vEHICULO = db.VEHICULO.Find(id);
            if (vEHICULO == null)
            {
                return HttpNotFound();
            }
            return View(vEHICULO);
        }

        // GET: vehiculos/Create
        public ActionResult Create()
        {
            ViewBag.ID_MARCA = new SelectList(db.MARCA, "ID_MARCA", "NOMBRE_MARCA");
            ViewBag.ID_MODELO = new SelectList(db.MODELO, "ID_MODELO", "NOMBRE_MODELO");
            ViewBag.ID_PAGINA = new SelectList(db.PAGINA, "ID_PAGINA", "NOMBRE_PAGINA");
            ViewBag.ID_TIPO_COMBUSTIBLE = new SelectList(db.TIPO_COMBUSTIBLE, "ID_TIPO_COMBUSTIBLE", "NOMBRE_TIPO_COMBUSTIBLE");
            ViewBag.ID_TIPO_VEHICULO = new SelectList(db.TIPO_VEHICULO, "ID_TIPO_VEHICULO", "NOMBRE_TIPO_VEHICULO");
            return View();
        }

        // POST: vehiculos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_VEHICULO,NO_PLACA,ID_TIPO_VEHICULO,ID_MARCA,ID_MODELO,ID_TIPO_COMBUSTIBLE,PRECIO_VEHICULO,ID_PAGINA,ESTADO,YEAR")] VEHICULO vEHICULO)
        {
            if (ModelState.IsValid)
            {
                db.VEHICULO.Add(vEHICULO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_MARCA = new SelectList(db.MARCA, "ID_MARCA", "NOMBRE_MARCA", vEHICULO.ID_MARCA);
            ViewBag.ID_MODELO = new SelectList(db.MODELO, "ID_MODELO", "NOMBRE_MODELO", vEHICULO.ID_MODELO);
            ViewBag.ID_PAGINA = new SelectList(db.PAGINA, "ID_PAGINA", "NOMBRE_PAGINA", vEHICULO.ID_PAGINA);
            ViewBag.ID_TIPO_COMBUSTIBLE = new SelectList(db.TIPO_COMBUSTIBLE, "ID_TIPO_COMBUSTIBLE", "NOMBRE_TIPO_COMBUSTIBLE", vEHICULO.ID_TIPO_COMBUSTIBLE);
            ViewBag.ID_TIPO_VEHICULO = new SelectList(db.TIPO_VEHICULO, "ID_TIPO_VEHICULO", "NOMBRE_TIPO_VEHICULO", vEHICULO.ID_TIPO_VEHICULO);
            return View(vEHICULO);
        }

        // GET: vehiculos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VEHICULO vEHICULO = db.VEHICULO.Find(id);
            if (vEHICULO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_MARCA = new SelectList(db.MARCA, "ID_MARCA", "NOMBRE_MARCA", vEHICULO.ID_MARCA);
            ViewBag.ID_MODELO = new SelectList(db.MODELO, "ID_MODELO", "NOMBRE_MODELO", vEHICULO.ID_MODELO);
            ViewBag.ID_PAGINA = new SelectList(db.PAGINA, "ID_PAGINA", "NOMBRE_PAGINA", vEHICULO.ID_PAGINA);
            ViewBag.ID_TIPO_COMBUSTIBLE = new SelectList(db.TIPO_COMBUSTIBLE, "ID_TIPO_COMBUSTIBLE", "NOMBRE_TIPO_COMBUSTIBLE", vEHICULO.ID_TIPO_COMBUSTIBLE);
            ViewBag.ID_TIPO_VEHICULO = new SelectList(db.TIPO_VEHICULO, "ID_TIPO_VEHICULO", "NOMBRE_TIPO_VEHICULO", vEHICULO.ID_TIPO_VEHICULO);
            return View(vEHICULO);
        }

        // POST: vehiculos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_VEHICULO,NO_PLACA,ID_TIPO_VEHICULO,ID_MARCA,ID_MODELO,ID_TIPO_COMBUSTIBLE,PRECIO_VEHICULO,ID_PAGINA,ESTADO,YEAR")] VEHICULO vEHICULO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vEHICULO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_MARCA = new SelectList(db.MARCA, "ID_MARCA", "NOMBRE_MARCA", vEHICULO.ID_MARCA);
            ViewBag.ID_MODELO = new SelectList(db.MODELO, "ID_MODELO", "NOMBRE_MODELO", vEHICULO.ID_MODELO);
            ViewBag.ID_PAGINA = new SelectList(db.PAGINA, "ID_PAGINA", "NOMBRE_PAGINA", vEHICULO.ID_PAGINA);
            ViewBag.ID_TIPO_COMBUSTIBLE = new SelectList(db.TIPO_COMBUSTIBLE, "ID_TIPO_COMBUSTIBLE", "NOMBRE_TIPO_COMBUSTIBLE", vEHICULO.ID_TIPO_COMBUSTIBLE);
            ViewBag.ID_TIPO_VEHICULO = new SelectList(db.TIPO_VEHICULO, "ID_TIPO_VEHICULO", "NOMBRE_TIPO_VEHICULO", vEHICULO.ID_TIPO_VEHICULO);
            return View(vEHICULO);
        }

        // GET: vehiculos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VEHICULO vEHICULO = db.VEHICULO.Find(id);
            if (vEHICULO == null)
            {
                return HttpNotFound();
            }
            return View(vEHICULO);
        }

        // POST: vehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VEHICULO vEHICULO = db.VEHICULO.Find(id);
            db.VEHICULO.Remove(vEHICULO);
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
