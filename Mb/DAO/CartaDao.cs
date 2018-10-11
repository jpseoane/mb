using MbDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mb.DAO
{
    public class CartaDao
    {

        public bool agregar(Carta carta) {
            bool cargaOk = false;
            try
            {                
                using (mbDBContext cartaDBEntities = new mbDBContext())
                {
                    cartaDBEntities.Cartas.Add(carta);
                    cartaDBEntities.SaveChanges();
                }
                cargaOk = true;
            }
            catch 
            {
                cargaOk=false;
            }
            
            return cargaOk;
        }

        public bool agregar(String descri, int idProducto, bool activa, String UserId )
        {
            bool cargaOk=false;
            try
            {
                Carta carta = new Carta();
                carta.activa = activa;
                carta.descripcion = descri;
                carta.UserId = UserId;
                carta.idproducto = idProducto;
                carta.fecha = DateTime.Now;
                using (mbDBContext cartaDBEntities = new mbDBContext())
                {
                    cartaDBEntities.Cartas.Add(carta);
                    cartaDBEntities.SaveChanges();
                }
                cargaOk = true;
            }
            catch
            {
                cargaOk=false;
            }
            return cargaOk;

        }
         
        }
    }
}