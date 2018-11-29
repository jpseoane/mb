<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="muestramuro.aspx.cs" Inherits="Mb.Views.Admin.muestramuro" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Muro</h1>
        <p class="lead">Mira lo que comparten las mesas en este momento!!!</p>
    </div>
    <div class="form-row" >    
         <div class="form-group col-lg-12" >        
                  <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                    <HeaderTemplate>
                      <div class="panel panel-default">
                      <div class="panel-heading">
                        <h3 class="panel-title"><strong>Muro del bar!.....contanos de donde sos y con quien estas!!</strong></h3>
                      </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                          <div class="panel-body" style="background-color:aliceblue">
                                <strong><label for="lblTitulo">Soy: </label></strong>
                                <asp:Label ID="Label3" CssClass="form-control" runat="server" Text='<%# Eval("email") %>' ></asp:Label><br />
                                <strong><label for="lblTitulo">Titulo: </label></strong>
                                <asp:Label ID="lblTitulo" CssClass="form-control" runat="server" Text='<%# Eval("titulo") %>' ></asp:Label><br />
                                <strong><label for="lblMensaje">Mensaje: </label></strong>
                                <asp:Label ID="lblMensaje" CssClass="form-control" runat="server" Text='<%# Eval("mensaje") %>' ></asp:Label><br />
                                <hr />
                                <strong><label for="lblFecha">Fecha: </label></strong>
                                <asp:Label ID="lblFecha" CssClass="form-control" runat="server" Text='<%# Eval("fecha") %>' ></asp:Label><br />
                          </div>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                          <div class="panel-body" style="background-color:azure">
                                <strong><label for="lblTitulo">Soy: </label></strong>
                                <asp:Label ID="Label3" CssClass="alert-info" runat="server" Text='<%# Eval("email") %>' ></asp:Label><br />
                                <strong><label for="lblTitulo">Titulo: </label></strong>
                                <asp:Label ID="lblTitulo" CssClass="form-control" runat="server" Text='<%# Eval("titulo") %>' ></asp:Label><br />
                                <strong><label for="lblMensaje">Mensaje: </label></strong>
                                <asp:Label ID="lblMensaje" CssClass="form-control" runat="server" Text='<%# Eval("mensaje") %>' ></asp:Label><br />
                                <hr />
                                <strong><label for="lblFecha">Fecha: </label></strong>
                                <asp:Label ID="lblFecha" CssClass="form-control" runat="server" Text='<%# Eval("fecha") %>' ></asp:Label><br />
                          </div>
                    </AlternatingItemTemplate>
                    <FooterTemplate>
                      </table>
                    </FooterTemplate>
                  </asp:Repeater>
                  <asp:SqlDataSource ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                    ID="SqlDataSource1" runat="server" SelectCommand="SELECT [UserId], [titulo], [mensaje],[fecha]
                        ,apu.Email email, apu.UserName username FROM [MensajeMuro] mm INNER JOIN AspNetUsers apu ON mm.UserId = apu.Id"></asp:SqlDataSource>
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
