<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abm.aspx.cs" Inherits="Mb.Views.Admin.abm" MasterPageFile="~/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>MiBar - Abm</h1>
        <p class="lead">Administrar pequeños abm!</p>        
    </div>
    <asp:Label ID="lblUsuario" runat="server" Text="Label"></asp:Label>

<cc1:TabContainer ID="TabContainer"  CssClass="BackColorTab" runat="server" ActiveTabIndex="0">
<cc1:TabPanel ID="tabPanelCarta" CssClass="tab-content" runat="server" HeaderText="Carta" TabIndex="0">
    <HeaderTemplate>
        <img src="search.jpg" alt="Tab1"/>
    </HeaderTemplate>
<ContentTemplate>
                <asp:Panel runat="server" ID="Panel1" ScrollBars="Vertical">
                    <label for="txtNombreCarta">Nombre de Carta</label><br />
                    <asp:TextBox ID="txtNombreCarta" runat="server" placeholder="Nombre"  ></asp:TextBox><br />
                    <label for="chkActiva">Esta activa</label><br />
                    &nbsp;<asp:CheckBox ID="chkActiva" runat="server" Checked="True" />                                
                </asp:Panel>
</ContentTemplate>
</cc1:TabPanel>
<cc1:TabPanel ID="tabPanelTipoProducto" runat="server" HeaderText="Tipo Producto" TabIndex="1">
    <HeaderTemplate>
                <img src="search.jpg" alt="Tab2"/>
</HeaderTemplate>
<ContentTemplate>
        <asp:Panel runat="server" ID="Panel2" ScrollBars="Vertical">
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
            <asp:Button ID="Button1" runat="server" Text="Button" />
        </asp:Panel>
</ContentTemplate>
</cc1:TabPanel>
<cc1:TabPanel ID="tabPanelSubTipo" runat="server" HeaderText="SubTipo de productos" TabIndex="2">
    <HeaderTemplate>
        <img src="search.jpg" alt="Tab3"/>
</HeaderTemplate>
<ContentTemplate>
        <asp:Panel runat="server" ID="Panel3" ScrollBars="Vertical">
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
            <asp:Button ID="Button2" runat="server" Text="Button" />
            </asp:Panel>
</ContentTemplate>
</cc1:TabPanel>
<cc1:TabPanel ID="tabPanel1" runat="server" HeaderText="Mesas" TabIndex="3">
    <HeaderTemplate>
        <img src="search.jpg" alt="Tab3"/>
</HeaderTemplate>
<ContentTemplate>
            <asp:Panel runat="server" ID="Panel4" ScrollBars="Vertical">
                <div class="row">
                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <a href=""></a>
                        <h2>Datos de la mesa</h2>            
                        <div>
                            <label for="numMesa" >Numero de mesa</label><br />
                            <input type="text" id="txtNumMesa" runat="server" /><br />
                            <label for="numSillaAprox" >Cantidad de sillas aproximadas</label><br />
                            <input type="text" id="txtNumSillaAprox" runat="server"/>
                                
                        </div>
                        <br />
                    </div>
                </div>
                </asp:Panel>
</ContentTemplate>
</cc1:TabPanel>
</cc1:TabContainer>
    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click"  />
    <asp:Button ID="btnCarga" runat="server" Text="Cargar" OnClick="btnCarga_Click1" />
</asp:Content>
