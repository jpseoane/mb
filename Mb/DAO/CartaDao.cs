using MbDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mb.DAO
{
    public static class CartaDao
    {
        public static Carta Get(int id)
        {
            using (mbDBContext entities = new mbDBContext())
            {
               return entities.Cartas.FirstOrDefault(e => e.idcarta == id);
            }
        }
        public static IEnumerable<Carta> Get()
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.Cartas.ToList();
            }
        }
        public static bool agregar(Carta carta) {
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
        public static bool agregar(String descri, int idProducto, bool activa, String UserId )
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
        public static bool Borrar(int id)
        {
            bool TodoOk = false;
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {
                    var entity = dBEntities.Cartas.FirstOrDefault(e => e.idcarta == id);
                    if (entity != null)
                    {
                        dBEntities.Cartas.Remove(entity);
                        dBEntities.SaveChanges();
                        TodoOk = true;
                    }                    
                }
            }
            catch (Exception ex)
            {
                TodoOk=false;
            }
            return TodoOk;
        }               
        public static bool update(Carta carta)
        {
            bool TodoOk = false;
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {
                    var entity = dBEntities.Cartas.FirstOrDefault(e => e.idcarta == carta.idcarta);
                    if (entity !=null)
                    {
                        entity.idproducto = carta.idproducto;
                        entity.UserId = carta.UserId;
                        entity.descripcion = carta.descripcion;
                        entity.fecha = carta.fecha;
                        dBEntities.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                TodoOk = false;
            }
            return TodoOk;
        }
        public static bool update(int id, String descri, int idProducto, bool activa, String UserId)
        {
            bool TodoOk = false;
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {
                    var entity = dBEntities.Cartas.FirstOrDefault(e => e.idcarta == id);
                    if (entity != null)
                    {
                        entity.idproducto = idProducto;
                        entity.UserId = UserId;
                        entity.descripcion = descri;
                        entity.fecha = DateTime.Now;
                        dBEntities.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                TodoOk = false;
            }
            return TodoOk;
        }
    }
}