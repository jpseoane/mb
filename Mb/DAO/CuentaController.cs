using MbDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Mb.DAO.UserMesaController;

namespace Mb.DAO
{
    public class CuentaController
    {

        public enum EnumEstadoCuenta { Solicitada = 1, AceptayEnviarParaCobro = 2, PagadoyCerrado = 3 };
        public static bool exito { get; set; }
        public static String mens { get; set; }
        public static ErrorCuenta errorCuenta { get; set; }

        public static Cuenta Get(int id)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.Cuentas.FirstOrDefault(e => e.id == id);
            }
        }

        public static IEnumerable<Cuenta> GetAll()
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.Cuentas.ToList();
            }
        }


        //Obtener cuenta X IdUserMesa
        public static Cuenta GetXUsuMesa(int idUserMesa)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                Cuenta cuenta = (from p in entities.Cuentas                                  
                                  where p.idUserMesa == idUserMesa
                                  select p).FirstOrDefault();

                return cuenta;
            }
        }


        //Obtener cuenta X IdUserMesa
        public static Cuenta GetXNumeroMesa(int numeroMesa)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                Cuenta cuenta = (from cu in entities.Cuentas
                              join um in entities.UserMesas on cu.idUserMesa equals um.id
                              join me in entities.Mesas on um.IdMesa equals me.Id
                              where me.numero == numeroMesa 
                                select cu).FirstOrDefault();

                return cuenta;
            }
        }


        public class CuentaDetalle : Cuenta
        {
            //private int id { get; set; }
            public int idUserMesa { get; set; }
            public String userName { get; set; }
            public String email { get; set; }
            public int numeroMesa { get; set; }
            
            //public float Total { get; set; }
            //public DateTime fecha { get; set; }
            


        }


        //Traer todas las cuentas con detalle para el usuarioMesa
        public static List<CuentaDetalle> GetAlldetalle()
        {

            using (mbDBContext entities = new mbDBContext())
            {
                var query = from Cuenta c in entities.Cuentas
                            join um in entities.UserMesas on c.idUserMesa equals um.id //Join UserMesa
                            join me in entities.Mesas  on um.IdMesa equals me.Id //Join Mesa
                            join apu in entities.AspNetUsers on um.UserId equals apu.Id //Join AspnetUser
                            
                            select new CuentaDetalle
                            {
                                id = c.id,
                                idUserMesa = um.id,
                                userName = apu.UserName,
                                email =apu.Email,
                                numeroMesa = me.numero,                                
                                total = c.total,
                                fecha = c.fecha,
                                estadoCod = c.estadoCod,
                                estado_descri= c.estado_descri
                            };
                var CuentaDetalle = query.ToList();
                return CuentaDetalle;
            }
        }


        public static Cuenta GetXUsuMesaXEstado(int idUserMesa, EnumEstadoCuenta enumEstadoCuenta)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                Cuenta cuenta = (from p in entities.Cuentas
                                 where p.idUserMesa == idUserMesa && p.estadoCod==(int) enumEstadoCuenta
                                 select p).FirstOrDefault();

                return cuenta;
            }
        }

        public static bool ExisteCuentaActiva(int numMesa)
        {

            using (mbDBContext entities = new mbDBContext())
            {
                var Existe = (from cu in entities.Cuentas
                              join um in entities.UserMesas on cu.idUserMesa equals um.id
                              join me in entities.Mesas on um.IdMesa equals me.Id
                              where me.numero == numMesa && cu.estadoCod != (int)EnumEstadoCuenta.PagadoyCerrado
                              select cu).Any();

                return Existe;
            }
        }

        public static bool ExisteCuentaActiva(String userId)
        {

            using (mbDBContext entities = new mbDBContext())
            {
                var Existe = (from cu in entities.Cuentas
                              join um in entities.UserMesas on cu.idUserMesa equals um.id
                              where um.UserId == userId && cu.estadoCod != (int) EnumEstadoCuenta.PagadoyCerrado
                              select cu).Any();

                return Existe;
            }
        }

        ////Cuentas X usuario
        //public static IEnumerable<Cuenta> GetTodos(AspNetUser aspNetUser)
        //{
        //    using (mbDBContext entities = new mbDBContext())
        //    {
        //        var CuentaTipo = (from p in entities.Cuentas
        //                          join um in entities.UserMesas on p.IdUserMesa equals um.id
        //                          where um.UserId == aspNetUser.Id
        //                          select p).ToList();

        //        return entities.Cuentas.ToList();
        //    }
        //}




        ////Cuentas X Mesa Con cierto Estado
        //public static IEnumerable<Cuenta> GetXMesaXestado(int numMesa, EnumEstadoCuenta enumEstado)
        //{

        //    using (mbDBContext entities = new mbDBContext())
        //    {
        //        var CuentaTipo = (from p in entities.Cuentas
        //                          join um in entities.UserMesas on p.IdUserMesa equals um.id
        //                          join me in entities.Mesas on um.IdMesa equals me.Id
        //                          where me.numero == numMesa && p.IdEstado == (int)enumEstado
        //                          select p).ToList();

        //        return entities.Cuentas.ToList();
        //    }
        //}

        //public static bool ExistenCuentasPendientes(int numMesa)
        //{

        //    using (mbDBContext entities = new mbDBContext())
        //    {
        //        var Existe = (from p in entities.Cuentas
        //                      join um in entities.UserMesas on p.IdUserMesa equals um.id
        //                      join me in entities.Mesas on um.IdMesa equals me.Id
        //                      where me.numero == numMesa && p.IdEstado != (int)EnumEstadoCuenta.Entregado
        //                      select p).Any();

        //        return Existe;
        //    }
        //}


        ////Obtener el subtotal de la mesa con culaquier estado que esten los Cuentas
        //public static float ObtnerSubtotalXMesaXEstado(int numMesa)
        //{

        //    using (mbDBContext entities = new mbDBContext())
        //    {
        //        var Subtotal = (from p in entities.Cuentas
        //                        join um in entities.UserMesas on p.IdUserMesa equals um.id
        //                        join me in entities.Mesas on um.IdMesa equals me.Id
        //                        where me.numero == numMesa
        //                        select p.cantidad * p.precio
        //                          );


        //        return Subtotal.Sum();
        //    }
        //}

        ////Obtener el subtotal de la mesa para el estado+++
        //public static float ObtnerSubtotalXMesaXEstado(int numMesa, EnumEstadoCuenta enumEstado)
        //{

        //    using (mbDBContext entities = new mbDBContext())
        //    {
        //        var Subtotal = (from p in entities.Cuentas
        //                        join um in entities.UserMesas on p.IdUserMesa equals um.id
        //                        join me in entities.Mesas on um.IdMesa equals me.Id
        //                        where me.numero == numMesa && p.IdEstado == (int)enumEstado
        //                        select p.cantidad * p.precio
        //                          );


        //        return Subtotal.Sum();
        //    }
        //}





        public static Cuenta CrearyObtnerCuenta(UsuarioMesaDetalle usuarioMesaDetalle)
        {
            try
            {
              //  UserMesa userMesa = UserMesaController.Get(iduserMesa);
                Cuenta Cuenta = new Cuenta();
                Cuenta.idUserMesa = usuarioMesaDetalle.id;
                Cuenta.estadoCod = (int) EnumEstadoCuenta.Solicitada;
                Cuenta.estado_descri = EnumEstadoCuenta.Solicitada.ToString();
                Cuenta.total = PedidoController.ObtnerSubtotalXMesa(usuarioMesaDetalle.mesaNumero);                
                Cuenta.fecha = DateTime.Now;
                using (mbDBContext CuentaDBEntities = new mbDBContext())
                {
                    CuentaDBEntities.Cuentas.Add(Cuenta);
                    CuentaDBEntities.SaveChanges();
                }
            }
            catch
            {
                exito = false;
                errorCuenta = new ErrorCuenta(1, "Error al carga Cuenta por parametros");
            }

            return GetXUsuMesaXEstado(usuarioMesaDetalle.id, EnumEstadoCuenta.Solicitada);

        }



        public static bool Borrar(int id)
        {
            bool TodoOk = false;
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {
                    var entity = dBEntities.Cuentas.FirstOrDefault(e => e.id == id);
                    if (entity != null)
                    {
                        dBEntities.Cuentas.Remove(entity);
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

        

        //Actualizar el estado de un Cuenta 
        public static bool UpdateCuentastado(int idCuenta, EnumEstadoCuenta enumEstado)
        {
            exito = false;
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {
                    var entity = dBEntities.Cuentas.Where(x => x.id == idCuenta).FirstOrDefault();
                    if (entity != null)
                    {
                        entity.estadoCod = (int) enumEstado;
                        entity.estado_descri = (String) enumEstado.ToString();
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


        //Cerrar la cuenta, pedidos y mesa 
        public static bool CerrarCuenta(int idCuenta, int numeroMesa)
        {
            exito = false;
            try
            {
                //Cierro todos los pedidos (id estado pedido 5, Recibido y pagado) que tengan el idcuenta pasado
                if (PedidoController.UpdatePedidosDeMesaEstado(numeroMesa, PedidoController.EnumEstadoPedido.RecibidoYpagado))
                {
                    //Actualizo el estado de la cuenta
                    if (UpdateCuentastado(idCuenta, EnumEstadoCuenta.PagadoyCerrado)) {
                        //Libero la mesa (Actualizo el estado de todos los usuarios mesa a activo false
                        Mesa mesa = MesaController.GetbyNumeroMesa(numeroMesa);
                        if (UserMesaController.CerrarUsuariosDeMesa(mesa)) {

                            //Finalizo con exito
                            exito = true;
                        }
                        else
                        {
                            //No pudo actualizarse el estado de los usuarios en la mesa
                            exito = false;
                        }

                    }
                    else
                    {
                        //No pudo actualizarse el estado de la cuenta
                        exito = false;
                    }
                    
                }
                else
                {
                    //No pudo actualizarse los pedidos de la mesa
                    exito = false;
                }
            }
            catch
            {
                //No pudo actualizarse
                exito = false;
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

    public class ErrorCuenta : Exception
    {

        public int numero { get; set; }
        public String mensaje { get; set; }

        public ErrorCuenta()
        {
            this.mensaje = mensaje;
            this.numero = numero;
        }

        public ErrorCuenta(int numero, String mensaje)
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