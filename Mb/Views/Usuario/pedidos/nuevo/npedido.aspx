<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="npedido.aspx.cs" Inherits="Mb.Views.Usuario.pedidos.nuevo.npedido"  MasterPageFile="~/Site.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Generar Pedido</h1>
        <p class="lead">Cargar productos para que me entreguen en la mesa</p>
    </div>
  <div class="container">
    <div class="form-horizontal">
       <div class="form-row" id="dvUsuarioMesa" runat="server" visible="false">
            <div class="form-group col-lg-6" >        
                <div class="panel panel-default">
                  <div class="panel-heading">
                    <h3 class="panel-title">Datos de tu cuenta:</h3>
                  </div>
                  <div class="panel-body">
                      <strong><label for="lblMail">Email: </label></strong>
                      <asp:Label ID="lblMail" runat="server" Text="Tu mail"></asp:Label><br />
                      <strong><label for="lblPerfil">Perfil:</label></strong>
                      <asp:Label ID="lblPerfil" runat="server" Text="Tu Perfil"></asp:Label><br />
                      <strong><label for="lblActivo">Activo</label></strong>
                      <asp:CheckBox ID="chkActiva" runat="server" />                    
                  
                  </div>
                </div>
            </div>
       </div>
       <div class="form-row" >
            <div class="col-md-12 col-lg-12"  id="dvMensajeCambio" runat="server" >
                <div class="alert alert-info alert-dismissible " role="alert">
                   <h3>No tenes asignada una mesa</h3>
                   <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                   <asp:Label  id="lblMensaje" runat="server" Text=""></asp:Label>
                    <a href="../asignamesa.aspx" id="aCambioMesa" runat="server" class="alert-link" visible="false">Elegir Mesa!</a>                
                </div>
           </div>
       </div>
       <div class="form-row" >
            <div class="form-group col-lg-4" >        
                <label for="ddlTipo">Tipo</label><br />
                <asp:DropDownList ID="ddlTipo" CssClass="form-control"  runat="server"></asp:DropDownList>            
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlTipo" Text="*" 
                    runat="server" ForeColor="red" ></asp:RequiredFieldValidator>
            </div>
            <div class="form-group col-lg-4" >        
                <label for="ddlSubTipo">SubTipo</label><br />
                <asp:DropDownList ID="ddlSubTipo" CssClass="form-control"  runat="server"></asp:DropDownList>            
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="ddlSubTipo" Text="*" 
                    runat="server" ForeColor="red" ></asp:RequiredFieldValidator>
            </div>
            <div class="form-group col-lg-4" >        
                <label for="ddlProducto">Producto</label><br />
                <asp:DropDownList ID="ddlProducto" CssClass="form-control"  runat="server"></asp:DropDownList>            
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddlProducto" Text="*" 
                    runat="server" ForeColor="red" ></asp:RequiredFieldValidator>
            </div>
       </div>
        
        <div class="form-row" >
            <div class="form-group col-lg-6 " >                
                <label for="txtDescri">Descripción</label><br />
                <asp:TextBox ID="txtDescri" runat="server" TextMode="MultiLine" CssClass="form-control"  placeholder="Descripción"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDescri" Text="*" 
                    runat="server" ForeColor="red" ></asp:RequiredFieldValidator>            
            </div>        
            <div class="form-group col-lg-6 " >                
                <label for="txtPrecio">Precio</label><br />
                <asp:TextBox ID="txtPrecio" CssClass="form-control"  runat="server" Width="180px" placeholder="Precio"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPrecio" Text="*" 
                    runat="server" ForeColor="red" ></asp:RequiredFieldValidator>
            </div>          
        </div>
        <div class="form-row" >
            <div class="form-group col-lg-12" >        
                <asp:Button ID="btnCargar" runat="server"  Text="Cargar" class="btn btn-primary" OnClick="btnCargar_Click"  />                              
                <asp:Button ID="btnLimpiar" runat="server"  Text="Limpiar" class="btn btn-secondary" CausesValidation="false" OnClick="btnLimpiar_Click"  />
            </div>
        </div>
        <div class="form-row" >
            <div class="form-group col-lg-12" >        
                <div id="divPrueba" runat="server" class="alert alert-warning alert-dismissable" visible="false">
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                <div id="divMensaje" runat="server"></div>           
            </div>
        </div>
 
    </div>
</div>     
    <!-- GridView-->
    <div class="form-row">
        <div class="form-group col-lg-6" style="text-align:center; " >        
            <asp:GridView ID="gv" runat="server" CellPadding="4" HeaderStyle-HorizontalAlign="Center" 
                AllowPaging="True" AllowSorting="True" PageSize="5"  
                ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" >
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" Height="50px" HorizontalAlign="Center" />
                <Columns>
                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" NullDisplayText="descripcion" SortExpression="descripcion" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                          
                    <asp:BoundField DataField="activa" HeaderText="Activa" NullDisplayText="activa" SortExpression="activa" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                          
                    <asp:BoundField DataField="precio" HeaderText="precio" NullDisplayText="Sin precio" SortExpression="precio" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                          
                    <asp:BoundField DataField="tipo" HeaderText="tipo" NullDisplayText="Sin tipo" SortExpression="tipo" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                          
                    <asp:BoundField DataField="Subtipo" HeaderText="Subtipo" NullDisplayText="Subtipo" SortExpression="Subtipo" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                          
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" causesvalidation="false"  ImageUrl="~/Content/img/edit.png"
                                commandname="editar" commandargument='<%# Eval("id")%>' Height="24px" Width="24px" 
                                ToolTip="Editar carta" />
                            <asp:ImageButton id="imgbtnBorrar" runat="server" CausesValidation="false"    
                                CommandName="eliminar" CommandArgument='<%#Eval("id")%>'
                                ImageUrl="~/Content/img/del.png" ToolTip="Eliminar Carta" Height="24px" Width="24px"  />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" Font-Size="Smaller"  BorderStyle="None"  BorderWidth="5px"/>
                        <HeaderStyle Width="50px" />
                    </asp:TemplateField>     
                    </Columns>
                <EditRowStyle BackColor="#999999" Height="50px" HorizontalAlign="Center" />
                <EmptyDataRowStyle HorizontalAlign="Center" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"  Height="50px" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle Height="50px" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" HorizontalAlign="Center" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" HorizontalAlign="Center" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" HorizontalAlign="Center" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" HorizontalAlign="Center" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" HorizontalAlign="Center" />
            </asp:GridView>
        </div>
    </div>
 </div>
</asp:Content>


 