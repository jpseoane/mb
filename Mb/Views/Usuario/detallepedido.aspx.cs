using Mb.DAO;
using MbDataAccess;
using Microsoft.AspNet.Identity;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Mb.DAO.UserMesaController;

namespace Mb.Views.Usuario
{
    public partial class detallepedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Busca si ya estas logueado en una mesa
                UsuarioMesaDetalle usuarioDeMesa = UserMesaController.GetUsuarioDeMesaByIdUser(User.Identity.GetUserId());
                if (usuarioDeMesa != null && usuarioDeMesa.activo == true)
                {
                    ViewState["idUserMesa"] = usuarioDeMesa.id;
                    ViewState["numeroMesa"] = usuarioDeMesa.mesaNumero;
                    ViewState["tumail"] = usuarioDeMesa.email;
                    ViewState["username"] = User.Identity.GetUserName();
                    dvMensajeCambio.Visible = false;
                    dvDetallePedido.Visible = true;
                    try
                    {
                        h3Mesa.InnerText = "" + usuarioDeMesa.mesaNumero;
                        lblMail.Text = usuarioDeMesa.email;
                        lblPerfil.Text = usuarioDeMesa.perfilEnMesa;
                        chkActiva.Checked = usuarioDeMesa.activo;
                        CargaGrilla();
                        CalcularSubtotal();
                    }
                    catch (Exception ex){
                        lblMensaje.Text = ex.Message;
                    }
                }
                else if (usuarioDeMesa != null && usuarioDeMesa.activo == false)
                {
                    dvMensajeCambio.Visible = true;
                    dvDetallePedido.Visible = false;
                    lblMensaje.Text = "Tu usuario esta asignado a la mesa pero necesitas que el ADMIN te autorize para poder comprar!";

                }
                else
                {
                    dvMensajeCambio.Visible = true;
                    dvDetallePedido.Visible = false;
                    lblMensaje.Text = "Tenes que seleccionar una mesa para poder cargar un pedido";
                }

            }

        }


        private void Mensaje(bool exito, String mensajeExitoso="", String mensajeError = "")
        {
            if (exito)
            {
                divPrueba.Attributes.Add("class", "alert alert-success");
                    divMensaje.InnerText = mensajeExitoso;
            }
            else
            {
                divPrueba.Attributes.Add("class", "alert alert-warning");
               divMensaje.InnerText = mensajeError;
            }
            divPrueba.Visible = true;
        }

    

        protected void chkVerMisPedidos_CheckedChanged(object sender, EventArgs e)
        {
            CargaGrilla();
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {   
            switch (e.CommandName)
            {
                case "cancelar":
                    ImageButton btn = (ImageButton)e.CommandSource;
                    GridViewRow gvr = (GridViewRow)btn.NamingContainer;
                    String username = (string)gv.DataKeys[gvr.RowIndex].Value;                    
                    if (ViewState["username"].ToString().ToLower() == username.ToLower().ToString())
                    {
                        if (PedidoController.Cancelar(Convert.ToInt32(e.CommandArgument)))
                        {
                            Mensaje(true, "El pedido fue cancelado");
                        }
                        else
                        {
                            Mensaje(false, "", "El pedido No puede ser cancelado si esta preparandose o fue encargado");
                        }

                    }
                    else
                    {
                        Mensaje(false,"", "El pedido solo puede ser cancelado por el usuario que lo solicito.");
                    }

                    
                    break;
            }
            CargaGrilla();
            CalcularSubtotal();
        }

        private void CargaGrilla()
        {
            if (this.chkVerMisPedidos.Checked)
            {
                gv.DataSource = PedidoController.GetAllCondetalleXUsuario(Convert.ToInt32(ViewState["idUserMesa"]));
                gv.DataBind();
                
            }
            else
            {
                gv.DataSource = PedidoController.GetAllCondetallPporMesa(Convert.ToInt32(ViewState["numeroMesa"]));
                gv.DataBind();
                
            }
        }


        private void CalcularSubtotal()
        {
            if (gv.Rows.Count > 0)
            {                
                this.lblTotal.Text = "Subtotal Mesa: $" + Convert.ToString(PedidoController.ObtnerSubtotalXMesa(Convert.ToInt32(ViewState["numeroMesa"])));
            }
            this.lblTuSubtotal.Text = "Subtotal " + ViewState["username"] + " : $" + Convert.ToString(PedidoController.ObtnerSubtotalXUsarioDeMesa(Convert.ToInt32(ViewState["idUserMesa"])));
            this.lblSubTotalUsuario.Text = this.lblTuSubtotal.Text;
        }

        protected void btnCerrarCuenta_Click(object sender, EventArgs e)
        {
            if (!PedidoController.ExistenPedidosPendientes(Convert.ToInt32(ViewState["numeroMesa"])))
            {
                //Pedir cuenta
                UsuarioMesaDetalle usuarioDeMesa = UserMesaController.GetUsuarioDeMesaByIdUser(User.Identity.GetUserId());
                if (usuarioDeMesa != null)
                {
                    Cuenta cuenta = PedidoController.PedirCuentaMesa(usuarioDeMesa);
                    Response.Redirect("cuenta.aspx");
                }
                else
                {
                    Mensaje(false, "", "No se pudo cargar la cuenta. Intente de nuevo o contacte al mozo de su mesa");
                }
            }
            else
            {
                Mensaje(false, "", "No se puede solicitar la cuenta con pedidos pendientes de entrega (Encargados o En preparación)");
            }

        }
    }




}