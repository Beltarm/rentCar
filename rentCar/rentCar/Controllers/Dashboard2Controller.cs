using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rentCar.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Dashboard2Controller : Controller
    {
        // GET: Dashboard2
        public ActionResult Index()
        {
            return View();
        }
    }
}