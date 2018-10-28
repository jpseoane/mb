using Mb.DAO;
using MbDataAccess;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Mb.DAO.UserMesaController;

namespace Mb.Views.Usuario
{
    public partial class pedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                UsuariosDeMesa usuarioDeMesa = UserMesaController.GetUsuarioDeMesaByIdUser(User.Identity.GetUserId());
                if (usuarioDeMesa != null)
                {
                    this.lblMail.Text = usuarioDeMesa.email;
                    this.lblPerfil.Text = usuarioDeMesa.perfilEnMesa;
                    this.chkActivo.Checked = usuarioDeMesa.activo;
                    gvUsuariosEnMesa.DataSource = UserMesaController.GetUsuariosDeMesa(usuarioDeMesa.IdMesa);
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

        protected void lnbReservar_Click(object sender, EventArgs e)
        {
            Mesa mesa = MesaController.GetbyNumeroMesa(Convert.ToInt32(this.txtNumeroMesa.Text));
            if (mesa!=null)
            {
                //Busco los usuarios del numero de mesa habilitados
                List<UserMesa> Lista = UserMesaController.GetUserMesaByNumeroMesa(Convert.ToInt32(this.txtNumeroMesa.Text));
                //Si hay al menos hay un usuario
                if (Lista.Count > 0)
                {
                    //Lo cargo como perfil INVITADO (2) desactivado (false) y deshabilitado (false)
                    UserMesaController.agregar(User.Identity.GetUserId(), mesa.Id, 2, false, true);
                    Mensaje("Bienvenido! Has sido asignado a la mesa numero: " + this.txtNumeroMesa.Text + ". " +
                    "Recorda que para poder empezar a realizar pedidos debe autorizarte el que primero ingreso a la mesa!", true);
                }
                else
                {
                    //Sino
                    //Lo cargo como perfil ADMINISTRADOR (1) Activo (true) y habilitado (true)
                    UserMesaController.agregar(User.Identity.GetUserId(), mesa.Id, 1, true, true);
                    Mensaje("Bienvenido! Has sido asignado a la mesa numero: " + this.txtNumeroMesa.Text + " y por ser el primero SOS ADMINISTRADOR DE LA MISMA!."
                        + "Por lo tanto vos poder otorgarle o quitarle la opcion de poder hacer pedidos a la mesa a los invitados que te lo soliciten! (Checkea esto en la pestaña Amigos Pendientes!)", true);
                }
            }
            //El numero de mesa que esta buscando no existe o esta con estado no disponible
            else
            {
                Mensaje("Bienvenido! Lo sentimos pero la Mesa numero: " + this.txtNumeroMesa.Text + " no esta disponible o no existe en sistema. Por favor ingresa un nuevo numero o consulta con el personal", false);

            }

        }

        private void Mensaje(String mensaje, bool exito)
        {
            
            if (exito)
            {
                divPrueba.Attributes.Add("class", "alert alert-success");
                divMensaje.InnerText = mensaje + " exitosa";
            }
            else
            {
                divPrueba.Attributes.Add("class", "alert alert-warning");
                divMensaje.InnerText = "Eror en " + mensaje;
            }
            divPrueba.Visible = true;
        }

    }
}