﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productocarta.aspx.cs" Inherits="Mb.Views.Admin.productocarta" MasterPageFile="~/Site.Master" %>

 <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="jumbotron">
        <h1>Asignacion de productos a Carta</h1>
        <p class="lead">Administracion de productos x carta</p>
    </div>
    <div class="Container" >
       <div class="form-row">
                 <div class="form-group col-lg-6 " >                
                        <label for="ddlTipo">Tipo</label> 
                        <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control"
                            DataTextField="descripcion" DataValueField="ID" ></asp:DropDownList>                                
                 </div>           
                 <div class="form-group col-lg-6 " >                
                        <label for="ddlSubTipo">SubTipo</label> 
                        <asp:DropDownList ID="ddlSubTipo" runat="server" CssClass="form-control"
                            DataTextField="descripcion" DataValueField="ID" ></asp:DropDownList>                                
                 </div>           
                 
       </div>
       <div class="form-row">
           <div class="form-group col-lg-12" >        
               <asp:Button ID="btnListar" runat="server"  Text="Listar" class="btn btn-primary" OnClick="btnListar_Click" />
               <asp:Button ID="btnLimpiar" runat="server"  Text="Limpiar" class="btn btn-warning" formnovalidate="" CausesValidation="false" OnClick="btnLimpiar_Click" />
           </div>
       </div>            
         <div class="form-row" >             
            <div class="form-group col-lg-12" >        
                <div id="divPrueba" runat="server" class="alert alert-warning alert-dismissable" visible="false" >                          
                    <div id="divMensaje" runat="server"></div>           
                </div>
            </div>
         </div>
       <!-- GridView-->
       <div class="form-row">
            <div class="form-group col-lg-12" >  
                <div class="form-group col-lg-4 pull-right " >                
                        <label for="ddlCarta">Asignar a esta Carta</label> 
                        <asp:DropDownList ID="ddlCarta" runat="server" CssClass="form-control"
                            DataTextField="descripcion" DataValueField="ID" ></asp:DropDownList>     
                 </div>           
                <asp:GridView ID="gv" runat="server" CellPadding="4" HeaderStyle-HorizontalAlign="Center" 
                    AllowPaging="True" AllowSorting="True" PageSize="15"  CssClass="gridview" DataKeyNames="id,idCarta_Producto"
                    ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnPageIndexChanging="gv_PageIndexChanging" OnSorting="gv_Sorting" >
                    <RowStyle Height="50px" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" Height="50px" />
                    <EditRowStyle BackColor="#999999" Height="50px" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"  Height="50px" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    <Columns>
                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" NullDisplayText="descripcion" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                              
                    <asp:BoundField DataField="tipoDescri" HeaderText="Tipo Prod." NullDisplayText="Tipo de producto"  >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                          
                    <asp:BoundField DataField="subTipoDescri" HeaderText="SubTipo Prod." NullDisplayText="SubTipo de producto"  >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                          
                    <asp:BoundField DataField="precioUnitario" HeaderText="Precio" NullDisplayText="Precio"  >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="activo" HeaderText="Activo" NullDisplayText="activo"  >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px" />
                    </asp:BoundField>                          
                    <asp:BoundField DataField="fecha" HeaderText="Fecha" NullDisplayText="fecha"  >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                                              
                        <asp:BoundField DataField="descriCarta" HeaderText="Carta" NullDisplayText="Sin Carta"  >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  Width="150px"/>
                    </asp:BoundField>                          
                        <asp:TemplateField HeaderText="Asignar" SortExpression="idCarta">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkAsignar" runat="server" AutoPostBack="true"  CausesValidation="false"     
                                        Checked='<%#Convert.ToBoolean(Eval("idCarta"))%>' ToolTip="Asignar a Carta" OnCheckedChanged="chkAsignar_CheckedChanged" />
                                  </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"  />
                                <HeaderStyle HorizontalAlign="Center" />
                         </asp:TemplateField>
                        </Columns>
                </asp:GridView>
              </div>
       </div>
    </div>
</div>
     </div>
</asp:Content>
