using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mb.Views.Usuario.pedidos.nuevo
{
    public partial class npedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                ValidaUsuario();

            }
        }

        private void ValidaUsuario()
        {
            if (Session["RolDeCompra"].ToString() == "Mesa") {


            }
        }
    }
}