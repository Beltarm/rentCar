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
    public class imagenController : Controller
    {
       
        private RentCarDBEntities db = new RentCarDBEntities();

        // GET: imagen
        public ActionResult Index()
        {
            var iMAGEN = db.IMAGEN.Include(i => i.VEHICULO);
            return View(iMAGEN.ToList());
        }

        // GET: imagen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMAGEN iMAGEN = db.IMAGEN.Find(id);
            if (iMAGEN == null)
            {
                return HttpNotFound();
            }
            return View(iMAGEN);
        }

        // GET: imagen/Create
        public ActionResult Create()
        {
            ViewBag.ID_VEHICULO = new SelectList(db.VEHICULO, "ID_VEHICULO", "NO_PLACA");
            return View();
        }

        // POST: imagen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_IMAGEN,ID_VEHICULO,RUTA_IMAGEN")] IMAGEN imagen, HttpPostedFileBase rutaImagen)
        {
           
            if (rutaImagen != null)
            {
                string pic = System.IO.Path.GetFileName(rutaImagen.FileName);
                string ruta = System.IO.Path.Combine(Server.MapPath("~/Content/Images"), pic);
                rutaImagen.SaveAs(ruta);
                if (ModelState.IsValid)
                {
                    IMAGEN admin =  new IMAGEN { RUTA_IMAGEN = "~/Content/Images/" + pic};
                    imagen.RUTA_IMAGEN = admin.RUTA_IMAGEN;
                    db.IMAGEN.Add(imagen);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.ID_VEHICULO = new SelectList(db.VEHICULO, "ID_VEHICULO", "NO_PLACA", imagen.ID_VEHICULO);
            return View(imagen);
        }

        // GET: imagen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMAGEN iMAGEN = db.IMAGEN.Find(id);
            if (iMAGEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_VEHICULO = new SelectList(db.VEHICULO, "ID_VEHICULO", "NO_PLACA", iMAGEN.ID_VEHICULO);
            return View(iMAGEN);
        }

        // POST: imagen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_IMAGEN,ID_VEHICULO,RUTA_IMAGEN")] IMAGEN iMAGEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iMAGEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_VEHICULO = new SelectList(db.VEHICULO, "ID_VEHICULO", "NO_PLACA", iMAGEN.ID_VEHICULO);
            return View(iMAGEN);
        }

        // GET: imagen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMAGEN iMAGEN = db.IMAGEN.Find(id);
            if (iMAGEN == null)
            {
                return HttpNotFound();
            }
            return View(iMAGEN);
        }

        // POST: imagen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IMAGEN iMAGEN = db.IMAGEN.Find(id);
            db.IMAGEN.Remove(iMAGEN);
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
