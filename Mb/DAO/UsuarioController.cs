using MbDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mb.DAO
{
    public class UsuarioController
    {       
            public static bool exito { get; set; }
            public static String mens { get; set; }
            public static bool resultado { get; set; }
            public static AspNetUser GetbyId(String id)
            {
                using (mbDBContext entities = new mbDBContext())
                {
                    return entities.AspNetUsers.FirstOrDefault(e => e.Id == id);
                }
            }        
            public static IEnumerable<AspNetUser> GetTodos()
            {
                using (mbDBContext entities = new mbDBContext())
                {
                    return entities.AspNetUsers.ToList();
                }
            }
            public static bool ExisteAspNetUserNumero(String userName)
            {
                using (mbDBContext entities = new mbDBContext())
                {
                    var query = (from m in entities.AspNetUsers
                                 where m.UserName == userName
                                 select m
                                  ).Any();
                    return query;
                }
            }
            public static bool agregar(AspNetUser AspNetUser)
            {
                exito = false;
                try
                {
                    using (mbDBContext AspNetUserDBEntities = new mbDBContext())
                    {
                        AspNetUserDBEntities.AspNetUsers.Add(AspNetUser);
                        AspNetUserDBEntities.SaveChanges();
                    }
                    exito = true;
                }
                catch
                {
                    exito = false;
                }
                return exito;
            }
            public static bool Borrar(String id)
            {
                exito = false;
                try
                {
                    using (mbDBContext dBEntities = new mbDBContext())
                    {
                        var entity = dBEntities.AspNetUsers.FirstOrDefault(e => e.Id == id);
                        if (entity != null)
                        {
                            dBEntities.AspNetUsers.Remove(entity);
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