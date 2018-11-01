using MbDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mb.DAO
{
    public static class ProductoController
    {
        public static bool exito { get; set; }
        public static String mens { get; set; }
        public static ErrorProducto errorProducto { get; set; }

        public static Producto Get(int id)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.Productoes.FirstOrDefault(e => e.id == id);
            }
        }
        public static IEnumerable<Producto> Get()
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.Productoes.ToList();
            }
        }

        public static IEnumerable<Producto> GetByTipo(int idTipo)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.Productoes.Where(e => e.IdTipo == idTipo).ToList();
            }
        }

        public static IEnumerable<Producto> GetBySubtipo(int idSubtipo)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.Productoes.Where(e => e.idSubTipo == idSubtipo).ToList();
            }
        }

        public static IEnumerable<Producto> GetByTipoySubtipo(int idTipo, int idSubtipo)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.Productoes.Where(e => e.IdTipo==idTipo && e.idSubTipo==idSubtipo).ToList();
            }
        }

        public static IEnumerable<Producto> GetConDescri()
        {
            using (mbDBContext entities = new mbDBContext())
            {
                var productoTipo = (from p in entities.Productoes
                                    join tp in entities.TipoProductoes on p.IdTipo equals tp.Id
                                    select p).FirstOrDefault();

                return entities.Productoes.ToList();
            }
        }


        //En teoria traeria todos los productos de la cartaId que le pase
        public static IEnumerable<Producto> GetTodosPorCartaId(int idCarta)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                var query = from p in entities.Productoes
                            join cp in entities.Carta_Producto on p.id equals cp.idProducto
                            where cp.idCarta == idCarta
                            select p;

               var productos= query.ToList();
               return productos;                
            }
        }


        //Busca en el numero de mesa usuarios habilitados
        public static List<UserMesa> GetUserMesaByNumeroMesa(int numMesa)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                var query = from um in entities.UserMesas
                            join me in entities.Mesas on um.IdMesa equals me.Id
                            where me.numero == numMesa && um.habilitado == true
                            select um;
                var userMesas = query.ToList();
                return userMesas;
            }
        }


        //public static IQueryable hola()
        //{
        //    using (mbDBContext entities = new mbDBContext())
        //    {

        //        //var lalaa = from Producto p in entities.Productoes
        //        //            join tp in entities.TipoProductoes on p.IdTipo equals tp.Id
        //        //            select new  ProductoConDescri
        //        //            {
        //        //                id = p.id,
        //        //                DescripcionTipo = p.descripcion,
        //        //                TipoNombre = tp.descripcion
        //        //            };

        //        //return lalaa;
        //    }
        //}
        //public class ProductoConDescri : Producto
        //{
        //    public Producto producto { get; set; }
        //    public int idTipo { get; set; }
        //    public string tipoDEscri { get; set; }

        //    public IEnumerable<ProductoConDescri> listar()
        //    {
        //        using (mbDBContext entities = new mbDBContext())
        //        {
        //            List<ProductoConDescri> headers = entities.Productoes.Select(p => new ProductoConDescri
        //            {
        //                producto=p,
        //                idTipo = p.IdTipo,
        //                ProductName = p.ProductName
        //            }).ToList();

        //            List<ProductoConDescri> headers = from Producto p in entities.Productoes
        //                                              join tp in entities.TipoProductoes on p.IdTipo equals tp.Id
        //                                              select new ProductoConDescri
        //                                              {
        //                                                  id = p.id,
        //                                                  DescripcionTipo = p.descripcion,
        //                                                  TipoNombre = tp.descripcion
        //                                              }).;

        //            //var lalaa = from Producto p in entities.Productoes
        //            //        //            join tp in entities.TipoProductoes on p.IdTipo equals tp.Id
        //            //        //            select new  ProductoConDescri
        //            //        //            {
        //            //        //                id = p.id,
        //            //        //                DescripcionTipo = p.descripcion,
        //            //        //                TipoNombre = tp.descripcion
        //            //        //            };

        //            //        //return lalaa;
        //        }
        //    }
        //}





        //using (mbDBContext entities = new mbDBContext())
        //{

        //    gv.DataSource = from Producto in entities.Productoes
        //                    from TipoProducto in entities.TipoProductoes
        //                    select new
        //                    {
        //                        ProductoNombre = Producto.descripcion,
        //                        TipoNombre = TipoProducto.descripcion
        //                    };
        //    gv.DataBind();

        //}


        //          public class ProductHeader
        //    {
        //        public int ProductId { get; set; }
        //        public string ProductName { get; set; }
        //    }

        //    List<ProductHeader> headers = context.Products.Select(p => new ProductHeader
        //    {
        //        ProductId = p.ProductId,
        //        ProductName = p.ProductName
        //    }).ToList();

        //}



        //public static IEnumerable<Producto> GetProductosDetalle(int estado)
        //{

        //    try
        //    {
        //        using (mbDBContext dBEntities = new mbDBContext())
        //        {
        //          var productoTipoDescri = 
        //          dBEntities.Productoes.Join(dBEntities.TipoProductoes, pro => pro.IdTipo, tipo => tipo.Id, (pro, tipo) => new { pro, tipo }).Where(x => x.pro.IdTipo == 1);
        //        }
        //    }
        //    catch
        //    {
        //        exito = false;
        //    }

        //}


        //public static object GetProductoConTipoProductoIgual(int tipoProducto)
        //{

        //    try
        //    {
        //        using (mbDBContext dBEntities = new mbDBContext())
        //        {

        //            var productoTipoDescri = dBEntities.Productoes.Join(dBEntities.TipoProductoes, pro => pro.IdTipo, tipo => tipo.Id, (pro, tipo) => new { pro, tipo }).Where(x => x.pro.IdTipo == tipoProducto);

        //        }
        //    }
        //    catch
        //    {
        //        exito = false;
        //    }

        //    return productoTipoDescri;

        //}






        public static bool agregar(Producto Producto)
        {
            exito = false;
            try
            {
                using (mbDBContext ProductoDBEntities = new mbDBContext())
                {
                    ProductoDBEntities.Productoes.Add(Producto);
                    ProductoDBEntities.SaveChanges();
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
                Producto Producto = new Producto();
                Producto.UserId = UserId;
                Producto.IdTipo = idTipo;
                Producto.idSubTipo= idSubTipo;
                Producto.descripcion = descripcion;
                Producto.precioUnitario = (float) precioUnitario;
                Producto.activo = activo;
                Producto.fecha_carga = DateTime.Now;
                using (mbDBContext ProductoDBEntities = new mbDBContext())
                {
                    ProductoDBEntities.Productoes.Add(Producto);
                    ProductoDBEntities.SaveChanges();
                }
                exito = true;             
            }
            catch
            {
                exito = false;                
                errorProducto = new ErrorProducto(1, "Error al carga producto por parametros");
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
                    var entity = dBEntities.Productoes.FirstOrDefault(e => e.id == id);
                    if (entity != null)
                    {
                        dBEntities.Productoes.Remove(entity);
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
        public static bool update(Producto Producto)
        {
            exito = false;
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {
                    var entity = dBEntities.Productoes.FirstOrDefault(e => e.id == Producto.id);
                    if (entity != null)
                    { 
                        entity.UserId = Producto.UserId;
                        entity.IdTipo = Producto.IdTipo;
                        entity.idSubTipo = Producto.idSubTipo;
                        entity.descripcion = Producto.descripcion;
                        entity.precioUnitario = Producto.precioUnitario;
                        entity.activo = Producto.activo;
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
      

        public static bool update(int id,String UserId, int idTipo, int idSubTipo,
                                   String descripcion, Double precioUnitario, bool activo)
        {
            exito = false;
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {
                    var entity = dBEntities.Productoes.FirstOrDefault(e => e.id == id);
                    if (entity != null)
                    {
                        entity.UserId = UserId;
                        entity.IdTipo = idTipo;
                        entity.idSubTipo = idSubTipo;
                        entity.descripcion = descripcion;
                        entity.precioUnitario = (float) precioUnitario;
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

    public class ErrorProducto : Exception
    {

        public int numero { get; set; }
        public String mensaje { get; set; }

        public ErrorProducto()
        {
            this.mensaje = mensaje;
            this.numero = numero;
        }

        public ErrorProducto(int numero, String mensaje)
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