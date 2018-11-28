using Mb.DAO;
using MbDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Mb.DAO.MuroController;

namespace Mb.Views.Admin
{
    public partial class muestramuro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                CrearMuro();
            }
        }

        private void CrearMuro()
        {
            List<MensajeMurosDetalle> ListaDeMensajeMurosDetalles = MuroController.GetAllCondetalle(false, EnumEstadoMensaje.Aprobado);
            foreach (MensajeMuro mensajeMuro in ListaDeMensajeMurosDetalles) {
                Response.Write("<table> <tr> <td>");
                Response.Write("Tiutlo: " + mensajeMuro.titulo + " </td> </tr> ");
                Response.Write("<tr> <td>");
                Response.Write("Mensaje: " + mensajeMuro.mensaje + " </td> </tr> ");
                Response.Write("</table>");
            }
        }
    }
}