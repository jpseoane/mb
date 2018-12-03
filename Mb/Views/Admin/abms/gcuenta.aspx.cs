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
            if (!Page.IsPostBack) {

                //Si no te habilita para loguearte                    
                this.ddlMesa.DataTextField = ("numero");
                this.ddlMesa.DataValueField = ("id");
                this.ddlMesa.DataSource = MesaController.GetDisponibles();
                this.ddlMesa.DataBind();
                ListItem item = new ListItem("Todas", "S");
                this.ddlMesa.Items.Insert(0, item);
                CargarGrilla();



            }
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "cerrar")
            {
                //Cerrar Cuenta
                Button btn = (Button)e.CommandSource;
                GridViewRow gvr = (GridViewRow)btn.NamingContainer;
                int numeromesa = (int)gv.DataKeys[gvr.RowIndex].Value;

                Button btnCantidad = (Button)e.CommandSource;
                GridViewRow gvr2 = (GridViewRow)btnCantidad.NamingContainer;
                int numerodemesa2 =(int) gv.DataKeys[gvr2.RowIndex].Value;

                if (CuentaController.CerrarCuenta(Convert.ToInt32(e.CommandArgument), numeromesa))
                { 
                    Mensaje(true, "La cuenta ha sido cerrada como tambien los pedidos de la mesa y se ha liberado la mesa", "");
                }
                else
                {
                    Mensaje(false, "", "Ocurrio uno o mas errores al intentar cerrar la mesa");
                }

            }
            else if (e.CommandName.ToString() == "EnviarAcobrar")
            {

                if (CuentaController.UpdateCuentastado(Convert.ToInt32(e.CommandArgument), CuentaController.EnumEstadoCuenta.EnEsperaDelPago))
                {
                    Mensaje(true, "Se paso la cuenta al estado para enviar a cobrar. Luego de confirmar la recepcion del cobro cierre la mesa para poder liberar los lugares", "");
                }
                else {
                    Mensaje(false, "", "Ocurrio uno o mas errores al intentar cambiar el estado de la mesa al estado Enviar a cobrar");
                }
            }
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnEnviar = e.Row.FindControl("btnEnviarAcobrar") as Button;
                Button btnCerrar = e.Row.FindControl("btnCerrar") as Button;
                if (e.Row.Cells[2].Text == "Solicitada")
                {   
                    btnEnviar.Visible = true;
                }
                else if (e.Row.Cells[2].Text == "EnEsperaDelPago")
                {
                    btnCerrar.Visible = true;
                }
                else {
                    btnCerrar.Visible = false;
                    btnEnviar.Visible = false;
                }

            }
        }



        private void Mensaje(bool exito, String mensajeExitoso = "", String mensajeError = "")
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



        

        protected void btnListar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
          

        }

        private void CargarGrilla()
        {
            int numMesa = ddlMesa.SelectedValue != "S" ? Convert.ToInt32(ddlMesa.SelectedValue) : 0;
            int idEstado = this.ddlEstadoDeCuenta.SelectedValue != "S" ? Convert.ToInt32(ddlEstadoDeCuenta.SelectedValue) : 0;


            gv.DataSource = CuentaController.GetAlldetalle(null, numMesa, idEstado);
            gv.DataBind();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.ddlEstadoDeCuenta.ClearSelection();
            this.ddlMesa.ClearSelection();
            CargarGrilla();
        }
    }
    
}