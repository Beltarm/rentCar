//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace rentCar.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VEHICULO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VEHICULO()
        {
            this.IMAGEN = new HashSet<IMAGEN>();
        }
    
        public int ID_VEHICULO { get; set; }
        public string NO_PLACA { get; set; }
        public int ID_TIPO_VEHICULO { get; set; }
        public int ID_MARCA { get; set; }
        public int ID_MODELO { get; set; }
        public int ID_TIPO_COMBUSTIBLE { get; set; }
        public Nullable<int> PRECIO_VEHICULO { get; set; }
        public int ID_PAGINA { get; set; }
        public string ESTADO { get; set; }
        public string YEAR { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IMAGEN> IMAGEN { get; set; }
        public virtual MARCA MARCA { get; set; }
        public virtual MODELO MODELO { get; set; }
        public virtual PAGINA PAGINA { get; set; }
        public virtual TIPO_COMBUSTIBLE TIPO_COMBUSTIBLE { get; set; }
        public virtual TIPO_VEHICULO TIPO_VEHICULO { get; set; }
    }
}
