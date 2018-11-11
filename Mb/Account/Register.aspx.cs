using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Mb.Models;
using Nemiro.OAuth;

namespace Mb.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
            //    //if (Request.QueryString["UserId"] != "") {
            //        var result = OAuthWeb.VerifyAuthorization();
            //        Response.Write(String.Format("Provider: {0}<br />", result.ProviderName));

            //        if (result.IsSuccessfully)
            //        {

            //            // successfully
            //            var user = result.UserInfo;

            //            //Response.Write(String.Format("User ID:  {0}<br />", user.UserId));
            //            //Response.Write(String.Format("Name:     {0}<br />", user.DisplayName));
            //            //Response.Write(String.Format("Email:    {0}", user.Email));

            //            CrearUsuario(user.DisplayName, user.Email);
            //        }
            //        else
            //        {
            //            // error
            //            Response.Write(result.ErrorInfo.Message);
            //        }


                    
            //    //}

                
            }
        }


        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text, perfil = ddlPerfil.SelectedValue.ToString()};
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // Para obtener más información sobre cómo habilitar la confirmación de cuentas y el restablecimiento de contraseña, visite https://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirmar cuenta", "Para confirmar la cuenta, haga clic <a href=\"" + callbackUrl + "\">aquí</a>.");

                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        //protected void CrearUsuario(String UserName, String Email) {
        //    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
        //    var user = new ApplicationUser() { UserName = UserName, Email = Email, perfil = "Cliente" };

        //    if (manager.Find(user.UserName, "externo") != null)
        //    {
        //    //    signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
        //        var result2 = signInManager.PasswordSignIn(Email, "externo", true, shouldLockout: false);

        //    }
        //    else
        //    {
        //        IdentityResult result = manager.Create(user, "externo");
        //        if (result.Succeeded)
        //        {
        //            signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
        //            var result2 = signInManager.PasswordSignIn(Email, "externo", true, shouldLockout: false);

        //        }
        //        else
        //        {
        //            //  ErrorMessage.Text = result.Errors.FirstOrDefault();
        //        }

        //    }
        //}

        //protected void validaUsuario(String UserName, String Email) {
        //    // Validar la contraseña del usuario
        //    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

        //    // Esto no cuenta los errores de inicio de sesión hacia el bloqueo de cuenta
        //    // Para habilitar los errores de contraseña para desencadenar el bloqueo, cambie a shouldLockout: true
        //    var result = signinManager.PasswordSignIn(Email,"externo", true, shouldLockout: false);
        
        //    switch (result)
        //    {
        //        case SignInStatus.Success:
        //            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        //            break;
        //        case SignInStatus.LockedOut:
        //            Response.Redirect("/Account/Lockout");
        //            break;             
        //        case SignInStatus.Failure:
        //        default:                    
        //            break;
        //    }

        //}

    }
}