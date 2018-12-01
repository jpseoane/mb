using Mb.DAO;
using MbDataAccess;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Mb.DAO.UserMesaController;

namespace Mb.Views.Usuario.pedidos.nuevo
{
    public partial class npedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                //Busca si ya estas logueado en una mesa
                UsuarioMesaDetalle usuarioDeMesa = UserMesaController.GetUsuarioDeMesaByIdUser(User.Identity.GetUserId());
                if (usuarioDeMesa != null && usuarioDeMesa.activo == true)
                {
                    ViewState["idUserMesa"] = usuarioDeMesa.id;
                    Inicializarcombos();
                    dvMensajeCambio.Visible = false;
                    dvCargaProducto.Visible = true;
                }
                else if (usuarioDeMesa != null && usuarioDeMesa.activo == false) {
                    dvMensajeCambio.Visible = true;
                    dvCargaProducto.Visible = false;
                    h3.InnerText="El administrador de la mesa debe autorizarte!";
                    lblMensaje.Text = "Tu usuario esta asignado a la mesa pero necesitas que el ADMIN te autorize para poder comprar! Consulta aca quien es el admin";
                }
                else
                {
                    dvMensajeCambio.Visible = true;
                    dvCargaProducto.Visible = false;
                    lblMensaje.Text = "Tenes que seleccionar una mesa para poder cargar un pedido";                    
                }

            }
            
        }      

        private void Inicializarcombos()
        {
            ListItem selecc = new ListItem("Seleccionar", "0");
            this.ddlCarta.DataTextField = ("descripcion");
            this.ddlCarta.DataValueField = ("Id");
            this.ddlCarta.DataSource = CartaController.Get();            
            this.ddlCarta.DataBind();
            this.ddlCarta.Items.Insert(0,selecc);
            this.ddlCarta.SelectedIndex = 0;

          
            this.ddlTipo.DataTextField = ("descripcion");
            this.ddlTipo.DataValueField = ("Id");
            this.ddlTipo.DataSource = TipoProductoController.Get();
            this.ddlTipo.DataBind();

            this.ddlTipo.Items.Insert(0, "Todos");
            this.ddlTipo.SelectedIndex = 0;

            this.ddlSubTipo.DataTextField = ("descripcion_subtipo");
            this.ddlSubTipo.DataValueField = ("id");
            this.ddlSubTipo.DataSource = SubTipoProductoController.Get();
            this.ddlSubTipo.DataBind();

            this.ddlSubTipo.Items.Insert(0, "Todos");
            this.ddlSubTipo.SelectedIndex = 0;
        }

      
               

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargaGrilla();
        }

        private void CargaGrilla()
        {
            int? idTipo = null;
            int? idSubTipo = null;

            if (this.ddlSubTipo.SelectedIndex.ToString() != "0") {
                idSubTipo = Convert.ToInt32(ddlSubTipo.SelectedValue.ToString());
            }

            if (this.ddlTipo.SelectedIndex.ToString() != "0")
            {
                idTipo = Convert.ToInt32(ddlTipo.SelectedValue.ToString());
            }

            gv.DataSource = ProductoController.GetConFiltro(Convert.ToInt32(ddlCarta.SelectedValue), idTipo, idSubTipo);
            gv.DataBind();
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "agregar"){
                
                ImageButton btnCantidad = (ImageButton)e.CommandSource;
                GridViewRow gvr = (GridViewRow)btnCantidad.NamingContainer;
                float precioUnitario2 = (float)gv.DataKeys[gvr.RowIndex].Value;

                
                GridViewRow row = gv.Rows[gvr.RowIndex];
                TextBox txtCantidad = row.FindControl("txtCantidad") as TextBox;
                //Usuario
                Mensaje("Nuevo pedido", PedidoController.agregar(Convert.ToInt32(ViewState["idUserMesa"]), Convert.ToInt32(e.CommandArgument.ToString()), 1, Convert.ToInt32(txtCantidad.Text), precioUnitario2,null));
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

    }

}