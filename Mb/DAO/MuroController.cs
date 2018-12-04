using MbDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mb.DAO
{
    public class MuroController
    {
        public static bool exito { get; set; }

        public enum EnumEstadoMensaje { Cargado = 1, Aprobado = 2, Desaprobado = 3, EnEspera = 4 };

        public static MensajeMuro Get(int id)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.MensajeMuroes.FirstOrDefault(e => e.id == id);
            }
        }
        public static IEnumerable<MensajeMuro> GetAll()
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.MensajeMuroes.ToList();
            }
        }

        //Traer todos los mensajes no reportados
        public static IEnumerable<MensajeMuro> GetAllNoReportados()
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.MensajeMuroes.Where(e => e.reportado == false).ToList();
            }
        }

        //Traer todos los mensajes no reportados y aprobados para ser mostrados
        public static IEnumerable<MensajeMuro> GetAllNoReportadosyAprobados()
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.MensajeMuroes.Where(e => e.reportado == false && e.estadoCod==1).ToList();
            }
        }


        //En teoria traeria todos los MensajeMuros de la cartaId que le pase
        public static IEnumerable<MensajeMuro> GetTodosPorCartaId(String userId)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                var query = from mm in entities.MensajeMuroes                            
                            where mm.UserId == userId
                            select mm;


                var MensajeMuros = query.ToList();
                return MensajeMuros;
            }
        }

        //Filtrar por Tipo y Subtipo
        public static IEnumerable<MensajeMuro> GetConFiltro(EnumEstadoMensaje? enumEstadoMensaje, bool? reportado)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                var query = (from mm in entities.MensajeMuroes                            
                             select mm).ToList();

                if (enumEstadoMensaje != null)
                {
                    query = (from mm in query
                             where mm.estadoCod == (int) enumEstadoMensaje
                             select mm).ToList();
                }

                if (reportado != null)
                {
                    query = (from mm in query
                             where mm.reportado == reportado
                             select mm).ToList();
                }

                //var MensajeMuros = query.ToList();
                return query;
            }
        }


        public class MensajeMurosDetalle : MensajeMuro
        {   
            public String Email { get; set; }
        }



        public static List<MensajeMurosDetalle> GetAllCondetalle()
        {
            using (mbDBContext entities = new mbDBContext())
            {
                var query = from mm in entities.MensajeMuroes
                            from apu in entities.AspNetUsers.Where(x => x.Id == mm.UserId)
                            select new MensajeMurosDetalle
                            {
                                id = mm.id,
                                UserId = mm.UserId,                                
                                Email = apu.Email,
                                titulo = mm.titulo,
                                mensaje = mm.mensaje,
                                estadoCod = mm.estadoCod,
                                estado_descri = mm.estado_descri,
                                reportado = mm.reportado,
                                fecha = mm.fecha,
                                confoto = mm.confoto,
                                nombrefoto=mm.nombrefoto
                            };
                var MensajeMuros = query.ToList();            

                return MensajeMuros;
            }

        }


        public static List<MensajeMurosDetalle> GetAllCondetalle(bool reportado, EnumEstadoMensaje? enumEstadoMensaje)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                var query = from mm in entities.MensajeMuroes
                            from apu in entities.AspNetUsers.Where(x => x.Id == mm.UserId)
                            select new MensajeMurosDetalle
                            {
                                id = mm.id,
                                UserId = mm.UserId,
                                Email = apu.Email,
                                titulo = mm.titulo,
                                mensaje = mm.mensaje,
                                estadoCod = mm.estadoCod,
                                estado_descri = mm.estado_descri,
                                reportado = mm.reportado,
                                fecha = mm.fecha,
                                confoto = mm.confoto,
                                nombrefoto = mm.nombrefoto
                            };
                var MensajeMuros = query.ToList();

                if (enumEstadoMensaje != null)
                {
                    MensajeMuros = (from mm in query
                                    where mm.estadoCod == (int)enumEstadoMensaje && mm.reportado == reportado
                                    select mm).ToList();
                }
                return MensajeMuros;
            }

        }



        public static bool CambiarEstadoMensaje(int id,bool reportado, EnumEstadoMensaje enumEstadoMensaje)
        {
            exito = false;
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {
                    var entity = dBEntities.MensajeMuroes.FirstOrDefault(e => e.id == id);
                    if (entity != null)
                    {
                        entity.estadoCod = (int) enumEstadoMensaje;
                        entity.reportado = reportado;
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



        public static bool PermitirMensaje(int id)
        {
            exito = false;
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {
                    var entity = dBEntities.MensajeMuroes.FirstOrDefault(e => e.id == id);
                    if (entity != null)
                    {
                        entity.estadoCod = (int)EnumEstadoMensaje.Aprobado;
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

        public static bool PermitirMensajes(List<MensajeMurosDetalle> ListaDeMensajeMuro)
        {
            exito = false;
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {

                    foreach (MensajeMuro mensajeMuro in ListaDeMensajeMuro){
                        if (mensajeMuro != null)
                        {
                        mensajeMuro.estadoCod = (int)EnumEstadoMensaje.Aprobado;
                        dBEntities.Entry(mensajeMuro).State = System.Data.Entity.EntityState.Modified;
                        dBEntities.SaveChanges();
                        }
                    }
                }
            }
            catch
            {
                exito = false;
            }
            return exito;
        }




        public static bool agregar(MensajeMuro mensajeMuro)
        {
            exito = false;
            try
            {
                using (mbDBContext MensajeDBEntities = new mbDBContext())
                {
                    MensajeDBEntities.MensajeMuroes.Add(mensajeMuro);
                    MensajeDBEntities.SaveChanges();
                }
                exito = true;
            }
            catch
            {
                exito = false;
            }
            return exito;
        }

        public static bool agregar(String UserId, String titulo, String mensaje, bool confoto, String nombrefoto="" )
        {
            exito = false;
            try
            {
                MensajeMuro mensajeMuro = new MensajeMuro();
                mensajeMuro.UserId = UserId;
                mensajeMuro.titulo = titulo;
                mensajeMuro.mensaje = mensaje;
                mensajeMuro.estadoCod = (int) EnumEstadoMensaje.Cargado;
                mensajeMuro.estado_descri = EnumEstadoMensaje.Cargado.ToString();
                mensajeMuro.reportado = false;
                mensajeMuro.confoto = confoto;
                mensajeMuro.nombrefoto = nombrefoto;
                mensajeMuro.fecha = DateTime.Now;
                using (mbDBContext MensajeDBEntities = new mbDBContext())
                {
                    MensajeDBEntities.MensajeMuroes.Add(mensajeMuro);
                    MensajeDBEntities.SaveChanges();
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
    }
}
