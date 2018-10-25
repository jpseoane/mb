using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MbDataAccess;

namespace Mb.DAO
{
    public static class TipoProductoController
    {

        public static IEnumerable<TipoProducto> Get()
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.TipoProductoes.ToList();
            }
        }

        public static bool agregar(TipoProducto tipoProducto)
        {
            bool cargaOk = false;
            try
            {
                using (mbDBContext DBEntities = new mbDBContext())
                {
                    DBEntities.TipoProductoes.Add(tipoProducto);
                    DBEntities.SaveChanges();
                }
                cargaOk = true;
            }
            catch
            {
                cargaOk = false;
            }

            return cargaOk;
        }

        public static bool agregar(String descri, DateTime fechaCarga)
        {
            bool cargaOk = false;
            try
            {
                TipoProducto tipoProducto = new TipoProducto();
                tipoProducto.descripcion = descri;
                tipoProducto.fecha_carga = fechaCarga;
                using (mbDBContext DBEntities = new mbDBContext())
                {
                    DBEntities.TipoProductoes.Add(tipoProducto);
                    DBEntities.SaveChanges();
                }
                cargaOk = true;
            }
            catch
            {
                cargaOk = false;
            }
            return cargaOk;

        }

        public static bool Borrar(int id)
        {
            bool TodoOk = false;
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {
                    var entity = dBEntities.SubTipoes.FirstOrDefault(e => e.id == id);
                    if (entity != null)
                    {
                        dBEntities.SubTipoes.Remove(entity);
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

        public static bool update(TipoProducto tipoProducto)
        {
            bool TodoOk = false;
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {
                    var entity = dBEntities.TipoProductoes.FirstOrDefault(e => e.Id == tipoProducto.Id);
                    if (entity != null)
                    {
                        entity.descripcion = tipoProducto.descripcion;
                        entity.fecha_carga = tipoProducto.fecha_carga;
                        dBEntities.SaveChanges();
                    }

                }
            }
            catch (Exception ex)
            {
                TodoOk = false;
            }
            return TodoOk;


        }


    }
}