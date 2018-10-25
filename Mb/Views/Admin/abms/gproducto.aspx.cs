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
    public partial class gproducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                Inicializarcombos();
                CargaGrilla();
                
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargaGrilla();
        }

     




        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "editar":
                    Producto producto;
                    producto = ProductoController.Get(Convert.ToInt32(e.CommandArgument));
                    if (carta != null)
                    {
                        this.txtNombreCarta.Text = carta.descripcion;
                        this.chkActiva.Checked = carta.activa;
                        ViewState["id"] = e.CommandArgument;
                    }
                    break;
                case "eliminar":
                    Mensaje("Eliminar", CartaController.Borrar(Convert.ToInt32(e.CommandArgument)));
                    break;
            }
            CargaGrilla();
        }


  

        private void CargaGrilla()
        {
            gv.DataSource = CartaController.Get();
            gv.DataBind();
            divPrueba.Visible = false;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Mensaje("Actualizacion", CartaController.update(Convert.ToInt32(ViewState["id"]), txtNombreCarta.Text, chkActiva.Checked, User.Identity.GetUserId()));
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






        private void Inicializarcombos() {

            this.ddlTipo.DataTextField = ("descripcion");
            this.ddlTipo.DataValueField = ("Id");
            this.ddlTipo.DataSource = TipoProductoController.Get();
            this.ddlTipo.DataBind();
            this.ddlSubTipo.DataTextField = ("descripcion_subtipo");
            this.ddlSubTipo.DataValueField = ("id");
            this.ddlSubTipo.DataSource = SubTipoProductoController.Get();
            this.ddlSubTipo.DataBind();
            this.ddlCarta.DataTextField = ("descripcion");
            this.ddlCarta.DataValueField = ("Id");
            this.ddlCarta.DataSource = CartaController.Get();
            this.ddlCarta.DataBind();
        }
    }
}