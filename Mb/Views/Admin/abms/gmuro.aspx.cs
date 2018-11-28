using Mb.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mb.Views.Usuario
{
    public partial class gmuro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gv.DataSource=MuroController.GetAllCondetalle();
                gv.DataBind();
            }
        }


        protected void chkHabilitaTodas_CheckedChanged(object sender, EventArgs e)
        {
         
        }


        protected void chkHabilitar_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkhabilitar = (CheckBox)sender;
            GridViewRow gridViewRow = (GridViewRow)chkhabilitar.Parent.Parent;
            int idMesanje = (int)gv.DataKeys[gridViewRow.RowIndex].Value;
      

            //Your update method            
         //   MuroController.

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            MuroController.EnumEstadoMensaje enumEstadoMensaje;
            switch (Convert.ToInt32(this.ddlEstado.SelectedValue))
            {
                
                case 1:
                enumEstadoMensaje = MuroController.EnumEstadoMensaje.Cargado;
                break;
                case 2:
                enumEstadoMensaje = MuroController.EnumEstadoMensaje.Aprobado;
                break;
                case 3:
                enumEstadoMensaje = MuroController.EnumEstadoMensaje.Desaprobado;
                break;
                case 4:
                enumEstadoMensaje = MuroController.EnumEstadoMensaje.EnEspera;
                break;
                default:
                enumEstadoMensaje = MuroController.EnumEstadoMensaje.Cargado;
                break;
            }
            
            gv.DataSource = MuroController.GetAllCondetalle(this.chkReportado.Checked, enumEstadoMensaje);
            gv.DataBind();

        }
    }
}