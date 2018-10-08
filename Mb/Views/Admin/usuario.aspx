<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usuario.aspx.cs" Inherits="Mb.Views.Admin.usuario" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>MiBar - Usuarios</h1>
        <p class="lead">Verifique los usuarios registrados ene l sistema</p>        
    </div>

    <div class="row">
        <div class="col-sm-12 col-md-12 col-lg-12">
            <a href=""></a>
            <h2>Usuarios</h2>
            
            <div>
               <label for="numMesa" >Numero de mesa</label><br />
               <input type="text" id="txtNumMesa" runat="server" required/><br />
                <label for="numSillaAprox" >Cantidad de sillas aproximadas</label><br />
               <input type="text" id="txtNumSillaAprox" runat="server"/>

                <asp:Button ID="btnCargar" runat="server" Text="Cargar" OnClick="btnCargar_Click" />
            </div>
            <br />
        </div>
        <div div class="col-sm-12 col-md-12 col-lg-12"> 
            <asp:GridView ID="gvUsuarios" runat="server">

            </asp:GridView> 

        </div>
        
    </div>
</asp:Content>
