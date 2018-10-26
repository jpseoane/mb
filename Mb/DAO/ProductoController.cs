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
                                   String descripcion, float precioUnitario, bool activo)
        {
            exito = false;
            try
            {
                Producto Producto = new Producto();
                Producto.UserId = UserId;
                Producto.IdTipo = idTipo;
                Producto.idSubTipo= idSubTipo;
                Producto.descripcion = descripcion;
                Producto.precioUnitario = precioUnitario;
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
            catch (Exception ex)
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
            catch (Exception ex)
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
                        entity.precioUnitario =(float) precioUnitario;
                        entity.activo = activo;
                        entity.fecha_carga = DateTime.Now;
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