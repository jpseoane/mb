using Mb.DAO;
using MbDataAccess;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mb.Views.Admin.abms
{
    public partial class gproducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Inicializarcombos();
                CargaGrilla();

            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargaGrilla();
        }




        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "editar":
                    Producto producto;
                    producto = ProductoController.Get(Convert.ToInt32(e.CommandArgument));
                    if (producto != null)
                    {
                        this.txtDescri.Text = producto.descripcion;
                        this.txtPrecio.Text = producto.precioUnitario.ToString();
                        this.ddlTipo.SelectedValue = producto.IdTipo.ToString();
                        this.ddlSubTipo.SelectedValue = producto.idSubTipo.ToString();
                        this.chkActiva.Checked = producto.activo;
                        ViewState["id"] = e.CommandArgument;
                    }
                    break;
                case "eliminar":
                    Mensaje("Eliminar", ProductoController.Borrar(Convert.ToInt32(e.CommandArgument)));
                    break;
            }
            CargaGrilla();
        }




        private void CargaGrilla()
        {
            using (mbDBContext entities = new mbDBContext())
            {

                var lalaa = from Producto p in entities.Productoes
                            join tp in entities.TipoProductoes on p.IdTipo equals tp.Id
                            join stp in entities.SubTipoes on p.idSubTipo equals stp.id
                            select new
                            {
                                id = p.id,
                                descriProducto=p.descripcion,
                                descriPrecio = p.precioUnitario,
                                descriActivo = p.activo,                                
                                tipoDescri = tp.descripcion,
                                subTipoDescri=stp.descripcion_subtipo,
                                fecha =  p.fecha_carga
                            };

                gv.DataSource = lalaa.ToList();
                gv.DataBind();
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {

            Mensaje("Actualizacion", ProductoController.update(Convert.ToInt32(ViewState["id"]), User.Identity.GetUserId(), Convert.ToInt32(ddlTipo.SelectedValue.ToString()),
                Convert.ToInt32(ddlSubTipo.SelectedValue.ToString()), this.txtDescri.Text, Convert.ToDouble(txtPrecio.Text), chkActiva.Checked));
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






        private void Inicializarcombos()
        {

            this.ddlTipo.DataTextField = ("descripcion");
            this.ddlTipo.DataValueField = ("Id");
            this.ddlTipo.DataSource = TipoProductoController.Get();
            this.ddlTipo.DataBind();
            this.ddlSubTipo.DataTextField = ("descripcion_subtipo");
            this.ddlSubTipo.DataValueField = ("id");
            this.ddlSubTipo.DataSource = SubTipoProductoController.Get();
            this.ddlSubTipo.DataBind();
            //this.ddlCarta.DataTextField = ("descripcion");
            //this.ddlCarta.DataValueField = ("Id");
            //this.ddlCarta.DataSource = CartaController.Get();
            //this.ddlCarta.DataBind();
        }
    }
}
