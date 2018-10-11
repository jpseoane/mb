using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using MbDataAccess;

namespace Mb.Views.Admin
{
    public partial class cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (mbDBContext entities = new mbDBContext()) {

          //       entities.Clientes.ToList<cliente>;
            }

        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            int i = (int)Membership.GetUser().ProviderUserKey;
        }
    }
}