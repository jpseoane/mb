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
        public static IEnumerable<Pedido> Get()
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.Pedidoes.ToList();
            }
        }

        public static IEnumerable<Pedido> GetByTipo(int id)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.Pedidoes.Where(e => e.id == id).ToList();
            }
        }

        //Obtener todos los pedidos de la mesa
        public static IEnumerable<Pedido> GetTodos(int  numMesa)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                var PedidoTipo = (from p in entities.Pedidoes
                                    join um in entities.UserMesas on p.IdUserMesa equals um.id
                                    join me in entities.Mesas  on um.IdMesa equals me.Id
                                    where me.numero== numMesa
                                  select p).ToList();

                return entities.Pedidoes.ToList();
            }
        }
        
        //Obtener todos los pedidos del usuario
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


        //En teoria traeria todos los Pedidos de la cartaId que le pase
        public static IEnumerable<Pedido> GetTodosPorCartaId(int idCarta)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                var query = from p in entities.Pedidoes                         
                            where cp.idCarta == idCarta
                            select p;


                var Pedidos = query.ToList();
                return Pedidos;
            }
        }

        //Filtrar por Tipo y Subtipo
        public static IEnumerable<Pedido> GetConFiltro(int idCarta, int? idTipo, int? idSubtipo)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                var query = (from p in entities.Pedidoes                           
                             where cp.idCarta == idCarta
                             select p).ToList();

                if (idTipo != null)
                {
                    query = (from p in query
                             where p.IdTipo == idTipo
                             select p).ToList();
                }

                if (idSubtipo != null)
                {
                    query = (from p in query
                             where p.idSubTipo == idSubtipo
                             select p).ToList();
                }

                //var Pedidos = query.ToList();
                return query;
            }
        }


      



        public class PedidosDetalle : Pedido
        {
            private int id { get; set; }
            public int? idUserMesa { get; set; }
            public int? idProducto { get; set; }
            public int? idEstado { get; set; }
            public String estadoPedido { get; set; }
            public String descriProducto { get; set; }            
            private float precioUnitario { get; set; }
            public int? cantidad { get; set; }
            private float subTotal { get; set; }
            public DateTime fecha { get; set; }

        }



        public static List<PedidosDetalle> GetCondetalleConCarta(int idCarta, int idTipo, int idSubTipo)
        {

            using (mbDBContext entities = new mbDBContext())
            {

                var query = from p in entities.Pedidoes
                            from tp in entities.TipoPedidoes.Where(x => x.Id == p.id)
                            from stp in entities.SubTipoes.Where(z => z.id == p.id)
                            from cp in entities.Carta_Pedido.Where(h => h.idPedido == p.id).DefaultIfEmpty()
                            from ca in entities.Cartas.Where(k => k.id == cp.idCarta).DefaultIfEmpty()
                            select new PedidosDetalle
                            {
                                id = p.id,
                                idCarta = cp.idCarta,
                                descriCarta = ca.descripcion,
                                descripcion = p.descripcion,
                                precioUnitario = p.precioUnitario,
                                activo = p.activo,
                                tipoDescri = tp.descripcion,
                                subTipoDescri = stp.descripcion_subtipo,
                                fecha = p.fecha_carga

                            };

                var ProducosDescri = query.ToList();
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


        public static List<PedidosDetalle> GetCondetalleSinCarta()
        {

            using (mbDBContext entities = new mbDBContext())
            {

                var query = from Pedido p in entities.Pedidoes
                            join tp in entities.TipoPedidoes on p.IdTipo equals tp.Id
                            join stp in entities.SubTipoes on p.idSubTipo equals stp.id
                            select new PedidosDetalle
                            {
                                id = p.id,
                                descripcion = p.descripcion,
                                precioUnitario = p.precioUnitario,
                                activo = p.activo,
                                tipoDescri = tp.descripcion,
                                subTipoDescri = stp.descripcion_subtipo,
                                fecha = p.fecha_carga
                            };

                var ProducosDescri = query.ToList();
                return ProducosDescri;
            }


        }


        public static List<PedidosDetalle> GetCondetalleConCarta()
        {

            using (mbDBContext entities = new mbDBContext())
            {

                var query = from p in entities.Pedidoes
                            from tp in entities.TipoPedidoes.Where(x => x.Id == p.id)
                            from stp in entities.SubTipoes.Where(z => z.id == p.id)
                            from cp in entities.Carta_Pedido.Where(h => h.idPedido == p.id).DefaultIfEmpty()
                            from ca in entities.Cartas.Where(k => k.id == cp.idCarta).DefaultIfEmpty()
                            select new PedidosDetalle
                            {
                                id = p.id,
                                idCarta = cp.idCarta,
                                descriCarta = ca.descripcion,
                                descripcion = p.descripcion,
                                precioUnitario = p.precioUnitario,
                                activo = p.activo,
                                tipoDescri = tp.descripcion,
                                subTipoDescri = stp.descripcion_subtipo,
                                fecha = p.fecha_carga

                            };

                var ProducosDescri = query.ToList();
                return ProducosDescri;
            }
        }




        public static List<PedidosDetalle> GetCondetalleXCartaId(int idCarta)
        {

            using (mbDBContext entities = new mbDBContext())
            {

                var query = from Pedido p in entities.Pedidoes
                            join tp in entities.TipoPedidoes on p.IdTipo equals tp.Id
                            join stp in entities.SubTipoes on p.idSubTipo equals stp.id
                            join cp in entities.Carta_Pedido on p.id equals cp.idPedido
                            where cp.idCarta == idCarta
                            select new PedidosDetalle
                            {
                                id = p.id,
                                descripcion = p.descripcion,
                                precioUnitario = p.precioUnitario,
                                activo = p.activo,
                                tipoDescri = tp.descripcion,
                                subTipoDescri = stp.descripcion_subtipo,
                                fecha = p.fecha_carga

                            };

                var ProducosDescri = query.ToList();
                return ProducosDescri;
            }
        }






        public static bool agregar(Pedido Pedido)
        {
            exito = false;
            try
            {
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
            }
            return exito;
        }

        public static bool agregar(String UserId, int idTipo, int idSubTipo,
                                   String descripcion, double precioUnitario, bool activo)
        {
            exito = false;
            try
            {
                Pedido Pedido = new Pedido();
                Pedido.UserId = UserId;
                Pedido.IdTipo = idTipo;
                Pedido.idSubTipo = idSubTipo;
                Pedido.descripcion = descripcion;
                Pedido.precioUnitario = (float)precioUnitario;
                Pedido.activo = activo;
                Pedido.fecha_carga = DateTime.Now;
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
        public static bool update(Pedido Pedido)
        {
            exito = false;
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {
                    var entity = dBEntities.Pedidoes.FirstOrDefault(e => e.id == Pedido.id);
                    if (entity != null)
                    {
                        entity.UserId = Pedido.UserId;
                        entity.IdTipo = Pedido.IdTipo;
                        entity.idSubTipo = Pedido.idSubTipo;
                        entity.descripcion = Pedido.descripcion;
                        entity.precioUnitario = Pedido.precioUnitario;
                        entity.activo = Pedido.activo;
                        entity.fecha_carga = DateTime.Now;
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


        public static bool update(int id, String UserId, int idTipo, int idSubTipo,
                                   String descripcion, Double precioUnitario, bool activo)
        {
            exito = false;
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {
                    var entity = dBEntities.Pedidoes.FirstOrDefault(e => e.id == id);
                    if (entity != null)
                    {
                        entity.UserId = UserId;
                        entity.IdTipo = idTipo;
                        entity.idSubTipo = idSubTipo;
                        entity.descripcion = descripcion;
                        entity.precioUnitario = (float)precioUnitario;
                        entity.activo = activo;
                        entity.fecha_carga = DateTime.Now;
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

        //public static bool UpdateIdCarta(int id, int idCarta)
        //{
        //    exito = false;
        //    try
        //    {
        //        using (mbDBContext dBEntities = new mbDBContext())
        //        {
        //            var entity = dBEntities.Carta_Pedido.Where(x => x.idCarta == idCarta && x.idPedido == id).FirstOrDefault();
        //            if (entity != null)
        //            {
        //                entity. = activo;
        //                dBEntities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        //                dBEntities.SaveChanges();
        //                exito = true;
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        exito = false;
        //    }
        //    return exito;
        //}




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