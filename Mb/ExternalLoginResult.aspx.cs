using Mb;
using Mb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Nemiro.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsConOAuthNemiro
{
    public partial class ExternalLoginResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                    var result = OAuthWeb.VerifyAuthorization();                                   
                if (result.IsSuccessfully)
                {                                      
                    // successfully
                    var user = result.UserInfo;
                    CreateAndLoginUser(user.UserName, user.Email);
                }
                else
                {
                    // error
                    Response.Write(result.ErrorInfo.Message);
                }
            }
        }


        private void CreateAndLoginUser(String userName,String email)
        {
            
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();
            ApplicationUser userBuscado =  manager.FindByEmail(email) ;

            if (userBuscado != null)
            {
                signInManager.SignIn(userBuscado, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl("Default.aspx", Response);
            }
            else {
                var user = new ApplicationUser() { UserName = email, Email = email, perfil="cliente" };
                IdentityResult result = manager.Create(user, "Google");
                if (result.Succeeded)
                {                 

                    ExternalLoginInfo loginInfo = new ExternalLoginInfo();

                    UserLoginInfo userLoginInfo = new UserLoginInfo(email,"Google");

                    loginInfo.Login = userLoginInfo;

                    result = manager.AddLogin(user.Id, loginInfo.Login);
                    if (result.Succeeded)
                    {
                        signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);

                        // Para obtener más información sobre cómo habilitar la confirmación de cuentas y el restablecimiento de contraseña, visite https://go.microsoft.com/fwlink/?LinkID=320771
                        // var code = manager.GenerateEmailConfirmationToken(user.Id);
                        // Enviar este vínculo por correo electrónico: IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id)

                        IdentityHelper.RedirectToReturnUrl("Default.aspx", Response);
                        return;
                    }
                }
                AddErrors(result);
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}