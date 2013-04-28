<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FrmFacturar.aspx.vb" Inherits="ShiatsuWeb.FrmFacturar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
      <h3>Cistas por Facturar</h3>
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
</asp:Content>
