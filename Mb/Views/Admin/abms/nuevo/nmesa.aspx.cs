using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mb.Views.Admin.abms.nuevo
{
    public partial class nmesa : System.Web.UI.Page
    {
         
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                divPrueba.Visible = false;
            }
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            Mensaje("Carga", DAO.MesaController.agregar(1,Convert.ToInt32(this.txtNumeroMesa.Text), Convert.ToInt32(this.txtNumSillaAprox.Text), chkActiva.Checked));
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
            this.txtNumeroMesa.Text = "";
            this.txtNumSillaAprox.Text = "";
            chkActiva.Checked = true;
            divPrueba.Visible = false;
        }
    }
   
}