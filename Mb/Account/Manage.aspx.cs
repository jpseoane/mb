using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using Mb.Models;

namespace Mb.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected string SuccessMessage
        {
            get;
            private set;
        }

        private bool HasPassword(ApplicationUserManager manager)
        {
            return manager.HasPassword(User.Identity.GetUserId());
        }

        public bool HasPhoneNumber { get; private set; }

        public bool TwoFactorEnabled { get; private set; }

        public bool TwoFactorBrowserRemembered { get; private set; }

        public int LoginsCount { get; set; }

        protected void Page_Load()
        {
          //  RevisaModoCompra();
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            HasPhoneNumber = String.IsNullOrEmpty(manager.GetPhoneNumber(User.Identity.GetUserId()));

            // Habilitar esta opción tras configurar autenticación de dos factores
            //PhoneNumber.Text = manager.GetPhoneNumber(User.Identity.GetUserId()) ?? String.Empty;

            TwoFactorEnabled = manager.GetTwoFactorEnabled(User.Identity.GetUserId());

            LoginsCount = manager.GetLogins(User.Identity.GetUserId()).Count;

            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            if (!IsPostBack)
            {
                // Determine las secciones que se van a presentar
                if (HasPassword(manager))
                {
                    ChangePassword.Visible = true;
                }
                else
                {
                    CreatePassword.Visible = true;
                    ChangePassword.Visible = false;
                }

                // Presentar mensaje de operación correcta
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Seccionar la cadena de consulta desde la acción
                    Form.Action = ResolveUrl("~/Account/Manage");

                    SuccessMessage =
                        message == "ChangePwdSuccess" ? "Se cambió la contraseña."
                        : message == "SetPwdSuccess" ? "Se estableció la contraseña."
                        : message == "RemoveLoginSuccess" ? "La cuenta se quitó."
                        : message == "AddPhoneNumberSuccess" ? "Se ha agregado el número de teléfono"
                        : message == "RemovePhoneNumberSuccess" ? "Se ha quitado el número de teléfono"
                        : String.Empty;
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                }
            }
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        // Quitar número de teléfono del usuario
        protected void RemovePhone_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var result = manager.SetPhoneNumber(User.Identity.GetUserId(), null);
            if (!result.Succeeded)
            {
                return;
            }
            var user = manager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                Response.Redirect("/Account/Manage?m=RemovePhoneNumberSuccess");
            }
        }

        // DisableTwoFactorAuthentication
        protected void TwoFactorDisable_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.SetTwoFactorEnabled(User.Identity.GetUserId(), false);

            Response.Redirect("/Account/Manage");
        }

        //EnableTwoFactorAuthentication 
        protected void TwoFactorEnable_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.SetTwoFactorEnabled(User.Identity.GetUserId(), true);

            Response.Redirect("/Account/Manage");
        }


        //private void RevisaModoCompra()
        //{
        //    //NO TIENE UN ROL DE COMPRA ASIGNADO
        //    if (!String.IsNullOrEmpty(Session["RolDeCompra"] as string))
        //    {
               
        //        //Si quiere cambiar el modo de compra
        //        if (!String.IsNullOrEmpty(Request.QueryString["fc"]))
        //        {
        //            //cambiar a mesa
        //            if (Request.QueryString["fc"].ToString() == "m")
        //            {
        //                //Tengo que verificar que su cuenta de pedidos este salda y lo envio a registrase en mesa

        //                Session["RolDeCompra"] = "Mesa";
        //                Response.Redirect("Manage.aspx");
        //            }
        //            //Si selecciono barra 
        //            else if (Request.QueryString["fc"].ToString() == "b")
        //            {
        //                //Tengo que verificar que su cuenta de pedidos este saldada y su mesa cerrada para habilitar para que pueda pasar a barra y recargo la pagina
        //                Session["RolDeCompra"] = "Barra";
        //                Response.Redirect("Manage.aspx");
        //            }
        //        }
        //        GeneraMensaje();
        //    }
        //}


        //private void GeneraMensaje() {
            
        //    if (Session["RolDeCompra"].ToString() == "Mesa")
        //    {
        //        lblMensaje.Text = "Vos estas logueado para comprar desde la mesa, si queres cambiarte para comprar desde la barra clickea aca";
        //        aCambioBarra.Visible = true;
        //        aCambioMesa.Visible = false;
        //    }
        //    else
        //    {
        //        lblMensaje.Text = "Vos estas logueado para comprar desde la barra, si queres cambiarte para comprar desde una mesa clickea aca";
        //        aCambioBarra.Visible = false;
        //        aCambioMesa.Visible = true;
        //    }
        //}
    }
}