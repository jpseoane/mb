using Mb.DAO;
using MbDataAccess;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
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
                UsuarioMesaDetalle usuarioDeMesa = UserMesaController.GetUsuarioDeMesaByIdUser(User.Identity.GetUserId());                
                if (usuarioDeMesa != null)
                {
                    //Si el usuario en mesa NO es admin
                    if (usuarioDeMesa.idPerfilMesa != 1) {
                        gvUsuariosEnMesa.Enabled = false;
                    }
                    ViewState["idMesaUsuario"] = usuarioDeMesa.idMesa;
                    //Si estas logueado te muestra los datos
                    this.lblMail.Text = usuarioDeMesa.email;
                    this.lblPerfil.Text = usuarioDeMesa.perfilEnMesa;                    
                    chkActiva.Checked = usuarioDeMesa.activo;
                    CargaMesa(Convert.ToInt32(ViewState["idMesaUsuario"]));
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

        private void CargaMesa(int idMesa) {
            gvUsuariosEnMesa.DataSource = UserMesaController.GetUsuariosPorIdMesa(idMesa);
            gvUsuariosEnMesa.DataBind();
        }
        protected void lnbReservar_Click(object sender, EventArgs e)
        {
            Mesa mesa = MesaController.GetbyNumeroMesa(Convert.ToInt32(this.ddlNumeroMesa.SelectedValue));
            if (mesa != null)
            {
                //Busco los usuarios del numero de mesa habilitados
                List<UserMesa> ListaUserMesa = UserMesaController.GetUserMesaByNumeroMesa(Convert.ToInt32(this.ddlNumeroMesa.SelectedValue));
                //Si hay al menos hay un usuario                
                if (ListaUserMesa.Count > 0)
                {
                    //Lo cargo como perfil INVITADO (2) desactivado (false) y habilitado (true)
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
                aMensaje.HRef = "npedido.aspx";
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

        protected void gvUsuariosEnMesa_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            //if (e.CommandName.ToString() == "activar") {
            //    UserMesaController.Activar(Convert.ToInt32(e.CommandArgument));

            //}
            if (e.CommandName.ToString() == "eliminar")
            {
                UserMesaController.Borrar(Convert.ToInt32(e.CommandArgument));
            }


   
            CargaMesa(Convert.ToInt32(ViewState["idMesaUsuario"]));
        }

        protected void chkApproved_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkApproved = (CheckBox)sender;
            GridViewRow gridViewRow = (GridViewRow)chkApproved.Parent.Parent;
            int userMesaId = (int)gvUsuariosEnMesa.DataKeys[gridViewRow.RowIndex].Value;
            bool activo = chkApproved.Checked;

            //Your update method            
            UserMesaController.UpdateActivo(userMesaId,activo);

            //Your data load method
            CargaMesa(Convert.ToInt32(ViewState["idMesaUsuario"]));
        }

    }
}