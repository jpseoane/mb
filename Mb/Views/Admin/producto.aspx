<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="producto.aspx.cs" Inherits="Mb.Views.Admin.producto" MasterPageFile="~/Site.Master" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>MiBar - Nueva mesa</h1>
        <p class="lead">Generar cada mesa y los datos para que tus clientes puedan loguearse!</p>        
    </div>

    <div class="row">
        <div class="col-sm-12 col-md-12 col-lg-12">
            <a href=""></a>
            <h2>Datos de la mesa</h2>
            
            <div>
               <label for="numMesa" >Numero de mesa</label><br />
               <input type="text" id="txtNumMesa" runat="server" required/><br />
                <label for="numSillaAprox" >Cantidad de sillas aproximadas</label><br />
               <input type="text" id="txtNumSillaAprox" runat="server"/>

                <asp:Button ID="btnCargar" runat="server" Text="Cargar" OnClick="btnCargar_Click" />
            </div>
            <br />
        </div>
        
    </div>
</asp:Content>
