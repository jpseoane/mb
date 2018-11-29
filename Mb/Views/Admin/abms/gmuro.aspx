<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gmuro.aspx.cs" Inherits="Mb.Views.Usuario.gmuro" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Gestion del Muro</h1>
        <p class="lead">Hace un seguimiento de lo que esta posteando la gente del bar y deshabilitar si es necesario!</p>
    </div>
     <div class="form-row">
            <div class="form-group col-lg-4" >        
                <label for="ddlEstado">Estado</label><br />
                <asp:DropDownList ID="ddlEstado" CssClass="form-control"  runat="server">
                    <asp:ListItem Selected="True" Text="Filtro Estado" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Cargado" Value="1" ></asp:ListItem>
                    <asp:ListItem Text="Aprobado" Value="2" ></asp:ListItem>
                    <asp:ListItem Text="Desaprobado" Value="3" ></asp:ListItem>
                    <asp:ListItem Text="EnEspera" Value="4" ></asp:ListItem>
                    <asp:ListItem></asp:ListItem>

                </asp:DropDownList>            
            </div>
            <div class="form-group col-lg-4" >        
                <label for="ddlSubTipo">Reportado</label><br />
                <asp:CheckBox ID="chkReportado" Checked="false" runat="server" />
                
            </div>
        </div>
    <div class="form-group col-lg-12" >        
        <asp:Button ID="btnBuscar" runat="server"  Text="Buscar" class="btn btn-primary" OnClick="btnBuscar_Click" />                              
        <asp:Button ID="btnLimpiar" runat="server"  Text="Limpiar" class="btn btn-secondary" />
    </div>
   

    <div class="form-row" >
         <asp:GridView ID="gv" runat="server" CellPadding="4" HeaderStyle-HorizontalAlign="Center" 
                    AllowPaging="True" AllowSorting="false" PageSize="5"  CssClass="gridview" DataKeyNames="id"
                    ForeColor="#333333" GridLines="None" AutoGenerateColumns="False"  >
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
                    <asp:BoundField DataField="email" HeaderText="Usuario" NullDisplayText="email" SortExpression="email" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                              
                    <asp:BoundField DataField="mensaje" HeaderText="Mensaje" NullDisplayText="mensaje" SortExpression="mensaje" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                          
                    <asp:BoundField DataField="estado_descri" HeaderText="Estado" NullDisplayText="estado_descri" SortExpression="estado_descri" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="reportado" HeaderText="Reportado" NullDisplayText="reportado" SortExpression="reportado" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                          
                    <asp:BoundField DataField="fecha" HeaderText="Fecha" NullDisplayText="fecha" SortExpression="fecha" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Asignar">
                            <HeaderTemplate>
                                    <asp:CheckBox ID="chkHabilita" runat="server" AutoPostBack="true"  CausesValidation="false"    
                                    Checked='<%#Convert.ToBoolean(Eval("reportado"))%>' ToolTip="Deshabilitar comentarios" OnCheckedChanged="chkHabilitaTodas_CheckedChanged" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkHabilita" runat="server" AutoPostBack="true"  CausesValidation="false"    
                                    Checked='<%#Convert.ToBoolean(Eval("reportado"))%>' ToolTip="Deshabilitar comentario" OnCheckedChanged="chkHabilitar_CheckedChanged" />
                                </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  Width="50px"/>
                            <HeaderStyle HorizontalAlign="Center"  Width="50px" />
                     </asp:TemplateField>
                    </Columns>
                </asp:GridView>
    </div>
    
   
 
</asp:Content>
