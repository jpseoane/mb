using Mb.DAO;
using MbDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mb.Views.Admin.abms
{
    public partial class gmesa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargaGrilla();
            }
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "editar":
                    Mesa mesa;
                    mesa = MesaController.Get(Convert.ToInt32(e.CommandArgument));
                    if (mesa != null)
                    {
                        this.txtNumeroMesa.Text = mesa.numero.ToString();
                        this.txtNumSillaAprox.Text = mesa.cant_silla_aprox.ToString();
                        this.chkActiva.Checked = mesa.disponible;
                        ViewState["id"] = e.CommandArgument;
                    }
                    break;
                case "eliminar":
                    Mensaje("Eliminar", MesaController.Borrar(Convert.ToInt32(e.CommandArgument)));
                    break;
            }
            CargaGrilla();
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargaGrilla();
        }

        private void CargaGrilla()
        {
            gv.DataSource = MesaController.Get();
            gv.DataBind();
            divPrueba.Visible = false;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Mensaje("Actualizacion", MesaController.update(Convert.ToInt32(ViewState["id"]),1,
                Convert.ToInt32(this.txtNumeroMesa.Text), Convert.ToInt32(this.txtNumSillaAprox.Text), chkActiva.Checked));
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
