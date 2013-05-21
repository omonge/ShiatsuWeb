<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FrmAgendaIonica.aspx.vb" Inherits="ShiatsuWeb.FrmAgendaIonica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Mantenimiento Agenda Iónica</h3>
   <table>
        <tr>
        <td >Id</td>
        <td >
            <asp:TextBox ID="txtId" runat="server" MaxLength="10" Width="160px" Enabled="False"></asp:TextBox>
        </td>
    </tr> 
    <tr>
        <td>Cliente</td>
        <td>
            <asp:TextBox ID="txtCedCliente" runat="server" MaxLength="10" Width="160px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>Nombre</td>
        <td>
            <asp:TextBox ID="txtNombre" runat="server" MaxLength="100" Width="160px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>Apellidos</td>
        <td>
            <asp:TextBox ID="txtApellidos" runat="server" MaxLength="100" Width="160px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>Hora</td>
        <td>
            <asp:TextBox ID="txtHora" runat="server" MaxLength="10" Width="160px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td >Fecha</td>
        <td > 
         <asp:TextBox ID="txtFecha" runat="server" MaxLength="10" Width="160px"  ></asp:TextBox>
         
        </td> 
    </tr>
    
       <tr>
        <td >Tipo Cliente</td>
        <td >
            <asp:DropDownList ID="ddlTipocliente" runat="server" DataSourceID="tipoClienteDS" DataTextField="descripcion" DataValueField="id" Width="160px">
                </asp:DropDownList> 
            <asp:SqlDataSource ID="tipoClienteDS" runat="server" ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" SelectCommand="SELECT id, concat_ws('-', id, descripcion) as descripcion  FROM cat_tipo_cliente"></asp:SqlDataSource>
        </td>
    </tr> 

    <tr>
        <td>Observaciones</td>
        <td>
            <asp:TextBox ID="txtObservaciones" runat="server" MaxLength="100" Width="160px"></asp:TextBox>
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
            <asp:BoundField DataField="cedCliente" HeaderText="Cédula" SortExpression="cedCliente" />
            <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
            <asp:BoundField DataField="apellidos" HeaderText="Apellidos" SortExpression="apellidos" />
            <asp:BoundField DataField="hora" HeaderText="Hora" SortExpression="hora" />
            <asp:BoundField DataField="fecha" HeaderText="Fecha" SortExpression="fecha" />
            <asp:BoundField DataField="tipoCliente" HeaderText="TipoCliente" SortExpression="tipoCliente" />
            <asp:BoundField DataField="observaciones" HeaderText="Observaciones" SortExpression="observaciones" />
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
        DeleteCommand="DELETE FROM  cat_agenda_ionica  WHERE  id  = ?" 
        InsertCommand="INSERT INTO  cat_agenda_ionica  ( id ,  cedCliente , nombre,apellidos,hora, fecha,  tipoCliente, observaciones ) VALUES (?, ?, ?, ?, ?, ?, ?, ?)" 
        SelectCommand="SELECT  id ,  cedCliente ,  nombre,apellidos,hora,fecha,tipoCliente,observaciones,usuario,fmodifica  FROM  cat_agenda_ionica " 
        UpdateCommand="UPDATE  cat_agenda_ionica  SET  cedcliente=?,nombre=?,apellidos=?,hora=?,fecha=?,tipocliente=?,observaciones=?  WHERE  id  = ?">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="id" Type="Int32" />
            <asp:Parameter Name="cedcliente" Type="String" />
            <asp:Parameter Name="nombre" Type="String" />
            <asp:Parameter Name="apellidos" Type="String" />
             <asp:Parameter Name="hora" Type="Int32" /> 
            <asp:Parameter Name="fecha" Type="DateTime" />
            <asp:Parameter Name="tipoCliente" Type="Int32" /> 
            <asp:Parameter Name="observaciones" Type="String" /> 
        </InsertParameters>
        <UpdateParameters> 
           <asp:Parameter Name="id" Type="Int32" />
            <asp:Parameter Name="cedcliente" Type="String" />
            <asp:Parameter Name="nombre" Type="String" />
            <asp:Parameter Name="apellidos" Type="String" />
             <asp:Parameter Name="hora" Type="Int32" /> 
            <asp:Parameter Name="fecha" Type="DateTime" />
            <asp:Parameter Name="tipoCliente" Type="Int32" /> 
            <asp:Parameter Name="observaciones" Type="String" /> 
        </UpdateParameters>
    </asp:SqlDataSource>
&nbsp;
</asp:Content>
