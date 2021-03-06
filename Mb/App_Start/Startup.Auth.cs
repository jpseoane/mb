﻿using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Google;
using Owin;
using Mb.Models;
using Nemiro.OAuth;
using Nemiro.OAuth.Clients;

namespace Mb
{
    public partial class Startup {

        // Para obtener más información sobre cómo configurar la autenticación, visite https://go.microsoft.com/fwlink/?LinkId=301883
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure el contexto de bd, el administrador de usuarios y el administrador de inicio de sesión para usar una instancia única por solicitud
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Habilitar la aplicación para que use una cookie para almacenar la información del usuario que inició sesión
            // y usar una cookie para almacenar temporalmente información sobre un usuario que inicia sesión con un proveedor de inicio de sesión de un tercero
            // Configurar la cookie de inicio de sesión
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });



            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ExternalCookie
            });

            // Usar una cookie para almacenar temporalmente información sobre un usuario que inicia sesión con un proveedor de inicio de sesión de un tercero
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);


            //Seteado con la de MiBar
            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "188020733885-mbtmrvhv4nqjf24ip0j04vun2q91sh5o.apps.googleusercontent.com",
                ClientSecret = "GsxR_vq5myxnq_QqUbVIXT7F"
            });



            //Seteado con la de MiBar  Creada el 01-12-2018
            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "188020733885-dsoe0kbheph63v7r210taje1mlh6mnve.apps.googleusercontent.com",
            //    ClientSecret = "ps-uHA4vnfpv1hQo6cNvToFu"
            //});






            //OAuthManager.RegisterClient
            // (
            //   new GoogleClient
            //   (
            //     "188020733885-mbtmrvhv4nqjf24ip0j04vun2q91sh5o.apps.googleusercontent.com",
            //     "GsxR_vq5myxnq_QqUbVIXT7F"
            //   )
            // );




            // ODUumSpFqWmtDWzap3V4zVV0


            // Habilita a la aplicación para almacenar temporalmente la información del usuario cuando estén comprobando el segundo factor en el proceso de autenticación de dos factores.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Habilita a la aplicación para que recuerde el segundo factor de comprobación de inicio de sesión como teléfono o correo electrónico.
            // Una vez active esta opción, se recordará el segundo paso de comprobación durante el proceso de inicio de sesión en el dispositivo desde donde inició sesión.
            // Esto es similar a la opción RememberMe cuando inicia sesión.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Quitar las marcas de comentario de las líneas siguientes para habilitar el inicio de sesión con proveedores de inicio de sesión de terceros
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            




            // IdCliente Oauth =  188020733885-mbtmrvhv4nqjf24ip0j04vun2q91sh5o.apps.googleusercontent.com
            // Client Secret   =  X0oSClq7YfDBBB_kQ3WcMDQn

            // IdCliente Mibar =  188020733885-bdb8ombkpbceqp3d1ar23a7f95qa99o8.apps.googleusercontent.com
            // Client Secret   = NYFcv_bkcgPg_wY1Z104A_i1






        }
    }
}
