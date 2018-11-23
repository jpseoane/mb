using System;
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

        public static UserMesa GetByIdUSer(String userID)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.UserMesas.FirstOrDefault(e => e.UserId == userID);
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


        //Busca en el numero de mesa usuarios habilitados
        public static List<UserMesa> GetUserMesaByNumeroMesa(int numMesa)
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


        public class UsuarioMesaDetalle : UserMesa
        {
            public int id { get; set; }
            public String idUser { get; set; }
            public String email { get; set; }
            public int idMesa { get; set; }
            public int idPerfilMesa { get; set; }
            public int mesaNumero { get; set; }
            public bool activo { get; set; }
            public String perfilEnMesa { get; set; }
            public bool habilitado { get; set; }
          
        }

        //Obtiene todos los usuarios que estan guardados hasta el momento en la mesa del usuario con habilitado (activo) 
        //sean o no perfil administrador X idDeMesa
        public static List<UsuarioMesaDetalle> GetUsuariosPorIdMesa(int idmesa)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                var query = from UserMesa um in entities.UserMesas
                            join asu in entities.AspNetUsers on um.UserId equals asu.Id
                            join ms in entities.Mesas on um.IdMesa equals ms.Id
                            join pm in entities.PerfilMesas on um.idPerfilMesa equals pm.id
                            where um.IdMesa == idmesa && um.habilitado == true
                            select new UsuarioMesaDetalle
                            {
                                id = um.id,
                                idUser = asu.Id,
                                idMesa =um.IdMesa,
                                email = asu.Email,
                                mesaNumero = ms.numero,
                                activo=um.activo,
                                perfilEnMesa = pm.descripcion,
                                habilitado = um.habilitado
                            };
                
                var userMesas = query.ToList();
                
                return userMesas;
            }
        }
      
        public static UsuarioMesaDetalle GetUsuarioDeMesaByIdUser(String userId)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                var query = from UserMesa um in entities.UserMesas
                            join asu in entities.AspNetUsers on um.UserId equals asu.Id
                            join ms in entities.Mesas on um.IdMesa equals ms.Id
                            join pm in entities.PerfilMesas on um.idPerfilMesa equals pm.id
                            where asu.Id == userId
                            select new UsuarioMesaDetalle
                            {
                                id = um.id,
                                idMesa = um.IdMesa,
                                idPerfilMesa = um.idPerfilMesa,
                                email = asu.Email,
                                mesaNumero = ms.numero,
                                activo = um.activo,
                                perfilEnMesa = pm.descripcion,
                                habilitado = um.habilitado
                            };

                var usuarioDeMesa = query.FirstOrDefault();
                return usuarioDeMesa;
            }
        }



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

        public static bool agregar(String UserId, int idMesa,int idPerfilMesa,bool activo, bool habilitado)
        {
            exito = false;
            try
            {
                
                UserMesa UserMesa = new UserMesa();
                UserMesa.UserId = UserId;
                UserMesa.IdMesa = idMesa;
                UserMesa.idPerfilMesa = idPerfilMesa;
                UserMesa.activo = activo;
                UserMesa.habilitado = habilitado;
                UserMesa.fecha = DateTime.Now;
                using (mbDBContext UserMesaDBEntities = new mbDBContext())
                {
                    //UserMesaDBEntities.Entry(UserMesa).State = UserMesa.Modified;
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

        public static bool UpdateActivo(int id, bool activo)
        {
            exito = false;
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {
                    var entity = dBEntities.UserMesas.FirstOrDefault(e => e.id == id);
                    if (entity != null)
                    {
                        entity.activo = activo;
                        dBEntities.Entry(entity).State = System.Data.Entity.EntityState.Modified;                        
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
            catch 
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
                       entity.idPerfilMesa = userMesa.idPerfilMesa;
                       entity.activo = userMesa.activo;
                       entity.habilitado = userMesa.habilitado;                        
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
    
        public static bool update(int id ,String UserId, int idMesa, int idPerfilMesa, bool activo, bool habilitado)
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
                        entity.idPerfilMesa = idPerfilMesa;
                        entity.activo = activo;
                        entity.habilitado = habilitado;                        
                        entity.fecha =   DateTime.Now;
                        dBEntities.SaveChanges();
                        //         mens = "UserMesa actualizada con éxito";
                        exito = true;
                    }
                }
            }
            catch 
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