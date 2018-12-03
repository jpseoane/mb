using MbDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mb.DAO
{
    public static class CartaController
    {
        public static bool exito { get; set; }
        public static String mens { get; set; }

        public static Carta Get(int id)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.Cartas.FirstOrDefault(e => e.id == id);
            }
        }

        //Trae todas 
        public static IEnumerable<Carta> GetAll()
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.Cartas.ToList(); 
            }
        }


        //Trae todas o solo las activas
        public static IEnumerable<Carta> GetAllByActiva(bool activa)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.Cartas.Where(x => x.activa == activa).ToList();
            }
        }


        public static bool agregar(Carta carta)
        {
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
                cargaOk = false;
            }
            return cargaOk;
        }

        public static bool agregar(String descri, int idProducto, bool activa, String UserId)
        {
            exito = false;
            try
            {
                Carta carta = new Carta();
                carta.activa = activa;
                carta.descripcion = descri;
                carta.UserId = UserId;
                carta.fecha = DateTime.Now;
                using (mbDBContext cartaDBEntities = new mbDBContext())
                {
                    cartaDBEntities.Cartas.Add(carta);
                    cartaDBEntities.SaveChanges();
                }
                exito = true;
                //  mens = "Carga Realizada";
            }
            catch
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
                    var entity = dBEntities.Cartas.FirstOrDefault(e => e.id == id);
                    if (entity != null)
                    {
                        dBEntities.Cartas.Remove(entity);
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
        public static bool update(Carta carta)
        {
            exito = false;
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {
                    var entity = dBEntities.Cartas.FirstOrDefault(e => e.id == carta.id);
                    if (entity != null)
                    {
                        entity.UserId = carta.UserId;
                        entity.descripcion = carta.descripcion;
                        entity.fecha = carta.fecha;
                        entity.activa = carta.activa;
                        dBEntities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
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


        public static bool update(int id, String descri, bool activa, String UserId)
        {
            exito = false;
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {
                    var entity = dBEntities.Cartas.FirstOrDefault(e => e.id == id);
                    if (entity != null)
                    {
                        
                        entity.UserId = UserId;
                        entity.descripcion = descri;
                        entity.fecha = DateTime.Now;
                        entity.activa = activa;
                        dBEntities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                        dBEntities.SaveChanges();
                        
                        exito = true;
                    }
                }
            }
            catch
            {
                exito = false;
                //mens = "Error al intentar actualizar la carta";
            }
            return exito;
        }

    }    
}