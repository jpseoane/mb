//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MbDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class SubTipo
    {
        public SubTipo()
        {
            this.Productoes = new HashSet<Producto>();
        }
    
        public int idSubTipo { get; set; }
        public string descripcion_subtipo { get; set; }
        public System.DateTime fecha_carga { get; set; }
    
        public virtual ICollection<Producto> Productoes { get; set; }
    }
}
