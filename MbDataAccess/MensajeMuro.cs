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
    
    public partial class MensajeMuro
    {
        public int id { get; set; }
        public string UserId { get; set; }
        public string titulo { get; set; }
        public string mensaje { get; set; }
        public int estadoCod { get; set; }
        public string estado_descri { get; set; }
        public bool reportado { get; set; }
        public System.DateTime fecha { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
