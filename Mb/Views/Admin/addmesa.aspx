<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addmesa.aspx.cs" Inherits="MiBarApp.Views.admin.addqr" MasterPageFile="~/Site.Master" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>MiBar - Administracion Codigos QR de mesa</h1>
        <p class="lead">Genera los codigos QR de cada mesa y colocalos para que tus clientes puedan loguearse!</p>        
    </div>
     <hgroup class="title">
        <div class="col-sm-12 col-md-12 col-lg-12">
            <a href=""></a>
            <h2>CARGA DE MESA</h2>
            <p>
                Si tenes una mesa selecciona esta opcion y acercate a la misma para ingresar el numero o leer el codigo QR                
            </p>
            <br />
        </div>
    </hgroup>
    <div class="row">
          <div class="form-row">
            <div class="form-group col-lg-3 " >                
                <label for="txtNumMesa">Numero de la mesa</label> 
                <input runat="server" id="txtNumMesa" type="text"  class="form-control"  placeholder="Numero"   required/>
            </div>             
            <div class="form-group col-lg-3">
                <label for="txtCantSilla">Cantidad de sillas</label><input runat="server" id="txtCantSilla" type="text" class="form-control"  placeholder="Cant. Silla Aprox."  />
            </div>                        
           
        </div>       
        <div class="form-row">
           <div class="form-group col-lg-12" >        
               <asp:Button ID="btnCargar" runat="server"  Text="Cargar" class="btn btn-primary" OnClick="btnCargar_Click" />
               <asp:Button ID="btnLimpiar" runat="server"  Text="Limpiar" class="btn btn-warning" formnovalidate="" OnClick="btnLimpiar_Click" />
           </div>
        </div>         
        <div class="form-row">
            <div class="form-group col-lg-12" >        
                <div id="MensajeMedicamento" runat="server" class="alert alert-success" role="alert" visible="false">
                    Silla Cargado </div>
            </div>
        </div>

        <div class="form-row">
            <div class="form-group col-lg-12" >        
                <asp:GridView ID="gvSilla" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
            </div>
        </div>
     </div>
</asp:Content>
