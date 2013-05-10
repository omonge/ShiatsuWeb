<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FrmRegistro.aspx.vb" Inherits="ShiatsuWeb.FrmRegistro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
            <h3>Información de cuenta</h3>

<table>
    <tr>
        <td>
                Usario</td>
        <td >
                <asp:TextBox ID="txtUserName" runat="server" Width="160px" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" 
                    ControlToValidate="txtUserName" ErrorMessage="Valor requerido" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
    </tr>
    <tr>
        <td>
                Nombre</td>
        <td >
                <asp:TextBox ID="txtNombre" runat="server" Width="160px" ></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rfvNombre" runat="server" 
                    ControlToValidate="txtNombre" ErrorMessage="Valor requerido" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
    </tr>
    <tr>
        <td>
                Contraseña</td>
        <td >
                <asp:TextBox ID="txtPassword1" runat="server" CssClass="passwordEntry"  TextMode="Password" Width="160px"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rfvContrasena1" runat="server" 
                    ControlToValidate="txtPassword1" ErrorMessage="Valor requerido" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
    </tr>
    <tr>
        <td>
                Confirmar Contraseña</td>
        <td >
                <asp:TextBox ID="txtPassword2" runat="server" CssClass="passwordEntry"  TextMode="Password" Width="160px"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rfvContrasena2" runat="server" 
                    ControlToValidate="txtPassword2" ErrorMessage="Valor requerido" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="txtPassword2" ControlToValidate="txtPassword1" 
                    ErrorMessage="Las contraseñas no son iguales" ForeColor="Red"></asp:CompareValidator>
            </t
    </tr>
    <tr>
        <td>
                Cubiculo</td>
        <td >
                <asp:DropDownList ID="ddlCubiculos" runat="server" DataSourceID="cubiculoDS" DataTextField="cubiculo" DataValueField="cubiculo" Width="160px">
                     
                         </asp:DropDownList>

                        <asp:SqlDataSource ID="cubiculoDS" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:shiatsuDB %>"
                             ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" SelectCommand="SELECT cubiculo FROM cat_cubiculo ORDER BY cubiculo"></asp:SqlDataSource>

                    <tr>
        <td>
                Caja</td>
        <td >
                <asp:DropDownList ID="ddlCaja" runat="server" DataSourceID="cajaDS" DataTextField="descripcion" DataValueField="id" Width="160px">
                </asp:DropDownList>
                <asp:SqlDataSource ID="cajaDS" runat="server" ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" 
                    ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" 
                    SelectCommand="SELECT 0 as id,'Todos' as descripcion FROM dual
                                   union all
                                   SELECT id, descripcion FROM cat_caja"></asp:SqlDataSource>
            <tr>
        <td>Estado</td>
        <td ><asp:DropDownList ID="ddlEstados" runat="server" DataSourceID="" DataTextField="" DataValueField="" Width="160px">
            <asp:ListItem Value="Activo">Activo</asp:ListItem>
            <asp:ListItem Value="Inactivo">Inactivo</asp:ListItem>
                </asp:DropDownList> 
                </td>
    </tr>
            <tr>
        <td>Perfil</td>
        <td ><asp:DropDownList ID="ddlPerfil" runat="server" DataSourceID="" DataTextField="" DataValueField="" Width="160px">
            <asp:ListItem Value="Administrador">Administrador</asp:ListItem>
            <asp:ListItem>Agenda</asp:ListItem>
            <asp:ListItem Value="Consulta">Consulta</asp:ListItem>
                <asp:ListItem>Facturación</asp:ListItem>
                <asp:ListItem>Cita</asp:ListItem>
                </asp:DropDownList> 
                </td>
    </tr>
</table> 
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" />
             
             <asp:Button ID="btnModificar" runat="server" Text="Modificar" Visible="False" />
             <br />
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
             
            <br />
             <asp:GridView ID="gvDatos" runat="server" CellPadding="4" DataSourceID="usuarioDS" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="usuario">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                 <Columns>
                     <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" />
                     <asp:BoundField DataField="usuario" HeaderText="Usuario" ReadOnly="True" SortExpression="usuario" />
                     <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                     <asp:BoundField DataField="perfil" HeaderText="Perfil" SortExpression="perfil" />
                     <asp:BoundField DataField="cubiculo" HeaderText="Cubiculo" SortExpression="cubiculo" />
                     <asp:BoundField DataField="caja" HeaderText="Caja" SortExpression="caja" />
                     <asp:BoundField DataField="estado" HeaderText="Estado" SortExpression="estado" />
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
         <asp:Label ID="lblError" runat="server"></asp:Label>
           
            <br />
            
            <asp:SqlDataSource ID="usuarioDS" runat="server" 
                ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" 
                DeleteCommand="DELETE FROM cat_usuario WHERE usuario = ?" 
                InsertCommand="INSERT INTO cat_usuario (usuario, password, nombre, perfil, cubiculo, caja, estado) VALUES (?, ?, ?, ?, ?, ?, ?)" 
                ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" 
                SelectCommand="SELECT usuario, password, nombre, perfil, cubiculo, caja, estado, fmodifica FROM cat_usuario" 
                UpdateCommand="UPDATE cat_usuario SET password = ?, nombre = ?, perfil = ?, cubiculo = ?, caja = ?, estado = ? WHERE usuario = ?">
                <DeleteParameters>
                    <asp:Parameter Name="usuario" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="usuario" Type="String" />
                    <asp:Parameter Name="password" Type="String" />
                    <asp:Parameter Name="nombre" Type="String" />
                    <asp:Parameter Name="perfil" Type="String" />
                    <asp:Parameter Name="cubiculo" Type="Int32" />
                    <asp:Parameter Name="caja" Type="Int32" />
                    <asp:Parameter Name="estado" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="password" Type="String" />
                    <asp:Parameter Name="nombre" Type="String" />
                    <asp:Parameter Name="perfil" Type="String" />
                    <asp:Parameter Name="cubiculo" Type="Int32" />
                    <asp:Parameter Name="caja" Type="Int32" />
                    <asp:Parameter Name="estado" Type="String" />
                    <asp:Parameter Name="usuario" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
           
</asp:Content>
