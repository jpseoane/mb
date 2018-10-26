using Mb.DAO;
using MbDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mb.Views.Usuario
{
    public partial class pedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnbReservar_Click(object sender, EventArgs e)
        {

            List<UserMesa> Lista = UserMesaController.GetUserMesaByNumeroMesa2(2);
                        
            gv.DataSource= UserMesaController.GetUserMesaByNumeroMesa2(2);
            gv.DataBind();

            foreach (UserMesa userMesa in Lista)
                {
                    
                }



        }
    }
}