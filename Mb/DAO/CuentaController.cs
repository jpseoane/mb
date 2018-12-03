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

        public enum EnumEstadoCuenta { Solicitada = 1, EnEsperaDelPago = 2, PagadoyCerrado = 3 };
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



        //Obtener cuenta actual por numero de mesa en cualquier estado
        public static Cuenta GetActualporNumeroMesa(int numeroMesa)

        {
            using (mbDBContext entities = new mbDBContext())
            {
                Cuenta cuenta = (from cu in entities.Cuentas
                              join um in entities.UserMesas on cu.idUserMesa equals um.id
                              join me in entities.Mesas on um.IdMesa equals me.Id
                              where me.numero == numeroMesa && cu.esactual == true
                                 select cu).FirstOrDefault();


        
                return cuenta;
            }
        }

        //Obtener cuenta actual por numero de mesa en cualquier estado
        public static Cuenta GetActualporusuario(int idUSerMesa)

        {
            using (mbDBContext entities = new mbDBContext())
            {
                Cuenta cuenta = (from cu in entities.Cuentas
                                 join um in entities.UserMesas on cu.idUserMesa equals um.id
                                 join me in entities.Mesas on um.IdMesa equals me.Id
                                 where um.id == idUSerMesa && cu.esactual==true
                                 select cu).FirstOrDefault();

                return cuenta;
            }
        }



        //Obtener todas las cuenta X numero de mesa y si quiero solo la actual
        public static IEnumerable<Cuenta> GetXNumeroMesa(int numeroMesa, bool? actual)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                var cuenta = (from cu in entities.Cuentas
                              join um in entities.UserMesas on cu.idUserMesa equals um.id
                              join me in entities.Mesas on um.IdMesa equals me.Id
                              where me.numero == numeroMesa  
                             select cu).ToList();


                if (actual != null)
                {
                    cuenta = (from mm in cuenta
                              where mm.esactual == actual
                                      select mm).ToList();
                }
                return cuenta.ToList();
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


        //Traer todas las cuentas con detalle para el usuarioMesa y si quiero la actual
        public static List<CuentaDetalle> GetAlldetalle(bool? actual, int numeroMesa,int estadoCuenta)
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

                if (actual != null )
                {
                    CuentaDetalle = (from mm in CuentaDetalle
                                     where mm.esactual == actual
                              select mm).ToList();
                }

                if (numeroMesa != 0)
                {
                    CuentaDetalle = (from me in CuentaDetalle
                                     where me.numeroMesa == numeroMesa
                                     select me).ToList();
                }

                if (estadoCuenta != 0)
                {
                    CuentaDetalle = (from c in CuentaDetalle
                                     where c.estadoCod == estadoCuenta
                                     select c).ToList();
                }



                return CuentaDetalle.ToList();
                
            }
        }


        public static IEnumerable<Cuenta> GetXUsuMesaXEstado(int idUserMesa, EnumEstadoCuenta enumEstadoCuenta, bool? actual)
        {
            using (mbDBContext entities = new mbDBContext())
            {
               var  cuenta = (from cu in entities.Cuentas
                                 where cu.idUserMesa == idUserMesa && cu.estadoCod==(int) enumEstadoCuenta
                                 select cu).ToList();


                if (actual != null)
                {
                    cuenta = (from mm in cuenta
                              where mm.esactual == actual
                              select mm).ToList();
                }
                return cuenta.ToList();
            }
        }

        //Busca si existe una cuenta con cualquier estado pero que sea actual=true para la mesa
        public static bool ExisteCuentaActiva(int numMesa)
        {

            using (mbDBContext entities = new mbDBContext())
            {
                var Existe = (from cu in entities.Cuentas
                              join um in entities.UserMesas on cu.idUserMesa equals um.id
                              join me in entities.Mesas on um.IdMesa equals me.Id
                              where me.numero == numMesa && cu.esactual==true
                              select cu).Any();

                return Existe;
            }
        }

        //Busca si existe una cuenta con cualquier estado pero que sea actual=true Para el userid
        public static bool ExisteCuentaActiva(String userId)
        {

            using (mbDBContext entities = new mbDBContext())
            {
                var Existe = (from cu in entities.Cuentas
                              join um in entities.UserMesas on cu.idUserMesa equals um.id
                              where um.UserId == userId && cu.esactual == true
                              select cu).Any();

                return Existe;
            }
        }

     


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
                Cuenta.esactual = true;
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

            return  GetActualporusuario(usuarioMesaDetalle.id);

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


        //Actualizar cuenta
        public static bool Update(Cuenta cuenta)
        {
            exito = false;
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {   
                    if (cuenta != null)
                    {   
                        dBEntities.Entry(cuenta).State = System.Data.Entity.EntityState.Modified;
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
                    Cuenta cuenta = GetActualporNumeroMesa(numeroMesa);
                    cuenta.estadoCod = (int) EnumEstadoCuenta.PagadoyCerrado;
                    cuenta.estado_descri = EnumEstadoCuenta.PagadoyCerrado.ToString();
                    cuenta.esactual = false;
                    //Corro update
                    if (Update(cuenta)){
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