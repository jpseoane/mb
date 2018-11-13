<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cuenta.aspx.cs" Inherits="Mb.Views.Usuario.cuenta"  MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Cuenta</h1>
        <p class="lead">Detalle de la cuenta para la mesa</p>
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
       <div  id="dvCargaProducto" runat="server"  visible="false" >
               <div class="form-row" >
                    <div class="form-group col-lg-12" >        
                        <asp:Button ID="btnBuscar" runat="server"  Text="Buscar" class="btn btn-primary" OnClick="btnBuscar_Click"  />
                        <asp:Button ID="btnLimpiar" runat="server"  Text="Limpiar" class="btn btn-warning" formnovalidate="" CausesValidation="false" />
                    </div>
                    <div class="form-group col-lg-12 " >                
                        <!-- GridView-->
                        <asp:GridView ID="gv" runat="server" CellPadding="4" HeaderStyle-HorizontalAlign="Center" 
                                AllowPaging="True" AllowSorting="True" PageSize="5"   CssClass="gridview"
                                AutoGenerateColumns="False" ShowHeader="False" OnRowCommand="gv_RowCommand" >
                                <EmptyDataRowStyle HorizontalAlign="Center" />
                                <Columns>                                    
                                    <asp:BoundField  DataField="descripcion" HeaderText="Descripcion" NullDisplayText="descripcion" SortExpression="descripcion" >
                                        <ItemStyle CssClass="izq" Font-Bold="true" Font-Size="Medium" VerticalAlign="Middle" Wrap="True"  />
                                    </asp:BoundField>                          
                                    <asp:BoundField DataField="precioUnitario" HeaderText="Precio" NullDisplayText="Sin precio" SortExpression="precioUnitario" >
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Medium" VerticalAlign="Middle" Wrap="True"  />
                                    </asp:BoundField>                          
                                    <asp:TemplateField HeaderText="Acciones">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgbtnAgregar" causesvalidation="false"  ImageUrl="~/Content/img/mas48.png"
                                                commandname="agregar" commandargument='<%# Eval("id")%>' Height="48px" Width="48px" 
                                                ToolTip="Agregar a mi carrito" />                                           
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Height="25px" Width="25px"/>
                                    </asp:TemplateField>     
                                    </Columns>
                        </asp:GridView>
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


 