using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Nemiro.OAuth;

namespace Mb
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // IdCliente Oauth =  188020733885-mbtmrvhv4nqjf24ip0j04vun2q91sh5o.apps.googleusercontent.com
            // Client Secret   =  X0oSClq7YfDBBB_kQ3WcMDQn

            // IdCliente Mibar =  188020733885-bdb8ombkpbceqp3d1ar23a7f95qa99o8.apps.googleusercontent.com
            // Client Secret   = NYFcv_bkcgPg_wY1Z104A_i1

            //   OAuthManager.RegisterClient
            //(      
            //   "google",
            //   "188020733885-bdb8ombkpbceqp3d1ar23a7f95qa99o8.apps.googleusercontent.com",
            //   "NYFcv_bkcgPg_wY1Z104A_i1"
            //);


            //Oauth
                OAuthManager.RegisterClient
             (
                "google",
                "188020733885-mbtmrvhv4nqjf24ip0j04vun2q91sh5o.apps.googleusercontent.com",
                "X0oSClq7YfDBBB_kQ3WcMDQn"
             );


            OAuthManager.RegisterClient
            (
               "facebook",
               "1978055228883879",
               "7c47ef27b3c51327b7a0983e03a187c6"
            );


        }
    }
}