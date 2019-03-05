using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using rentCar.Models;

namespace rentCar.Controllers
{
    public class GraficosController : ApiController
    {
        TIPO_VEHICULO[] products = new TIPO_VEHICULO[]
       {
            new TIPO_VEHICULO { ID_TIPO_VEHICULO = 57, NOMBRE_TIPO_VEHICULO = "asjdas", ESTADO = "Activo" },
           new TIPO_VEHICULO { ID_TIPO_VEHICULO = 57, NOMBRE_TIPO_VEHICULO = "qweqwe", ESTADO = "Activo" },
           new TIPO_VEHICULO { ID_TIPO_VEHICULO = 57, NOMBRE_TIPO_VEHICULO = "zxbzxv", ESTADO = "Activo" },
       };

        public IEnumerable<TIPO_VEHICULO> GetAllProducts()
        {
            return products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.ID_TIPO_VEHICULO == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
