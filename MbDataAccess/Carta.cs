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
    
    public partial class Carta
    {
        public Carta()
        {
            this.Carta_Producto = new HashSet<Carta_Producto>();
        }
    
        public int id { get; set; }
        public string UserId { get; set; }
        public string descripcion { get; set; }
        public bool activa { get; set; }
        public System.DateTime fecha { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual ICollection<Carta_Producto> Carta_Producto { get; set; }
    }
}
