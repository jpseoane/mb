<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Mb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>MiBar!!</h1>
        <p class="lead">Bienvenido a MiBar! Una apliacion para compartir y relacionarte con todas las personas del bar y ademas podras gestionar tus pedidos sin necesidad de 
            esperar a que te atiendan!!. Empeza ya a utilizar MiBar!!</p>
        <p><a href="Views/Usuario/nuevo/asignamesa.aspx" class="btn btn-primary btn-lg">Asigname una Mesa!! &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Tu mesa</h2>
            <p>
                Por medio de la gestion de la mesa podras ver a quien autorizas o no para poder realizar pedidos, quien pidio cada consumible y cuanto debe pagar
                (Cuentas claras conservan la amistad :) )
            </p>
            <p>
                <a class="btn btn-default" href="Views/Usuario/nuevo/asignamesa.aspx">Ver mi mesa!! &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Muro</h2>
            <p>
                Escribi en el muro del bar tus ideas, gustos, tu nombre, de donde sos, que edad tenes y compartilo con el resto del bar!.  
            </p>
            <p>
                <a class="btn btn-default" href="Views/Usuario/nuevo/nmuro.aspx"> Quiero escribir en el muro!! &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Pedidos</h2>
            <p>
                Pedi lo que quieras para tu mesa, pudiendo ordenar y filtrar a tu gusto. Enterarte que tiene cada producto de la carta con el maximo nivel de detalle!
            </p>
            <p>
                <a class="btn btn-default" href="Views/Usuario/nuevo/npedido.aspx"> Ya tengo mesa y quiero hacer mi pedido! &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
