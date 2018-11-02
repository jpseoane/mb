﻿using MbDataAccess;
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
        public static IEnumerable<Carta> Get()
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.Cartas.ToList();
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
                        //entity.idproducto = idProducto;
                        entity.UserId = UserId;
                        entity.descripcion = descri;
                        entity.fecha = DateTime.Now;
                        dBEntities.SaveChanges();
                        //         mens = "Carta actualizada con éxito";
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