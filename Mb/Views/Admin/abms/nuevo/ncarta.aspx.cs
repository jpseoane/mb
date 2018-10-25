using Mb.DAO;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mb.Views.Admin.abms
{
    public partial class ncarta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                divPrueba.Visible = false;
            }
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {  
           Mensaje("Carga", CartaController.agregar(txtNombreCarta.Text, 1, chkActiva.Checked, User.Identity.GetUserId()));
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
    }
}