<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FrmCatalogoCliente.aspx.vb" Inherits="ShiatsuWeb.FrmCatalogoCliente" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   

   
    <style type="text/css">
    .auto-style1 {
        height: 28px;
    }
    .auto-style2 {
        height: 49px;
    }
    .auto-style3 {
        width: 136px;
    }
    .auto-style4 {
        height: 28px;
        width: 136px;
    }
    .auto-style5 {
        height: 49px;
        width: 136px;
    }
</style>
   

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Mantenimiento Provincia</h3>
   <table>
        <tr>
        <td >Diagnóstico</td>
        <td class="auto-style3" >
            <asp:DropDownList ID="ddlDiagnostico" runat="server" DataSourceID="diagnosticoDS" DataTextField="nombre" DataValueField="cedcliente" Width="160px">
                </asp:DropDownList> 
                                        <asp:ImageButton ID="btnActualizarPrecio1" runat="server" Height="16px" ImageUrl="~/Images/update.png" Width="18px" />
            <asp:SqlDataSource ID="diagnosticoDS" runat="server" ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" SelectCommand="SELECT cedcliente, nombre FROM cat_diagnostico"></asp:SqlDataSource>
        </td>
        <td >
            &nbsp;</td>
        <td >
            &nbsp;</td>
    </tr> 

        <tr>
        <td >Identificación</td>
        <td class="auto-style3" >
            <asp:TextBox ID="txtIdentificacion" runat="server" MaxLength="25" Width="160px"></asp:TextBox>
        </td>
        <td >
            Correo Pricipal</td>
        <td >
            <asp:TextBox ID="txtCorreoPrincipal" runat="server" MaxLength="100" Width="160px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCorreoPrincipal" ErrorMessage="Valor incorrecto" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)* "></asp:RegularExpressionValidator>
        </td>
    </tr> 

    <tr>
        <td >Nombre</td>
        <td class="auto-style3" >
            <asp:TextBox ID="txtNombre" runat="server" MaxLength="50" Width="160px"></asp:TextBox>
        </td>
        <td >
            Correo Secundario</td>
        <td >
            <asp:TextBox ID="txtCorreoSecundario" runat="server" MaxLength="100" Width="160px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCorreoSecundario" ErrorMessage="Valor incorrecto" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)* "></asp:RegularExpressionValidator>
        </td>
    </tr> 
    <tr>
        <td>Primer Apellido</td>
        <td class="auto-style3">
            <asp:TextBox ID="txtApellido1" runat="server" MaxLength="50" Width="160px"></asp:TextBox>
            </td>
        <td>
            Telefóno Casa</td>
        <td>
            <asp:TextBox ID="txtTelefonoCasa" runat="server" MaxLength="100" Width="160px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtTelefonoCasa" ErrorMessage="Valor incorrecto" ForeColor="Red" ValidationExpression="^[0-9]{1,8}?$"></asp:RegularExpressionValidator>
            </td>
    </tr> 
       <tr>
        <td class="auto-style1">Segundo Apellido</td>
        <td class="auto-style4">
            <asp:TextBox ID="txtApellido2" runat="server" MaxLength="50" Width="160px"></asp:TextBox>
            </td>
        <td class="auto-style1">
            Telefóno Celular</td>
        <td class="auto-style1">
            <asp:TextBox ID="txtTelefonoCelular" runat="server" MaxLength="100" Width="160px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtTelefonoCelular" ErrorMessage="Valor incorrecto" ForeColor="Red" ValidationExpression="^[0-9]{1,8}?$"></asp:RegularExpressionValidator>
            </td>
    </tr> 
       <tr>
        <td class="auto-style1">Provincia</td>
        <td class="auto-style4">
            <asp:DropDownList ID="ddlProvincia" runat="server" DataSourceID="provinciaDS" DataTextField="descripcion" DataValueField="id" Width="160px">
                </asp:DropDownList> 
            <asp:SqlDataSource ID="provinciaDS" runat="server" ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" SelectCommand="SELECT id, descripcion FROM cat_provincia"></asp:SqlDataSource>
            </td>
        <td class="auto-style1">
            Profesión</td>
        <td class="auto-style1">
            <asp:DropDownList ID="ddlProfesion" runat="server" DataSourceID="profesionDS" DataTextField="descripcion" DataValueField="id" Width="160px">
                </asp:DropDownList> 
            <asp:SqlDataSource ID="profesionDS" runat="server" ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" SelectCommand="SELECT id, descripcion FROM cat_profesion"></asp:SqlDataSource>
            </td>
    </tr> 
       <tr>
        <td class="auto-style2">Cantón</td>
        <td class="auto-style5">
            <asp:DropDownList ID="ddlCanton" runat="server" DataSourceID="cantonDS" DataTextField="descripcion" DataValueField="id" Width="160px">
                </asp:DropDownList> 
                                        <asp:ImageButton ID="btnActualizarPrecio" runat="server" Height="16px" ImageUrl="~/Images/update.png" Width="18px" />
            <asp:SqlDataSource ID="cantonDS" runat="server" ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" SelectCommand="SELECT id, descripcion FROM cat_canton"></asp:SqlDataSource>
            </td>
        <td class="auto-style2">
            Tipo Cliente</td>
        <td class="auto-style2">
            <asp:DropDownList ID="ddlTipocliente" runat="server" DataSourceID="tipoClienteDS" DataTextField="descripcion" DataValueField="id" Width="160px">
                </asp:DropDownList> 
            <asp:SqlDataSource ID="tipoClienteDS" runat="server" ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" SelectCommand="SELECT id, descripcion FROM cat_tipo_cliente"></asp:SqlDataSource>
            </td>
    </tr> 
       <tr>
        <td>Distrito</td>
        <td class="auto-style3">
            <asp:DropDownList ID="ddlDistrito" runat="server" DataSourceID="distrioDS" DataTextField="descripcion" DataValueField="id" Width="160px">
                </asp:DropDownList> 
                                        <asp:ImageButton ID="btnActualizarPrecio0" runat="server" Height="16px" ImageUrl="~/Images/update.png" Width="18px" />
                                    <asp:SqlDataSource ID="distrioDS" runat="server" ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" SelectCommand="SELECT id, descripcion FROM cat_distrito"></asp:SqlDataSource>
            </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr> 
       <tr>
        <td>Dirección</td>
        <td class="auto-style3">
            <asp:TextBox ID="txtDireccion" runat="server" MaxLength="100" Width="160px" Rows="2" TextMode="MultiLine"></asp:TextBox>
            </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
       </tr>
        <tr>
        <td colspan="2" > 
        
             <asp:Button ID="btnAgregar" runat="server" Text="Agregar" />      
             <asp:Button ID="btnModificar" runat="server" Text="Modificar" Visible="False" />
             <br />
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        
        </td>
        <td > 
        
             </td>
        <td > 
        
             </td>
    </tr> 
    </table>

    <asp:GridView ID="gvDatos" runat="server" AllowPaging="True" AllowSorting="True" CellPadding="4" DataSourceID="frenciasDS" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="cedcliente">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" />
            <asp:BoundField DataField="cedcliente" HeaderText="Identificación" ReadOnly="True" SortExpression="cedcliente" />
            <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
            <asp:BoundField DataField="tipo_alopecia" HeaderText="Tipo Alopecia" SortExpression="tipo_alopecia" />
             <asp:BoundField DataField="porcentaje_perdida" HeaderText="Porcentaje Perdida" SortExpression="porcentaje_perdida" />
             <asp:BoundField DataField="dermatitis_oleosa" HeaderText="Dermatitis Oleosa" SortExpression="dermatitis_oleosa" />
            <asp:BoundField DataField="dermatitis_seca" HeaderText="Dermatitis Seca" SortExpression="dermatitis_seca" />
            <asp:BoundField DataField="dermatitis_seborreica" HeaderText="Dermatitis Seborreica" SortExpression="dermatitis_seborreica" />
            <asp:BoundField DataField="caspa" HeaderText="Caspa" SortExpression="caspa" />
            <asp:BoundField DataField="hongo" HeaderText="Hongo" SortExpression="hongo" />
            <asp:BoundField DataField="deshidratacion" HeaderText="Deshidratación" SortExpression="deshidratacion" />
            <asp:BoundField DataField="psoriasis" HeaderText="Psoriasis" SortExpression="psoriasis" />
            <asp:BoundField DataField="telanocitos" HeaderText="Telanocitos" SortExpression="telanocitos" />
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
        DeleteCommand="DELETE FROM cat_diagnostico WHERE cedcliente = ?" 
        InsertCommand="INSERT INTO cat_diagnostico (cedcliente, nombre, tipo_alopecia, porcentaje_perdida, dermatitis_oleosa, dermatitis_seca, dermatitis_seborreica, caspa, hongo, deshidratacion, psoriasis, telanocitos) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)" 
        SelectCommand="SELECT cedcliente, nombre, tipo_alopecia, porcentaje_perdida, dermatitis_oleosa, dermatitis_seca, dermatitis_seborreica, caspa, hongo, deshidratacion, psoriasis, telanocitos FROM cat_diagnostico ORDER BY nombre" 
        UpdateCommand="UPDATE cat_diagnostico SET nombre = ?, tipo_alopecia = ?, porcentaje_perdida = ?, dermatitis_oleosa = ?, dermatitis_seca = ?, dermatitis_seborreica = ?, caspa = ?, hongo = ?, deshidratacion = ?, psoriasis = ?, telanocitos = ? WHERE cedcliente = ?">
        <DeleteParameters>
            <asp:Parameter Name="cedcliente" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="cedcliente" Type="String" />
            <asp:Parameter Name="nombre" Type="String" />
            <asp:Parameter Name="tipo_alopecia" Type="Decimal" />
            <asp:Parameter Name="porcentaje_perdida" Type="Decimal" />
            <asp:Parameter Name="dermatitis_oleosa" Type="String" />
            <asp:Parameter Name="dermatitis_seca" Type="String" />
            <asp:Parameter Name="dermatitis_seborreica" Type="String" />
            <asp:Parameter Name="caspa" Type="String" />
            <asp:Parameter Name="hongo" Type="String" />
            <asp:Parameter Name="deshidratacion" Type="String" />
            <asp:Parameter Name="psoriasis" Type="String" />
            <asp:Parameter Name="telanocitos" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="nombre" Type="String" />
            <asp:Parameter Name="tipo_alopecia" Type="Decimal" />
            <asp:Parameter Name="porcentaje_perdida" Type="Decimal" />
            <asp:Parameter Name="dermatitis_oleosa" Type="String" />
            <asp:Parameter Name="dermatitis_seca" Type="String" />
            <asp:Parameter Name="dermatitis_seborreica" Type="String" />
            <asp:Parameter Name="caspa" Type="String" />
            <asp:Parameter Name="hongo" Type="String" />
            <asp:Parameter Name="deshidratacion" Type="String" />
            <asp:Parameter Name="psoriasis" Type="String" />
            <asp:Parameter Name="telanocitos" Type="String" />
            <asp:Parameter Name="cedcliente" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>

</asp:Content>
