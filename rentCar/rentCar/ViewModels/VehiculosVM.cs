using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rentCar.ViewModels
{
    public class VehiculosVM
    {
        public string Marca { get; set; } //Marca
        public string Modelo { get; set; }//Modelo
        public string year { get; set; } //Vehiculo
        public string tipoVehiculo { get; set; }//Tipo_vehiculo
        public string tipoCombustible { get; set; }//tipo_combustible 
        public string nombrePagina { get; set; }//pagina
        public string url { get; set; }//pagina
        public int? precio { get; set; }//Vehiculo
       
    }
}