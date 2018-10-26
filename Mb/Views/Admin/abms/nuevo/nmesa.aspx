<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="nmesa.aspx.cs" Inherits="Mb.Views.Admin.abms.nuevo.nmesa" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>MiBar - Gestion Mesa</h1>
        <p class="lead">Buscar y modificar la mesa</p>
    </div>
  <div class="container">
    <div class="form-row" style="text-align:right">
        <div class="form-group col-lg-12" >                    
                    <asp:LinkButton  PostBackUrl="~/Views/Admin/abms/gmesa.aspx" runat="server" CssClass="btn btn-toolbar"
                        CausesValidation="false" >Volver al listado</asp:LinkButton>
        </div>
    </div>
    <div class="form-row" >
        <div class="form-group col-lg-6 " >                
            <label for="txtNumeroMesa">Numero de mesa </label><br />
            <asp:TextBox ID="txtNumeroMesa" TextMode="Number" runat="server" CssClass="form-control" placeholder="Numero"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtNumeroMesa" Text="*" 
                runat="server" ForeColor="red" ></asp:RequiredFieldValidator>
            <br />            
        </div>
        <div class="form-group col-lg-6 " >                
            <label for="txtNumSillaAprox">Cantidad de sillas aproximado</label><br />
            <asp:TextBox ID="txtNumSillaAprox" runat="server" CssClass="form-control" TextMode="Number" placeholder="Numero Sillas aprox."></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtNumSillaAprox" Text="*" 
                runat="server" ForeColor="red" ></asp:RequiredFieldValidator>
            <br />
            <asp:CheckBox Text="Activa  " TextAlign="Left" ID="chkActiva" runat="server" Checked="True" />
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-lg-12" >        
            <asp:Button ID="btnCargar" runat="server"  Text="Cargar" class="btn btn-primary" OnClick="btnCargar_Click" />                              
            <asp:Button ID="btnLimpiar" runat="server"  Text="Limpiar" class="btn btn-secondary" OnClick="btnLimpiar_Click"  />
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
    </div>
</asp:Content>