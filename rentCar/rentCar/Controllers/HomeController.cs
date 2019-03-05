using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using rentCar.Models;
using rentCar.ViewModels;
using System.Data.Entity;

namespace rentCar.Controllers
{
 
    public class HomeController : Controller
    {
        private RentCarDBEntities db = new RentCarDBEntities();
        public ActionResult Index()
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("Index", "Dashboard2");
            //}
            List<VehiculosVM> ListaVehiculosVM = new List<VehiculosVM>();
            var listavehiculos = (from vehiculo in db.VEHICULO join marca in db.MARCA
             on vehiculo.ID_MARCA equals marca.ID_MARCA join modelo in db.MODELO 
             on vehiculo.ID_MODELO equals modelo.ID_MODELO join tipoVehiculo in db.TIPO_VEHICULO
             on vehiculo.ID_TIPO_VEHICULO equals tipoVehiculo.ID_TIPO_VEHICULO
             join tipoCombustible in db.TIPO_COMBUSTIBLE on vehiculo.ID_TIPO_COMBUSTIBLE equals
             tipoCombustible.ID_TIPO_COMBUSTIBLE join pagina in db.PAGINA on vehiculo.ID_PAGINA
             equals pagina.ID_PAGINA select new {marca.NOMBRE_MARCA, modelo.NOMBRE_MODELO
             , vehiculo.YEAR, tipoVehiculo.NOMBRE_TIPO_VEHICULO, tipoCombustible.NOMBRE_TIPO_COMBUSTIBLE,
             pagina.NOMBRE_PAGINA, pagina.URL_PAGINA, vehiculo.PRECIO_VEHICULO}).ToList();

             //super query con pila de joins para hacer una vista vacanísma con EntityFramework

            foreach(var item in listavehiculos)
            {
                VehiculosVM objectVM = new VehiculosVM();//view model
                objectVM.Marca = item.NOMBRE_MARCA;
                objectVM.Modelo = item.NOMBRE_MODELO;
                objectVM.year = item.YEAR;
                objectVM.tipoVehiculo = item.NOMBRE_TIPO_VEHICULO;
                objectVM.tipoCombustible = item.NOMBRE_TIPO_COMBUSTIBLE;
                objectVM.nombrePagina = item.NOMBRE_PAGINA;
                objectVM.url = item.URL_PAGINA;
                objectVM.precio = item.PRECIO_VEHICULO;
                ListaVehiculosVM.Add(objectVM);
            }
            // se usa el bucle foreach para llenar de datos desde listavehiculos a ListaVehiculosVM
            return View(ListaVehiculosVM);
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