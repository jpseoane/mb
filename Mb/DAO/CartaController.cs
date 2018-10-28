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
        public static ErrorCarta errorCarta { get; set; }

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
                errorCarta = new ErrorCarta(1, "Error en carga");
            }
            return exito;

        }



        public static bool Borrar(int id)
        {
            bool TodoOk = false;
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {
                    var entity = dBEntities.Cartas.FirstOrDefault(e => e.id == id);
                    if (entity != null)
                    {
                        dBEntities.Cartas.Remove(entity);
                        dBEntities.SaveChanges();
                        TodoOk = true;
                    }
                }
            }
            catch
            {
                TodoOk = false;
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
                TodoOk = false;
            }
            return TodoOk;
        }
        //public static bool update(int id, String descri, int idProducto, bool activa, String UserId)
        //{
        //    bool TodoOk = false;
        //    try
        //    {
        //        using (mbDBContext dBEntities = new mbDBContext())
        //        {
        //            var entity = dBEntities.Cartas.FirstOrDefault(e => e.idcarta == id);
        //            if (entity != null)
        //            {
        //                entity.idproducto = idProducto;
        //                entity.UserId = UserId;
        //                entity.descripcion = descri;
        //                entity.fecha = DateTime.Now;
        //                dBEntities.SaveChanges();
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        TodoOk = false;
        //    }
        //    return TodoOk;
        //}


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

        public static String GetMensajeError(int numerror)
        {
            String mensaje = "";


            switch (numerror)
            {

                case 1:
                    mensaje = "Error al cargar";
                    break;
                case 2:
                    mensaje = "Error al cargar";
                    break;
                case 3:
                    mensaje = "Error al cargar";
                    break;
                case 4:
                    mensaje = "Error al cargar";
                    break;
                default:

                    break;
            }

            return mensaje;
        }

    }

    public class ErrorCarta : Exception
    {

        public int numero { get; set; }
        public String mensaje { get; set; }

        public ErrorCarta()
        {
            this.mensaje = mensaje;
            this.numero = numero;
        }

        public ErrorCarta(int numero, String mensaje)
        {
            this.mensaje = mensaje;
            this.numero = numero;
        }

        public static String GetMensaje(int numero)
        {
            String mensaje = "";


            switch (numero)
            {

                case 1:

                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:

                    break;
            }

            return mensaje;
        }

    }
}