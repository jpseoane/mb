using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mb.DAO;
using MbDataAccess;
using Microsoft.AspNet.Identity;

namespace Mb.Views.Admin.abms
{
    public partial class gcarta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                CargaGrilla();
            }
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "editar":
                    Carta carta;
                    carta = CartaDao.Get(Convert.ToInt32(e.CommandArgument));
                    if (carta != null)
                    {
                        this.txtNombreCarta.Text = carta.descripcion;
                        this.chkActiva.Checked = carta.activa;
                        ViewState["id"] = e.CommandArgument;
                        btnActualizar.Enabled = true;
                    }
                    else {
                        btnActualizar.Enabled = false;
                    }                    
                    ;
                    break;
                case "eliminar":
                    CartaDao.Borrar(Convert.ToInt32(e.CommandArgument));
                    break;
            }
            CargaGrilla();
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            //Type t = value.GetType();
            bool obj = (bool) CartaDao.agregar(txtNombreCartaNueva.Text, 1, chkActivaNueva.Checked, User.Identity.GetUserId());
            //bool ban = (bool) obj[0];
            //if (auxiliar.GetType() == Type.GetType("System.Int32"))
            //    return true;
            //else
            //    return false;

            //if (obj.GetType()== Type.GetType("bool"))
            if (obj)
                {
                divPrueba.Attributes.Add("class", "alert alert-success");
                divMensaje.InnerText = "Carga realizada";
            }
            else
            {   
                divPrueba.Attributes.Add("class", "alert alert-warning");
                divMensaje.InnerText = CartaDao.errorCarta.mensaje;
                //divMensaje.InnerText = "No se pudo realizar la carga";
            }
            divPrueba.Visible = true;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargaGrilla();
        }

        private void CargaGrilla(){
            gv.DataSource = CartaDao.Get();
            gv.DataBind();
            divPrueba.Visible = false;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            //Carta carta= CartaDao.Get(Convert.ToInt32(ViewState["id"]));
            
            CartaDao.update(Convert.ToInt32(ViewState["id"]), txtNombreCarta.Text, 1, chkActiva.Checked, User.Identity.GetUserId());
        }
        private  void Mensaje(bool exito, String mensaje="")
        {
            
            if (exito)
            {divPrueba.Attributes.Add("class", "alert alert-success");
                if (mensaje != "")
                {
                    divMensaje.InnerText = mensaje;
                }
                else
                {
                    divMensaje.InnerText = "Accion exitosa";
                }
                
            }
            else
            {divPrueba.Attributes.Add("class", "alert alert-warning");}
            divPrueba.Visible = true;
        }
    }
}