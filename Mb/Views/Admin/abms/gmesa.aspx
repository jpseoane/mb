<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gmesa.aspx.cs" Inherits="Mb.Views.Admin.abms.gmesa" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>MiBar - Gestion Mesa</h1>
        <p class="lead">Buscar y modificar la mesa</p>
    </div>
  <div class="container">
    <div class="form-row" style="text-align:right">
        <div class="form-group col-lg-12" >                    
                    <asp:LinkButton  PostBackUrl="~/Views/Admin/abms/nuevo/nmesa.aspx" runat="server" CssClass="btn btn-toolbar"
                        CausesValidation="false" >Nuevo</asp:LinkButton>
        </div>
    </div>
    <div class="form-row" >
        <div class="form-group col-lg-6 " >                
            <label for="txtNumeroMesa">Numero de mesa </label><br />
            <asp:TextBox ID="txtNumeroMesa" runat="server" CssClass="form-control" placeholder="Numero"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtNumeroMesa" Text="*" 
                runat="server" ForeColor="red" ></asp:RequiredFieldValidator>
            <br />            
        </div>
        <div class="form-group col-lg-6 " >                
            <label for="txtNumSillaAprox">Cantidad de sillas aproximado</label><br />
            <asp:TextBox ID="txtNumSillaAprox" runat="server" CssClass="form-control" placeholder="Numero Sillas aprox."></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtNumSillaAprox" Text="*" 
                runat="server" ForeColor="red" ></asp:RequiredFieldValidator>
            <br />
            <asp:CheckBox Text="Activa  " TextAlign="Left" ID="chkActiva" runat="server" Checked="True" />
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-lg-12" >        
            <asp:Button ID="btnBuscar" runat="server"  Text="Buscar" class="btn btn-primary" OnClick="btnBuscar_Click" />                              
            <asp:Button ID="btnActualizar" runat="server"  Text="Actualizar" class="btn btn-secondary"  OnClick="btnActualizar_Click"/>
        </div>
    </div> 
    <div class="form-row">
        <div class="form-group col-lg-12" >        
                <div id="divPrueba" runat="server" class="alert alert-warning alert-dismissable" visible="false">
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                    <div id="divMensaje" runat="server"></div>           
            </div>
        </div>
    </div>     
    <!-- GridView-->
    <div class="form-row">
        <div class="form-group col-lg-6" >        
            <asp:GridView ID="gv" runat="server" CellPadding="4" HeaderStyle-HorizontalAlign="Center" 
                AllowPaging="True" AllowSorting="True" PageSize="5"  
                ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gv_RowCommand" >
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
                    <asp:BoundField DataField="numero" HeaderText="numero" NullDisplayText="numero" SortExpression="numero" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                          
                    <asp:BoundField DataField="cant_silla_aprox" HeaderText="Cant. Silla Aprox." NullDisplayText="Sin cantidad" SortExpression="cant_silla_aprox" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                          
                    <asp:BoundField DataField="disponible" HeaderText="Disponible" NullDisplayText="disponible" SortExpression="disponible" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                          
                    <asp:BoundField DataField="fecha_creacion" HeaderText="Fecha" NullDisplayText="Sin Fecha Creacion" SortExpression="fecha_creacion" >
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
 </div>
</asp:Content>
