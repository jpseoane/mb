using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mb.DAO;
using MbDataAccess;
using Microsoft.AspNet.Identity;

namespace Mb.Views.Admin
{
    public partial class abm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {

                this.lblUsuario.Text = IdentityHelper.UserIdKey.ToString();
            }

        }

       

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCarga_Click1(object sender, EventArgs e)
        {
            switch (this.TabContainer.ActiveTabIndex)
            {
                case 0:
                    //Carta
                    try
                    {
                        Carta carta = new Carta();
                        carta.activa = chkActiva.Checked;
                        carta.descripcion = txtNombreCarta.Text;
                        carta.UserId = User.Identity.GetUserId();
                        carta.idproducto = 1;
                        carta.fecha = DateTime.Now;

                        //CartaDao cartaDao = new CartaDao();
                        if (CartaController.agregar(carta))
                        {
                            divPrueba.Attributes.Add("class", "alert alert-success");
                            divPrueba.Visible = true;
                            divMensaje.InnerText = "Carga realizada";
                        }
                        else {
                            divPrueba.Attributes.Add("class", "alert alert-warning");
                            divPrueba.Visible = true;
                            divMensaje.InnerText = "No se pudo realizar la carga";
                        }

                    }
                    catch(EntityDataSourceValidationException ex)
                    {
                        //divErrorText.InnerText = ex.Message.ToString();
                        divPrueba.Attributes.Add("class", "alert alert-warning");
                        divPrueba.Visible = true;
                        //divPrueba.InnerText = "No se pudo realizar la carga";
                        
                    }
                    finally {
                    }
                    break;
                case 1:
                    //TipoProductos
                    Console.WriteLine("Case 2");
                    break;
                case 2:
                    //SubTipoProductos
                    Console.WriteLine("Case 2");
                    break;
                case 3:
                    //Mesa
                    Console.WriteLine("Case 2");
                    break;

            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}