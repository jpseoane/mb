<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cuenta.aspx.cs" Inherits="Mb.Views.Usuario.cuenta"  MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron container">
        <h1>Cuenta</h1>
        <p class="lead">Detalle de la cuenta para la mesa y su estado</p>
    </div>
 <div class="container">
        <!-- dvMensajeCambio-->
        <div class="form-row"   id="dvMensajeCambio" runat="server"  visible="false" >
            <div class="col-md-12 col-lg-12">
                <div class="alert alert-info alert-dismissible " role="alert">
                    <h3>No tenes asignada una mesa</h3>
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <asp:Label  id="lblMensaje" runat="server" Text=""></asp:Label>
                    <a href="asignamesa.aspx" class="alert-link">Ir a Mesa!</a>                
                </div>
            </div>
        </div> <!-- dvMensajeCambio-->
       <div  id="dvDetalleCuenta" runat="server"  visible="false" >
            <div class="form-row">
                <div class="form-group col-lg-12" >        
                    <div class="panel panel-default">
                      <div class="panel-heading">
                        <h3 class="panel-title">Detalle de la cuenta solicitada para la mesa N° <strong><b><span runat="server" id="spNmesa"></span></b></strong></h3>
                      </div>
                      <div class="panel-body">
                        <strong><label for="lblUsuarioSolicito">Uuario que solicita la cuenta: </label></strong>
                        <asp:Label ID="lblUsuarioSolicito" CssClass="form-control" runat="server" Text="Usuario"></asp:Label><br />
                        <strong><label for="lblEstadoCuenta">Estado de la cuenta:</label></strong>
                        <asp:Label ID="lblEstado" CssClass="form-control" runat="server" Text="Fecha"></asp:Label><br />
                        <strong><label for="lblTotal">Total </label></strong>
                        <asp:Label ID="lblTotalCuenta" CssClass="form-control" runat="server" Text="Total"
                          ToolTip="Esta es la suma total de todos los pedidos de la mesa"                                                         
                            ></asp:Label><br />
                          <strong><label for="lblTotalUsuario" >Tu subtotal</label></strong>
                        <asp:Label ID="lblTotalUsuario" CssClass="form-control" runat="server" Text="Tu Subtotal" 
                            ToolTip="Esta es la suma de todos los pedidos que fueron realizados exclusivamente por vos"></asp:Label><br />
                        <strong><label for="lblFecha">Fecha y hora:</label></strong>
                        <asp:Label ID="lblFecha" CssClass="form-control" runat="server" Text="Fecha y hora"></asp:Label><br />
                      </div>
                    </div>
                </div>
           </div>   
           <div class="form-row" >
                <div class="form-group col-lg-12" >        
                    <asp:Button ID="btnPagarConMercadoPago" runat="server"  Text="Pagar Con MercadoPago " class="btn btn-primary"   CssClass="hidden"/>
                </div>                
           </div>
           <div class="form-row" >             
                <div class="form-group col-lg-12" >        
                    <div id="divPrueba" runat="server" class="alert alert-warning alert-dismissable" visible="false" >
                        <button type="button" class="close" data-dismiss="alert">&times;</button>
                    <div id="divMensaje" runat="server"></div>           
                    </div>
                </div>
           </div>
       </div>  <!-- dvDetalleCuenta-->
 </div><!-- Container-->
</asp:Content>


 