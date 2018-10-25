<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ncarta.aspx.cs" Inherits="Mb.Views.Admin.abms.ncarta" MasterPageFile="~/Site.Master" %>

 <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="jumbotron">
        <h1>MiBar - Crear Carta</h1>
        <p class="lead">Nueva Carta</p>
    </div>
    <div class="container"> 
       <div class="form-row" style="text-align:right">
          <div class="form-group col-lg-12" >  
                <asp:LinkButton  PostBackUrl="~/Views/Admin/abms/gcarta.aspx" runat="server"
                     CausesValidation="false"
                    CssClass="btn btn-toolbar" >Volver al listado</asp:LinkButton>
            </div>
       </div>
       <div class="form-row" >
           <div class="form-group col-lg-12 " >                
                <label for="txtNombreCarta">Nombre de Carta</label><br />
                <asp:TextBox ID="txtNombreCarta" runat="server" Width="180px" placeholder="Nombre"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtNombreCarta" Text="*" 
                    runat="server" ForeColor="red" ></asp:RequiredFieldValidator>
               <br />
                <asp:CheckBox Text="Activa  " TextAlign="Left" ID="chkActiva" runat="server" Checked="True" />
            </div>
       </div>
       <div class="form-row">
           <div class="form-group col-lg-12" >        
               <asp:Button ID="btnCargar" runat="server"  Text="Cargar" class="btn btn-primary" OnClick="btnCargar_Click"  />                              
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
