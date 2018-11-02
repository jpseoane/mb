using System;
using System.Collections.Generic;
using System.Linq;

using MbDataAccess;

namespace Mb.DAO
{
    public static class CartaProductoController
    {
        public static bool exito { get; set; }
        public static String mens { get; set; }

        public static Carta_Producto Get(int id)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.Carta_Producto.FirstOrDefault(e => e.id == id);
            }
        }
        public static IEnumerable<Carta_Producto> Get()
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.Carta_Producto.ToList();
            }
        }
        public static bool agregar(Carta_Producto carta_Producto)
        {
            bool cargaOk = false;
            try
            {
                using (mbDBContext cartaDBEntities = new mbDBContext())
                {
                    cartaDBEntities.Carta_Producto.Add(carta_Producto);
                    cartaDBEntities.SaveChanges();
                }
                cargaOk = true;
            }
            catch
            {
                cargaOk = false;
            }
            return cargaOk;
        }

        public static bool agregar( int idProducto, int idCarta, String userId)
        {
            exito = false;
            try
            {
                Carta_Producto carta_Producto = new Carta_Producto();
                carta_Producto.idCarta = idCarta;
                carta_Producto.idProducto = idProducto;
                carta_Producto.UserId = userId;
                carta_Producto.fecha = DateTime.Now;
                carta_Producto.estado = 1;
                using (mbDBContext cartaDBEntities = new mbDBContext())
                {
                    cartaDBEntities.Carta_Producto.Add(carta_Producto);
                    cartaDBEntities.SaveChanges();
                }
                exito = true;
             
            }
            catch (Exception e)
            {
                exito = false;

                //mens = "Error al intentar cargar - Carta";

            }
            return exito;

        }



        public static bool Borrar(int id)
        {
            exito = false;
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {
                    var entity = dBEntities.Carta_Producto.FirstOrDefault(e => e.id == id);
                    if (entity != null)
                    {
                        dBEntities.Carta_Producto.Remove(entity);
                        dBEntities.SaveChanges();
                        exito = true;
                    }
                }
            }
            catch
            {
                exito = false;
            }
            return exito;
        }
        public static bool update(Carta_Producto carta)
        {
            exito = false;
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {
                    var entity = dBEntities.Carta_Producto.FirstOrDefault(e => e.id == carta.id);
                    if (entity != null)
                    {
                        entity.idCarta = carta.idCarta;
                        entity.idProducto = carta.idProducto;
                        entity.fecha = DateTime.Now;
                        dBEntities.SaveChanges();
                    }
                }
            }
            catch
            {
                exito = false;
            }
            return exito;
        }


        public static bool update(int id, int idProducto, int idCarta)
        {
            exito = false;
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {
                    var entity = dBEntities.Carta_Producto.FirstOrDefault(e => e.id == id);
                    if (entity != null)
                    {                     
                        entity.idCarta = idCarta;
                        entity.idProducto = idProducto;
                        entity.fecha = DateTime.Now;
                        dBEntities.SaveChanges();
                        exito = true;
                    }
                }
            }
            catch
            {
                exito = false;               
            }
            return exito;
        }

    }
}