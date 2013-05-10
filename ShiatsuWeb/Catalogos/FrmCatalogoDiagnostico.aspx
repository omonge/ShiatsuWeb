<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FrmCatalogoDiagnostico.aspx.vb" Inherits="ShiatsuWeb.FrmCatalogoDiagnostico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   

   
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
    </style>
   

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Mantenimiento Provincia</h3>
    <p></p>
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="100%" Width="100%">
        <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
            <HeaderTemplate>
                Datos Personales
            </HeaderTemplate>
            <ContentTemplate>
                <table >
                    <tr>
                        <td >Identificación</td>
                        <td >
                            <asp:TextBox ID="txtIdentificacion" runat="server" MaxLength="25" Width="160px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Nombre</td>
                        <td>
                            <asp:TextBox ID="txtNombre" runat="server" MaxLength="50" Width="160px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Primer Apellido</td>
                        <td>
                            <asp:TextBox ID="txtApellido1" runat="server" MaxLength="50" Width="160px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Segundo Apellido</td>
                        <td>
                            <asp:TextBox ID="txtApellido2" runat="server" MaxLength="50" Width="160px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Estado</td>
                        <td>
                            <asp:DropDownList ID="ddlEstados" runat="server" Width="160px">
                                <asp:ListItem Value="Activo">Activo</asp:ListItem>
                                <asp:ListItem Value="Inactivo">Inactivo</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                   
                    <tr>
                        <td>Observaciones</td>
                        <td>
                            <asp:TextBox ID="txtObservaciones" runat="server" MaxLength="100" Rows="2" TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Diagnóstico
            </HeaderTemplate>
            <ContentTemplate>
                <table>
        <tr>
        <td >
            Dermatitis Oleosa</td>
        <td >
            <asp:TextBox ID="txtDermatitisOleosa" runat="server" MaxLength="100" Width="160px"></asp:TextBox>
        </td>
    </tr> 

    <tr>
        <td >
            Dermatitis Seca</td>
        <td >
            <asp:TextBox ID="txtDermatitisSeca" runat="server" MaxLength="100" Width="160px"></asp:TextBox>
        </td>
    </tr> 
    <tr>
        <td>
            Dermatitis Seborreica</td>
        <td>
            <asp:TextBox ID="txtDermatitisisSeborreica" runat="server" MaxLength="100" Width="160px"></asp:TextBox>
            </td>
    </tr> 
       <tr>
        <td>
            Deshidratación</td>
        <td>
            <asp:TextBox ID="txtDeshidratacion" runat="server" MaxLength="100" Width="160px"></asp:TextBox>
            </td>
    </tr> 
       <tr>
        <td>
            Telanocitos</td>
        <td>
            <asp:TextBox ID="txtTelanocitos" runat="server" MaxLength="100" Width="160px"></asp:TextBox>
            </td>
    </tr> 
       <tr>
        <td class="auto-style3">
            Psoriasis</td>
        <td class="auto-style3">
            <asp:TextBox ID="txtPsoriasis" runat="server" MaxLength="100" Width="160px"></asp:TextBox>
            </td>
    </tr> 
       <tr>
        <td>
            Caspa</td>
        <td>
            <asp:TextBox ID="txtCaspa" runat="server" MaxLength="100" Width="160px"></asp:TextBox>
            </td>
    </tr> 
       <tr>
        <td>
            Hongos</td>
        <td>
            <asp:TextBox ID="txtHongos" runat="server" MaxLength="100" Width="160px"></asp:TextBox>
            </td>
       </tr>
                     <tr>
                        <td>Tipo Alopecia</td>
                        <td>
                            <asp:DropDownList ID="ddlTipoAlopecia" runat="server" DataSourceID="tipoAlopeciaDS" DataTextField="descripcion" DataValueField="id" Width="160px">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="tipoAlopeciaDS" runat="server" ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" SelectCommand="SELECT id, descripcion FROM cat_tipo_alopecia"></asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>Porcentaje de Perdida</td>
                        <td>
                            <asp:TextBox ID="txtIPorcentajePerdida" runat="server" MaxLength="5" TextMode="Number" Width="160px">0.0</asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtIPorcentajePerdida" ErrorMessage="Valor incorrecto" ForeColor="Red" ValidationExpression="[0-9]{0,2}(\.[0-9]{0,2})?$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
    </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
      
    </ajaxToolkit:TabContainer>
   
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" />      
             <asp:Button ID="btnModificar" runat="server" Text="Modificar" Visible="False" />
             <br />
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    <asp:GridView ID="gvDatos" Width="100%" runat="server" AllowPaging="True" AllowSorting="True" CellPadding="4" DataSourceID="frenciasDS" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="cedcliente">
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
