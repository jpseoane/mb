<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pedidomesa.aspx.cs" Inherits="Mb.Views.Usuario.pedido" MasterPageFile="~/Site.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Pedidos - Asignación de Mesa</h1>
        <p class="lead">Reserve su mesa ingresando el numero!</p>        
    </div>
<div class="container">
    <div class="row">
        <div class="col-sm-12 col-md-12 col-lg-12">
            <h2>Datos de la mesa</h2>            
        </div>
    </div>
    <div class="form-row" id="dvAsignaMesa" runat="server" visible="false">
       <div lass="form-group col-lg-12" >
            <label for="txtNumeroMesa" >Numero de mesa</label><br />
            <asp:TextBox runat="server" ID="txtNumeroMesa" placeholder="Numero de mesa" required></asp:TextBox>
            <br />
            <asp:LinkButton ID="lnbReservar" runat="server" OnClick="lnbReservar_Click">Asginame a esta Mesa!</asp:LinkButton>
       </div>
        <div class="form-group col-lg-12" >        
            <div id="divPrueba" runat="server" class="alert alert-warning alert-dismissable" visible="false">
            <button type="button" class="close" data-dismiss="alert">&times;</button>
            <div id="divMensaje" runat="server"></div>           
            </div>
        </div>
    </div>
    <div class="form-row" id="dvUsuarioMesa" runat="server" visible="false">
        <div class="form-group col-lg-6" >        
            <div class="panel panel-default">
              <div class="panel-heading">
                <h3 class="panel-title">Datos de tu cuenta:</h3>
              </div>
              <div class="panel-body">
                  <strong><label for="lblMail">Email: </label></strong>
                  <asp:Label ID="lblMail" runat="server" Text="Tu mail"></asp:Label><br />
                  <strong><label for="lblPerfil">Perfil:</label></strong>
                  <asp:Label ID="lblPerfil" runat="server" Text="Tu Perfil"></asp:Label><br />
                  <strong><label for="lblActivo">Activo</label></strong>
                  <asp:CheckBox ID="chkActiva" runat="server" />                    
                  
              </div>
            </div>
        </div>
    </div>
    <div class="form-row" id="dvGrupoMesa" runat="server" visible="false">
        <div class="form-group col-lg-6" >        
            <div class="panel panel-default">
                  <!-- Default panel contents -->
                  <div class="panel-heading">El grupo de tu mesa:</div>
                  <div class="panel-body">
                    <p>Estas personas estan compartiendo con vos la mesa si queres que alguno pueda o no realizar pedidos y ponerlo a cuenta de la mesa puedes confirmar el permiso por medio de la pestaña Amigos!</p>
                  
                  <table class="table">
                    <asp:GridView ID="gvUsuariosEnMesa" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" >
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        <EmptyDataTemplate>
                            <div>
                                   No hay mas usuarios registrados en esta mesa
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                  </table>
              </div>
           </div>
        </div>
    </div>
      
</div>
    
</asp:Content>
