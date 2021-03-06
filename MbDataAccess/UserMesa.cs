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
    
    public partial class UserMesa
    {
        public UserMesa()
        {
            this.Pedidoes = new HashSet<Pedido>();
            this.Cuentas = new HashSet<Cuenta>();
        }
    
        public int id { get; set; }
        public string UserId { get; set; }
        public int IdMesa { get; set; }
        public int idPerfilMesa { get; set; }
        public bool activo { get; set; }
        public System.DateTime fecha { get; set; }
        public bool habilitado { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Mesa Mesa { get; set; }
        public virtual PerfilMesa PerfilMesa { get; set; }
        public virtual ICollection<Pedido> Pedidoes { get; set; }
        public virtual ICollection<Cuenta> Cuentas { get; set; }
    }
}
