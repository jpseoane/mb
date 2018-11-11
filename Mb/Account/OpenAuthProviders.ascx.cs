using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Nemiro.OAuth;

namespace Mb.Account
{
    public partial class OpenAuthProviders : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {


                // gets a provider name from the data-provider
            //    string provider = ((LinkButton)sender).Attributes["data-provider"];
                // build the return address
                //string returnUrl = new Uri(Request.Url, "../ExternalLoginResult.aspx").AbsoluteUri;
                ////
                //// redirect user into external site for authorization
                //OAuthWeb.RedirectToAuthorization("Google", returnUrl);

          
            }
        }

        public string ReturnUrl { get; set; }
        //public string ReturnUrl {
        //    get
        //    { return "ExternalLoginResult"; }
        //    set
        //    { }

        //}

        public IEnumerable<string> GetProviderNames()
        {
            return Context.GetOwinContext().Authentication.GetExternalAuthenticationTypes().Select(t => t.AuthenticationType);
        }
    }
}