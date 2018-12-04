<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vermuro.aspx.cs" Inherits="Mb.Views.Usuario.nuevo.vermuro" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Muro</h1>
        <p class="lead">Mira lo que comparten las mesas en este momento!!!</p>
    </div>
    <div class="form-row" >    
        <div class="form-group col-lg-12 text-right" >        
            <asp:Button ID="btnActualizar" runat="server"  Text="Actualizar" class="btn btn-secondary" OnClick="btnActualizar_Click" />
        </div>
         <div class="form-group col-lg-12" >        
                  <asp:Repeater ID="Repeater1" runat="server"   >
                    <HeaderTemplate>
                        <div class="page-header">
                            <h1>¡Usuarios del bar Compartiendo!<small> Mira en vivo lo que estan compartiendo la gente del Bar</small></h1>
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="panel panel-primary"> 
                            <div class="panel-heading"> 
                                <h3 class="panel-title"><strong><span class="text-capitalize" >Publicación de la Mesa :  <%# Eval("numMesa") %></span> </span></strong></h3>
                            </div> 
                            <div class="panel-body">
                               <strong><label style="font-size: larger;" >Titulo: </label></strong><span> <%# Eval("titulo") %></span>
                                <br />
                                <br />
                                <br />
                                 <center><asp:Image runat="server" ImageUrl='<%#"~/Content/imgSub/"+Eval("nombrefoto") %>'  alt="ImagenMesa"  Visible='<%# Eval("confoto") %>'   /></center>
                             
                                <blockquote>
                                  <p> <%# Eval("mensaje") %></p>
                                  <footer>Dice: <cite title="Source Title"> <%# Eval("email") %></cite></footer>
                                </blockquote>
                              </div>
                              <div class="panel-footer">
                                  <strong><label for="lblFecha">Fecha: </label></strong><br />
                                  <asp:Label ID="Label1" runat="server" Text='<%# Eval("fecha") %>' ></asp:Label>
                              </div>
                        </div>
                        <br />
                        <div>
                            <hr />
                        </div>
                    </ItemTemplate>
                   <AlternatingItemTemplate>
                         <div class="panel panel-info"> 
                            <div class="panel-heading"> 
                                <h3 class="panel-title"><strong><span class="text-capitalize" >Publicación de la Mesa :  <%# Eval("numMesa") %></span> </span></strong></h3>
                            </div> 
                            <div class="panel-body">
                                <strong><label style="font-size: larger;" >Titulo: </label></strong><span> <%# Eval("titulo") %></span>
                                <br />
                                <br />
                                <br />
                                 <center><asp:Image runat="server" ImageUrl='<%#"~/Content/imgSub/"+Eval("nombrefoto") %>'  alt="ImagenMesa"  Visible='<%# Eval("confoto") %>'  /></center>
                             
                                <blockquote>
                                  <p> <%# Eval("mensaje") %></p>
                                  <footer>Dice: <cite title="Source Title"> <%# Eval("email") %></cite></footer>
                                </blockquote>
                              </div>
                              <div class="panel-footer">
                                  <strong><label for="lblFecha">Fecha: </label></strong><br />
                                  <asp:Label ID="Label2" runat="server" Text='<%# Eval("fecha") %>' ></asp:Label>
                              </div>
                        </div>
                        <br />
                        <div>
                            <hr />
                        </div>
                     
                    </AlternatingItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                  </asp:Repeater>
       </div>
    </div>
    
    <div class="form-group col-lg-12" >        
        <div id="divPrueba" runat="server" class="alert alert-warning alert-dismissable" visible="false">
            <button type="button" class="close" data-dismiss="alert">&times;</button>
            <div id="divMensaje" runat="server"></div>           
        </div>
    </div>     
  
 
</asp:Content>
