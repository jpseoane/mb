﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gcarta.aspx.cs" Inherits="Mb.Views.Admin.abms.gcarta" MasterPageFile="~/Site.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>MiBar - Gestion Carta</h1>
        <p class="lead">Buscar y modificar la carta</p>
    </div>
  <div class="container">
    <div class="form-row" style="text-align:right">
        <div class="form-group col-lg-12" >                    
                    <asp:LinkButton  PostBackUrl="~/Views/Admin/abms/nuevo/ncarta.aspx" runat="server" CssClass="btn btn-toolbar"
                        CausesValidation="false" >Nuevo</asp:LinkButton>
        </div>
    </div>
    <div class="form-row" >
        <div class="form-group col-lg-6 " >                
            <label for="txtNombreCarta">Nombre de Carta</label><br />
            <asp:TextBox ID="txtNombreCarta" CssClass="form-control" runat="server" Width="180px" placeholder="Nombre"></asp:TextBox>
        </div>
        <div class="form-group col-lg-6 " >                
            <label for="ddlEstadoDeCarta">Estado De Carta</label> 
            <asp:DropDownList ID="ddlEstadoDeCarta" runat="server" CssClass="form-control"
                DataTextField="descripcion" DataValueField="ID"  >
                    <asp:ListItem Value="S">Todas</asp:ListItem>
                    <asp:ListItem Value="1">Activa</asp:ListItem>
                    <asp:ListItem Value="0">Deshabilitada</asp:ListItem>
            </asp:DropDownList>                                
              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddlEstadoDeCarta" Text="Elige un estado!" ErrorMessage="Eliga un estado!" InitialValue="Todas" 
               runat="server" ForeColor="red" ></asp:RequiredFieldValidator>
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
        <div class="form-group col-lg-12" >        
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            <asp:GridView ID="gv" runat="server" CellPadding="4" HeaderStyle-HorizontalAlign="Center"  Width="100%"
                AllowPaging="false" AllowSorting="false" PageSize="10"  
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
                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" NullDisplayText="descripcion" SortExpression="descripcion" >
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                          
                    <asp:BoundField DataField="activa" HeaderText="Activa" NullDisplayText="activa" SortExpression="activa" >
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                          
                    <asp:BoundField DataField="fecha" HeaderText="Fecha" NullDisplayText="fecha" SortExpression="fecha" >
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
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
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" Font-Size="Smaller"  BorderStyle="None"  BorderWidth="5px"/>
                        <HeaderStyle Width="50px" />
                    </asp:TemplateField>     
                    </Columns>
            </asp:GridView>
        </div>
    </div>
 </div>
</asp:Content>
