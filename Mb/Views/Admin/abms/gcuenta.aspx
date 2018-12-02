<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gcuenta.aspx.cs" Inherits="Mb.Views.Admin.abms.gcuenta" MasterPageFile="~/Site.Master" %>


 <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="jumbotron">
        <h1>Administracion de cuenta</h1>
        <p class="lead">Gestionar las cuentas</p>
    </div>
    <div class="Container" >
       <div class="form-row">
                 <div class="form-group col-lg-4 " >                
                        <label for="ddlMesa">Mesa N°</label> 
                        <asp:DropDownList ID="ddlMesa" runat="server" CssClass="form-control"
                            DataTextField="descripcion" DataValueField="ID" AutoPostBack="true" ></asp:DropDownList>                                
                 </div>           
                 <div class="form-group col-lg-4 " >                
                        <label for="ddlEstadoDeCuenta">Estado De Cuenta</label> 
                        <asp:DropDownList ID="ddlEstadoDeCuenta" runat="server" CssClass="form-control"
                            DataTextField="descripcion" DataValueField="ID" AutoPostBack="true" ></asp:DropDownList>                                
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
            <div class="form-row" >             
                   <div class="form-group col-lg-12" >        
                        <div id="divPrueba" runat="server" class="alert alert-warning alert-dismissable" visible="false" >
                            <button type="button" class="close" data-dismiss="alert">&times;</button>
                        <div id="divMensaje" runat="server"></div>           
                        </div>
                    </div>
                </div>   
            </div>
      </div>
       <!-- GridView-->
       <div class="form-row">
            <div class="form-group col-lg-12" >        
                <asp:GridView ID="gv" runat="server" CellPadding="4" HeaderStyle-HorizontalAlign="Center" 
                    AllowPaging="True" AllowSorting="false" PageSize="15"  CssClass="gridview" DataKeyNames="numeroMesa"
                    ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gv_RowCommand" OnRowDataBound="gv_RowDataBound" >
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
                    <asp:BoundField DataField="numeroMesa" HeaderText="N° Mesa" NullDisplayText="numeroMesa" SortExpression="numeroMesa" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                              
                    <asp:BoundField DataField="email" HeaderText="Usuario" NullDisplayText="email" SortExpression="email" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                          
                    <asp:BoundField DataField="estado_descri" HeaderText="Estado Cuenta" NullDisplayText="estado_descri" SortExpression="estado_descri" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                          
                    <asp:BoundField DataField="total" HeaderText="Total" NullDisplayText="total" SortExpression="total" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="fecha" HeaderText="Fecha" NullDisplayText="fecha" SortExpression="fecha" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                          
                        <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:Button  ID="btnCerrar" runat="server"  CommandName="cerrar"  Text="Cerrar"  Visible="false" Commandargument='<%# Eval("id")%>'
                                        CausesValidation="false" ToolTip="Cerrar mesa" />

                                    <asp:Button  ID="btnEnviarAcobrar" runat="server"  CommandName="EnviarAcobrar" Text="Cobrar"  Visible="false"  Commandargument='<%# Eval("id")%>'
                                        CausesValidation="false" ToolTip="Envio a cobrar" />
                                    
                                    
                                  </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"  Width="50px"/>
                                <HeaderStyle HorizontalAlign="Center"  Width="50px" />
                         </asp:TemplateField>
                        </Columns>
                </asp:GridView>
              </div>
       </div>
    </div>
     </div>
</asp:Content>
