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
    
    public partial class Carta_Producto
    {
        public int id { get; set; }
        public int idCarta { get; set; }
        public int idProducto { get; set; }
        public string UserId { get; set; }
        public System.DateTime fecha { get; set; }
        public int estado { get; set; }
    
        public virtual Carta Carta { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
