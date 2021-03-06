﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MbDataAccess;

namespace Mb.DAO
{
    public  static class SubTipoProductoController
    {
        public static IEnumerable<SubTipo> Get()
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.SubTipoes.ToList();
            }
        }

        public static IEnumerable<SubTipo> GetBy()
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.SubTipoes.ToList();
            }
        }

        public static bool agregar(SubTipo subTipo)
        {
            bool cargaOk = false;
            try
            {
                using (mbDBContext DBEntities = new mbDBContext())
                {
                    DBEntities.SubTipoes.Add(subTipo);
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
                SubTipo subTipo = new SubTipo();
                subTipo.descripcion_subtipo = descri;
                subTipo.fecha_carga = fechaCarga;
                using (mbDBContext DBEntities = new mbDBContext())
                {
                    DBEntities.SubTipoes.Add(subTipo);
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

        public static bool update(SubTipo  subTipo)
        {
            bool TodoOk = false;
            try
            {
                using (mbDBContext dBEntities = new mbDBContext())
                {
                    var entity = dBEntities.SubTipoes.FirstOrDefault(e => e.id == subTipo.id);
                    if (entity != null)
                    {
                        entity.descripcion_subtipo = subTipo.descripcion_subtipo;
                        entity.fecha_carga = subTipo.fecha_carga;
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