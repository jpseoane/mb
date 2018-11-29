<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="nproducto.aspx.cs" Inherits="Mb.Views.Admin.abms.nproducto" MasterPageFile="~/Site.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>MiBar - Nuevo Producto</h1>
        <p class="lead">Cargar nuevos productos</p>
    </div>
  <div class="container">
    <div class="form-row" style="text-align:right">
        <div class="form-group col-lg-12" >                    
                    <asp:LinkButton  PostBackUrl="~/Views/Admin/abms/gproducto.aspx" runat="server" CssClass="btn btn-toolbar"
                        CausesValidation="false" >Volver al listado</asp:LinkButton>
        </div>
    </div>
    <div class="form-row">
        <%--    <div class="form-group col-lg-4 " >                
                <label for="ddlCarta">Carta</label><br />
                <asp:DropDownList ID="ddlCarta" CssClass="form-control"  runat="server"></asp:DropDownList>            
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddlCarta" Text="*" 
                    runat="server" ForeColor="red" ></asp:RequiredFieldValidator>
            </div>--%>
            <div class="form-group col-lg-4" >        
                <label for="ddlTipo">Tipo</label><br />
                <asp:DropDownList ID="ddlTipo" CssClass="form-control"  runat="server"></asp:DropDownList>            
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlTipo" Text="*" 
                    runat="server" ForeColor="red" ></asp:RequiredFieldValidator>
            </div>
            <div class="form-group col-lg-4" >        
                <label for="ddlSubTipo">SubTipo</label><br />
                <asp:DropDownList ID="ddlSubTipo" CssClass="form-control"  runat="server"></asp:DropDownList>            
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="ddlSubTipo" Text="*" 
                    runat="server" ForeColor="red" ></asp:RequiredFieldValidator>
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
                <asp:TextBox ID="txtPrecio" CssClass="form-control"  runat="server" Width="180px" placeholder="Precio"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPrecio" Text="*" 
                    runat="server" ForeColor="red" ></asp:RequiredFieldValidator>
            </div>          
        </div>
        <div class="form-row" >
        <div class="form-group col-lg-12" >                       
                <!-- Checked checkbox -->
                <div class="checkbox">
                    <label>
                    <input type="checkbox" id="chkActiva" value="" runat="server" checked>
                    <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                    <strong> Producto Disponible</strong>
                    </label>
                </div>
            </div>    
          </div>
    
        <div class="form-group col-lg-12" >        
            <asp:Button ID="btnCargar" runat="server"  Text="Cargar" class="btn btn-primary" OnClick="btnCargar_Click"  />                              
            <asp:Button ID="btnLimpiar" runat="server"  Text="Limpiar" class="btn btn-secondary" CausesValidation="false" OnClick="btnLimpiar_Click"  />
        </div>
        <div class="form-group col-lg-12" >        
                <div id="divPrueba" runat="server" class="alert alert-warning alert-dismissable" visible="false">
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                    <div id="divMensaje" runat="server"></div>           
        </div>
        
    </div>     
    <!-- GridView-->
    <div class="form-row">
        <div class="form-group col-lg-6" style="text-align:center; " >        
            <asp:GridView ID="gv" runat="server" CellPadding="4" HeaderStyle-HorizontalAlign="Center" 
                AllowPaging="True" AllowSorting="True" PageSize="5"  
                ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" >
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" Height="50px" HorizontalAlign="Center" />
                <Columns>
                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" NullDisplayText="descripcion" SortExpression="descripcion" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                          
                    <asp:BoundField DataField="activa" HeaderText="Activa" NullDisplayText="activa" SortExpression="activa" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                          
                    <asp:BoundField DataField="precio" HeaderText="precio" NullDisplayText="Sin precio" SortExpression="precio" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                          
                    <asp:BoundField DataField="tipo" HeaderText="tipo" NullDisplayText="Sin tipo" SortExpression="tipo" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                          
                    <asp:BoundField DataField="Subtipo" HeaderText="Subtipo" NullDisplayText="Subtipo" SortExpression="Subtipo" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                          
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" causesvalidation="false"  ImageUrl="~/Content/img/edit.png"
                                commandname="editar" commandargument='<%# Eval("id")%>' Height="24px" Width="24px" 
                                ToolTip="Editar carta" />
                            <asp:ImageButton id="imgbtnBorrar" runat="server" CausesValidation="false"    
                                CommandName="eliminar" CommandArgument='<%#Eval("id")%>'
                                ImageUrl="~/Content/img/del.png" ToolTip="Eliminar Carta" Height="24px" Width="24px"  />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" Font-Size="Smaller"  BorderStyle="None"  BorderWidth="5px"/>
                        <HeaderStyle Width="50px" />
                    </asp:TemplateField>     
                    </Columns>
                <EditRowStyle BackColor="#999999" Height="50px" HorizontalAlign="Center" />
                <EmptyDataRowStyle HorizontalAlign="Center" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"  Height="50px" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle Height="50px" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" HorizontalAlign="Center" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" HorizontalAlign="Center" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" HorizontalAlign="Center" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" HorizontalAlign="Center" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" HorizontalAlign="Center" />
            </asp:GridView>
        </div>
    </div>
 </div>
</asp:Content>
