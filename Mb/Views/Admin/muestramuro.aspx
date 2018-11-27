<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="muestramuro.aspx.cs" Inherits="Mb.Views.Admin.muestramuro" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Muro</h1>
        <p class="lead">Mira lo que comparten las mesas en este momento!!!</p>
    </div>
    <div class="form-row" >    
            <asp:ListView ID="ListView1" runat="server" GroupItemCount="1" DataSourceID="sqlds" DataKeyNames="ID">
                <LayoutTemplate>
                    <table cellpadding="0" runat="server" id="tblDepartments" cellspacing="2">
                        <tr runat="server" id="groupPlaceholder" />
                    </table>
                </LayoutTemplate>
                <GroupTemplate>
                    <tr runat="server" id="ProductsRow">
                        <td runat="server" id="itemPlaceholder" />
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td id="Td2" align="center">
                    </td>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <tr>
                        <td>No data</td>
                    </tr>
                </EmptyDataTemplate>
        </asp:ListView>
    </div>
    <div class="form-group col-lg-12" >        
    <asp:Button ID="btnBuscar" runat="server"  Text="Publicar" class="btn btn-primary" CausesValidation="false" />                              
    <asp:Button ID="btnActualizar" runat="server"  Text="Actualizar" class="btn btn-secondary" />
    </div>
    <div class="form-group col-lg-12" >        
        <div id="divPrueba" runat="server" class="alert alert-warning alert-dismissable" visible="false">
            <button type="button" class="close" data-dismiss="alert">&times;</button>
            <div id="divMensaje" runat="server"></div>           
        </div>
    </div>     
  
 
</asp:Content>
