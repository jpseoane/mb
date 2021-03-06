﻿using Mb.DAO;
using MbDataAccess;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Mb.DAO.CuentaController;
using static Mb.DAO.UserMesaController;

namespace Mb.Views.Usuario
{
    public partial class cuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Busca si ya estas logueado en una mesa
                UsuarioMesaDetalle usuarioDeMesa = UserMesaController.GetUsuarioDeMesaByIdUser(User.Identity.GetUserId());
                if (usuarioDeMesa != null && usuarioDeMesa.activo == true)
                {
                    ViewState["idUserMesa"] = usuarioDeMesa.id;                  
                    dvMensajeCambio.Visible = false;
                    CuentaDetalle cuenta = CuentaController.GetAlldetalle(true,usuarioDeMesa.mesaNumero,0).SingleOrDefault();

                    if (cuenta != null)
                    {
                        //Muestra el detalle de la cuenta
                        this.lblUsuarioSolicito.Text = cuenta.email.ToString();
                        this.lblFecha.Text = cuenta.fecha.ToString("dd/MM/yyyy");
                        this.lblEstado.Text = cuenta.estado_descri;
                        this.lblTotalCuenta.Text = Convert.ToString(cuenta.total);
                        this.lblTotalUsuario.Text = Convert.ToString(PedidoController.ObtnerSubtotalXUsarioDeMesa(Convert.ToInt32(ViewState["idUserMesa"])));                        
                        dvDetalleCuenta.Visible = true;
                        spNmesa.InnerText = Convert.ToString(usuarioDeMesa.mesaNumero);
                    }
                    else
                    {
                        //Todavia no pediste la cuenta
                    }
                }
                else if (usuarioDeMesa != null && usuarioDeMesa.activo == false)
                {
                    dvMensajeCambio.Visible = true;
                    dvDetalleCuenta.Visible = false;
                    lblMensaje.Text = "Tu usuario esta asignado a la mesa pero necesitas que el ADMIN te autorize para poder comprar!";

                }
                else
                {
                    dvMensajeCambio.Visible = true;
                    dvDetalleCuenta.Visible = false;
                    lblMensaje.Text = "Tenes que seleccionar una mesa para poder cargar un pedido";
                }

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

    }
}