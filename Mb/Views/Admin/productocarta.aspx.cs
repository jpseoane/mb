using Mb.DAO;
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
                CargarGrilla();
                Inicializarcombos();
            }            
        }



        private void CargarGrilla() {
            this.gv.DataSource = ProductoController.GetTodosPorCartaId(1);
            this.gv.DataBind();
        }
        protected void chkAsignarTodas_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkApproved = (CheckBox)sender;
            GridViewRow gridViewRow = (GridViewRow)chkApproved.Parent.Parent;
            int userMesaId = (int)gv.DataKeys[gridViewRow.RowIndex].Value;
            bool activo = chkApproved.Checked;

            //Your update method            
            UserMesaController.UpdateActivo(userMesaId, activo);

            //Your data load method
           // CargaMesa(Convert.ToInt32(ViewState["idMesaUsuario"]));
        }


        protected void chkAsignar_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkApproved = (CheckBox)sender;
            GridViewRow gridViewRow = (GridViewRow)chkApproved.Parent.Parent;
            int userMesaId = (int)gv.DataKeys[gridViewRow.RowIndex].Value;
            bool activo = chkApproved.Checked;

            //Your update method            
            UserMesaController.UpdateActivo(userMesaId, activo);

            //Your data load method
            //CargaMesa(Convert.ToInt32(ViewState["idMesaUsuario"]));
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
    }
}