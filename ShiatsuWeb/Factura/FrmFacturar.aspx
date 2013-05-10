<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FrmFacturar.aspx.vb" Inherits="ShiatsuWeb.FrmFacturar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
      <h3>Cistas por Facturar</h3>
    <asp:GridView ID="gvDatosP" runat="server" CellPadding="4" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="agendaDB" ForeColor="#333333" GridLines="None" Width="100%">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="id" HeaderText="Id" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="hora" HeaderText="Hora" SortExpression="hora" />
            <asp:BoundField DataField="telefono" HeaderText="Teléfono " SortExpression="telefono" />
            <asp:BoundField DataField="cliente" HeaderText="Cliente" SortExpression="cliente" />
            <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
            <asp:BoundField DataField="cubiculo" HeaderText="Cubiculo" SortExpression="cubiculo" > 
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="observaciones" HeaderText="Observaciones" SortExpression="observaciones" ApplyFormatInEditMode="True" HtmlEncode="False" HtmlEncodeFormatString="False" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView> 
    <asp:SqlDataSource ID="agendaDB" runat="server" 
        ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" 
        ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" 
        DeleteCommand="DELETE FROM cita WHERE id = ?"
        SelectCommand="SELECT id, fecha, hora,observaciones, telefono,cliente, (SELECT  c.nombre FROM cat_cliente c WHERE c.cedCliente = cliente ) nombre ,cubiculo FROM cita WHERE (fecha = ?) AND (estado = 'Factura')  ORDER BY hora ASC">
         <DeleteParameters>
             <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters> 
        <SelectParameters>
            <asp:ControlParameter ControlID="hfFecha" Name="fecha" PropertyName="Value" Type="String" />  
        </SelectParameters>
    </asp:SqlDataSource>
      <asp:HiddenField ID="hfFecha" runat="server" />

     <h3>Factura</h3><hr>
   <table   >
        <tr>
        <td  >Cliente:</td>
        <td  >
            <asp:TextBox ID="txtCliente" runat="server" Enabled="False" Width="160px"></asp:TextBox>
        
        </td>
        <td  >
            Factura:</td>
        <td  >
            <asp:Label ID="lblId" runat="server" Font-Size="14pt" ForeColor="Red"></asp:Label>
        
        </td>
        <td  >
            </td>
    </tr> 

    <tr>
        <td >Tipo Cliente:</td>
        <td  > 
            <asp:TextBox ID="txtTipoCliente" runat="server" Enabled="False" Width="160px"></asp:TextBox>
        
        </td>
        <td >Usuario:</td>
        <td >
            <asp:TextBox ID="txtUsuario" runat="server" Enabled="False" Width="160px"></asp:TextBox>
        
        </td>
        <td ></td>
    </tr> 
    <tr>
        <td>Teléfono:</td>
        <td >
            <asp:TextBox ID="txtTelefono" runat="server" Enabled="False" Width="160px"></asp:TextBox>
        
        </td>
        <td>
            Fecha:</td>
        <td>
            <asp:TextBox ID="txtFecha" runat="server" Enabled="False" Width="160px"></asp:TextBox>
        
            </td>
        <td>
            </td>
    </tr> 
    <tr>
        <td></td>
        <td >
            </td>
        <td>
            </td>
        <td>
            
        </td>
        <td>
            
            </td>
    </tr> 
        <tr>
        <td colspan="5"  > 
        
             <asp:Button ID="btnFacturar" runat="server" Text="Facturar" Visible="False" />
             
             <br />
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        <hr>
        </td>
    </tr> 
        <tr>
        <td colspan="2"  > 
        
             </td>
        <td  > 
        
             </td>
        <td  > 
        
             </td>
        <td  > 
        
             </td>
    </tr> 
        <tr>
        <td colspan="4" > 
        

                        <asp:GridView ID="gvProductos" runat="server" CellPadding="4" DataSourceID="productosDS" AutoGenerateColumns="False" DataKeyNames="factura,producto" AllowPaging="True" AllowSorting="True" ForeColor="#333333" GridLines="None" Width="90%">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="cantidad" HeaderText="Cantidad" SortExpression="cantidad" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="producto" HeaderText="Producto" ReadOnly="True" SortExpression="producto" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="descripcion" HeaderText="Descripción" ReadOnly="True" SortExpression="descripcion" />
                                <asp:BoundField DataField="precio" HeaderText="Precio" ReadOnly="True" SortExpression="precio" DataFormatString="{0:C}" >
                                <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField> 
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="productosDS" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" 
                            DeleteCommand="DELETE FROM factura_detalle WHERE factura = ? AND producto = ?" 
                            InsertCommand="INSERT INTO factura_detalle (factura, cantidad, producto) VALUES (?, ?, ?)" 
                            ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" 
                            SelectCommand="SELECT  d.factura ,  d.cantidad , d.producto,
                                            (select i.descripcion FROM cat_inventario i WHERE i.id = d.producto) descripcion, d.precio
                                             FROM  factura_detalle d  WHERE ( d.factura  = ?)" 
                            UpdateCommand="UPDATE factura_detalle SET cantidad = ? WHERE factura = ? AND producto = ?">
                            <DeleteParameters>
                                <asp:Parameter Name="factura" Type="Int32" />
                                <asp:Parameter Name="producto" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="factura" Type="Int32" />
                                <asp:Parameter Name="cantidad" Type="Int32" />
                                <asp:Parameter Name="producto" Type="Int32" />
                            </InsertParameters>
                             <SelectParameters>
                                 <asp:ControlParameter ControlID="lblId" Name="factura" PropertyName="Text" Type="String" />
                             </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="cantidad" Type="Int32" />
                                <asp:Parameter Name="factura" Type="Int32" />
                                <asp:Parameter Name="producto" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
        
        </td>
        <td > 
        
              <table >
                                <tr>
                                    <td  >Caja</td>
                                    <td   >
            <asp:Label ID="lblCaja" runat="server"></asp:Label>
                                    </td>
                                </tr> 
                                <tr>
                                    <td  >Cantidad</td>
                                    <td   >
                                        <asp:TextBox ID="txtCantidad" runat="server" MaxLength="2" TextMode="Number" Width="160px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCantidad" ErrorMessage="Valor incorrecto" ForeColor="Red" ValidationExpression="^[0-9]{1,5}?$"></asp:RegularExpressionValidator>
                                    </td>
                                </tr> 
                                <tr>
                                    <td  >Producto</td>
                                    <td   ><asp:DropDownList ID="ddlProdcutos" runat="server" DataSourceID="InventarioDB" DataTextField="descripcion" DataValueField="id" Width="160px">
                                    </asp:DropDownList> 
                                        <asp:SqlDataSource ID="InventarioDB" runat="server" ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" SelectCommand="SELECT id, CONCAT( descripcion, ' -  Cantidad: ',cantidad   )  descripcion FROM cat_inventario WHERE cantidad > 0"></asp:SqlDataSource>
                                    </td>
                                </tr> 
                                <tr>
                                    <td  >Precio</td>
                                    <td   ><asp:DropDownList ID="ddlPrecios" runat="server" DataSourceID="PreciosDS" DataTextField="descripcion" DataValueField="precio" Width="160px">
                                    </asp:DropDownList> 
                                        <asp:SqlDataSource ID="PreciosDS" runat="server" ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" 
                                            ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" 
                                            SelectCommand="SELECT precio1 precio, CONCAT('Precio 1: ',precio1) descripcion FROM cat_inventario WHERE (id = ?) union all
                                                           SELECT precio2 precio, CONCAT('Precio 2: ',precio2) descripcion FROM cat_inventario WHERE (id = ?) union all
                                                           SELECT precio3 precio, CONCAT('Precio 3: ',precio3) descripcion FROM cat_inventario WHERE (id = ?)">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlProdcutos" Name="id1" PropertyName="SelectedValue" Type="Int32" />
                                                <asp:ControlParameter ControlID="ddlProdcutos" Name="id2" PropertyName="SelectedValue" Type="Int32" />
                                                <asp:ControlParameter ControlID="ddlProdcutos" Name="id3" PropertyName="SelectedValue" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <asp:ImageButton ID="btnActualizarPrecio" runat="server" Height="16px" ImageUrl="~/Images/update.png" Width="18px" />
                                    </td>
                                </tr> 
                                <tr>
                                    <td ></td>
                                    <td  >
                                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" />
                                        <asp:Button ID="btnModificarProducto" runat="server" Text="Modificar" Visible="False" />
                                    </td>
                                </tr> 
                                <tr>
                                    <td ></td>
                                    <td  >
            <asp:Label ID="lblMensajeDetalle" runat="server"></asp:Label>
                                    </td>
                                </tr> 
                        </table>

        </tr> 
        <tr>
        <td  > 
        
             Tipo Pago</td>
        <td   > 
        
             <asp:DropDownList ID="ddlTipoPago" runat="server" DataSourceID="tipoPagoDS" DataTextField="descripcion" DataValueField="id" Width="160px">
                                    </asp:DropDownList> 
                                        <asp:SqlDataSource ID="tipoPagoDS" runat="server" ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" SelectCommand="SELECT id, descripcion FROM cat_tipo_pago"></asp:SqlDataSource>
        
             </td>
        <td  > 
        
             Sub Total:</td>
        <td  > 
        
             <asp:TextBox ID="txtSubTotal" runat="server" Font-Bold="True" Width="100px" ReadOnly="True"></asp:TextBox>
        
             </td>
        <td  > 
        
             </td>
    </tr> 
        <tr>
        <td > 
        
             &nbsp;</td>
        <td  > 
        
             &nbsp;</td>
        <td > 
        
             I.V.A:<asp:CheckBox ID="chkIva" runat="server" Checked="True" />
            </td>
        <td > 
        
             <asp:TextBox ID="txtImpuesto" runat="server" Font-Bold="True" Width="100px" ReadOnly="True"></asp:TextBox>
        
             </td>
        <td > 
                                        <asp:ImageButton ID="btnActualizarPrecio0" runat="server" Height="16px" ImageUrl="~/Images/update.png" Width="18px" />
        </td>
    </tr> 
        <tr>
        <td colspan="2"  > </td>
        <td > 
        
             Total:</td>
        <td > 
        
             <asp:TextBox ID="txtTotal" runat="server" Font-Bold="True" Width="100px" ReadOnly="True"></asp:TextBox>
            </td>
        <td > </td>
    </tr> 
        <tr>
        <td colspan="2"  > 
                                        <asp:Button ID="btnCancelar" runat="server" Text="Facturar" Visible="False" />
            </td>
        <td > 
        &nbsp;</td>
        <td > 
        
             </td>
        <td > </td>
    </tr> 
    </table>
    <hr>
</asp:Content>
