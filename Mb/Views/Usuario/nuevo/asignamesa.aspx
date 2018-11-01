<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="asignamesa.aspx.cs" Inherits="Mb.Views.Usuario.pedidos.asignamesa"  MasterPageFile="~/Site.Master"  %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Asignación de Mesa</h1>
        <p class="lead">Reserva tu mesa ingresando el numero y autoriza a invitados!</p>        
    </div>
<div class="container">
    <div class="row">
        <div class="col-sm-12 col-md-12 col-lg-12">
            <h2>Datos de la mesa</h2>            
        </div>
    </div>
    <div class="form-row" id="dvAsignaMesa" runat="server" visible="false">
       <div class="form-group col-lg-12" >
            <label for="txtNumeroMesa" >Numero de mesa</label><br />
           <asp:DropDownList ID="ddlNumeroMesa" CssClass="form-control"  runat="server"></asp:DropDownList>
            <br />
            <asp:LinkButton ID="lnbReservar" runat="server" OnClick="lnbReservar_Click">Asginame a esta Mesa!</asp:LinkButton>
       </div>      
    </div>
    <div class="form-row">
      <div class="form-group col-lg-12" >        
            <div id="divPrueba" runat="server" class="alert alert-warning alert-dismissable" visible="false">
                <button type="button" class="close" data-dismiss="alert">&times;</button>
                <div id="divMensaje" runat="server">
                    </div>           
                <a id="aMensaje" href="nuevo/npedido.aspx" runat="server" title="Dale">Nuevo</a>
            </div>
        </div>
    </div>
    <div class="form-row" id="dvUsuarioMesa" runat="server" visible="false">
        <div class="form-group col-lg-6" >        
            <div class="panel panel-default">
              <div class="panel-heading">
                <h3 class="panel-title">Datos de tu cuenta:</h3>
              </div>
              <div class="panel-body">
                  <strong><label for="lblMail">Email: </label></strong>
                  <asp:Label ID="lblMail" runat="server" Text="Tu mail"></asp:Label><br />
                  <strong><label for="lblPerfil">Perfil:</label></strong>
                  <asp:Label ID="lblPerfil" runat="server" Text="Tu Perfil"></asp:Label><br />
                  <strong><label for="lblActivo">Activo</label></strong>
                  <input type="checkbox" runat="server" id="chkActiva" disabled/>
                  
              </div>
            </div>
        </div>
    </div>
    <div class="form-row" id="dvGrupoMesa" runat="server" visible="false">
        <div class="form-group col-lg-6" >        
            <div class="panel panel-default">
                  <!-- Default panel contents -->
                  <div class="panel-heading">El grupo de tu mesa:</div>
                  <div class="panel-body">
                    <p>Estas personas estan compartiendo con vos la mesa si queres que alguno pueda o no realizar pedidos y ponerlo a cuenta de la mesa puedes confirmar el permiso por medio de la pestaña Amigos!</p>
                    <asp:GridView CssClass="gridview" ID="gvUsuariosEnMesa" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False"
                        OnRowCommand="gvUsuariosEnMesa_RowCommand" DataKeyNames="id">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        <EmptyDataTemplate>
                            <div>
                                   No hay mas usuarios registrados en esta mesa
                            </div>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="email" HeaderText="Email" NullDisplayText="email" SortExpression="email" >
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                            </asp:BoundField>                          
                            <asp:BoundField DataField="perfilEnMesa" HeaderText="Perfil" NullDisplayText="perfilEnMesa" SortExpression="perfilEnMesa" >
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                            </asp:BoundField> 
                            <asp:TemplateField HeaderText="Activo">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkActivo" runat="server" AutoPostBack="true"  CausesValidation="false"    
                                        Checked='<%#Convert.ToBoolean(Eval("activo"))%>' ToolTip="Permitir amigo" OnCheckedChanged="chkApproved_CheckedChanged" />
                                  </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:ImageButton id="imgbtnBorrar" runat="server" CausesValidation="false"    
                                        CommandName="eliminar" CommandArgument='<%#Eval("id")%>' 
                                        ImageUrl="~/Content/img/del.png" ToolTip="Eliminar Amigo de la mesa" Height="24px" Width="24px"  />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>     
                        </Columns>
                    </asp:GridView>
              </div>
           </div>
        </div>
    </div>
      
</div>
    
</asp:Content>
