<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modocompra.aspx.cs" Inherits="Mb.Views.Usuario.pedidos.prepedido" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">asignamesa.aspx
    <div class="jumbotron">
        <h1>Bienvenido a MiBar!</h1>
        <p class="lead">Para empezar a utilizar la apliacion selecciona una opcion!</p>        
    </div>
    <div class="form-horizontal">
       <div class="col-md-12 col-lg-12"  id="dvMensajeCambio" runat="server" >
            <div class="alert alert-info alert-dismissible " role="alert">
               <h3>Cambio de compra</h3>
               <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
               <asp:Label  id="lblMensaje" runat="server" Text=""></asp:Label>
                <a href="modocompra.aspx?fc=b" id="aCambioBarra" runat="server" class="alert-link" visible="false">Si quiero pasar a la Barra!</a> 
                <a href="modocompra.aspx?fc=m" id="aCambioMesa" runat="server" class="alert-link" visible="false">Si quiero pasar a una mesa!</a>                
            </div>
       </div>
       <div id="divSeleccion" runat="server" >
            <div class="col-sm-6 col-md-6 col-lg-6">
                <h2>Con Mesa</h2>
                <p>
                    Si tenes una mesa selecciona esta opcion y acercate a la misma para ingresar el numero o leer el codigo QR                
                </p>
                <div style="text-align:center">
                    <asp:ImageButton runat="server"  ID="imbtnMesa" width="250px" height="250px" 
                   ImageUrl="../../../Content/img/mesa.png" OnClick="imbtnMesa_Click" />   
                </div>
            </div>
            <div class="col-sm-6 col-md-6 col-lg-6">
                <h2>Barra</h2>
                <p>
                    ¿Venis solo y queres hacer pedidos en la barra sin esperar?. Selecciona esta opcion, hace tu pedido, pasa por caja 
                    y listo espera que te avisemos para ir a buscar tu pedido!
                </p>
                  <div style="text-align:center">
                    <asp:ImageButton runat="server"  ID="imgbtnBarra" width="250px" height="250px" 
                   ImageUrl="../../../Content/img/barra.png" OnClick="imgbtnBarra_Click"  />   
                </div>
            </div>  
       </div>        
    </div>
</asp:Content>
