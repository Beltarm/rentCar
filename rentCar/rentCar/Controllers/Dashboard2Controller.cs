using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using rentCar.Models;

namespace rentCar.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Dashboard2Controller : Controller
    {
        private RentCarDBEntities db = new RentCarDBEntities();
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: Dashboard2
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            ApplicationUser user = context.Users.FirstOrDefault(x => x.Id == userId);

            ViewBag.User = user;
            ViewBag.paginasAsociadas = db.PAGINA.Count();
            ViewBag.VehiculosDisponibles = db.VEHICULO.Where(vehiculo => vehiculo.ESTADO == "ACTIVO").Count();
            ViewBag.VehiculosAlquilados = db.VEHICULO.Where(vehiculo => vehiculo.ESTADO == "INACTIVO").Count();
            return View();
        }
    }
}