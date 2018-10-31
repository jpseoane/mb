<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="muro.aspx.cs" Inherits="Mb.Views.Usuario.muro"  MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Muro</h1>
        <p class="lead">Comparti lo que quieras con las demas personas del Bar!</p>
    </div>
    <div class="form-row" >
    <div class="form-group col-lg-12 " >                
        <label for="txtPublicacion">Publicacion</label><br />
        <asp:TextBox ID="txtPublicacion" runat="server" Width="605px" CssClass="form-control"  placeholder="Descripción" Height="42px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDescri" Text="*" 
            runat="server" ForeColor="red" ></asp:RequiredFieldValidator>            
    </div>
    </div>
    <div class="form-group col-lg-12" >        
    <asp:Button ID="btnBuscar" runat="server"  Text="Publicar" class="btn btn-primary" CausesValidation="false" />                              
    <asp:Button ID="btnActualizar" runat="server"  Text="Actualizar" class="btn btn-secondary" />
    </div>
    <div class="form-group col-lg-12" >        
        <div id="divPrueba" runat="server" class="alert alert-warning alert-dismissable" visible="false">
            <button type="button" class="close" data-dismiss="alert">&times;</button>
            <div id="divMensaje" runat="server"></div>           
        </div>
    </div>     
  
 
</asp:Content>
