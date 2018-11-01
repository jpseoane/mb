<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="npedido.aspx.cs" Inherits="Mb.Views.Usuario.pedidos.nuevo.npedido"  MasterPageFile="~/Site.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Generar Pedido</h1>
        <p class="lead">Cargar productos para que me entreguen en la mesa</p>
    </div>
 <div class="container">
   <div class="form-horizontal">     
       <!-- dvMensajeCambio-->
       <div class="form-row"   id="dvMensajeCambio" runat="server"  visible="false" >
            <div class="col-md-12 col-lg-12">
                <div class="alert alert-info alert-dismissible " role="alert">
                   <h3>No tenes asignada una mesa</h3>
                   <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                   <asp:Label  id="lblMensaje" runat="server" Text=""></asp:Label>
                    <a href="asignamesa.aspx" class="alert-link">Ir a Mesa!</a>                
                </div>
           </div>
       </div>
       <div class="form-row"   id="dvCargaProducto" runat="server"  visible="false" >
           <div >
               <div class="form-group col-lg-4" >        
                    <label for="ddlCarta">Carta</label><br />
                    <asp:DropDownList ID="ddlCarta" CssClass="form-control"  runat="server" ></asp:DropDownList>            
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddlCarta" Text="*" 
                        runat="server" ForeColor="red" ></asp:RequiredFieldValidator>
                </div>
                <div class="form-group col-lg-4" >        
                    <label for="ddlTipo">Tipo</label><br />
                    <asp:DropDownList ID="ddlTipo" CssClass="form-control"  runat="server" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged"></asp:DropDownList>            
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlTipo" Text="*" 
                        runat="server" ForeColor="red" ></asp:RequiredFieldValidator>
                </div>
                <div class="form-group col-lg-4" >        
                    <label for="ddlSubTipo">SubTipo</label><br />
                    <asp:DropDownList ID="ddlSubTipo" CssClass="form-control"  runat="server"  OnSelectedIndexChanged="ddlSubTipo_SelectedIndexChanged"></asp:DropDownList>            
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="ddlSubTipo" Text="*" 
                        runat="server" ForeColor="red" ></asp:RequiredFieldValidator>
                </div>                               
                 
           </div>
           <div  class="form-row" >
                <div class="form-group col-lg-4" >        
                    <asp:Button ID="btnBuscar" runat="server"  Text="Buscar" class="btn btn-primary" OnClick="btnBuscar_Click" />
                    <asp:Button ID="btnLimpiar" runat="server"  Text="Limpiar" class="btn btn-warning" formnovalidate="" CausesValidation="false" />
               </div>
           </div>
           <div class="form-row" >
                <div class="form-group col-lg-12 " >                
                      <!-- GridView-->
                      <asp:GridView ID="gv" runat="server" CellPadding="4" HeaderStyle-HorizontalAlign="Center" 
                                AllowPaging="True" AllowSorting="True" PageSize="5"   CssClass="gridview"
                                AutoGenerateColumns="False" >
                                <Columns>
                                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" NullDisplayText="descripcion" SortExpression="descripcion" >
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                                    </asp:BoundField>                          
                                    <asp:BoundField DataField="precio" HeaderText="Precio" NullDisplayText="Sin precio" SortExpression="precio" >
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                                    </asp:BoundField>                          
                                    <asp:TemplateField HeaderText="Acciones">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgbtnAgregar" causesvalidation="false"  ImageUrl="~/Content/img/mas48.png"
                                                commandname="agregar" commandargument='<%# Eval("id")%>' Height="48px" Width="48px" 
                                                ToolTip="Agregar a mi carrito" />
                                            <asp:ImageButton id="imgbtnBorrar" runat="server" CausesValidation="false"    
                                                CommandName="cancelar" CommandArgument='<%#Eval("id")%>'
                                                ImageUrl="~/Content/img/del.png"  Height="24px" Width="24px" 
                                                 ToolTip="Cancelar" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"/>
                                    </asp:TemplateField>     
                                    </Columns>
                        </asp:GridView>
                </div>
           </div>
           
           
           <div class="form-row" >
                <div class="form-group col-lg-6 " >                
                    <label for="txtDescri">Descripción</label><br />
                    <asp:TextBox ID="txtDescri" runat="server" TextMode="MultiLine" CssClass="form-control"  placeholder="Descripción"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDescri" Text="*" 
                        runat="server" ForeColor="red" ></asp:RequiredFieldValidator>            
                </div>        
                <div class="form-group col-lg-6 " >                
                    <label for="txtPrecio">Precio</label><br />
                    <asp:TextBox ID="txtPrecio" CssClass="form-control" TextMode="Number"  runat="server" Width="180px" placeholder="Precio"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPrecio" Text="*" 
                        runat="server" ForeColor="red" ></asp:RequiredFieldValidator>
                </div>          
            </div>
           <div class="form-row" >
                <div class="form-group col-lg-12" >        
                    <asp:Button ID="btnCargar" runat="server"  Text="Pedir" class="btn btn-primary"  />                              
                </div>
               <div class="form-group col-lg-12" >        
                    <div id="divPrueba" runat="server" class="alert alert-warning alert-dismissable" visible="false" >
                        <button type="button" class="close" data-dismiss="alert">&times;</button>
                    <div id="divMensaje" runat="server"></div>           
                    </div>
                </div>
            </div>
           
         
       </div>
    </div>     <!-- form-Horizontal-->
 </div><!-- Container-->
</asp:Content>


 