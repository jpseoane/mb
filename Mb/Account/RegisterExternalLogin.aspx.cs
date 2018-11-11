using System;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using Mb.Models;
using System.Security.Claims;
using System.Collections.Generic;
using Nemiro.OAuth;

namespace Mb.Account
{
    public partial class RegisterExternalLogin : System.Web.UI.Page
    {
        protected string ProviderName
        {
            get { return (string)ViewState["ProviderName"] ?? String.Empty; }
            private set { ViewState["ProviderName"] = value; }
        }

        protected string ProviderAccountKey
        {
            get { return (string)ViewState["ProviderAccountKey"] ?? String.Empty; }
            private set { ViewState["ProviderAccountKey"] = value; }
        }

        private void RedirectOnFail()
        {
            Response.Redirect((User.Identity.IsAuthenticated) ? "~/Account/Manage" : "~/Account/Login");
        }

        protected void Page_Load()
        {
            // Procesar el resultado de un proveedor de autenticación en la solicitud
            ProviderName = IdentityHelper.GetProviderNameFromRequest(Request);            
            if (String.IsNullOrEmpty(ProviderName))
            {
                RedirectOnFail();
                return;
            }
            if (!IsPostBack)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                                                                                      
                var result = OAuthWeb.VerifyAuthorization();
                //        Response.Write(String.Format("Provider: {0}<br />", result.ProviderName));

                if (result.IsSuccessfully)
                {
                    // successfully
                    var user2 = result.UserInfo;


                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, user2.UserName));
                    claims.Add(new Claim(ClaimTypes.Email, user2.Email));
                    var id = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ExternalCookie);



                    var ctx = Request.GetOwinContext();
                    var authenticationManager = ctx.Authentication;
                    authenticationManager.SignIn(id);



                    ExternalLoginInfo loginInfo = new ExternalLoginInfo();
                    //UserLoginInfo a = new UserLoginInfo("google", IdentityHelper.XsrfKey);

                    loginInfo.ExternalIdentity = id;
                    loginInfo.DefaultUserName = user2.UserName;

                    loginInfo.Email = user2.Email;
                    
                    
                    //loginInfo.Login = a;

                    //  loginInfo.Login = Context.GetOwinContext().Authentication.GetExternalLoginInfo();

                    UserLoginInfo userLoginInfo = new UserLoginInfo(user2.UserName, "externo");
                    loginInfo.Login = userLoginInfo;

                    var loginInfo2 = Context.GetOwinContext().Authentication.GetExternalLoginInfo();

                    var user = manager.Find(userLoginInfo);
                    if (user != null)
                    {
                        signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                    }
                    else if (User.Identity.IsAuthenticated)
                    {
                        // Aplicar comprobación de Xsrf durante la vinculación
                        var verifiedloginInfo = Context.GetOwinContext().Authentication.GetExternalLoginInfo(IdentityHelper.XsrfKey, User.Identity.GetUserId());
                        if (verifiedloginInfo == null)
                        {
                            RedirectOnFail();
                            return;
                        }



                        var resultLogin = manager.AddLogin(User.Identity.GetUserId(), verifiedloginInfo.Login);
                        if (resultLogin.Succeeded)
                        {
                            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        }
                        else
                        {
                            AddErrors(resultLogin);
                            return;
                        }
                    }
                    else
                    {
                        email.Text = loginInfo.Email;
                    }


                }
                else
                {
                    RedirectOnFail();
                    return;

                }







                //if (loginInfo == null)
                //{
                //    RedirectOnFail();
                //    return;
                //}

            }//POSTABACK
        }  //Page load      
        
        protected void LogIn_Click(object sender, EventArgs e)
        {
            CreateAndLoginUser();
        }

        private void CreateAndLoginUser()
        {
            if (!IsValid)
            {
                return;
            }
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = email.Text, Email = email.Text };
            IdentityResult result = manager.Create(user);
            if (result.Succeeded)
            {
                //var loginInfo = Context.GetOwinContext().Authentication.GetExternalLoginInfo();
                //if (loginInfo == null)
                //{
                //    RedirectOnFail();
                //    return;
                //}

                ExternalLoginInfo loginInfo = new ExternalLoginInfo();
                UserLoginInfo userLoginInfo = new UserLoginInfo("juan pablo", "externo");
                loginInfo.Login = userLoginInfo;

                result = manager.AddLogin(user.Id, loginInfo.Login);
                if (result.Succeeded)
                {
                    signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);

                    // Para obtener más información sobre cómo habilitar la confirmación de cuentas y el restablecimiento de contraseña, visite https://go.microsoft.com/fwlink/?LinkID=320771
                    // var code = manager.GenerateEmailConfirmationToken(user.Id);
                    // Enviar este vínculo por correo electrónico: IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id)

                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                    return;
                }
            }
            AddErrors(result);
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