﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MbDataAccess;

namespace Mb.DAO
{
    public static class UserMesaController
    {
        public static bool exito { get; set; }
        public static String mens { get; set; }
        public static ErrorUserMesa errorUserMesa { get; set; }

        public static UserMesa Get(int id)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.UserMesas.FirstOrDefault(e => e.id == id);
            }
        }
        public static IEnumerable<UserMesa> Get()
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.UserMesas.ToList();
            }
        }

        //TODO: Mesa Reservada estadoCod=1
        public static UserMesa MesaReservada()
        {
            UserMesa userMesa = Get(1);
            int numeroDeMesa = userMesa.Mesa.numero;

            using (mbDBContext entities = new mbDBContext())
            {
                return entities.UserMesas.FirstOrDefault(e => e.Mesa.numero == 1);
            }
        }


        public static List<UserMesa> GetUserMesaByNumeroMesa(int numMesa)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return  (from um in entities.UserMesas
                        join me in entities.Mesas on um.IdMesa equals me.Id
                        where me.numero == numMesa
                        select new UserMesa
                        {
                        }).ToList();
               
            }
        }


        public static List<UserMesa> GetUserMesaByNumeroMesa2(int numMesa)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                var query = from um in entities.UserMesas
                            join me in entities.Mesas on um.IdMesa equals me.Id
                            where me.numero == numMesa && um.habilitado==true 
                            select um;
                var userMesas = query.ToList();
                return userMesas;
            }
        }



        //public List<UserMesa> GetUserMesaByNumeroMesa2(int numMesa)
        //{
        //    var query = from p in db.Products
        //                where p.CategoryID == categoryID
        //                select p;
        //    var products = query.ToList();

        //    return products;
        //}



        //        class ClientePresenter
        //        {
        //            public ClientePresenter() { }
        //            public int Id { get; set; }//esto para tener referencia de que registro es..
        //            public int Identificacion { get; set; }
        //            public string clienteNombre { get; set; }
        //            public string contactoNombre { get; set; }

        //        }
        //        y despues realizar:

        //var result = from c in dbContext.Cliente
        //             select new ClientePresenter
        //             {
        //                 Id = c.Id
        //                Identificacion = c.Identificacion,
        //                 clienteNombre = c.Nombre,
        //                 contactoNombre = c.Contacto.Where(x => x.Estado && x.IdTipoContacto == 1)
        //                                        .Select(x => x.Nombres)
        //             };

        //public class AlumnoDireccion
        //{
        //    public string Direccion { get; set; }
        //    public string Nombre { get; set; }
        //    public string Apellido { get; set; }
        //    public string Estado { get; set; }
        //    public double PromedioAcumulado { get; set }
        //}
        //public List<AlumnoDireccion> ListaJoin()
        //{
        //    return (from ad in model.AlumnoDireccion
        //            join a in model.Alumno on ad.AlumnoId equals a.AlumnoId
        //            select new AlumnoDireccion
        //            {
        //                Direccion = ad.Direccion,
        //                Nombre = a.Nombre,
        //                Apellido = a.Apellido,
        //                Estado = a.Estado,
        //                PromedioAcumulado = a.PromedioAcumulado
        //            }).ToList();
        //}


        public static bool agregar(UserMesa UserMesa)
        {
            exito = false;
            try
            {
                using (mbDBContext UserMesaDBEntities = new mbDBContext())
                {
                    UserMesaDBEntities.UserMesas.Add(UserMesa);
                    UserMesaDBEntities.SaveChanges();
                }
                exito = true;
            }
            catch
            {
                exito = false;
            }
            return exito;
        }

        public static bool agregar(String UserId, int idMesa,int perfilMesaUsuCod,bool activo, bool habilitado)
        {
            exito = false;
            try
            {
                UserMesa UserMesa = new UserMesa();
                UserMesa.UserId = UserId;
                UserMesa.IdMesa = idMesa;
                UserMesa.PerfilMesaUsuCod = perfilMesaUsuCod;
                UserMesa.activo = activo;
                UserMesa.habilitado = habilitado;
                UserMesa.fecha = DateTime.Now;
                using (mbDBContext UserMesaDBEntities = new mbDBContext())
                {
                    UserMesaDBEntities.UserMesas.Add(UserMesa);
                    UserMesaDBEntities.SaveChanges();
                }
                exito = true;
                //  mens = "Carga Realizada";
            }
            catch
            {
                exito = false;
                //mens = "Error al intentar cargar - UserMesa";
                errorUserMesa = new ErrorUserMesa(1, "Error en carga");
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
                    var entity = dBEntities.UserMesas.FirstOrDefault(e => e.id == id);
                    if (entity != null)
                    {
                        dBEntities.UserMesas.Remove(entity);
                        dBEntities.SaveChanges();
                        exito = true;
                    }
                }
            }
            catch (Exception ex)
            {
                exito = false;
            }
            return exito;
        }
        public static bool update(UserMesa userMesa)
        {
            exito = false;
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {
                    var entity = dBEntities.UserMesas.FirstOrDefault(e => e.id == userMesa.id);
                    if (entity != null)
                    {
                        entity.UserId = userMesa.UserId;
                        entity.IdMesa = userMesa.IdMesa;
                        entity.PerfilMesaUsuCod = userMesa.PerfilMesaUsuCod;
                        entity.activo = userMesa.activo;
                        entity.habilitado = userMesa.habilitado;                        
                        entity.fecha = DateTime.Now; 
                       dBEntities.SaveChanges();

                    }
                }
            }
            catch (Exception ex)
            {
                exito = false;
            }
            return exito;
        }
    
        public static bool update(int id ,String UserId, int idMesa, int perfilMesaUsuCod, bool activo, bool habilitado)
        {
            exito = false;
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {
                    var entity = dBEntities.UserMesas.FirstOrDefault(e => e.id == id);
                    if (entity != null)
                    {
                        //entity.idproducto = idProducto;
                        entity.UserId = UserId;
                        entity.IdMesa= idMesa;
                        entity.PerfilMesaUsuCod = perfilMesaUsuCod;
                        entity.activo = activo;
                        entity.habilitado = habilitado;                        
                        entity.fecha =   DateTime.Now;
                        dBEntities.SaveChanges();
                        //         mens = "UserMesa actualizada con éxito";
                        exito = true;
                    }
                }
            }
            catch (Exception ex)
            {
                exito = false;
                //mens = "Error al intentar actualizar la UserMesa";
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

    public class ErrorUserMesa : Exception
    {

        public int numero { get; set; }
        public String mensaje { get; set; }

        public ErrorUserMesa()
        {
            this.mensaje = mensaje;
            this.numero = numero;
        }

        public ErrorUserMesa(int numero, String mensaje)
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