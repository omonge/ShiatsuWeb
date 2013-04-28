<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FrmLogin.aspx.vb" Inherits="ShiatsuWeb.FrmLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
        <table align="center" >
           <tr>
            <td colspan="2" >
            <h2>Información de cuenta</h2>
            </td>
            </tr>
        <tr>
            <td>
                Usuario</td>
            <td>
                <asp:TextBox ID="txtIdentificacion" runat="server" style="margin-left: 0px" 
                    MaxLength="255"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtIdentificacion" ErrorMessage="Valor requerido" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Contraseña</td>
            <td>
                <asp:TextBox ID="txtContrasena" runat="server" MaxLength="255" 
                    ToolTip="Ejemplo: 12345678" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtContrasena" ErrorMessage="Valor requerido" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnValidar" runat="server" style="margin-right: 5px; text-align: center;" 
                    Text="Iniciar sesión" />
                 </td>
        </tr> 
        <tr>
            <td colspan="2" align="center">
                <asp:HyperLink ID="hlk" runat="server" NavigateUrl="~/Registrar.aspx">Registrar</asp:HyperLink>
                 </td>
        </tr> 
        <tr>
            <td colspan="2" align="center">
         <asp:Label ID="lblError" runat="server"></asp:Label>
                 </td>
        </tr> 
        </table>
</asp:Content>
