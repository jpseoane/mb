//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mb.DAO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cliente
    {
        public int idCliente { get; set; }
        public string UserId { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int dni { get; set; }
        public System.DateTime fecha_creacion { get; set; }
        public string estado { get; set; }
        public Nullable<int> edad { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
