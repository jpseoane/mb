using MbDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mb.DAO
{
    public class CartaController
    {

        public IEnumerable<Carta> Get()
        {
            using (mbDBContext entities = new mbDBContext())
            {
                return entities.Cartas.ToList();
            }
        }

        public Carta Obtener(int id)
        {
            using (mbDBContext entities = new mbDBContext())
            {
                
                var entity = entities.Cartas.FirstOrDefault(e => e.idcarta == id);

                if (entity != null)
                {
                    return entity;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool Agregar(Carta carta) {
            bool cargaOk = false;
            try
            {                
                using (mbDBContext entities = new mbDBContext())
                {
                    entities.Cartas.Add(carta);
                    entities.SaveChanges();
                }
                cargaOk = true;
            }
            catch 
            {
                cargaOk=false;
            }
            
            return cargaOk;
        }

        public bool Agregar(String descri, int idProducto, bool activa, String UserId )
        {
            bool cargaOk=false;
            try
            {
                Carta carta = new Carta();
                carta.activa = activa;
                carta.descripcion = descri;
                carta.UserId = UserId;
                carta.idproducto = idProducto;
                carta.fecha = DateTime.Now;
                using (mbDBContext entities = new mbDBContext())
                {
                    entities.Cartas.Add(carta);
                    entities.SaveChanges();
                }
                cargaOk = true;
            }
            catch
            {
                cargaOk=false;
            }
            return cargaOk;

        }

        public bool Borrar(int id)
        {
            bool EliminaOk = false;
            try
            {
                using (mbDBContext entities = new mbDBContext())
                {
                    var entity = entities.Cartas.FirstOrDefault(e => e.idcarta == id);
                    if (entity != null)
                    {
                        entities.Cartas.Remove(entity);
                        entities.SaveChanges();
                        EliminaOk = true;
                    }
                    else {
                        EliminaOk = false;
                    }
                }
            }
            catch
            {
                EliminaOk = false;
            }
            return EliminaOk;
        }

        public bool Actualizar(Carta carta)
        {
            bool cargaOk = false;
            try
            {
                using (mbDBContext cartaDBEntities = new mbDBContext())
                {
                    cartaDBEntities.Cartas.Add(carta);
                    cartaDBEntities.SaveChanges();
                }
                cargaOk = true;
            }
            catch
            {
                cargaOk = false;
            }

            return cargaOk;
        }


    }

}