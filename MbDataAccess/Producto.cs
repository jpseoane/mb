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
    
    public partial class Producto
    {
        public Producto()
        {
            this.Carta_Producto = new HashSet<Carta_Producto>();
            this.Pedidoes = new HashSet<Pedido>();
        }
    
        public int id { get; set; }
        public string UserId { get; set; }
        public int IdTipo { get; set; }
        public int idSubTipo { get; set; }
        public string descripcion { get; set; }
        public float precioUnitario { get; set; }
        public bool activo { get; set; }
        public System.DateTime fecha_carga { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual ICollection<Carta_Producto> Carta_Producto { get; set; }
        public virtual ICollection<Pedido> Pedidoes { get; set; }
        public virtual SubTipo SubTipo { get; set; }
        public virtual TipoProducto TipoProducto { get; set; }
    }
}
