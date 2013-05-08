<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FrmCatalogoCliente.aspx.vb" Inherits="ShiatsuWeb.FrmCatalogoCliente" %> 
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Mantenimiento Cliente</h3>
   <table>
        <tr>
        <td >Diagnóstico</td>
        <td  >
            <asp:DropDownList ID="ddlDiagnostico" runat="server" DataSourceID="diagnosticoDS" DataTextField="nombre" DataValueField="cedcliente" Width="160px">
                </asp:DropDownList> 
            <asp:SqlDataSource ID="diagnosticoDS" runat="server"
                 ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" 
                ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>"
                 SelectCommand="SELECT cedcliente, nombre FROM cat_diagnostico"></asp:SqlDataSource>
        </td>
        <td >
               <asp:Button ID="btnCargar" runat="server" Text="Cargar" />
            </td>
        <td >
            </td>
    </tr> 

        <tr>
        <td >Identificación</td>
        <td  >
            <asp:TextBox ID="txtIdentificacion" runat="server" MaxLength="25" Width="160px" Enabled="False"></asp:TextBox>
        </td>
        <td >
            Correo Pricipal</td>
        <td >
            <asp:TextBox ID="txtCorreoPrincipal" runat="server" MaxLength="100" Width="160px" ToolTip="corre@dominio.com"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCorreoPrincipal" ErrorMessage="Valor incorrecto" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </td>
    </tr> 

    <tr>
        <td >Nombre</td>
        <td  >
            <asp:TextBox ID="txtNombre" runat="server" MaxLength="50" Width="160px" Enabled="False"></asp:TextBox>
        </td>
        <td >
            Correo Secundario</td>
        <td >
            <asp:TextBox ID="txtCorreoSecundario" runat="server" MaxLength="100" Width="160px" ToolTip="corre@dominio.com"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCorreoSecundario" ErrorMessage="Valor incorrecto" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </td>
    </tr> 
    <tr>
        <td>Primer Apellido</td>
        <td >
            <asp:TextBox ID="txtApellido1" runat="server" MaxLength="50" Width="160px" Enabled="False"></asp:TextBox>
            </td>
        <td>
            Telefóno Casa</td>
        <td>
            <asp:TextBox ID="txtTelefonoCasa" runat="server" MaxLength="100" Width="160px" ToolTip="+50622334455"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtTelefonoCasa" ErrorMessage="Valor incorrecto" ForeColor="Red" ValidationExpression="^[+-]?\d+(\.\d+)?$"></asp:RegularExpressionValidator>
            </td>
    </tr> 
       <tr>
        <td >Segundo Apellido</td>
        <td >
            <asp:TextBox ID="txtApellido2" runat="server" MaxLength="50" Width="160px" Enabled="False"></asp:TextBox>
            </td>
        <td >
            Telefóno Celular</td>
        <td >
            <asp:TextBox ID="txtTelefonoCelular" runat="server" MaxLength="100" Width="160px" ToolTip="+50622334455"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtTelefonoCelular" ErrorMessage="Valor incorrecto" ForeColor="Red" ValidationExpression="^[+-]?\d+(\.\d+)?$"></asp:RegularExpressionValidator>
            </td>
    </tr> 
       <tr>
        <td >Sexo</td>
        <td >
            <asp:DropDownList ID="ddlSexo" runat="server"   Width="160px">
                <asp:ListItem>Masculino</asp:ListItem>
                <asp:ListItem>Femenino</asp:ListItem>
                </asp:DropDownList> 
            </td>
        <td >
            Lugar de Trabajo</td>
        <td >
            <asp:TextBox ID="txtLugarTrabajo" runat="server" MaxLength="100" Width="160px"></asp:TextBox>
            </td>
    </tr> 
       <tr>
        <td >Fecha Nacimiento</td>
        <td > 
         <asp:TextBox ID="txtFechaNacimiento" runat="server" MaxLength="50" Width="160px"  ></asp:TextBox>
         
            <asp:CalendarExtender ID="txtFechaNacimiento_CalendarExtender" runat="server" TargetControlID="txtFechaNacimiento">
            </asp:CalendarExtender>
        
    
        
        </td>
        <td >
            Nombre Factura</td>
        <td >
            <asp:TextBox ID="txtNombreFactura" runat="server" MaxLength="100" Width="160px"></asp:TextBox>
            </td>
    </tr> 
       <tr>
        <td ></td>
        <td >
            </td>
        <td >
            Tipo Alopecia</td>
        <td >
            <asp:DropDownList ID="ddlTipoAlopecia" runat="server"   Width="160px" DataSourceID="tipoAlopecia" DataTextField="descripcion" DataValueField="id">
                </asp:DropDownList> 
            <asp:SqlDataSource ID="tipoAlopecia" runat="server" ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" SelectCommand="SELECT id, descripcion FROM cat_tipo_alopecia"></asp:SqlDataSource>
            </td>
    </tr> 
       <tr>
        <td >Provincia</td>
        <td >
            <asp:DropDownList ID="ddlProvincia" runat="server" DataSourceID="provinciaDS" DataTextField="descripcion" DataValueField="id" Width="160px">
                </asp:DropDownList> 
            <asp:SqlDataSource ID="provinciaDS" runat="server" ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" SelectCommand="SELECT id, descripcion FROM cat_provincia"></asp:SqlDataSource>
            </td>
        <td >
            Profesión</td>
        <td >
            <asp:DropDownList ID="ddlProfesion" runat="server" DataSourceID="profesionDS" DataTextField="descripcion" DataValueField="id" Width="160px">
                </asp:DropDownList> 
            <asp:SqlDataSource ID="profesionDS" runat="server" ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" SelectCommand="SELECT id, descripcion FROM cat_profesion"></asp:SqlDataSource>
            </td>
    </tr> 
       <tr>
        <td >Cantón</td>
        <td >
            <asp:DropDownList ID="ddlCanton" runat="server" DataSourceID="cantonDS" DataTextField="descripcion" DataValueField="id" Width="160px">
                </asp:DropDownList> 
                                        <asp:ImageButton ID="btnActualizarPrecio" runat="server" Height="16px" ImageUrl="~/Images/update.png" Width="18px" />
            <asp:SqlDataSource ID="cantonDS" runat="server" ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" 
                ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" 
                SelectCommand="SELECT id, descripcion FROM cat_canton WHERE (provincia = ?)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlProvincia" Name="provincia" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            </td>
        <td >
            Tipo Cliente</td>
        <td >
            <asp:DropDownList ID="ddlTipocliente" runat="server" DataSourceID="tipoClienteDS" DataTextField="descripcion" DataValueField="id" Width="160px">
                </asp:DropDownList> 
            <asp:SqlDataSource ID="tipoClienteDS" runat="server" ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" SelectCommand="SELECT id, descripcion FROM cat_tipo_cliente"></asp:SqlDataSource>
            </td>
    </tr> 
       <tr>
        <td>Distrito</td>
        <td >
            <asp:DropDownList ID="ddlDistrito" runat="server" DataSourceID="distrioDS" DataTextField="descripcion" DataValueField="id" Width="160px">
                </asp:DropDownList> 
                                        <asp:ImageButton ID="btnActualizarPrecio0" runat="server" Height="16px" ImageUrl="~/Images/update.png" Width="18px" />
                                    <asp:SqlDataSource ID="distrioDS" runat="server" ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" 
                                        ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" 
                                        SelectCommand="SELECT id, descripcion FROM cat_distrito WHERE ((provincia = ?) AND (canton = ?))">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlProvincia" Name="provincia" PropertyName="SelectedValue" Type="Int32" />
                                            <asp:ControlParameter ControlID="ddlCanton" Name="canton" PropertyName="SelectedValue" Type="Int32" />
                                        </SelectParameters>
            </asp:SqlDataSource>
            </td>
        <td>
            Frecuencia Cita</td>
        <td>
            <asp:DropDownList ID="ddlFrecuenciaCita" runat="server" DataSourceID="frecuenciaCita" DataTextField="descripcion" DataValueField="id" Width="160px">
                </asp:DropDownList> 
            <asp:SqlDataSource ID="frecuenciaCita" runat="server" ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" SelectCommand="SELECT id, descripcion FROM cat_frecuencia_asistencia"></asp:SqlDataSource>
           </td>
    </tr> 
       <tr>
        <td>Dirección</td>
        <td >
            <asp:TextBox ID="txtDireccion" runat="server" MaxLength="100" Width="160px" Rows="2" TextMode="MultiLine"></asp:TextBox>
            </td>
        <td>
            Estado</td>
        <td>
            <asp:DropDownList ID="ddlEstado" runat="server"   Width="160px">
                <asp:ListItem Selected="True">Activo</asp:ListItem>
                <asp:ListItem>Inactivo</asp:ListItem>
                </asp:DropDownList> 
            </td>
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
            <asp:BoundField DataField="usuario" HeaderText="usuario" SortExpression="usuario" Visible="False" />
            <asp:BoundField DataField="estado" HeaderText="Estado" SortExpression="estado" />
            <asp:BoundField DataField="fmodifica" HeaderText="fmodifica" SortExpression="fmodifica" Visible="False" />
             <asp:BoundField DataField="cedcliente" HeaderText="Identificación" SortExpression="cedcliente" ReadOnly="True" />
             <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" HtmlEncode="False" HtmlEncodeFormatString="False" />
            <asp:BoundField DataField="nombre_factura" HeaderText="Nombre Factura" SortExpression="nombre_factura"  HtmlEncode="False" HtmlEncodeFormatString="False" />
            <asp:BoundField DataField="email1" HeaderText="Correo" SortExpression="email1"  HtmlEncode="False" HtmlEncodeFormatString="False" />
            <asp:BoundField DataField="email2" HeaderText="email2" SortExpression="email2" Visible="False"   HtmlEncode="False" HtmlEncodeFormatString="False" />
            <asp:BoundField DataField="direccion" HeaderText="direccion" SortExpression="direccion" Visible="False" HtmlEncode="False" HtmlEncodeFormatString="False" /> 
            <asp:BoundField DataField="provincia" HeaderText="provincia" SortExpression="provincia" Visible="False"  />
            <asp:BoundField DataField="canton" HeaderText="canton" SortExpression="canton"  Visible="False"/>
            <asp:BoundField DataField="distrito" HeaderText="distrito" SortExpression="distrito" Visible="False"/>
            <asp:BoundField DataField="fecha_nacimiento" HeaderText="fecha_nacimiento" SortExpression="fecha_nacimiento" Visible="False" />
            <asp:BoundField DataField="frecuencia_cita" HeaderText="frecuencia_cita" SortExpression="frecuencia_cita" Visible="False"  />
            <asp:BoundField DataField="lugar_profesion" HeaderText="lugar_profesion" SortExpression="lugar_profesion" Visible="False"  HtmlEncode="False" HtmlEncodeFormatString="False" />
            <asp:BoundField DataField="nacionalidad" HeaderText="nacionalidad" SortExpression="nacionalidad" Visible="False" />
            <asp:BoundField DataField="profesion" HeaderText="profesion" SortExpression="profesion"  Visible="False"/>
            <asp:BoundField DataField="sexo" HeaderText="Sexo" SortExpression="sexo" />
            <asp:BoundField DataField="telefono_casa" HeaderText="Teléfono Casa" SortExpression="telefono_casa" />
            <asp:BoundField DataField="telefono_celular" HeaderText="Teléfono Celular" SortExpression="telefono_celular" />
            <asp:BoundField DataField="tipo_alopecia" HeaderText="tipo_alopecia" SortExpression="tipo_alopecia" Visible="False" />
            <asp:BoundField DataField="tipo_cliente" HeaderText="tipo_cliente" SortExpression="tipo_cliente" Visible="False" />
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
        DeleteCommand="DELETE FROM cat_cliente WHERE cedcliente = ?" 
        InsertCommand="INSERT INTO cat_cliente (cedcliente, nombre, tipo_alopecia, porcentaje_perdida, dermatitis_oleosa, dermatitis_seca, dermatitis_seborreica, caspa, hongo, deshidratacion, psoriasis, telanocitos) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)" 
        SelectCommand="SELECT usuario,estado,fmodifica,cedcliente,nombre,nombre_factura,
                            email1, email2, direccion, provincia, canton, distrito,fecha_nacimiento, frecuencia_cita, lugar_profesion,nacionalidad,
                            profesion,sexo,telefono_casa,telefono_casa,telefono_celular,tipo_alopecia,tipo_cliente FROM cat_cliente ORDER BY nombre" 
        UpdateCommand="UPDATE cat_cliente SET nombre = ?, tipo_alopecia = ?, porcentaje_perdida = ?, dermatitis_oleosa = ?, dermatitis_seca = ?, dermatitis_seborreica = ?, caspa = ?, hongo = ?, deshidratacion = ?, psoriasis = ?, telanocitos = ? WHERE cedcliente = ?">
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
