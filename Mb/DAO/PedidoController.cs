using MbDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Mb.DAO.UserMesaController;

namespace Mb.DAO
{
    public static class PedidoController
    {
        public static bool exito { get; set; }
        public static String mens { get; set; }
        public static ErrorPedido errorPedido { get; set; }

        public static Pedido Get(int id)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.Pedidoes.FirstOrDefault(e => e.id == id);
            }
        }

        public static IEnumerable<Pedido> GetAll()
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.Pedidoes.ToList();
            }
        }
            

        //Pedidos X Mesa
        public static IEnumerable<Pedido> GetTodos(int numMesa)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                var PedidoTipo = (from p in entities.Pedidoes
                                  join um in entities.UserMesas on p.IdUserMesa equals um.id
                                  join me in entities.Mesas on um.IdMesa equals me.Id
                                  where me.numero == numMesa
                                  select p).ToList();

                return entities.Pedidoes.ToList();
            }
        }

        //Pedidos X usuario
        public static IEnumerable<Pedido> GetTodos(AspNetUser aspNetUser)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                var PedidoTipo = (from p in entities.Pedidoes
                                  join um in entities.UserMesas on p.IdUserMesa equals um.id
                                  where um.UserId == aspNetUser.Id
                                  select p).ToList();

                return entities.Pedidoes.ToList();
            }
        }




        //Pedidos X Mesa Con cierto Estado
        public static IEnumerable<Pedido> GetXMesaXestado(int numMesa, EnumEstadoPedido enumEstado)
        {

            using (mbDBContext entities = new mbDBContext())
            {
                var PedidoTipo = (from p in entities.Pedidoes
                                  join um in entities.UserMesas on p.IdUserMesa equals um.id
                                  join me in entities.Mesas on um.IdMesa equals me.Id
                                  where me.numero == numMesa && p.IdEstado==(int) enumEstado
                                  select p).ToList();

                return entities.Pedidoes.ToList();
            }
        }

        public static bool ExistenPedidosPendientes(int numMesa)
        {

            using (mbDBContext entities = new mbDBContext())
            {
                var Existe = (from p in entities.Pedidoes
                                  join um in entities.UserMesas on p.IdUserMesa equals um.id
                                  join me in entities.Mesas on um.IdMesa equals me.Id
                                  where me.numero == numMesa && p.IdEstado != (int) EnumEstadoPedido.Entregado
                                  select p).Any();

                return Existe;
            }
        }


        //Obtener el subtotal de la mesa con culaquier estado que esten los pedidos
        public static float ObtnerSubtotalXMesaXEstado(int numMesa)
        {

            using (mbDBContext entities = new mbDBContext())
            {
                var Subtotal = (from p in entities.Pedidoes
                                  join um in entities.UserMesas on p.IdUserMesa equals um.id
                                  join me in entities.Mesas on um.IdMesa equals me.Id
                                  where me.numero == numMesa
                                  select p.cantidad * p.precio
                                  );
                                  

                return Subtotal.Sum();
            }
        }

        //Obtener el subtotal de la mesa para el estado
        public static float ObtnerSubtotalXMesaXEstado(int numMesa, EnumEstadoPedido enumEstado)
        {

            using (mbDBContext entities = new mbDBContext())
            {
                var Subtotal = (from p in entities.Pedidoes
                                join um in entities.UserMesas on p.IdUserMesa equals um.id
                                join me in entities.Mesas on um.IdMesa equals me.Id
                                where me.numero == numMesa && p.IdEstado == (int) enumEstado
                                select p.cantidad * p.precio
                                  );


                return Subtotal.Sum();
            }
        }




        public class PedidosDetalle : Pedido
        {
            private int id { get; set; }            
            public int? idUserMesa { get; set; }
            public String userName { get; set; }
            public int? idProducto { get; set; }            
            public String descriProducto { get; set; }
            public float precioUnitario { get; set; }
            public int? cantidad { get; set; }
            public float subTotal { get; set; }
            public DateTime fecha { get; set; }
            public int? idEstado { get; set; }
            public String descriEstadoPedido { get; set; }


        }


        //Traer el datalle del pedido para el usuarioMesa
        public static List<PedidosDetalle> GetCondetalle(int idUserMesa)
        {

            using (mbDBContext entities = new mbDBContext())
            {
                var query = from Pedido p in entities.Pedidoes
                            join um in entities.UserMesas on p.IdUserMesa equals um.id //Join UserMesa
                            join apu in entities.AspNetUsers on um.UserId equals apu.Id //Join AspnetUser
                            join pr in entities.Productoes on p.IdProducto equals pr.id //Join Producto
                            join ep in entities.EstadoPedidoes on p.IdEstado equals ep.id //Join EstadoProducto
                            where p.IdUserMesa==idUserMesa
                            select new PedidosDetalle
                            {
                                id = p.id,
                                idUserMesa=um.id,
                                userName =apu.UserName,
                                idProducto=pr.id,
                                descriProducto=pr.descripcion,
                                precioUnitario=pr.precioUnitario,
                                cantidad =p.cantidad,
                                subTotal =(float) p.subtotal,
                                fecha =p.fecha,
                                idEstado =ep.id,
                                descriEstadoPedido=ep.descripcion
                            };
                var PedidosDetalle = query.ToList();
                //var ProducosDescri = query.Where(p => p.idUserMesa == idUserMesa).ToList();
                return PedidosDetalle;
            }
        }


   


        public static bool agregar(UserMesa userMesa, Producto  producto, int idEstadoProducto,
                                   int cantidad, double precioUnitario, int? idCuenta)
        {
            exito = false;
            try
            {
                Pedido Pedido = new Pedido();
                Pedido.IdUserMesa = userMesa.id;
                Pedido.IdProducto = producto.id;
                Pedido.IdEstado = idEstadoProducto;
                Pedido.cantidad = cantidad;
                Pedido.precio = (float)precioUnitario;
                Pedido.subtotal = (float) (precioUnitario * cantidad);
                Pedido.idCuenta = idCuenta;
                Pedido.fecha = DateTime.Now;
                using (mbDBContext PedidoDBEntities = new mbDBContext())
                {
                    PedidoDBEntities.Pedidoes.Add(Pedido);
                    PedidoDBEntities.SaveChanges();
                }
                exito = true;
            }
            catch
            {
                exito = false;
                errorPedido = new ErrorPedido(1, "Error al carga Pedido por parametros");
            }
            return exito;

        }

        public static bool agregar(int idUserMesa, int idProducto, int idEstadoProducto,
                               int cantidad, double precioUnitario, int? idCuenta)
        {
            exito = false;
            try
            {
                Pedido Pedido = new Pedido();
                Pedido.IdUserMesa = idUserMesa;
                Pedido.IdProducto = idProducto;
                Pedido.IdEstado = idEstadoProducto;
                Pedido.cantidad = cantidad;
                Pedido.precio = (float)precioUnitario;
                Pedido.subtotal = (float)(precioUnitario * cantidad);
                Pedido.idCuenta = idCuenta;
                Pedido.fecha = DateTime.Now;
                using (mbDBContext PedidoDBEntities = new mbDBContext())
                {
                    PedidoDBEntities.Pedidoes.Add(Pedido);
                    PedidoDBEntities.SaveChanges();
                }
                exito = true;
            }
            catch
            {
                exito = false;
                errorPedido = new ErrorPedido(1, "Error al carga Pedido por parametros");
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
                    var entity = dBEntities.Pedidoes.FirstOrDefault(e => e.id == id);
                    if (entity != null)
                    {
                        dBEntities.Pedidoes.Remove(entity);
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

        public enum EnumEstadoPedido { Encargado = 1, Preparacion = 2, Entregado = 3, PedidoDeCuenta = 4, RecibidoYpagado = 5 };

        //Actualizar el estado de un pedido 
        public static bool UpdatePedidoEstado(int idPedido, EnumEstadoPedido enumEstado)
        {
            exito = false;
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {
                    var entity = dBEntities.Pedidoes.Where(x => x.id == idPedido).FirstOrDefault();
                    if (entity != null)
                    {
                        entity.IdEstado =(int)enumEstado;
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

        //Actualizar el estado de una lista de pedidos para cierta mesa (numero de mesa) al idEstado que se le pasa
        public static bool UpdatePedidosDeMesaEstado(int numeroMesa, EnumEstadoPedido enumEstado)
        {
            IEnumerable<Pedido> ListaPedidosDeMesa= GetTodos(numeroMesa); 
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {
                    foreach (Pedido pedido  in ListaPedidosDeMesa){
                        pedido.IdEstado = (int) enumEstado;
                        dBEntities.Entry(pedido).State = System.Data.Entity.EntityState.Modified;
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

        //Actualizar el estado de una lista de pedidos para cierta mesa (numero de mesa) al idEstado que se le pasa
        public static Cuenta PedirCuentaMesa(UsuarioMesaDetalle  usuarioMesaDetalle)
        {
            //Creo la cuenta
            Cuenta cuenta = CuentaController.CrearyObtnerCuenta(usuarioMesaDetalle);
            if (cuenta != null)
            {            
                try
                {
                    //Obtengo los pedidos de la mesa
                    IEnumerable<Pedido> ListaPedidosDeMesa = GetTodos(usuarioMesaDetalle.mesaNumero);

                    using (mbDBContext dBEntities = new mbDBContext())
                    {
                        //Actualizo el estado de los pedidos y le asigno su id de cuenta
                        foreach (Pedido pedido in ListaPedidosDeMesa)
                        {
                            pedido.IdEstado = (int) EnumEstadoPedido.PedidoDeCuenta;
                            pedido.idCuenta = cuenta.id;
                            dBEntities.Entry(pedido).State = System.Data.Entity.EntityState.Modified;
                            dBEntities.SaveChanges();
                            exito = true;
                        }
                    }
                }
                catch
                {
                    exito = false;
                }
            }
            return cuenta;
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

    public class ErrorPedido : Exception
    {

        public int numero { get; set; }
        public String mensaje { get; set; }

        public ErrorPedido()
        {
            this.mensaje = mensaje;
            this.numero = numero;
        }

        public ErrorPedido(int numero, String mensaje)
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