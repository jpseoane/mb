<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abm.aspx.cs" Inherits="Mb.Views.Admin.abm" MasterPageFile="~/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>MiBar - Abm</h1>
        <p class="lead">Administrar pequeños abm!</p>        
    </div>
    <cc1:TabContainer ID="TabContainer"  CssClass="BackColorTab" runat="server" ActiveTabIndex="0">
            <cc1:TabPanel ID="tabPanelCarta" CssClass="tab-content" runat="server" HeaderText="Carta">
                <HeaderTemplate>
                    <img src="search.jpg" alt="Tab1"/>
            </HeaderTemplate>
            <ContentTemplate>
                      <asp:Panel runat="server" ID="Panel1" ScrollBars="Vertical">
                            <label for="txtNombreCarta">Nombre de Carta</label>
                            <asp:TextBox ID="txtNombreCarta" runat="server" placeholder="Nombre"  required></asp:TextBox><br />
                            <label for="chkActiva">Esta activa</label>
                            <asp:CheckBox ID="chkActiva" runat="server" Checked="true" />
                            <asp:Button ID="BtnCarga" runat="server" Text="Cargar" />
                      </asp:Panel>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="tabPanelTipoProducto" runat="server" HeaderText="Tipo Producto">
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
        <cc1:TabPanel ID="tabPanelSubTipo" runat="server" HeaderText="SubTipo de productos">
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
        <cc1:TabPanel ID="tabPanel1" runat="server" HeaderText="SubTipo de productos">
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
                               <input type="text" id="txtNumMesa" runat="server" required/><br />
                                <label for="numSillaAprox" >Cantidad de sillas aproximadas</label><br />
                               <input type="text" id="txtNumSillaAprox" runat="server"/>
                                
                            </div>
                            <br />
                        </div>
                     </asp:Panel>
            </ContentTemplate>
        </cc1:TabPanel>
  </cc1:TabContainer>
  <style type="text/css">
        .BackColorTab
        {
            font-family:Verdana, Arial, Courier New;
            font-size: 10px;
            color:Gray;
            background-color:Silver;
        }
        .TabHeaderCSS
        {
             font-family:Verdana, Arial, Courier New;
             font-size: 10px;
             background-color: Silver;
             text-align: center;
             cursor: pointer
        }
  </style>
</asp:Content>
