<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FrmCatalogoCanton.aspx.vb" Inherits="ShiatsuWeb.FrmCatalogoCanton" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Mantenimiento Cánton</h3>
   <table>
        <tr>
        <td >Id</td>
        <td class="auto-style1">
            <asp:TextBox ID="txtId" runat="server" MaxLength="10" Width="160px" Enabled="False"></asp:TextBox>
        </td>
    </tr> 

    <tr>
        <td >Estado</td>
        <td class="auto-style1"><asp:DropDownList ID="ddlEstados" runat="server" DataSourceID="" DataTextField="" DataValueField="" Width="160px">
            <asp:ListItem Value="Activo">Activo</asp:ListItem>
            <asp:ListItem Value="Inactivo">Inactivo</asp:ListItem>
                </asp:DropDownList> 
        </td>
    </tr> 

    <tr>
        <td >Provincia</td>
        <td class="auto-style1"><asp:DropDownList ID="ddlProvincia" runat="server" DataSourceID="provinciaDS" DataTextField="descripcion" DataValueField="id" Width="160px">
                </asp:DropDownList> 
            <asp:SqlDataSource ID="provinciaDS" runat="server" ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" SelectCommand="SELECT id, descripcion FROM cat_provincia"></asp:SqlDataSource>
        </td>
    </tr> 
    <tr>
        <td>Descripción</td>
        <td>
            <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="100" Width="160px" ValidateRequestMode="Disabled"></asp:TextBox>
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

    <asp:GridView ID="gvDatos" runat="server" AllowPaging="True" AllowSorting="True" CellPadding="4" DataSourceID="cantonDS" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="id">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" />
            <asp:BoundField DataField="id" HeaderText="Código" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="estado" HeaderText="Estado" SortExpression="estado" />
            <asp:BoundField DataField="descripcion" HeaderText="Cantón" SortExpression="descripcion" HtmlEncode="False" HtmlEncodeFormatString="False" />
            <asp:BoundField DataField="provincia" HeaderText="Provincia" SortExpression="provincia" HtmlEncode="False" HtmlEncodeFormatString="False" />
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
    <asp:SqlDataSource ID="cantonDS" runat="server" 
        ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" 
        ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" 
        DeleteCommand="DELETE FROM  cat_canton  WHERE  id  = ?" 
        InsertCommand="INSERT INTO  cat_canton  ( id ,  estado , descripcion ) VALUES (?, ?, ?)" 
        SelectCommand="SELECT  id , (select CONCAT(id,' - ',descripcion) from cat_provincia where id = provincia) provincia, estado ,  descripcion,usuario,fmodifica  FROM  cat_canton " 
        UpdateCommand="UPDATE  cat_canton  SET  estado  = ?,  descripcion  = ? WHERE  id  = ?">
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


</asp:Content>
