<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cuenta.aspx.cs" Inherits="Mb.Views.Usuario.cuenta"  MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
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
                        <h3 class="panel-title">Detalle de la cuenta solicitada para la mesa N° <strong><b><span runat="server" id="Span1"></span></b></strong></h3>
                      </div>
                      <div class="panel-body">
                        <strong><label for="lblUsuario">Uuario que solicita la cuenta: </label></strong>
                        <asp:Label ID="lblUsuario" CssClass="form-control" runat="server" Text="Usuario"></asp:Label><br />
                        <strong><label for="lblEstadoCuenta">Estado de la cuenta:</label></strong>
                        <asp:Label ID="lblFecha" CssClass="form-control" runat="server" Text="Fecha"></asp:Label><br />
                        <strong><label for="lblTotal">Total</label></strong>
                        <asp:Label ID="lblTotalCuenta" CssClass="form-control" runat="server" Text="Total"></asp:Label><br />
                      </div>
                    </div>
                </div>
           </div>   
           <div class="form-row" >
                <div class="form-group col-lg-12" >        
                    <asp:Button ID="btnPagar" runat="server"  Text="Pagar con MercadoPago" class="btn btn-primary" />
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


 