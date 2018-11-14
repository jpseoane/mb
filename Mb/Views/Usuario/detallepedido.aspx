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
               <div class="form-row" >                    
                    <div class="form-group col-lg-12 " >                
                        <!-- GridView-->
                        <asp:GridView ID="gv" runat="server" CellPadding="4" HeaderStyle-HorizontalAlign="Center" 
                                AllowPaging="True" AllowSorting="True" PageSize="5"   CssClass="gridview"
                                AutoGenerateColumns="False" ShowHeader="False" OnRowCommand="gv_RowCommand"  >
                                <EmptyDataRowStyle HorizontalAlign="Center" />
                                <Columns>                                    
                                    <asp:BoundField DataField="usuario" HeaderText="usuario" NullDisplayText="Sin usuario" SortExpression="usuario" >
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Medium" VerticalAlign="Middle" Wrap="True"  />
                                    </asp:BoundField>                          
                                    <asp:BoundField DataField="cantidad" HeaderText="Cant." NullDisplayText="Sin cantidad" SortExpression="cantidad" >
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Medium" VerticalAlign="Middle" Wrap="True"  />
                                    </asp:BoundField>                          
                                    <asp:BoundField  DataField="descripcion" HeaderText="Descripcion" NullDisplayText="descripcion" SortExpression="descripcion" >
                                        <ItemStyle CssClass="izq" Font-Bold="true" Font-Size="Medium" VerticalAlign="Middle" Wrap="True"  />
                                    </asp:BoundField>                                                              
                                    <asp:BoundField DataField="precioUnitario" HeaderText="Precio" NullDisplayText="Sin precio" SortExpression="precioUnitario" >
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Medium" VerticalAlign="Middle" Wrap="True"  />
                                    </asp:BoundField>                          
                                    <asp:BoundField DataField="subtotal" HeaderText="Subtotal" NullDisplayText="Sin subtotal" SortExpression="subtotal" >
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Medium" VerticalAlign="Middle" Wrap="True"  />
                                    </asp:BoundField>                          
                                    <asp:TemplateField HeaderText="Acciones">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgbtnCancelar" causesvalidation="false"  ImageUrl="~/Content/img/mas48.png"
                                                commandname="cancelar" commandargument='<%# Eval("id")%>' Height="48px" Width="48px" 
                                                ToolTip="Se podra cancelar el pedido solo si no empezo a prepararse" />                                           
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Height="25px" Width="25px"/>
                                    </asp:TemplateField>     
                                    </Columns>
                        </asp:GridView>
                        <div class="form-group col-lg-12" >        
                            <asp:Button ID="btnPedirCuenta" runat="server"  Text="Pedir la cuenta" class="btn btn-primary"  ToolTip="Cerrar la mesa y pedir que me traigan la cuenta"  />
                            <asp:Button ID="btnRefrescar" runat="server"  Text="Refrescar" class="btn btn-warning" formnovalidate="" CausesValidation="false" />
                        </div>
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
       </div>  <!-- divCargaDePedido-->
 </div><!-- Container-->
</asp:Content>


 