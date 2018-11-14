using MbDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public static IEnumerable<Pedido> GetXMesaXestado(int numMesa, int idEstado)
        {

            using (mbDBContext entities = new mbDBContext())
            {
                var PedidoTipo = (from p in entities.Pedidoes
                                  join um in entities.UserMesas on p.IdUserMesa equals um.id
                                  join me in entities.Mesas on um.IdMesa equals me.Id
                                  where me.numero == numMesa && p.IdEstado==idEstado
                                  select p).ToList();

                return entities.Pedidoes.ToList();
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
        public static List<PedidosDetalle> GetCondetalle(UserMesa userMesa)
        {

            using (mbDBContext entities = new mbDBContext())
            {
                var query = from p in entities.Pedidoes
                            from um in entities.UserMesas.Where(a => a.id == p.IdUserMesa) //Join UserMesa
                            from apu in entities.AspNetUsers.Where(b => b.Id == um.UserId) //Join AspnetUser
                            from pr in entities.Productoes.Where(c => c.id == p.IdProducto) //Join Producto
                            from ep in entities.EstadoPedidoes.Where(d => d.id == p.IdEstado) //Join EstadoProducto
                            select new PedidosDetalle
                            {
                                id = p.id,
                                idUserMesa=um.id,
                                userName =apu.UserName,
                                idProducto=pr.id,
                                descriProducto=pr.descripcion,
                                precioUnitario=pr.precioUnitario,
                                cantidad =p.cantidad,
                                subTotal =p.subtotal,
                                fecha =p.fecha,
                                idEstado =ep.id,
                                descriEstadoPedido=ep.descripcion
                            };
                var ProducosDescri = query.Where(u => u.id==userMesa.id).ToList();
                return ProducosDescri;
            }


            //var result = this.context.employees.Where(
            //     x => x.Id == id &&
            //     (LocationId == null || LocationId.Contains(x.locationId)) &&
            //     (PayrollNo == null || x.payrollNo == PayrollNo) &&
            //     (rowVersion == null || x.rowVersion > rowVersion));

            // Otra formaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa

            //    var query = from u in DataContext.Users
            //                where u.Division == strUserDiv
            //                && u.Age > 18
            //                && u.Height > strHeightinFeet
            //                select u;

            //    if (useAge)
            //        query = query.Where(u => u.Age > age);

            //    if (useHeight)
            //        query = query.Where(u => u.Height > strHeightinFeet);

            //    // Build the results at the end
            //    var results = query.Select(u => new DTO_UserMaster
            //    {
            //        Prop1 = u.Name,
            //    }).ToList();
        }


   


        public static bool agregar(UserMesa userMesa, Producto  producto, int idEstadoProducto,
                                   int cantidad, double precioUnitario)
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
                               int cantidad, double precioUnitario)
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
        // id codigo  descripcion fecha
        // 1	E Encargado	2018-10-01 00:00:00.000
        // 2	EP En preparacion	2018-10-01 00:00:00.000
        // 3	PP Preparandose	2018-10-01 00:00:00.000
        // 4	PE Para Entregar	2018-10-01 00:00:00.000
        // 5	EN Entregado	2018-10-01 00:00:00.000

        //Actualizar el estado de un pedido 
        public static bool UpdatePedidoEstado(int idPedido, int idEstado)
        {
            exito = false;
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {
                    var entity = dBEntities.Pedidoes.Where(x => x.id == idPedido).FirstOrDefault();
                    if (entity != null)
                    {
                        entity.IdEstado =idEstado;
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

// id codigo  descripcion fecha
// 1	E Encargado	2018-10-01 00:00:00.000
// 2	EP En preparacion	2018-10-01 00:00:00.000
// 3	PP Preparandose	2018-10-01 00:00:00.000
// 4	PE Para Entregar	2018-10-01 00:00:00.000
// 5	EN Entregado	2018-10-01 00:00:00.000

        //Actualizar el estado de una lista de pedidos para cierta mesa (numero de mesa) al idEstado que se le pasa
        public static bool UpdatePedidosDeMesaEstado(int numeroMesa, int idEstado)
        {
            IEnumerable<Pedido> ListaPedidosDeMesa= GetTodos(numeroMesa); 
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {
                    foreach (Pedido pedido  in ListaPedidosDeMesa){
                        pedido.IdEstado = idEstado;
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