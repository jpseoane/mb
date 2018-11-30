using Mb.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mb.Views.Admin.abms
{
    public partial class gcuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //public enum EnumEstadoCuenta { Solicitada = 1, AceptayEnviarParaCobro = 2, PagadoyCerrado = 3 };

            if (!Page.IsPostBack) {

                gv.DataSource = CuentaController.GetAlldetalle();
                gv.DataBind();
            }
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "cerrar")
            {
                int index = Convert.ToInt32(e.CommandArgument) - 1;
                float precioUnitario2 = (float)gv.DataKeys[index].Value;
                GridViewRow row = gv.Rows[index];
                TextBox txtCantidad = row.FindControl("txtCantidad") as TextBox;
                //Usuario
             //   Mensaje("Nuevo pedido", PedidoController.agregar(Convert.ToInt32(ViewState["idUserMesa"]), Convert.ToInt32(e.CommandArgument.ToString()), 1, Convert.ToInt32(txtCantidad.Text), precioUnitario2, null));
            }
            else if (e.CommandName.ToString() == "EnviarAcobrar")
            {

            }
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
                    //btnEnviar.OnClientClick = "hola";

                }
                else {
                    Button btnCerrar = e.Row.FindControl("btnCerrar") as Button;
                    btnCerrar.Visible = true;
                    //btnEnviar.OnClientClick = "hola";

                }

            }
        }

        protected void hola(object sender) {
            int hola;

            hola = 0;



        }

        protected void btnListar_Click(object sender, EventArgs e)
        {

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }
    }
    
}