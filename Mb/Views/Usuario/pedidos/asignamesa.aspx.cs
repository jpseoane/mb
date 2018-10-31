using Mb.DAO;
using MbDataAccess;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Web.UI;
using static Mb.DAO.UserMesaController;

namespace Mb.Views.Usuario.pedidos
{
    public partial class asignamesa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Busca si ya estas logueado en una mesa
                UsuariosDeMesa usuarioDeMesa = UserMesaController.GetUsuarioDeMesaByIdUser(User.Identity.GetUserId());
                if (usuarioDeMesa != null)
                {
                    //Si estas logueado te muestra los datos
                    this.lblMail.Text = usuarioDeMesa.email;
                    this.lblPerfil.Text = usuarioDeMesa.perfilEnMesa;                    
                    chkActiva.Checked = usuarioDeMesa.activo;
                    gvUsuariosEnMesa.DataSource = UserMesaController.GetUsuariosDeMesa(usuarioDeMesa.idMesa);
                    gvUsuariosEnMesa.DataBind();
                    dvAsignaMesa.Visible = false;
                    dvUsuarioMesa.Visible = true;
                    dvGrupoMesa.Visible = true;
                    
                }
                else
                {
                    //Si no te habilita para loguearte                    
                    this.ddlNumeroMesa.DataTextField = ("numero");
                    this.ddlNumeroMesa.DataValueField = ("id");
                    this.ddlNumeroMesa.DataSource = MesaController.GetDisponibles();
                    this.ddlNumeroMesa.DataBind();

                    this.lnbReservar.Enabled = true;
                    dvUsuarioMesa.Visible = false;
                    dvGrupoMesa.Visible = false;
                    dvAsignaMesa.Visible = true;
                };

            }
        }

        protected void lnbReservar_Click(object sender, EventArgs e)
        {
            Mesa mesa = MesaController.GetbyNumeroMesa(Convert.ToInt32(this.ddlNumeroMesa.SelectedValue));
            if (mesa != null)
            {
                //Busco los usuarios del numero de mesa habilitados
                List<UserMesa> Lista = UserMesaController.GetUserMesaByNumeroMesa(Convert.ToInt32(this.ddlNumeroMesa.SelectedValue));
                //Si hay al menos hay un usuario                
                if (Lista.Count > 0)
                {
                    //Lo cargo como perfil INVITADO (2) desactivado (false) y deshabilitado (false)
                    UserMesaController.agregar(User.Identity.GetUserId(), mesa.Id, 2, false, true);
                    Mensaje("Excelente! Te registraste en la mesa numero: " + this.ddlNumeroMesa.SelectedValue + ". Ya podes empezar a utilizar MiBar!. " +
                    "Recorda que para poder realizar pedidos vos para la mesa debe autorizarte el Admin! (El primero que se registro en la mesa!)", true);
                }
                else
                {
                    //Sino
                    //Lo cargo como perfil ADMINISTRADOR (1) Activo (true) y habilitado (true)
                    UserMesaController.agregar(User.Identity.GetUserId(), mesa.Id, 1, true, true);
                    Mensaje("Perfecto! Sos administrador de la mesa N°: " + this.ddlNumeroMesa.SelectedValue + ". Podes empezar a realizar pedidos y autorizar a los invitados de la mesa que se registren!"
                        , true);
                }
            }
            //El numero de mesa que esta buscando no existe o esta con estado no disponible
            else
            {
                Mensaje("Bienvenido! Lo sentimos pero la Mesa numero: <strong>" + this.ddlNumeroMesa.SelectedValue + "</strong> no esta disponible o no existe en sistema. Por favor ingresa un nuevo numero o consulta con el personal", false);

            }
            this.lnbReservar.Enabled = false;

        }

        private void Mensaje(String mensaje, bool exito)
        {

            if (exito)
            {
                aMensaje.InnerText = "Continuar";
                aMensaje.HRef = "nuevo/npedido.aspx";
                divPrueba.Attributes.Add("class", "alert alert-success");
                divMensaje.InnerText = mensaje;
            }
            else
            {
                aMensaje.InnerText = "Reintentar";
                aMensaje.HRef = "asignamesa.aspx";
                divPrueba.Attributes.Add("class", "alert alert-warning");
                divMensaje.InnerText = mensaje;
            }
            divPrueba.Visible = true;
        }

    }
}