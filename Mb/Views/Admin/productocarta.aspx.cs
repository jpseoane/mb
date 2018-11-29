using Mb.DAO;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mb.Views.Admin
{
    public partial class productocarta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                CargaGrilla();
                Inicializarcombos();
            }            
        }


        private void CargaGrilla()
        {
            gv.DataSource = ProductoController.GetCondetalleConCarta();
            gv.DataBind();
        }
        protected void chkAsignarTodas_CheckedChanged(object sender, EventArgs e)
        {
            //CheckBox chkApproved = (CheckBox)sender;
            //GridViewRow gridViewRow = (GridViewRow)chkApproved.Parent.Parent;
            //int userMesaId = (int)gv.DataKeys[gridViewRow.RowIndex].Value;
            //bool activo = chkApproved.Checked;

            
            //TODO: Falta terminar esto

            //Your update method            
           // UserMesaController.UpdateActivo(userMesaId, activo);

            //Your data load method
           // CargaMesa(Convert.ToInt32(ViewState["idMesaUsuario"]));
        }


        protected void chkAsignar_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkAsignar = (CheckBox)sender;
            GridViewRow gridViewRow = (GridViewRow)chkAsignar.Parent.Parent;
            int idProducto = (int)gv.DataKeys[gridViewRow.RowIndex].Value;
            int idCarta = Convert.ToInt32(ddlCarta.SelectedValue);

            //Your update method            
            CartaProductoController.agregar(idProducto, idCarta, User.Identity.GetUserId());
       
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
            this.ddlCarta.DataTextField = ("descripcion");
            this.ddlCarta.DataValueField = ("Id");
            this.ddlCarta.DataSource = CartaController.Get();
            this.ddlCarta.DataBind();
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            CargaGrilla();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.ddlTipo.ClearSelection();
            this.ddlSubTipo.ClearSelection();
            this.ddlCarta.ClearSelection();
            CargaGrilla();
        }
    }
}