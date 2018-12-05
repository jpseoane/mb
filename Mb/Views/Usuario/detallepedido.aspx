<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detallepedido.aspx.cs" Inherits="Mb.Views.Usuario.detallepedido" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Detalle Pedido</h1>
        <p class="lead">Fijate en que estado esta tu pedido!</p>
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
        </div>
       <div  id="dvDetallePedido" runat="server"  visible="false" >
              <div class="form-row" style="text-align:right">
                    <div class="form-group col-lg-12" >                    
                                <asp:LinkButton  PostBackUrl="~/Views/Usuario/nuevo/npedido.aspx" runat="server" CssClass="btn btn-toolbar"
                                    CausesValidation="false" >Volver</asp:LinkButton>
                    </div>
               </div>
              <div class="form-row">
                <div class="form-group col-lg-12" >        
                    <div class="panel panel-default">
                      <div class="panel-heading">
                        <h3 class="panel-title">Detalle de pedidos de la mesa N° <strong><b><span runat="server" id="h3Mesa"></span></b></strong></h3>
                      </div>
                      <div class="panel-body">
                          <strong><label for="lblMail">Email: </label></strong>
                          <asp:Label ID="lblMail" runat="server" Text="Tu mail"></asp:Label><br />
                          <strong><label for="lblPerfil">Perfil:</label></strong>
                          <asp:Label ID="lblPerfil" runat="server" Text="Tu Perfil"></asp:Label><br />
                          <strong><label for="lblActivo">Activo</label></strong>
                          <input type="checkbox" runat="server" id="chkActiva" disabled/> <br />
                          <strong><label for="lblTuSubtotal">Tu subtotal hasta el momento:</label></strong><br />     
                          <asp:Label ID="lblSubTotalUsuario" runat="server" ></asp:Label>
                      </div>
                    </div>
                </div>
               </div>
            
               <div class="form-row" >                    
                    <div class="form-group col-lg-12 " >                
                     <%--   <!-- GridView-->
                        <div class="scrolling-table-container">--%>
                            <asp:CheckBox ID="chkVerMisPedidos" runat="server" AutoPostBack="True" ForeColor="#3366CC" OnCheckedChanged="chkVerMisPedidos_CheckedChanged" Text="Ver solo mis pedidos" />
                        <asp:GridView ID="gv" runat="server" HeaderStyle-HorizontalAlign="Center"  DataKeyNames="username"
                                AllowSorting="false"  CssClass="gridview"   AutoGenerateColumns="False" ShowHeader="true" OnRowCommand="gv_RowCommand"  >
                                <EmptyDataRowStyle HorizontalAlign="Center" />
                                <Columns>                                    
                                   <asp:BoundField DataField="userName" HeaderText="Usuario" NullDisplayText="Sin usuario" SortExpression="userName" >
                                        <ItemStyle HorizontalAlign="Center"  Font-Size="Medium" VerticalAlign="Middle" Wrap="True"  />
                                    </asp:BoundField> 
                                    <asp:BoundField DataField="fecha" HeaderText="Fecha" NullDisplayText="Sin fecha" SortExpression="fecha" >
                                        <ItemStyle HorizontalAlign="Center"  Font-Size="Small" VerticalAlign="Middle" Wrap="True"  />
                                    </asp:BoundField>                          
                                    
                                    <asp:BoundField DataField="cantidad" HeaderText="Cant." NullDisplayText="Sin cantidad" SortExpression="cantidad" >
                                        <ItemStyle HorizontalAlign="Center"  Font-Size="Small" VerticalAlign="Middle" Wrap="True"  />
                                    </asp:BoundField>                          
                                    <asp:BoundField  DataField="descriProducto" HeaderText="Descripcion" HeaderStyle-HorizontalAlign="Left" NullDisplayText="descripcion" SortExpression="descriProducto" >
                                        <HeaderStyle CssClass="izq" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="izq" Font-Bold="true" Font-Size="Small" VerticalAlign="Middle" Wrap="True"  />
                                    </asp:BoundField>                          
                                    
                                    <asp:BoundField DataField="precioUnitario" HeaderText="Precio" NullDisplayText="Sin precio" SortExpression="precioUnitario" >
                                        <ItemStyle HorizontalAlign="Center"  Font-Size="Small" VerticalAlign="Middle" Wrap="True"  />
                                    </asp:BoundField>                          
                                   <%-- <asp:BoundField DataField="subtotal" HeaderText="Subtotal" NullDisplayText="Sin subtotal" SortExpression="subtotal" >
                                        <ItemStyle HorizontalAlign="Center"  Font-Size="Medium" VerticalAlign="Middle" Wrap="True"  />
                                    </asp:BoundField>  --%>                        
                                    
                                    <asp:BoundField DataField="descriEstadoPedido" HeaderText="Estado" NullDisplayText="Sin descriEstadoPedido" SortExpression="descriEstadoPedido" >
                                        <ItemStyle HorizontalAlign="Center" Font-Size="Medium" VerticalAlign="Middle" Wrap="True"  />
                                    </asp:BoundField>                          
                                    <asp:TemplateField HeaderText="Acciones">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgbtnCancelar" causesvalidation="false"  ImageUrl="~/Content/img/del.png"
                                                commandname="cancelar" commandargument='<%# Eval("id")%>' Height="24px" Width="24px" 
                                                ToolTip="Se podra cancelar el pedido solo si no empezo a prepararse" />                                           
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Height="25px" Width="25px"/>
                                    </asp:TemplateField>     
                                    </Columns>
           
                        </asp:GridView>
                       <%-- </div>--%>
                    </div>
                   <div class="form-group col-lg-12" >        
                       <div class="text-right">
                           
                           <asp:Label ID="lblTotal" runat="server" ></asp:Label> <br />
                          <strong> <asp:Label ID="lblTuSubtotal" runat="server" ></asp:Label></strong>
                       </div>    
                       <div class="text-right">
                            <asp:Button ID="btnCerrarCuenta" runat="server" CssClass="btn btn-primary"  Text="Cerrar cuenta" OnClick="btnCerrarCuenta_Click" />
                       </div>    
                   </div>
              </div>
               <div class="form-row" >             
                   <div class="form-group col-lg-12" >        
                        <div id="divPrueba" runat="server" class="alert alert-warning alert-dismissable" visible="false" >
                            <button type="button" name="boton" class="close" data-dismiss="alert" >&times;</button>
                            <div id="divMensaje" runat="server"></div>           
                        </div>
                   </div>
             </div>
     
           
           

       </div>  <!-- divCargaDePedido-->
 </div><!-- Container-->
</asp:Content>


 