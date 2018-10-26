<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pedidomesa.aspx.cs" Inherits="Mb.Views.Usuario.pedido" MasterPageFile="~/Site.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>MiBar - Ingreso de Mesa</h1>
        <p class="lead">Reserve su mesa ingresando el numero!</p>        
    </div>

    <div class="row">
        <div class="col-sm-12 col-md-12 col-lg-12">
            <a href=""></a>
            <h2>Datos de la mesa</h2>
            
            <div>
               <label for="numMesa" >Numero de mesa</label><br />
               <input type="text" id="txtNumMesa" runat="server" required/><br />
                <asp:LinkButton ID="lnbReservar" runat="server" OnClick="lnbReservar_Click">Reservar y continuar</asp:LinkButton>
               
            </div>
        </div>
     </div>
            

      <div class="form-row">
        <div class="form-group col-lg-6" >        
            <asp:GridView ID="gv" runat="server" CellPadding="4" HeaderStyle-HorizontalAlign="Center" 
                AllowPaging="True" AllowSorting="True" PageSize="5"  
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
                    <asp:BoundField DataField="UserId" HeaderText="userid" NullDisplayText="userid" SortExpression="UserId" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                          
                    <asp:BoundField DataField="IdMesa" HeaderText="idmesa" NullDisplayText="Sin cantidad" SortExpression="IdMesa" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                          
                    <asp:BoundField DataField="PerfilMesaUsuCod" HeaderText="PerfilMesaUsu" NullDisplayText="PerfilMesaUsu" SortExpression="PerfilMesaUsuCod" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                          
                    <asp:BoundField DataField="activo" HeaderText="activo" NullDisplayText="activo" SortExpression="activo" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                          
                    <asp:BoundField DataField="fecha" HeaderText="Fecha" NullDisplayText="Sin Fecha" SortExpression="fecha" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                          
                    <asp:BoundField DataField="habilitado" HeaderText="habilitado" NullDisplayText="habilitado" SortExpression="habilitado" >
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
            </asp:GridView>
        </div>
    </div>
    
</asp:Content>
