using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MbDataAccess;

namespace Mb.DAO
{
    public static class MesaController
    {
        public static bool exito { get; set; }
        public static String mens { get; set; }
        public static ErrorMesa errorMesa { get; set; }

        public static Mesa Get(int id)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.Mesas.FirstOrDefault(e => e.Id == id);
            }
        }
        public static IEnumerable<Mesa> Get()
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.Mesas.ToList();
            }
        }

     

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


        public static bool agregar(Mesa Mesa)
        {
            exito = false;
            try
            {
                using (mbDBContext MesaDBEntities = new mbDBContext())
                {
                    MesaDBEntities.Mesas.Add(Mesa);
                    MesaDBEntities.SaveChanges();
                }
                exito = true;
            }
            catch
            {
                exito = false;
            }
            return exito;
        }

        public static bool agregar(int idQr, int numero,int cantSillaAprox, bool disponible)
        {
            exito = false;
            try
            {
                Mesa Mesa = new Mesa();
                Mesa.idqr = idQr;
                Mesa.numero = numero;
                Mesa.cant_silla_aprox = cantSillaAprox;
                Mesa.disponible = disponible;                
                Mesa.fecha_creacion = DateTime.Now;
                using (mbDBContext MesaDBEntities = new mbDBContext())
                {
                    MesaDBEntities.Mesas.Add(Mesa);
                    MesaDBEntities.SaveChanges();
                }
                exito = true;
                //  mens = "Carga Realizada";
            }
            catch
            {
                exito = false;
                //mens = "Error al intentar cargar - Mesa";
                errorMesa = new ErrorMesa(1, "Error en carga");
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
                    var entity = dBEntities.Mesas.FirstOrDefault(e => e.Id == id);
                    if (entity != null)
                    {
                        dBEntities.Mesas.Remove(entity);
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
        public static bool update(Mesa Mesa)
        {
            exito = false;
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {
                    var entity = dBEntities.Mesas.FirstOrDefault(e => e.Id == Mesa.Id);
                    if (entity != null)
                    {

                        entity.idqr = Mesa.idqr;
                        entity.numero = Mesa.numero;
                        entity.cant_silla_aprox = Mesa.cant_silla_aprox;
                        entity.disponible = Mesa.disponible;
                        entity.fecha_creacion = DateTime.Now;
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

        public static bool update(int id, int idQr, int numero, int cantSillaAprox, bool disponible)
        {
            exito = false;
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {
                    var entity = dBEntities.Mesas.FirstOrDefault(e => e.Id == id);
                    if (entity != null)
                    {
                        //entity.idproducto = idProducto;
                        entity.idqr = idQr;
                        entity.numero =numero;
                        entity.cant_silla_aprox = cantSillaAprox;
                        entity.disponible = disponible;
                        entity.fecha_creacion = DateTime.Now;
                        dBEntities.SaveChanges();
                        //         mens = "Mesa actualizada con éxito";
                        exito = true;
                    }
                }
            }
            catch (Exception ex)
            {
                exito = false;
                //mens = "Error al intentar actualizar la Mesa";
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

    public class ErrorMesa : Exception
    {

        public int numero { get; set; }
        public String mensaje { get; set; }

        public ErrorMesa()
        {
            this.mensaje = mensaje;
            this.numero = numero;
        }

        public ErrorMesa(int numero, String mensaje)
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