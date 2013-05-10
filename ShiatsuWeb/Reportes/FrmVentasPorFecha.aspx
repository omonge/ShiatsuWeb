<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FrmVentasPorFecha.aspx.vb" Inherits="ShiatsuWeb.FrmVentasPorFecha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table  >
        <tr>
            <td>Fecha Inicio</td>
            <td>
                <asp:TextBox ID="txtFechaInicio" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="txtFechaInicio_CalendarExtender" Format="yyyyMMdd" runat="server" TargetControlID="txtFechaInicio">
                </ajaxToolkit:CalendarExtender>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>Fecha Fin</td>
            <td>
                <asp:TextBox ID="txtFechaFin" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="txtFechaFin_CalendarExtender" Format="yyyyMMdd" runat="server" TargetControlID="txtFechaFin">
                </ajaxToolkit:CalendarExtender>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Caja</td>
            <td>
                <asp:DropDownList ID="ddlCaja" runat="server" DataSourceID="cajaDS" DataTextField="descripcion" DataValueField="id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="cajaDS" runat="server" ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" 
                    ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" 
                    SelectCommand="SELECT 0 as id,'Todos' as descripcion FROM dual
                                   union all
                                   SELECT id, descripcion FROM cat_caja"></asp:SqlDataSource>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>Tipo Pago</td>
            <td>
        
             <asp:DropDownList ID="ddlTipoPago" runat="server" DataSourceID="tipoPagoDS" DataTextField="descripcion" DataValueField="id" Width="160px">
                                    </asp:DropDownList> 
                                        <asp:SqlDataSource ID="tipoPagoDS" runat="server" ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>"
                                             SelectCommand="SELECT 0 as id,'Todos' as descripcion FROM dual
                                                       union all SELECT id, descripcion FROM cat_tipo_pago"></asp:SqlDataSource>
        
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td >
               
            </td>
            <td colspan="2" >
                <asp:Button ID="btnConsultat" runat="server" Text="Consulta" />
            </td>
        </tr>
        <tr>
            <td colspan="3" >
               
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
               
            </td>
        </tr>
    </table>
    <hr>
    <h3>Reporte de Ventas por Caja</h3>
     <asp:GridView ID="gvDatos" runat="server" CellPadding="4" DataSourceID="consultaDS" ForeColor="#333333" AutoGenerateColumns="False" DataKeyNames="factura" BorderStyle="Solid" BorderWidth="1px" ShowFooter="True">
         <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
         <Columns>
             <asp:BoundField DataField="factura" HeaderText="Factura" ReadOnly="True" SortExpression="factura" >
             <ItemStyle HorizontalAlign="Right" />
             </asp:BoundField>
             <asp:BoundField DataField="caja" HeaderText="Caja" SortExpression="caja" >
             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>
             <asp:BoundField DataField="fecha" HeaderText="Fecha" SortExpression="fecha" />
             <asp:BoundField DataField="cliente" HeaderText="Id Cliente" SortExpression="cliente" />
             <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
             <asp:BoundField DataField="tipo_pago" HeaderText="Tipo" SortExpression="tipo_pago" />
             <asp:BoundField DataField="subtotal" HeaderText="Sub Total" SortExpression="subtotal" DataFormatString="{0:c}" >
                              <ItemStyle HorizontalAlign="Right" />
             </asp:BoundField>
             <asp:BoundField DataField="iva" HeaderText="Impuesto" SortExpression="iva"  DataFormatString="{0:c}" >
                              <ItemStyle HorizontalAlign="Right" />
             </asp:BoundField>
             <asp:BoundField DataField="total" HeaderText="Total" SortExpression="total" DataFormatString="{0:c}" >
             <ItemStyle HorizontalAlign="Right" />
             </asp:BoundField>
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
    <asp:SqlDataSource ID="consultaDS" runat="server" 
        ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" 
        ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" 
        SelectCommand="SELECT e.factura, e.caja, e.fecha, e.cliente,
                        (SELECT c.nombre_factura FROM cat_cliente c WHERE c. cedcliente=e.cliente) nombre,
                        (SELECT c.descripcion FROM cat_tipo_pago c WHERE c.id =e.tipo_pago) tipo_pago,
                        e.subtotal, e.iva, e.total 
                        FROM factura_encabezado e
                        WHERE e.estado = 'XXX' "> 
    </asp:SqlDataSource>
</asp:Content>
