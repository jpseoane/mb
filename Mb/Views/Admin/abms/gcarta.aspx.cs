using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mb.DAO;
using MbDataAccess;
using Microsoft.AspNet.Identity;

namespace Mb.Views.Admin.abms
{
    public partial class gcarta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                CargaGrilla();
            }
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "editar":
                    Carta carta;
                    carta = CartaController.Get(Convert.ToInt32(e.CommandArgument));
                    if (carta != null)
                    {
                        this.txtNombreCarta.Text = carta.descripcion;
                        this.ddlEstadoDeCarta.SelectedValue =Convert.ToString(Convert.ToInt32(carta.activa));
                    //    this.chkActiva.Checked = carta.activa;
                        ViewState["id"] = e.CommandArgument;                     
                    }
                    break;
                case "eliminar":
                    Mensaje("Eliminar", CartaController.Borrar(Convert.ToInt32(e.CommandArgument)));
                    break;
            }
            CargaGrilla();
        }

        
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargaGrilla();
        }

        private void CargaGrilla(){
            
            if (ddlEstadoDeCarta.SelectedValue.ToString() == "S") {
                gv.DataSource = CartaController.GetAll();
            }
            else
            {
                bool activa=false;
                if (ddlEstadoDeCarta.SelectedValue.ToString() == "1")
                { activa = true;}
                
                gv.DataSource = CartaController.GetAllByActiva(activa);
            }
            
            gv.DataBind();
            divPrueba.Visible = false;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            bool activa = false;
            if (ddlEstadoDeCarta.SelectedValue.ToString() == "1")
            { activa = true; }

            Mensaje("Actualizacion", CartaController.update(Convert.ToInt32(ViewState["id"]), txtNombreCarta.Text, activa, User.Identity.GetUserId()));
            this.txtNombreCarta.Text = "";
            ddlEstadoDeCarta.ClearSelection();
            //chkActiva.Checked = true;
            CargaGrilla();
        }


        private void Mensaje(String movimiento, bool exito)
        {
            if (exito)
            {divPrueba.Attributes.Add("class", "alert alert-success");
             divMensaje.InnerText = movimiento + " exitosa";
            }
            else
            {divPrueba.Attributes.Add("class", "alert alert-warning");
             divMensaje.InnerText = "Eror en " + movimiento;
            }
            divPrueba.Visible = true;
        }

        
    }
}