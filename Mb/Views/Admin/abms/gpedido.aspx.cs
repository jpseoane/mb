using Mb.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mb.Views.Admin.abms
{
    public partial class gpedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                CargarGrilla();

            }
        }

        private void CargarGrilla()
        {
            PedidoController.EnumEstadoPedido enumEstado;
            switch (ddlEstadoPedido.SelectedValue) {
                case "1":
                enumEstado = PedidoController.EnumEstadoPedido.Encargado;
                break;
                case "2":
                enumEstado = PedidoController.EnumEstadoPedido.Preparacion;
                break;
                case "3":
                enumEstado = PedidoController.EnumEstadoPedido.Entregado;
                break;
                case "4":
                enumEstado = PedidoController.EnumEstadoPedido.PedidoDeCuenta;
                break;
                case "5":
                enumEstado = PedidoController.EnumEstadoPedido.RecibidoYpagado;
                break;
                default:
                    enumEstado = PedidoController.EnumEstadoPedido.Encargado;
                    break;
            }

            gv.DataSource=PedidoController.GetConDetalleXMesaXestado(Convert.ToInt32(ddlMesa.SelectedValue), enumEstado);
            gv.DataBind();
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (e.Row.Cells[2].Text == "Solicitada")
                {
                    //btnEnviarAcobrar btnCerrar
                    Button btnEnviar = e.Row.FindControl("btnEnviarAcobrar") as Button;
                    btnEnviar.Visible = true;
                    btnEnviar.OnClientClick = "hola";

                }
                else
                {
                    Button btnCerrar = e.Row.FindControl("btnCerrar") as Button;
                    btnCerrar.Visible = true;
                    btnCerrar.OnClientClick = "hola";

                }
            }
        }

        protected void btnActualizarEstado_Click(object sender, EventArgs e)
        {

        }
    }
}
