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
                ViewState["SortDirection"] = "desc";
                CargarGrilla();
              
            }
        }

        private void CargarGrilla()
        {

            //MuroController.EnumEstadoMensaje enumEstadoMensaje;
            //switch (Convert.ToInt32(this.ddlEstado.SelectedValue))
            //{

            //    case 1:
            //        enumEstadoMensaje = MuroController.EnumEstadoMensaje.Cargado;
            //        break;
            //    case 2:
            //        enumEstadoMensaje = MuroController.EnumEstadoMensaje.Aprobado;
            //        break;
            //    case 3:
            //        enumEstadoMensaje = MuroController.EnumEstadoMensaje.Desaprobado;
            //        break;
            //    case 4:
            //        enumEstadoMensaje = MuroController.EnumEstadoMensaje.EnEspera;
            //        break;
            //    default:
            //        enumEstadoMensaje = MuroController.EnumEstadoMensaje.Cargado;
            //        break;
            //}

          
            if (ViewState["SortDirection"].ToString() == "desc")
            {
                gv.DataSource = MuroController.GetAllCondetalle(this.chkReportado.Checked).OrderByDescending(s => s.fecha).ToList();
            }
            else
            {
                gv.DataSource = MuroController.GetAllCondetalle(this.chkReportado.Checked).OrderBy(s => s.fecha).ToList();
                ViewState["SortDirection"] = "asc";
            }
            gv.DataBind();

        }

      


        protected void chkHabilitar_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkhabilitar = (CheckBox)sender;
            
            GridViewRow gridViewRow = (GridViewRow)chkhabilitar.Parent.Parent;
            int idMesanje = (int)gv.DataKeys[gridViewRow.RowIndex].Value;
            MuroController.CambiarEstadoMensaje(idMesanje, chkhabilitar.Checked, MuroController.EnumEstadoMensaje.Desaprobado);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla();

        }

        protected void gv_Sorting(object sender, GridViewSortEventArgs e)
        {

            if (ViewState["SortDirection"].ToString() == "desc")
            {
                ViewState["SortDirection"] = "asc";
            }
            else
            {
                ViewState["SortDirection"] = "desc";
            };
            CargarGrilla();
        }

        protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv.PageIndex = e.NewPageIndex;
            CargarGrilla();
        }
    }
}