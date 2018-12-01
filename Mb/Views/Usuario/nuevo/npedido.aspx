<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="npedido.aspx.cs" Inherits="Mb.Views.Usuario.pedidos.nuevo.npedido"  MasterPageFile="~/Site.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Generar Pedido</h1>
        <p class="lead">Cargar productos para que me entreguen en la mesa</p>
    </div>
 <div class="container">
   <div>     
           <!-- dvMensajeCambio-->
           <div class="form-row"   id="dvMensajeCambio" runat="server"  visible="false" >
               <div class="col-md-12 col-lg-12">
                    <div class="alert alert-info alert-dismissible " role="alert">
                       <h3 runat="server" id="h3">No tenes asignada una mesa</h3>
                       <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                       <asp:Label  id="lblMensaje" runat="server" Text=""></asp:Label>
                        <a href="asignamesa.aspx" class="alert-link">Ir a Mesa!</a>                
                    </div>
               </div>
           </div>
       <div  id="dvCargaProducto" runat="server"  visible="false" >
               <div class="form-row" style="text-align:right">
                    <div class="form-group col-lg-12" >                    
                                <asp:LinkButton  PostBackUrl="~/Views/Usuario/detallepedido.aspx" runat="server" CssClass="btn btn-toolbar"
                                    CausesValidation="false" >Detalle del pedido</asp:LinkButton>
                    </div>
               </div>
               <div class="form-row" >
                    <div class="form-group col-lg-4" >        
                        <label for="ddlCarta">Carta</label><br />
                        <asp:DropDownList ID="ddlCarta" CssClass="form-control"  runat="server" ></asp:DropDownList>            
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddlCarta" Text="Eliga una carta!" ErrorMessage="Eliga una carta!" InitialValue="0"
                            runat="server" ForeColor="red" ></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-lg-4" >        
                        <label for="ddlTipo">Tipo</label><br />
                        <asp:DropDownList ID="ddlTipo" CssClass="form-control"  runat="server" ></asp:DropDownList>           
                  
                    </div>
                    <div class="form-group col-lg-4" >        
                        <label for="ddlSubTipo">SubTipo</label><br />
                        <asp:DropDownList ID="ddlSubTipo" CssClass="form-control"  runat="server"  ></asp:DropDownList> 
                    </div>
               </div>
               <div class="form-row" >                    
                    <div class="form-group col-lg-4 " >                
                        <label for="txtPrecio">Precio</label><br />
                        <asp:TextBox ID="txtPrecio" CssClass="form-control" TextMode="Number"  runat="server" placeholder="Precio"></asp:TextBox>
                    </div>          
                   <div class="form-group col-lg-4 " >                
                        <label for="txtDescri">Descripción</label><br />
                        <asp:TextBox ID="txtDescri" runat="server" TextMode="MultiLine" CssClass="form-control"  placeholder="Descripción"></asp:TextBox>
                    </div>        
                </div>
               <div class="form-row" >
                    <div class="form-group col-lg-12" >        
                        <asp:Button ID="btnBuscar" runat="server"  Text="Buscar" class="btn btn-primary" OnClick="btnBuscar_Click"  />
                        <asp:Button ID="btnLimpiar" runat="server"  Text="Limpiar" class="btn btn-warning" formnovalidate="" CausesValidation="false" />
                    </div>
                    <div class="form-group col-lg-12 " >                
                        <!-- GridView-->                        
                        <asp:GridView ID="gv" runat="server" HeaderStyle-HorizontalAlign="Center" 
                                AllowPaging="True" AllowSorting="false" PageSize="10"   CssClass="gridview" DataKeyNames="precioUnitario"
                                AutoGenerateColumns="False" ShowHeader="False" OnRowCommand="gv_RowCommand" >
                                <EmptyDataRowStyle HorizontalAlign="Center" />
                                <Columns>                                    
                                    <asp:BoundField  DataField="descripcion" HeaderText="Descripcion" NullDisplayText="descripcion" SortExpression="descripcion" >
                                        <ItemStyle CssClass="izq" Font-Bold="true" Font-Size="Medium" VerticalAlign="Middle" Wrap="True"  />
                                    </asp:BoundField>                          
                                    <asp:BoundField DataField="precioUnitario" HeaderText="Precio" NullDisplayText="Sin precio" SortExpression="precioUnitario" >
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" Font-Size="Medium" VerticalAlign="Middle" Wrap="True"  />
                                    </asp:BoundField>                        
                                    <asp:TemplateField HeaderText="Cantidad">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCantidad" CssClass="form-control" TextMode="Number" ToolTip="Ingrese la cantidad deseada del producto" CausesValidation="false"  Width="30%" runat="server">1</asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="50%" />
                                     </asp:TemplateField>
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
                            <div id="divMensaje" runat="server"></div>           
                        </div>
                    </div>
                </div>
       </div>  <!-- divCargaDePedido-->
    </div>     <!-- form-Horizontal-->
 </div><!-- Container-->
</asp:Content>


 