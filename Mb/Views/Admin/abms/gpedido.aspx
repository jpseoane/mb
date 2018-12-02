<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gpedido.aspx.cs" Inherits="Mb.Views.Admin.abms.gpedido" MasterPageFile="~/Site.Master" %>


 <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="jumbotron">
        <h1>Gestion de los pedidos</h1>
        <p class="lead">Administracion de los pedidos del bar. Actualice los estados de los pedidos por mesa</p>
    </div>
    <div class="Container" >
       <div class="form-row">
                 <div class="form-group col-lg-4 " >                
                        <label for="ddlMesa">Mesa</label> 
                        <asp:DropDownList ID="ddlMesa" runat="server" CssClass="form-control"
                            DataTextField="descripcion" DataValueField="ID" AutoPostBack="true" ></asp:DropDownList>                                
                 </div>           
                 <div class="form-group col-lg-4 " >                
                        <label for="ddlEstadoPedido">Estado Pedido</label> 
                        <asp:DropDownList ID="ddlEstadoPedido" runat="server" CssClass="form-control"
                            DataTextField="descripcion" DataValueField="ID" AutoPostBack="true" >
                                <asp:ListItem Value="S">Seleccionar</asp:ListItem>
                                <asp:ListItem Value="1">Encargado</asp:ListItem>
                                <asp:ListItem Value="2">En preparación</asp:ListItem>
                                <asp:ListItem Value="3">Entregado</asp:ListItem>
                                <asp:ListItem Value="4">Padido de Cuenta</asp:ListItem>
                                <asp:ListItem Value="5">Recibido y pagado</asp:ListItem>
                        </asp:DropDownList>                                
                 </div>           
       </div>
       <div class="form-row">
           <div class="form-group col-lg-12" >        
               <asp:Button ID="btnListar" runat="server"  Text="Listar" class="btn btn-primary" OnClick="btnListar_Click" />
               <asp:Button ID="btnLimpiar" runat="server"  Text="Limpiar" class="btn btn-warning" formnovalidate="" CausesValidation="false" OnClick="btnLimpiar_Click" />
           </div>
       </div>            
        <div class="form-row">
           <div class="form-group col-lg-12" >        
               <asp:Button ID="btnActualizarEstado" runat="server"  Text="Actualizar Estado de los pedidos" class="btn btn-primary" OnClick="btnActualizarEstado_Click" />
            </div>
        </div>
       <div class="form-row">
           <div class="form-group col-lg-12" >        
            <div id="div1" runat="server" class="alert alert-warning alert-dismissable" visible="false">
            <button type="button" class="close" data-dismiss="alert">&times;</button>
            <div id="div2" runat="server">
            </div>           
            </div>
      </div>
       <!-- GridView-->
       <div class="form-row">
            <div class="form-group col-lg-12" >        
                <asp:GridView ID="gv" runat="server" CellPadding="4" HeaderStyle-HorizontalAlign="Center" 
                    AllowPaging="True" AllowSorting="True"  CssClass="gridview" DataKeyNames="id"
                    ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowDataBound="gv_RowDataBound" OnPageIndexChanging="gv_PageIndexChanging" OnSorting="gv_Sorting" OnRowCommand="gv_RowCommand" >
                    <RowStyle Height="50px" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Height="50px" />
                    <EditRowStyle BackColor="#999999" Height="50px" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"  Height="50px" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    <Columns>
                    <asp:BoundField DataField="fecha" HeaderText="Fecha" NullDisplayText="fecha" SortExpression="fecha" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                                <asp:Button  ID="btnPreparandose" runat="server"  CommandName="preparandose"  Text="Preparacion" Visible="false" Commandargument='<%# Eval("id")%>'
                                    CausesValidation="false" ToolTip="Pasar este pedido al estado de 'Preparandose'" />

                                <asp:Button  ID="btnEntregado" runat="server"  CommandName="entregado" Text="Entregado"  Visible="false"  Commandargument='<%# Eval("id")%>'
                                    CausesValidation="false" ToolTip="Pasar este pedido al estado de 'Entregado'" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"  />
                        <HeaderStyle HorizontalAlign="Center"  />
                    </asp:TemplateField>
                    <asp:BoundField DataField="numeroMesa" HeaderText="N° Mesa" NullDisplayText="N°  Mesa" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  />
                    </asp:BoundField>                              
                    <asp:BoundField DataField="email" HeaderText="usuario" NullDisplayText="Email"  >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  />
                    </asp:BoundField>                          
                     <asp:BoundField DataField="id" HeaderText="N° Pedido" NullDisplayText="N° Pedido"  >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                    </asp:BoundField>                          
                    <asp:BoundField DataField="descriProducto" HeaderText="Descripcion Pedido" NullDisplayText="descriPedido"  >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  />
                    </asp:BoundField>                          
                    <asp:BoundField DataField="descriEstadoPedido" HeaderText="Estado Pedido" NullDisplayText="estadoPedido"  >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  />
                    </asp:BoundField>                          
                    <asp:BoundField DataField="precioUnitario" HeaderText="Precio" NullDisplayText="Precio"  >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                    </asp:BoundField>                    
                  </Columns>
                </asp:GridView>
              </div> 
       </div>
    </div>
     </div>
</asp:Content>
