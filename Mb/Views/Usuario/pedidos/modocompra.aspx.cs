using System;
using System.Web.UI;


namespace Mb.Views.Usuario.pedidos
{
    public partial class prepedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RevisaModoCompra();
        }

        private void RevisaModoCompra() {

            //NO TIENE UN ROL DE COMPRA ASIGNADO
            if (!String.IsNullOrEmpty(Session["RolDeCompra"] as string))
            {
                //Modo cambio
                habiliarModo("c");
                //Si quiere cambiar el modo de compra
                if (!String.IsNullOrEmpty(Request.QueryString["fc"]))
                {
                    //cambiar a mesa
                    if (Request.QueryString["fc"].ToString() == "m")
                    {
                        //Tengo que verificar que su cuenta de pedidos este salda y lo envio a registrase en mesa

                        Session["RolDeCompra"] = "Mesa";
                        Response.Redirect("modocompra.aspx");
                    }
                    //Si selecciono barra 
                    else if (Request.QueryString["fc"].ToString() == "b")
                    {
                        //Tengo que verificar que su cuenta de pedidos este saldada y su mesa cerrada para habilitar para que pueda pasar a barra y recargo la pagina
                        Session["RolDeCompra"] = "Barra";
                        Response.Redirect("modocompra.aspx");
                    }
                }
            }
            //YA TIENE UN ROL DE COMPRA ASIGNADO
            else
            {
                //Modo seleccion
                habiliarModo("s");
                ////SI SU ROL ES DE MESA
                //if (Session["RolEnBar"].ToString() == "Mesa")
                //{
                //    //HABILITO  PARA QUE PUEDA CAMBIAR A BARRA
                //}
                //else if (Session["RolEnBar"].ToString() == "Barra")
                //{
                //    //HABILITO PARA QUE PUEDA CAMBIAR A MESA

                //}
            }


        }

        private void habiliarModo(String modo) {

            switch (modo) {
                    //Modo Seleccion (s)
                case "s":
                    dvMensajeCambio.Visible = false;
                    this.divSeleccion.Visible = true;                                   
                    break;
                    //Modo Cambio (c)
                case "c":
                    dvMensajeCambio.Visible = true;
                    this.divSeleccion.Visible = false;
                    if (Session["RolDeCompra"].ToString() == "Mesa")
                    {
                        lblMensaje.Text = "Vos estas logueado para comprar desde la mesa, si queres cambiarte para comprar desde la barra clickea aca";
                        aCambioBarra.Visible = true;
                        aCambioMesa.Visible = false;
                    }
                    else
                    {
                        lblMensaje.Text = "Vos estas logueado para comprar desde la barra, si queres cambiarte para comprar desde una mesa clickea aca";
                        aCambioBarra.Visible = false;
                        aCambioMesa.Visible = true;
                    }
                    break;
                //Modo Seleccion (s)
                default:
                    dvMensajeCambio.Visible = false;
                    this.divSeleccion.Visible = true;
                    break;
            }
        }
        protected void imbtnMesa_Click(object sender, ImageClickEventArgs e)
        {
            Session["RolDeCompra"] = "Mesa";
            Response.Redirect("~/Views/Usuario/pedidos/pedmesa/asignamesa.aspx");
        }

        protected void imgbtnBarra_Click(object sender, ImageClickEventArgs e)
        {
            Session["RolDeCompra"] = "Barra";
            Response.Redirect("~/Views/Usuario/pedidos/modocompra.aspx");
        }
    }
}