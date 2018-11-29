<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="nmuro.aspx.cs" Inherits="Mb.Views.Usuario.nuevo.nmuro" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Muro</h1>
        <p class="lead">Comparti lo que quieras con las demas personas del Bar!</p>
    </div>
 <div class="form-horizontal" >
    <div class="form-row" >
    <div class="form-group col-lg-12 " >                
        <label for="txtTitulo">Titulo</label><br />
        <asp:TextBox ID="txtTitulo" runat="server"  CssClass="form-control"  placeholder="Titulo" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtTitulo" Text="*" 
            runat="server" ForeColor="red" ></asp:RequiredFieldValidator>   
    </div>
    <div class="form-group col-lg-12 " >                
        <label for="txtPublicacion">Publicacion</label><br />
        <asp:TextBox ID="txtPublicacion" runat="server" TextMode="MultiLine" CssClass="form-control"  placeholder="Publicacion" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtPublicacion" Text="*" 
            runat="server" ForeColor="red" ></asp:RequiredFieldValidator>         
    </div>
    </div>
    <div class="form-row" >
        <div class="form-group col-lg-12" >  
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" Font-Size="Small" />
        <asp:Button ID="btnCargar" runat="server"  Text="Publicar" class="btn btn-primary" OnClick="btnCargar_Click"  />                              
        <asp:Button ID="btnLimpiar" runat="server"  Text="Limpiar" class="btn btn-secondary" CausesValidation="false" OnClick="btnLimpiar_Click" />
        </div>
        <div class="form-group col-lg-12" >        
            <div id="divPrueba" runat="server" class="alert alert-warning alert-dismissable" visible="false">
                <button type="button" class="close" data-dismiss="alert">&times;</button>
                <div id="divMensaje" runat="server"></div>           
            </div>
        </div>
    </div>
    <div class="form-row" >
        <div class="form-group col-lg-12" >        
            <div class="table-responsive">
                <table class="table">

                </table>
            </div>
        </div>
    </div>
 </div>
    
  
 
</asp:Content>
