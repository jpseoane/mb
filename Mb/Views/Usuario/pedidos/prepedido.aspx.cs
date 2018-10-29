using Mb.DAO;
using Microsoft.AspNet.Identity;
using System;
using System.Web.UI;


namespace Mb.Views.Usuario.pedidos
{
    public partial class prepedido : System.Web.UI.Page
    {
        //private String _rol;
        //public String Rol
        //{
        //    get
        //    {
           
        //            return Session["Rol"].ToString();
           
        //    }
        //    set
        //    {
        //        Session["Rol"] = _rol;
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {  
            if (!string.IsNullOrEmpty(Session["Rol"] as string))
            {       
                if (Session["Rol"].ToString() == "Mesa")
                {
                }
                else if (Session["Rol"].ToString() == "Solo")
                {
                }
            }
        }

        protected void imbtnMesa_Click(object sender, ImageClickEventArgs e)
        {
            Session["Rol"] = "Mesa";
        }
    }
}