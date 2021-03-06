﻿using Mb.DAO;
using MbDataAccess;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Mb.DAO.UserMesaController;

namespace Mb.Views.Usuario.nuevo
{
    public partial class nmuro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["nombrefoto"] = "";
                //Busca si ya estas logueado en una mesa
                UsuarioMesaDetalle usuarioDeMesa = UserMesaController.GetUsuarioDeMesaByIdUser(User.Identity.GetUserId());
                if (usuarioDeMesa != null)
                {
                    dvMensajeCambio.Visible = false;
                    dvCargaMensaje.Visible = true;
                }
                else
                {
                    dvMensajeCambio.Visible = true;
                    dvCargaMensaje.Visible = false;
                };
            }
        }

        protected void UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            try
            {
                string path = Server.MapPath("../../../Content/imgSub/") + e.FileName.ToString();
                Session["nombrefoto"] = e.FileName.ToString();
                AjaxFileUpload1.SaveAs(path);
            }
            catch
            {
                Session["nombrefoto"] = "";
                Mensaje("publicacion de la foto", false);
                btnCargar.Enabled = false;
            }

            
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            if (Session["nombrefoto"].ToString() != "")
            {
                Mensaje("Publicacion", MuroController.agregar(User.Identity.GetUserId(), txtTitulo.Text, txtPublicacion.Text, true, Session["nombrefoto"].ToString()));
            }
            else {

                Mensaje("Publicacion", MuroController.agregar(User.Identity.GetUserId(), txtTitulo.Text, txtPublicacion.Text, false));
            }
           
        }


        private void Mensaje(String movimiento, bool exito)
        {
            if (exito)
            {
                divPrueba.Attributes.Add("class", "alert alert-success");
                divMensaje.InnerText = movimiento + " exitosa";
            }
            else
            {
                divPrueba.Attributes.Add("class", "alert alert-warning");
                divMensaje.InnerText = "Eror en " + movimiento;
            }
            divPrueba.Visible = true;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPublicacion.Text = "";
            txtTitulo.Text = "";
            divPrueba.Visible = false;
        }
    }
}