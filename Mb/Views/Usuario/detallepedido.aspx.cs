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
                UsuariosDeMesa usuarioDeMesa = UserMesaController.GetUsuarioDeMesaByIdUser(User.Identity.GetUserId());
                if (usuarioDeMesa != null && usuarioDeMesa.activo == true)
                {
                    ViewState["idUserMesa"] = usuarioDeMesa.id;
                    ViewState["numeroMesa"] = usuarioDeMesa.mesaNumero;
                    dvMensajeCambio.Visible = false;
                    dvDetallePedido.Visible = true;
                    try
                    {
                        h3Mesa.InnerText = "" + usuarioDeMesa.mesaNumero;
                        lblMail.Text = usuarioDeMesa.email;
                        lblPerfil.Text = usuarioDeMesa.perfilEnMesa;
                        chkActiva.Checked = usuarioDeMesa.activo;
                        gv.DataSource = PedidoController.GetCondetalle(usuarioDeMesa.id);
                        gv.DataBind();
                        if (gv.Rows.Count > 0) {                            
                            this.lblTotal.Text ="Subtotal: $" + Convert.ToString(PedidoController.ObtnerSubtotalXMesaXEstado(usuarioDeMesa.mesaNumero, PedidoController.EnumEstadoPedido.Encargado));
                        }

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

        private void CargaDetallePedido(int mesaNumero)
        {
            
           
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnPedirCuenta_Click(object sender, EventArgs e)
        {
            if (!PedidoController.ExistenPedidosPendientes(Convert.ToInt32(ViewState["numeroMesa"])))
            {
                //Pedir cuenta
               Cuenta cuenta = CuentaController.CrearyObtnerCuenta(Convert.ToInt32(ViewState["idUserMesa"]), Convert.ToInt32(ViewState["numeroMesa"]));
                if (cuenta != null)
                {
                    this.btnPedirCuenta.Enabled = false;
                    Response.Redirect("cuenta.aspx");
                }
                else
                {
                    Mensaje("", false, "No se pudo cargar la cuenta. Intente de nuevo o contacte al mozo de su mesa");
                }
            }
            else
            {
                Mensaje("", false, "No se puede solicitar la cuenta con pedidos pendientes de entrega");
            }
        }

        private void Mensaje(String movimiento="", bool exito, String mensaje="")
        {
            if (exito)
            {
                divPrueba.Attributes.Add("class", "alert alert-success");
                
                if (mensaje != "")
                {
                    divMensaje.InnerText = mensaje;
                }
                else
                {
                    divMensaje.InnerText = movimiento + " exitosa";
                }
            }
            else
            {
                divPrueba.Attributes.Add("class", "alert alert-warning");
                if (mensaje != "")
                {
                    divMensaje.InnerText = mensaje;
                }
                else
                {
                    divMensaje.InnerText = "Eror en " + movimiento;
                }
                
            }
            divPrueba.Visible = true;
        }

        protected void btnRefrescar_Click(EventArgs e)
        {

        }
    }
}