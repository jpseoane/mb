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
        <label for="txtComentario">Comentario</label><br />
        <asp:TextBox ID="txtComentario" runat="server" TextMode="MultiLine" CssClass="form-control"  placeholder="Comentario" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtComentario" Text="*" 
            runat="server" ForeColor="red" ></asp:RequiredFieldValidator>            
    </div>
    </div>
    <div class="form-row" >
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
    </div>
    <div class="form-row" >
        <div class="form-group col-lg-12" >        
            <asp:Table ID="tbComentarios" runat="server">

            </asp:Table>
        </div>
    </div>
 </div>
    
  
 
</asp:Content>
