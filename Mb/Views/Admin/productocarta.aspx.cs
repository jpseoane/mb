using Mb.DAO;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mb.Views.Admin
{
    public partial class productocarta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                ViewState["SortDirection"] = "desc";
                Inicializarcombos();
                CargaGrilla();
                
            }            
        }


        private void CargaGrilla()
        {
            int idCarta = ddlCarta.SelectedValue != "S" ? Convert.ToInt32(ddlCarta.SelectedValue) : 0;
            int idTipo = ddlTipo.SelectedValue != "S" ? Convert.ToInt32(ddlTipo.SelectedValue) : 0;
            int idSubTipo = this.ddlSubTipo.SelectedValue != "S" ? Convert.ToInt32(ddlSubTipo.SelectedValue) : 0;


            if (ViewState["SortDirection"].ToString() == "desc")
            {
                
                gv.DataSource = ProductoController.GetCondetalleConCarta(idCarta, idTipo, idSubTipo, null).OrderByDescending(s => s.idCarta).ToList();
            }
            else
            {
                gv.DataSource = ProductoController.GetCondetalleConCarta(idCarta, idTipo, idSubTipo, null).OrderBy(s => s.idCarta).ToList();
                ViewState["SortDirection"] = "asc";
            }
            
            gv.DataBind();
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
        protected void chkAsignarTodas_CheckedChanged(object sender, EventArgs e)
        {
            //CheckBox chkApproved = (CheckBox)sender;
            //GridViewRow gridViewRow = (GridViewRow)chkApproved.Parent.Parent;
            //int userMesaId = (int)gv.DataKeys[gridViewRow.RowIndex].Value;
            //bool activo = chkApproved.Checked;

            
            //TODO: Falta terminar esto

            //Your update method            
           // UserMesaController.UpdateActivo(userMesaId, activo);

            //Your data load method
           // CargaMesa(Convert.ToInt32(ViewState["idMesaUsuario"]));
        }


        protected void chkAsignar_CheckedChanged(object sender, EventArgs e)
        {
            int idCarta = ddlCarta.SelectedValue != "S" ? Convert.ToInt32(ddlCarta.SelectedValue) : 0;
            if (idCarta != 0) {
                CheckBox chkAsignar = (CheckBox)sender;
                GridViewRow gridViewRow = (GridViewRow)chkAsignar.Parent.Parent;
                int idProducto = (int)gv.DataKeys[gridViewRow.RowIndex].Value;
                if (CartaProductoController.agregar(idProducto, idCarta, User.Identity.GetUserId()))
                {
                    Mensaje(" Asignacion del producto a la carta " + ddlCarta.SelectedItem.Text + "", true);
                }
                else
                {
                    Mensaje(" intento de asignar carta al producto. Necesita tener seleccionada una carta de la lista para que este cambio se aplicado", false);
                };

            } else {
                Mensaje(" intento de asignar carta al producto. Necesita tener seleccionada una carta de la lista para que este cambio se aplicado", false);
            }
        }



        private void Inicializarcombos()
        {
            ListItem item = new ListItem("Todas", "S");

            ListItem selecc = new ListItem("Seleccionar", "0");

            


            this.ddlTipo.DataTextField = ("descripcion");
            this.ddlTipo.DataValueField = ("Id");
            this.ddlTipo.DataSource = TipoProductoController.Get();
            this.ddlTipo.DataBind();
            this.ddlTipo.Items.Insert(0, item);

            this.ddlSubTipo.DataTextField = ("descripcion_subtipo");
            this.ddlSubTipo.DataValueField = ("id");
            this.ddlSubTipo.DataSource = SubTipoProductoController.Get();
            this.ddlSubTipo.DataBind();
            this.ddlSubTipo.Items.Insert(0, item);

            this.ddlCarta.DataTextField = ("descripcion");
            this.ddlCarta.DataValueField = ("Id");
            this.ddlCarta.DataSource = CartaController.GetAllByActiva(true);
            this.ddlCarta.DataBind();
            this.ddlCarta.Items.Insert(0, selecc);
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            CargaGrilla();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.ddlTipo.ClearSelection();
            this.ddlSubTipo.ClearSelection();
            this.ddlCarta.ClearSelection();
            CargaGrilla();
        }

        protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv.PageIndex = e.NewPageIndex;
            CargaGrilla();
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
            CargaGrilla();
        }
    }
}