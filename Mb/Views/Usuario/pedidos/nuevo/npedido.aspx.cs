using Mb.DAO;
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
                ValidaUsuario();

            }
            
        }

        private String ValidaUsuario()
        {
            UsuariosDeMesa usuarioDeMesa = UserMesaController.GetUsuarioDeMesaByIdUser(User.Identity.GetUserId());
            if (usuarioDeMesa != null)
            {
                this.lblMail.Text = usuarioDeMesa.email;
                this.lblPerfil.Text = usuarioDeMesa.perfilEnMesa;
                this.chkActiva.Checked = usuarioDeMesa.activo;
                gvUsuariosEnMesa.DataSource = UserMesaController.GetUsuariosDeMesa(usuarioDeMesa.idMesa);
                gvUsuariosEnMesa.DataBind();
                dvAsignaMesa.Visible = false;
                dvUsuarioMesa.Visible = true;
                dvGrupoMesa.Visible = true;
            }
            else
            {
                dvUsuarioMesa.Visible = false;
                dvGrupoMesa.Visible = false;
                dvAsignaMesa.Visible = true;
            };
        }
    }
}