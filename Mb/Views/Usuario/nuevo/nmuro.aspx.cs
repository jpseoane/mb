using Mb.DAO;
using MbDataAccess;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mb.Views.Usuario.nuevo
{
    public partial class nmuro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
           Mensaje("Publicacion", MuroController.agregar(User.Identity.GetUserId(), txtTitulo.Text, txtPublicacion.Text));
        }


        private void Mensaje(String movimiento, bool exito)
        {
            if (exito)
            {
                divPrueba.Attributes.Add("class", "alert alert-success");
                divMensaje.InnerText = movimiento + " exitosa";
            }
            else
            {
                divPrueba.Attributes.Add("class", "alert alert-warning");
                divMensaje.InnerText = "Eror en " + movimiento;
            }
            divPrueba.Visible = true;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPublicacion.Text = "";
            txtTitulo.Text = "";
            divPrueba.Visible = false;
        }
    }
}