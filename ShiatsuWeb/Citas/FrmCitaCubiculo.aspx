<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FrmCitaCubiculo.aspx.vb" Inherits="ShiatsuWeb.FrmCitaCubiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

   
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    
      <h3>Cistas pendientes cubiculo #<asp:Label ID="lblCubiculoP" runat="server"></asp:Label> </h3>
    <asp:GridView ID="gvDatosP" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="agendaDB">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="id" HeaderText="Id" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="hora" HeaderText="Hora" SortExpression="hora" />
            <asp:BoundField DataField="telefono" HeaderText="Teléfono " SortExpression="telefono" />
            <asp:BoundField DataField="cliente" HeaderText="Cliente" SortExpression="cliente" />
            <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
            <asp:BoundField DataField="cubiculo" HeaderText="Cubiculo" SortExpression="cubiculo" > 
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="observaciones" HeaderText="Observaciones" SortExpression="observaciones" ApplyFormatInEditMode="True" HtmlEncode="False" HtmlEncodeFormatString="False" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
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
        SelectCommand="SELECT id, fecha, hora,observaciones, telefono,cliente, (SELECT CONCAT(c.apellido1,' ', c.apellido2, ' ', c.nombre)   FROM cliente c WHERE c.cedula = cliente ) nombre ,cubiculo FROM cita WHERE (fecha = ?) AND (estado = 'Pendiente') AND (cubiculo=?) ORDER BY hora ASC">
         <DeleteParameters>
             <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters> 
        <SelectParameters>
            <asp:ControlParameter ControlID="hfFecha" Name="fecha" PropertyName="Value" Type="String" /> 
            <asp:ControlParameter ControlID="lblCubiculoP" Name="cubiculo" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

             <asp:HiddenField ID="hfFecha" runat="server" />
           
     <table>
                 <tr>
                    <td >Id</td>
                    <td ><asp:Label ID="lblId" runat="server"></asp:Label></td>
                    <td rowspan="4">

                        <table>
                                <tr>
                                    <td class="auto-style1" >Cantidad</td>
                                    <td class="auto-style1"  >
                                        <asp:TextBox ID="txtCantidad" runat="server" MaxLength="2" TextMode="Number" Width="160px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCantidad" ErrorMessage="Valor incorrecto" ForeColor="Red" ValidationExpression="^[0-9]{1,5}?$"></asp:RegularExpressionValidator>
                                    </td>
                                </tr> 
                                <tr>
                                    <td class="auto-style1" >Prodcuto</td>
                                    <td class="auto-style1"  ><asp:DropDownList ID="ddlProdcutos" runat="server" DataSourceID="InventarioDB" DataTextField="descripcion" DataValueField="id" Width="160px">
                                    <asp:ListItem Value="F">Facturar</asp:ListItem>
                                    </asp:DropDownList> 
                                        <asp:SqlDataSource ID="InventarioDB" runat="server" ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" SelectCommand="SELECT id, CONCAT( descripcion, ' -  Cantidad: ',cantidad   )  descripcion FROM cat_inventario WHERE cantidad > 0"></asp:SqlDataSource>
                                    </td>
                                </tr> 
                                <tr>
                                    <td >&nbsp;</td>
                                    <td  >
                                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" Visible="False" />
             <asp:Button ID="btnModificarProducto" runat="server" Text="Modificar" Visible="False" />
                                    </td>
                                </tr> 
                        </table>


                        <asp:GridView ID="gvProductos" runat="server" CellPadding="4" DataSourceID="productosDS" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="factura,producto" AllowPaging="True" AllowSorting="True">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="factura" HeaderText="Factura" ReadOnly="True" SortExpression="factura" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cantidad" HeaderText="Cantidad" SortExpression="cantidad" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="producto" HeaderText="Producto" ReadOnly="True" SortExpression="producto" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="descripcion" HeaderText="Descripción" ReadOnly="True" SortExpression="descripcion" />
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
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
                            SelectCommand="SELECT  d.factura ,  d.cantidad , d.producto,(select i.descripcion FROM cat_inventario i WHERE i.id = d.producto) descripcion  FROM  factura_detalle d  WHERE ( d.factura  = ?)" 
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
                </tr>
                  <tr>
                    <td >Estado</td>
                    <td  ><asp:DropDownList ID="ddlEstados" runat="server" DataSourceID="" DataTextField="" DataValueField="" Width="160px">
                        <asp:ListItem Value="Factura">Factura</asp:ListItem>
                         </asp:DropDownList>

                    </td>
                </tr>
                   <tr>
                    <td>Observaciones</td>
                    <td>    
                        <asp:TextBox ID="txtObservaciones" runat="server" Height="80px" MaxLength="100" TextMode="MultiLine" Width="160px" ValidateRequestMode="Disabled"></asp:TextBox>
                       </td>
                </tr>
                   <tr>
                    <td colspan="2">      
             <asp:Button ID="btnModificar" runat="server" Text="Modificar" Visible="False" />
                        <br />
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label></td>
                </tr>
             </table>


    
      <h3>Cistas finalizadas cubiculo #<asp:Label ID="lblCubiculoF" runat="server"></asp:Label> </h3>
    <asp:GridView ID="gvDatosF" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="agendaDBFinalizada">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="id" HeaderText="Id" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="hora" HeaderText="Hora" SortExpression="hora" />
            <asp:BoundField DataField="telefono" HeaderText="Teléfono " SortExpression="telefono" />
            <asp:BoundField DataField="cliente" HeaderText="Cliente" SortExpression="cliente" />
            <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
            <asp:BoundField DataField="cubiculo" HeaderText="Cubiculo" SortExpression="cubiculo" > 
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="observaciones" HeaderText="Observaciones" SortExpression="observaciones" ApplyFormatInEditMode="True" HtmlEncode="False" HtmlEncodeFormatString="False" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView> 
    <asp:SqlDataSource ID="agendaDBFinalizada" runat="server" 
        ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" 
        ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" 
        DeleteCommand="DELETE FROM cita WHERE id = ?"
        SelectCommand="SELECT id, fecha, hora,observaciones, telefono,cliente, (SELECT CONCAT(c.apellido1,' ', c.apellido2, ' ', c.nombre)   FROM cliente c WHERE c.cedula = cliente ) nombre ,cubiculo FROM cita WHERE (fecha = ?) AND (estado = 'Factura') AND (cubiculo=?) ORDER BY hora ASC">
         <DeleteParameters>
             <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters> 
        <SelectParameters>
            <asp:ControlParameter ControlID="hfFecha" Name="fecha" PropertyName="Value" Type="String" /> 
            <asp:ControlParameter ControlID="lblCubiculoP" Name="cubiculo" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
