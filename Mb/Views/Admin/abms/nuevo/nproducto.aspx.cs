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
    public partial class nproducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Inicializarcombos();
                divPrueba.Visible = false;
            }
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

        private void Inicializarcombos()
        {

            this.ddlTipo.DataTextField = ("descripcion");
            this.ddlTipo.DataValueField = ("Id");
            this.ddlTipo.DataSource = TipoProductoController.Get();
            this.ddlTipo.DataBind();
            this.ddlSubTipo.DataTextField = ("descripcion_subtipo");
            this.ddlSubTipo.DataValueField = ("id");
            this.ddlSubTipo.DataSource = SubTipoProductoController.Get();
            this.ddlSubTipo.DataBind();
            //this.ddlCarta.DataTextField = ("descripcion");
            //this.ddlCarta.DataValueField = ("Id");
            //this.ddlCarta.DataSource = CartaController.Get();
            //this.ddlCarta.DataBind();
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            Mensaje("Agregar", ProductoController.agregar(User.Identity.GetUserId(), Convert.ToInt32(ddlTipo.SelectedValue), Convert.ToInt32(ddlSubTipo.SelectedValue),
                txtDescri.Text, Convert.ToDouble(txtPrecio.Text), chkActiva.Checked));
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPrecio.Text = "";
            this.txtDescri.Text = "";
            this.ddlSubTipo.ClearSelection();
            this.ddlTipo.ClearSelection();
            chkActiva.Checked = true;
            divPrueba.Visible = false;
        }
    }
}