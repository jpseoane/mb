using Mb.DAO;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Mb.DAO.UserMesaController;

namespace Mb.Views.Usuario.pedidos.nuevo
{
    public partial class npedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                //Busca si ya estas logueado en una mesa
                UsuariosDeMesa usuarioDeMesa = UserMesaController.GetUsuarioDeMesaByIdUser(User.Identity.GetUserId());
                if (usuarioDeMesa != null && usuarioDeMesa.activo == true)
                {
                    dvMensajeCambio.Visible = true;
                    dvCargaProducto.Visible = false;
                    lblMensaje.Text = "Tenes que seleccionar una mesa para poder cargar un pedido";
                }
                else if (usuarioDeMesa != null && usuarioDeMesa.activo == false) {
                    dvMensajeCambio.Visible = true;
                    dvCargaProducto.Visible = false;
                    lblMensaje.Text = "Tu usuario esta asignado a la mesa pero necesitas que el ADMIN te autorize para poder comprar!";
                    
                }
                else
                {
                    Inicializarcombos();
                    dvMensajeCambio.Visible = false;
                    dvCargaProducto.Visible = true;
                }

            }
            
        }      

        private void Inicializarcombos()
        {
            this.ddlCarta.DataTextField = ("descripcion");
            this.ddlCarta.DataValueField = ("Id");
            this.ddlCarta.DataSource = CartaController.Get();
            this.ddlCarta.DataBind();
            this.ddlTipo.DataTextField = ("descripcion");
            this.ddlTipo.DataValueField = ("Id");
            this.ddlTipo.DataSource = TipoProductoController.Get();
            this.ddlTipo.DataBind();
            this.ddlSubTipo.DataTextField = ("descripcion_subtipo");
            this.ddlSubTipo.DataValueField = ("id");
            this.ddlSubTipo.DataSource = SubTipoProductoController.Get();
            this.ddlSubTipo.DataBind();            
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ddlSubTipo.DataTextField = ("descripcion_subtipo");
            this.ddlSubTipo.DataValueField = ("id");
            this.ddlSubTipo.DataSource = SubTipoProductoController.Get();
        }

        protected void ddlSubTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
               

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargaGrilla();
        }

        private void CargaGrilla()
        {

            gv.DataSource = ProductoController.GetByTipo(Convert.ToInt32(ddlTipo.SelectedValue));
            gv.DataBind();
        }

}





    // <T> is the type of data in the list.
    // If you have a List<int>, for example, then call this as follows:
    // List<int> ListOfInt;
    // DataTable ListTable = BuildDataTable<int>(ListOfInt);
    //public static DataTable BuildDataTable<T>(IList<T> lst)
    //{
    //    //create DataTable Structure
    //    DataTable tbl = CreateTable<T>();
    //    Type entType = typeof(T);
    //    PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entType);
    //    //get the list item and add into the list
    //    foreach (T item in lst)
    //    {
    //        DataRow row = tbl.NewRow();
    //        foreach (PropertyDescriptor prop in properties)
    //        {
    //            row[prop.Name] = prop.GetValue(item);
    //        }
    //        tbl.Rows.Add(row);
    //    }
    //    return tbl;
    //}

    //private static DataTable CreateTable<T>()
    //{
    //    //T –> ClassName
    //    Type entType = typeof(T);
    //    //set the datatable name as class name
    //    DataTable tbl = new DataTable(entType.Name);
    //    //get the property list
    //    PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entType);
    //    foreach (PropertyDescriptor prop in properties)
    //    {
    //        //add property as column
    //        tbl.Columns.Add(prop.Name, prop.PropertyType);
    //    }
    //    return tbl;
    //}
//    Next, get the DataTable's default view:

//DataView NewView = MyDataTable.DefaultView;
//    A complete example would be as follows:

//List<int> ListOfInt = new List<int>();
//    // populate list
//    DataTable ListAsDataTable = BuildDataTable<int>(ListOfInt);
//    DataView ListAsDataView = ListAsDataTable.DefaultView;



}