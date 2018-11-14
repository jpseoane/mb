using Mb.DAO;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                    dvMensajeCambio.Visible = false;
                    dvDetallePedido.Visible = true;
                    gv.DataSource=PedidoController.GetCondetalle(usuarioDeMesa);
                    gv.DataBind();
                    

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
    }
}