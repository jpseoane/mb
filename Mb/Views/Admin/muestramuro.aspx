<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="muestramuro.aspx.cs" Inherits="Mb.Views.Admin.muestramuro" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<meta http-equiv="refresh" content="5" />--%>
    <div class="jumbotron">
        <h1>Muro</h1>
        <p class="lead">Mira lo que comparten las mesas en este momento!!!</p>
    </div>
    <div class="form-row" >    
         <div class="form-group col-lg-12" >        
                  <asp:Repeater ID="Repeater1" runat="server"   >
                    <HeaderTemplate>
                       <h3 class="panel-title"><strong>Usuarios del bar Compartiendo sus momentos!!!</strong></h3>
                        <br />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="row">
                              <div class="panel-heading">
                                    <h3 class="panel-title"><strong>Usuario: <span> <%# Eval("email") %> </span> - Mesa N°:<span> <%# Eval("nummesa") %></span></strong></h3>
                              </div>
                              <div class="col-lg-12 col-sm-6 col-md-4">
                                <div class="thumbnail" style="background-color:#f7fbff; margin: 60px;padding: 50px;">
                                    <asp:Image runat="server" ImageUrl='<%#"~/Content/imgSub/"+Eval("nombrefoto") %>'  alt="ImagenMesa"  Visible='<%# Eval("confoto") %>'  />
                                  <div class="caption">
                                        <h3><%# Eval("titulo") %></h3>
                                        <p><%# Eval("mensaje") %></p>
                                      <hr />
                                    <strong><label for="lblFecha">Fecha: </label></strong><br />
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("fecha") %>' ></asp:Label>
                                  </div>
                                </div>
                              </div>
                        </div>
                        <br />
                        <div>
                            <hr />
                        </div>
                    </ItemTemplate>
                 <%--   <AlternatingItemTemplate>
                       <div class="row">
                              <div class="panel-heading">
                                 <h3 class="panel-title"><strong>Usuario: <span> <%# Eval("email") %> </span> - Mesa N°:<span> <%# Eval("nummesa") %></span></strong></h3>
                              </div>
                              <div class="col-lg-12 col-sm-6 col-md-4">
                                <div class="thumbnail">
                                    <asp:Image runat="server" ImageUrl='<%#"~/Content/imgSub/"+Eval("nombrefoto") %>'  alt="ImagenMesa"  Visible='<%# Eval("confoto") %>'  />
                                  <div class="caption">
                                        <h3><%# Eval("titulo") %></h3>
                                        <p><%# Eval("mensaje") %></p>
                                      <hr />
                                    <strong><label for="lblFecha">Fecha: </label></strong><br />
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("fecha") %>' ></asp:Label>
                                  </div>
                                </div>
                              </div>
                        </div>
                    </AlternatingItemTemplate>--%>
                    <FooterTemplate>
                    </FooterTemplate>
                  </asp:Repeater>
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
