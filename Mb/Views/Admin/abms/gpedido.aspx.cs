using Mb.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Mb.DAO.PedidoController;

namespace Mb.Views.Admin.abms
{
    public partial class gpedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                
                //Si no te habilita para loguearte                    
                this.ddlMesa.DataTextField = ("numero");
                this.ddlMesa.DataValueField = ("id");
                this.ddlMesa.DataSource = MesaController.GetDisponibles();
                this.ddlMesa.DataBind();
                ListItem item= new ListItem("Todas","S");
                this.ddlMesa.Items.Insert(0, item);
                ViewState["SortDirection"] = "desc";

            }
        }


        private void CargarGrilla()
        {
            int numMesa = ddlMesa.SelectedValue != "S" ? Convert.ToInt32(ddlMesa.SelectedValue) : 0;
            int idEstado = ddlEstadoPedido.SelectedValue != "S" ? Convert.ToInt32(ddlEstadoPedido.SelectedValue) : 0;

            var Pedidos = PedidoController.GetConDetalleXMesaXestado(numMesa, idEstado);

            

            if (ViewState["SortDirection"].ToString() == "desc")
            {
                gv.DataSource = Pedidos.OrderByDescending(s => s.fecha).ToList();
            }
            else
            {
                gv.DataSource = Pedidos.OrderBy(s => s.fecha).ToList();
                ViewState["SortDirection"] = "asc";
            }

            gv.DataBind();


            //ViewState["pedidos"] = Pedidos;
            //List<PedidosDetalle> list = Pedidos.ToList();
            //DataTable dt = ConvertController.ToDataTable<PedidosDetalle>(list);


            //if (dt != null)
            //{
            //    ViewState["SortExpression"] ="fecha";
            //    ViewState["SortDirection"] = "desc";
            //    Session["TablaPedidos"] = dt;
            //    dt.DefaultView.Sort = ViewState["SortExpression"] + " " + ViewState["SortDirection"];
            //    //gv.DataSource = dt;
                
            //}

        }
        private void ObetnerrGrilla(String CampoOrden, String TipoOrden)
        {
            DataTable dt = Session["TablaPedidos"] as DataTable;

            dt.DefaultView.Sort = CampoOrden + " " + TipoOrden;
            gv.DataSource = dt;
            gv.DataBind();

        }


        protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv.PageIndex = e.NewPageIndex;
            //  ObetnerrGrilla(ViewState["SortExpression"].ToString(), ViewState["SortDirection"].ToString());
            CargarGrilla();
        }

        protected void gv_Sorting(object sender, GridViewSortEventArgs e)
        {
            //var Pedidos = ViewState["pedidos"];

            //switch (e.SortExpression) {

            //    case "fecha":

            //        gv.DataSource = Pedidos.OrderByDescending(s => s.fecha).ToList();
            //        gv.DataBind();
            //        break;
            //}

            //------------------------------------------------

            if (ViewState["SortDirection"].ToString() == "desc")
            {
                ViewState["SortDirection"] = "asc";
            }
            else
            {
                ViewState["SortDirection"] = "desc";
            }; 

             
            //ViewState["SortExpression"] = e.SortExpression;
            CargarGrilla();
            //ObetnerrGrilla(ViewState["SortExpression"].ToString(), ViewState["SortDirection"].ToString());
        }


        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnPreparandose = e.Row.FindControl("btnPreparandose") as Button;
                Button btnEntregado = e.Row.FindControl("btnEntregado") as Button;
                if (e.Row.Cells[6].Text == "Encargado")
                {
                    //btnEnviarAcobrar btnCerrar
                    btnPreparandose.Visible = true;
                    btnEntregado.Visible = false;
                }
                else if (e.Row.Cells[6].Text == "Preparacion")
                {
                    btnPreparandose.Visible = false;
                    btnEntregado.Visible = true;
                }
                else {
                    btnPreparandose.Visible = false;
                    btnEntregado.Visible = false;
                }
            }
        }

        protected void btnActualizarEstado_Click(object sender, EventArgs e)
        {

        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            ddlMesa.ClearSelection();
            ddlEstadoPedido.ClearSelection();
        }



        //private string GetSortDirection(string column)
        //{   
        //    string sortDirection = "ASC";
        //    string sortExpression = ViewState["SortExpression"] as string;

        //    if (sortExpression != null)
        //    {
        //        if (sortExpression == column)
        //        {
        //            string lastDirection = ViewState["SortDirection"] as string;
        //            if ((lastDirection != null) && (lastDirection == "ASC"))
        //            {
        //                sortDirection = "DESC";
        //            }
        //        }
        //    }
        //    ViewState["SortDirection"] = sortDirection;
        //    ViewState["SortExpression"] = column;

        //    return sortDirection;
        //}

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName== "preparandose" || e.CommandName== "entregado"){ 
                    EnumEstadoPedido enumEstadoPedido =  e.CommandName.ToString() == "preparandose" ? EnumEstadoPedido.Preparacion : EnumEstadoPedido.Entregado;
                    PedidoController.UpdatePedidoEstado(Convert.ToInt32(e.CommandArgument), enumEstadoPedido);
                    CargarGrilla();
            }
        }
    }
}
