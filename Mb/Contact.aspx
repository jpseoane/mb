<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Mb.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Pagina de contacto</h3>
    <address>
        Av. Libertador 3800<br />
         Buenos aires, Capital Federal<br />
        <abbr title="Phone">P:</abbr>
        4360-1500
    </address>

    <address>
        <strong>Soporte:</strong>   <a href="mailto:Soporte@mibar.com">SoporteMiBar@mibar.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@mibar.com">Marketing@mibar.com</a>
    </address>
</asp:Content>
