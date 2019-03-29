using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using rentCar.Models;
using rentCar.ViewModels;
using System.Data.Entity;
using System.Web.Script.Serialization;
using System.Globalization;

namespace rentCar.Controllers
{
 
    public class HomeController : Controller
    {
        private RentCarDBEntities db = new RentCarDBEntities();

        public ActionResult Index()
        {
            /******************CONTADOR DE VISITAS********************************/
            CultureInfo ci = new CultureInfo("Es-Es"); 
            string day = ci.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
            var visitas = db.VISITAS.Where(v => v.DIA_VSITA == day).FirstOrDefault();
            visitas.CANTIDAD_VISITA += 1;
            db.SaveChanges();
            /***************************************************************************/

            var vEHICULOs = db.VEHICULO
                .Include(v => v.MARCA).Include(v => v.MODELO).Include(v => v.PAGINA)
                .Include(v => v.TIPO_COMBUSTIBLE).Include(v => v.TIPO_VEHICULO).Include(v => v.IMAGEN)
                .Select(v => v);
 
            
            return View(vEHICULOs.ToList());
        }

        [HttpPost]
        public ActionResult Index(string option, string search)
        {
            if (option == "MARCA")
            {
                var vEHICULOs = db.VEHICULO
                .Include(v => v.MARCA).Include(v => v.MODELO).Include(v => v.PAGINA)
                .Include(v => v.TIPO_COMBUSTIBLE).Include(v => v.TIPO_VEHICULO)
                .Where(v => v.MARCA.NOMBRE_MARCA == search)
                .Select(v => v);
                return View(vEHICULOs.ToList());
            }
            else if (option == "MODELO")
            {
                var vEHICULOs = db.VEHICULO
                .Include(v => v.MARCA).Include(v => v.MODELO).Include(v => v.PAGINA)
                .Include(v => v.TIPO_COMBUSTIBLE).Include(v => v.TIPO_VEHICULO)
                .Where(v => v.MODELO.NOMBRE_MODELO == search)
                .Select(v => v);
                return View(vEHICULOs.ToList());
            }
            else if (option == "PAGINA")
            {
                 var vEHICULOs = db.VEHICULO
                .Include(v => v.MARCA).Include(v => v.MODELO).Include(v => v.PAGINA)
                .Include(v => v.TIPO_COMBUSTIBLE).Include(v => v.TIPO_VEHICULO)
                .Where(v => v.PAGINA.NOMBRE_PAGINA == search)
                .Select(v => v);
                return View(vEHICULOs.ToList());
            }
            else if (option == "TIPO_COMBUSTIBLE")
            {
                var vEHICULOs = db.VEHICULO
                .Include(v => v.MARCA).Include(v => v.MODELO).Include(v => v.PAGINA)
                .Include(v => v.TIPO_COMBUSTIBLE).Include(v => v.TIPO_VEHICULO)
                .Where(v => v.TIPO_COMBUSTIBLE.NOMBRE_TIPO_COMBUSTIBLE == search)
                .Select(v => v);
                return View(vEHICULOs.ToList());
            }
            else if (option == "TIPO_VEHICULO")
            {
                var vEHICULOs = db.VEHICULO
                .Include(v => v.MARCA).Include(v => v.MODELO).Include(v => v.PAGINA)
                .Include(v => v.TIPO_COMBUSTIBLE).Include(v => v.TIPO_VEHICULO)
                .Where(v => v.TIPO_VEHICULO.NOMBRE_TIPO_VEHICULO == search)
                .Select(v => v);
                return View(vEHICULOs.ToList());
            }
            else if (option == "PRECIO")
            {
                var vEHICULOs = db.VEHICULO
                .Include(v => v.MARCA).Include(v => v.MODELO).Include(v => v.PAGINA)
                .Include(v => v.TIPO_COMBUSTIBLE).Include(v => v.TIPO_VEHICULO)
                .Where(v => v.PRECIO_VEHICULO == Convert.ToInt32(search))
                .Select(v => v);
                return View(vEHICULOs.ToList());
            }
            else if(option == "YEAR")
            {
                var vEHICULOs = db.VEHICULO
                .Include(v => v.MARCA).Include(v => v.MODELO).Include(v => v.PAGINA)
                .Include(v => v.TIPO_COMBUSTIBLE).Include(v => v.TIPO_VEHICULO)
                .Where(v => v.YEAR == search)
                .Select(v => v);
                return View(vEHICULOs.ToList());
            }
            else
            {
                var vEHICULOs = db.VEHICULO
                .Include(v => v.MARCA).Include(v => v.MODELO).Include(v => v.PAGINA)
                .Include(v => v.TIPO_COMBUSTIBLE).Include(v => v.TIPO_VEHICULO)
                .Select(v => v);
                return View(vEHICULOs.ToList());
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Creadores del proyecto:";

            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}