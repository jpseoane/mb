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
    
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            this.AspNetUserClaims = new HashSet<AspNetUserClaim>();
            this.AspNetUserLogins = new HashSet<AspNetUserLogin>();
            this.Cartas = new HashSet<Carta>();
            this.Clientes = new HashSet<Cliente>();
            this.MensajeMuroes = new HashSet<MensajeMuro>();
            this.Pedidoes = new HashSet<Pedido>();
            this.Productoes = new HashSet<Producto>();
            this.UserMesas = new HashSet<UserMesa>();
            this.AspNetRoles = new HashSet<AspNetRole>();
        }
    
        public string Id { get; set; }
        public string Email { get; set; }
        public Nullable<bool> EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
    
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<Carta> Cartas { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<MensajeMuro> MensajeMuroes { get; set; }
        public virtual ICollection<Pedido> Pedidoes { get; set; }
        public virtual ICollection<Producto> Productoes { get; set; }
        public virtual ICollection<UserMesa> UserMesas { get; set; }
        public virtual ICollection<AspNetRole> AspNetRoles { get; set; }
    }
}
