<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="producto.aspx.cs" Inherits="Mb.Views.Admin.producto" MasterPageFile="~/Site.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

 


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>MiBar - Productos</h1>
        <p class="lead">Crear y administrar nuevos productos</p>
    </div>
 <%-- <style type="text/css">
    .modalBackground
    {
        background-color: Black;
        filter: alpha(opacity=60);
        opacity: 0.6;
    }
    .modalPopup
    {
        background-color: #FFFFFF;
        width: 300px;
        border: 3px solid #0DA9D0;
        border-radius: 12px;
        padding:0
      
    }
    .modalPopup .header
    {
        background-color: #2FBDF1;
        height: 30px;
        color: White;
        line-height: 30px;
        text-align: center;
        font-weight: bold;
        border-top-left-radius: 6px;
        border-top-right-radius: 6px;
    }
    .modalPopup .body
    {
        min-height: 50px;
        line-height: 30px;
        text-align: center;
        font-weight: bold;
    }
    .modalPopup .footer
    {
        padding: 6px;
    }
    .modalPopup .yes, .modalPopup .no
    {
        height: 23px;
        color: White;
        line-height: 23px;
        text-align: center;
        font-weight: bold;
        cursor: pointer;
        border-radius: 4px;
    }
    .modalPopup .yes
    {
        background-color: #2FBDF1;
        border: 1px solid #0DA9D0;
    }
    .modalPopup .no
    {
        background-color: #9F9F9F;
        border: 1px solid #5C5C5C;
    }
</style>--%>
  <div class="divBody">
       <div class="form-row" style="text-align:right">
                <div class="form-group col-lg-12" >                    
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-toolbar" />
                </div>
       </div>
       <div class="form-row" id="divAfiliado" runat="server" visible="false">
                 <div class="form-group col-lg-4 " >                
                        <label for="ddlAfiliado">Tipo</label> 
                        <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control"
                            DataTextField="descripcion" DataValueField="ID" AutoPostBack="true" ></asp:DropDownList>                                
                 </div>           
                 <div class="form-group col-lg-4 " >                
                        <label for="ddlSubTipo">SubTipo</label> 
                        <asp:DropDownList ID="ddlSubTipo" runat="server" CssClass="form-control"
                            DataTextField="descripcion" DataValueField="ID" AutoPostBack="true" ></asp:DropDownList>                                
                 </div>           
            </div>
       <div class="form-row">                 
                <div class="form-group col-lg-3 " >                
                    <label for="txtDetalle">Detalle</label> 
                    <input runat="server" id="txtDetalle" type="text"  class="form-control"    readonly/>
                </div>             
                <div class="form-group col-lg-3">
                    <label for="txtApellido">Precio</label>
                    <input runat="server" id="txtApellido" type="text" class="form-control" readonly />
                </div>
                 <div class="form-group col-lg-6" >                
                    <label for="chkActivo">Activo</label>
                     <asp:CheckBox ID="chkActivo" runat="server" Checked="true" />                    
                </div>
       </div>
       <div class="form-row">
           <div class="form-group col-lg-12" >        
               <asp:Button ID="btnBuscar" runat="server"  Text="Buscar" class="btn btn-primary" />
               <asp:Button ID="btnLimpiar" runat="server"  Text="Limpiar" class="btn btn-warning" formnovalidate="" CausesValidation="false" />
               <asp:Button ID="btnActualizar" runat="server"  Text="Actualizar" class="btn  btn-secondary" visible="False"/>
           </div>
        </div>         
       <div class="form-row">
            <div class="form-group col-lg-12" >        
                <div id="MensajeProducto" runat="server" class="alert alert-success" role="alert" visible="false">
                </div>
            </div>
        </div>
       <div class="form-row">
       <!--Bootstrap alert to display any validation errors-->
            <div id="divError" class="alert alert-danger collapse">
                <a id="linkClose" href="#" class="close">&times;</a>
                <div id="divErrorText">holadjkakjkjjkakjdk jdaskdjkadjaskdj adkjdaskjdkajdkj ak jdkasjdkasj</div>
            </div>
      </div>
      <!-- GridView-->
       <div class="form-row">
            <div class="form-group col-lg-12" >        
                <asp:GridView ID="gvReceta" runat="server" CellPadding="4" CellSpacing="0" HeaderStyle-HorizontalAlign="Center" 
                    AllowPaging="True" AllowSorting="True" PageSize="20" 
                    ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="100%" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"  />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    <Columns>
                        <asp:BoundField DataField="afiliado" HeaderText="Afiliado" NullDisplayText="Sin afiliado" SortExpression="afiliado" >
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="tipo" HeaderText="Tipo" NullDisplayText="Sin tipo" SortExpression="tipo" >
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" />                            
                        </asp:BoundField>                                                
                        <asp:BoundField DataField="cantidadTotal" HeaderText="Cantidad Total" NullDisplayText="NO" SortExpression="cantidadTotal" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                        </asp:BoundField>                                                                                                            
                        <asp:BoundField DataField="fechaactual" HeaderText="Fecha Actual" NullDisplayText="fechaactual" SortExpression="fechaactual" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False"  />
                            <HeaderStyle  HorizontalAlign="Center" />
                        </asp:BoundField>                                                                                    
                        <asp:BoundField DataField="fechaanterior" HeaderText="Fec. Ult. Receta" NullDisplayText="fechaanterior" SortExpression="fechaanterior" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                            <HeaderStyle  HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="observacion" HeaderText="Observacion" NullDisplayText="Observacion" SortExpression="observacion" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                        </asp:BoundField>                          
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" causesvalidation="false"  ImageUrl="~/Images/editreceta.png"
                                    commandname="Editar" commandargument='<%# Eval("Id")%>' Height="24px" Width="24px" 
                                    ToolTip="Editar receta" />
                                <asp:ImageButton id="imgbtnBorrar" runat="server" CausesValidation="false"    
                                    CommandName="Borrar" CommandArgument='<%#Eval("Id")%>'
                                    ImageUrl="~/Images/delreceta.png" ToolTip="Eliminar receta" Height="24px" Width="24px"  />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" Font-Size="Smaller"  BorderStyle="None"  BorderWidth="5px"/>
                            <HeaderStyle Width="50px" />
                        </asp:TemplateField>                                    
                  </Columns>
                </asp:GridView>
         </div>
     </div>

     
        
        <ajaxToolkit:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="btnNuevo"
            OkControlID="btnCargar" CancelControlID="btnCancelar" BackgroundCssClass="modalBackground">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none">
            <div class="header">
                Confirmation
            </div>
            <div class="body">
                Do you want to delete this record?
                <p>Este modal tiene el css de modalPopup</p>
                   <div class="form-row" id="div1" runat="server" visible="false">
                 <div class="form-group col-lg-4 " >                
                        <label for="ddlAfiliado">Tipo</label> 
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control"
                            DataTextField="descripcion" DataValueField="ID" AutoPostBack="true" ></asp:DropDownList>                                
                 </div>           
                 <div class="form-group col-lg-4 " >                
                        <label for="ddlSubTipo">SubTipo</label> 
                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control"
                            DataTextField="descripcion" DataValueField="ID" AutoPostBack="true" ></asp:DropDownList>                                
                 </div>           
            </div>
                   <div class="form-row">                 
                            <div class="form-group col-lg-3 " >                
                                <label for="txtDetalle">Detalle</label> 
                                <input runat="server" id="Text1" type="text"  class="form-control"    readonly/>
                            </div>             
                            <div class="form-group col-lg-3">
                                <label for="txtApellido">Precio</label>
                                <input runat="server" id="Text2" type="text" class="form-control" readonly />
                            </div>
                             <div class="form-group col-lg-6" >                
                                <label for="chkActivo">Activo</label>
                                 <asp:CheckBox ID="CheckBox1" runat="server" Checked="true" />                    
                            </div>
                   </div>
                   <div class="form-row">
                       <div class="form-group col-lg-12" >        
                           <asp:Button ID="Button1" runat="server"  Text="Buscar" class="btn btn-primary" />
                           <asp:Button ID="Button2" runat="server"  Text="Limpiar" class="btn btn-warning" formnovalidate="" CausesValidation="false" />
                           <asp:Button ID="Button3" runat="server"  Text="Actualizar" class="btn  btn-secondary" visible="False"/>
                       </div>
                    </div>         
                   <div class="form-row">
                        <div class="form-group col-lg-12" >        
                            <div id="Div2" runat="server" class="alert alert-success" role="alert" visible="false">
             
                            </div>
                        </div>
                    </div>
                   <div class="form-row">
                   <!--Bootstrap alert to display any validation errors-->
                        <div id="divError" class="alert alert-danger collapse">
                            <a id="linkClose" href="#" class="close">&times;</a>
                            <div id="divErrorText">holadjkakjkjjkakjdk jdaskdjkadjaskdj adkjdaskjdkajdkj ak jdkasjdkasj</div>
                        </div>
                  </div>
            </div>
            <div class="footer" align="right">
                <asp:Button ID="btnCargar" runat="server" Text="Cargar" CssClass="yes" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="no" />
            </div>
        </asp:Panel>



          <div id="divNuevoProducto">  
          </div>
    <script src="../../Scripts/jquery-3.3.1.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>           
    <script type="text/javascript">
        $(document).ready(function () {

            //Mostrar mensaje de error
            //$('#divError').show('fade');

            //Close the bootstrap alert
            $('#linkClose').click(function () {
                $('#divError').hide('fade');
            });

              //Mostrar Modal Para nuevo Producto
            $('#imgbtnNuevo').click(function () {
                 $('#successModal').modal('show');
            });


            //// Save the new user details
            //$('#imgbtnNuevo').click(function () {
            //    $.ajax({
            //        url: '/api/account/register',
            //        method: 'POST',
            //        data: {
            //            email: $('#txtEmail').val(),
            //            password: $('#txtPassword').val(),
            //            confirmPassword: $('#txtConfirmPassword').val()
            //        },
            //        success: function () {
            //            $('#successModal').modal('show');
            //        },
            //        error: function (jqXHR) {
            //            $('#divErrorText').text(jqXHR.responseText);
            //            $('#divError').show('fade');
            //        }
            //    });
            //});
        });
    </script>
 </div>
</asp:Content>
