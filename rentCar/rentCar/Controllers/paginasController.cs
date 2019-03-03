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
    public class paginasController : Controller
    {
        private RentCarDBEntities db = new RentCarDBEntities();

        // GET: paginas
        public ActionResult Index()
        {
            return View(db.PAGINA.ToList());
        }

        // GET: paginas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAGINA pAGINA = db.PAGINA.Find(id);
            if (pAGINA == null)
            {
                return HttpNotFound();
            }
            return View(pAGINA);
        }

        // GET: paginas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: paginas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PAGINA,NOMBRE_PAGINA,URL_PAGINA,ESTADO")] PAGINA pAGINA)
        {
            if (ModelState.IsValid)
            {
                db.PAGINA.Add(pAGINA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pAGINA);
        }

        // GET: paginas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAGINA pAGINA = db.PAGINA.Find(id);
            if (pAGINA == null)
            {
                return HttpNotFound();
            }
            return View(pAGINA);
        }

        // POST: paginas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PAGINA,NOMBRE_PAGINA,URL_PAGINA,ESTADO")] PAGINA pAGINA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pAGINA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pAGINA);
        }

        // GET: paginas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAGINA pAGINA = db.PAGINA.Find(id);
            if (pAGINA == null)
            {
                return HttpNotFound();
            }
            return View(pAGINA);
        }

        // POST: paginas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PAGINA pAGINA = db.PAGINA.Find(id);
            db.PAGINA.Remove(pAGINA);
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
