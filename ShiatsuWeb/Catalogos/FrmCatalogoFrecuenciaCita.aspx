<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FrmCatalogoFrecuenciaCita.aspx.vb" Inherits="ShiatsuWeb.FrmCatalogoFrecuenciaCita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Mantenimiento Frecuencia Citas</h3>
   <table>
        <tr>
        <td >Id</td>
        <td >
            <asp:TextBox ID="txtId" runat="server" MaxLength="10" Width="160px"></asp:TextBox>
        </td>
    </tr> 

    <tr>
        <td >Estado</td>
        <td ><asp:DropDownList ID="ddlEstados" runat="server" DataSourceID="" DataTextField="" DataValueField="" Width="160px">
            <asp:ListItem Value="Activo">Activo</asp:ListItem>
            <asp:ListItem Value="Inactivo">Inactivo</asp:ListItem>
                </asp:DropDownList> 
        </td>
    </tr> 
    <tr>
        <td>Descripción</td>
        <td>
            <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="100" Width="160px"></asp:TextBox>
        </td>
    </tr> 
        <tr>
        <td colspan="2" > 
        
             <asp:Button ID="btnAgregar" runat="server" Text="Agregar" />      
             <asp:Button ID="btnModificar" runat="server" Text="Modificar" Visible="False" />
             <br />
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        
        </td>
    </tr> 
    </table>

    <asp:GridView ID="gvDatos" runat="server" AllowPaging="True" AllowSorting="True" CellPadding="4" DataSourceID="frenciasDS" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="id">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" />
            <asp:BoundField DataField="id" HeaderText="Código" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="estado" HeaderText="Estado" SortExpression="estado" />
            <asp:BoundField DataField="descripcion" HeaderText="Descripción" SortExpression="descripcion" HtmlEncode="False" HtmlEncodeFormatString="False" />
             <asp:BoundField DataField="usuario" HeaderText="Usuario" SortExpression="usuario" />
             <asp:BoundField DataField="fmodifica" HeaderText="Fecha Modificación" SortExpression="fmodifica" />
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
    <asp:SqlDataSource ID="frenciasDS" runat="server" 
        ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" 
        ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" 
        DeleteCommand="DELETE FROM  cat_frecuencia_asistencia  WHERE  id  = ?" 
        InsertCommand="INSERT INTO  cat_frecuencia_asistencia  ( id ,  estado , descripcion ) VALUES (?, ?, ?)" 
        SelectCommand="SELECT  id ,  estado ,  descripcion,usuario,fmodifica  FROM  cat_frecuencia_asistencia " 
        UpdateCommand="UPDATE  cat_frecuencia_asistencia  SET  estado  = ?,  descripcion  = ? WHERE  id  = ?">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="id" Type="Int32" />
            <asp:Parameter Name="estado" Type="String" />
            <asp:Parameter Name="descripcion" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="estado" Type="String" />
            <asp:Parameter Name="descripcion" Type="String" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
&nbsp;
</asp:Content>
