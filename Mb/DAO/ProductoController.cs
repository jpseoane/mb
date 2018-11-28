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

        //Filtrar por Tipo y Subtipo
        public static IEnumerable<Producto> GetConFiltro(int idCarta, int? idTipo, int? idSubtipo)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                var query = (from p in entities.Productoes
                            join cp in entities.Carta_Producto on p.id equals cp.idProducto
                            where cp.idCarta == idCarta
                            select p).ToList();

                if (idTipo!=null)
                {
                    query = (from p in query
                             where p.IdTipo==idTipo
                           select p).ToList();
                }

                if (idSubtipo!= null)
                {
                    query = (from p in query
                             where p.idSubTipo==idSubtipo
                             select p).ToList();
                }

                //var productos = query.ToList();
                return query;
            }
        }




        public class ProductosDetalle : Producto
        {
            private int id { get; set; }
            public int? idCarta { get; set; }
            public String descriCarta { get; set; }
            private String descripcion { get; set; }
            private float precioUnitario { get; set; }
            private bool activo { get; set; }
            public String tipoDescri { get; set; }
            public String subTipoDescri { get; set; }
            public DateTime fecha { get; set; }
            
        }
        

        public static List<ProductosDetalle> GetCondetalleConCarta(int idCarta, int idTipo, int idSubTipo)
        {

            using (mbDBContext entities = new mbDBContext())
            {

                var query = from p in entities.Productoes
                            from tp in entities.TipoProductoes.Where(x => x.Id == p.id)
                            from stp in entities.SubTipoes.Where(z => z.id == p.id)
                            from cp in entities.Carta_Producto.Where(h => h.idProducto == p.id).DefaultIfEmpty()
                            from ca in entities.Cartas.Where(k => k.id == cp.idCarta).DefaultIfEmpty()
                            select new ProductosDetalle
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


        public static List<ProductosDetalle> GetCondetalleSinCarta()
        {

            using (mbDBContext entities = new mbDBContext())
            {

                var query = from Producto p in entities.Productoes
                            join tp in entities.TipoProductoes on p.IdTipo equals tp.Id
                            join stp in entities.SubTipoes on p.idSubTipo equals stp.id
                            select new ProductosDetalle
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


        public static List<ProductosDetalle> GetCondetalleConCarta()
        {

            using (mbDBContext entities = new mbDBContext())
            {

                var query = from p in entities.Productoes
                            from tp in entities.TipoProductoes.Where(x => x.Id == p.id)
                            from stp in entities.SubTipoes.Where(z => z.id == p.id)
                            from cp in entities.Carta_Producto.Where(h => h.idProducto == p.id).DefaultIfEmpty()
                            from ca in entities.Cartas.Where(k => k.id == cp.idCarta).DefaultIfEmpty()
                            select new ProductosDetalle
                            {
                                id = p.id,
                                idCarta = cp.idCarta,
                                descriCarta=ca.descripcion,
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

    


        public static List<ProductosDetalle> GetCondetalleXCartaId(int idCarta)
        {

            using (mbDBContext entities = new mbDBContext())
            {

                var query = from Producto p in entities.Productoes
                            join tp in entities.TipoProductoes on p.IdTipo equals tp.Id
                            join stp in entities.SubTipoes on p.idSubTipo equals stp.id
                            join cp in entities.Carta_Producto on p.id equals cp.idProducto
                            where cp.idCarta==idCarta
                            select new ProductosDetalle
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


    }
}