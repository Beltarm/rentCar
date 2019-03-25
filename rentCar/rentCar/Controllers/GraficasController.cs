using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using rentCar.Models;

namespace rentCar.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GraficasController : Controller
    {
        private RentCarDBEntities db = new RentCarDBEntities();

        [HttpGet]
        public JsonResult obtenerVehiculos()
        {

            var marcas = db.VEHICULO.GroupBy(v => v.MARCA.NOMBRE_MARCA)
                .OrderByDescending(v => v.Count())
                .Select(v => new
                {
                    Marca = v.Key,
                    cantidad = v.Count()
                }).Take(5);

            return Json(marcas, JsonRequestBehavior.AllowGet);
        }
    }
}