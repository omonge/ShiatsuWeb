<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FrmCitas.aspx.vb" Inherits="ShiatsuWeb.FrmCitas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table>
    <tr>
         <td>
             <asp:GridView ID="gvResumen" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="hora" DataSourceID="citasDS" ForeColor="#333333" GridLines="None">
                 <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                 <Columns>
                     <asp:CommandField ShowSelectButton="True" />
                     <asp:BoundField DataField="hora" HeaderText="Hora" ReadOnly="True" SortExpression="hora" />
                     <asp:BoundField DataField="cantidad" HeaderText="Cantidad" SortExpression="cantidad" >
                     <ItemStyle HorizontalAlign="Right" />
                     </asp:BoundField>
                     <asp:BoundField DataField="disponibles" HeaderText="Disponibles" SortExpression="disponibles" >
                         <ItemStyle HorizontalAlign="Right" />
                     </asp:BoundField>
                 </Columns>
                 <EditRowStyle BackColor="#999999" />
                 <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                 <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                 <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                 <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                 <SortedAscendingCellStyle BackColor="#E9E7E2" />
                 <SortedAscendingHeaderStyle BackColor="#506C8C" />
                 <SortedDescendingCellStyle BackColor="#FFFDF8" />
                 <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
             </asp:GridView>
             <asp:SqlDataSource ID="citasDS" runat="server" 
                 ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" 
                 ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" 
                 SelectCommand="select h.hora, 
                            (select count(1) from cita c where c.hora= h.hora and c.fecha = ?) cantidad, 
                            (select 20-count(1) from cita c where c.hora= h.hora and c.fecha = ?)disponibles
                            from cat_hora h
                            order by hora asc">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblFecha" Name="fecha1" PropertyName="Text" Type="String" /> 
                <asp:ControlParameter ControlID="lblFecha" Name="fecha2" PropertyName="Text" Type="String" /> 
            </SelectParameters>
    </asp:SqlDataSource>

             <asp:HiddenField ID="hfHora" runat="server" />
        </td>
        <td>
             <ajaxToolkit:BarChart ID="BarChart1" runat="server" 
                    ChartHeight="300" ChartWidth="450" ChartType="Column"  
                    ChartTitleColor="DarkBlue" BaseLineColor="Black" 
                    ValueAxisLineColor="#Grace"  CategoryAxisLineColor="Grace" Width="450px" >
                    <Series>
                         <ajaxToolkit:BarChartSeries Name="Citas Concretadas " BarColor="Red"  />
                         <ajaxToolkit:BarChartSeries Name="Citas Disponibles" BarColor="Green"  />
                    </Series>
             </ajaxToolkit:BarChart>
             
        </td>
         <td>
             <table>
                 <tr>
                    <td colspan="2"><asp:Label ID="lblFecha" runat="server" Visible="False"></asp:Label>
                        <asp:Calendar ID="calAgenda" runat="server" BackColor="White" BorderColor="White" Font-Names="Verdana" Font-Size="7pt" ForeColor="Black" BorderWidth="1px" NextPrevFormat="FullMonth">
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                            <TitleStyle BackColor="White"   Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                            <TodayDayStyle BackColor="#CCCCCC" />
                        </asp:Calendar>
                     </td>
                </tr>
                  <tr>
                    <td>Id</td>
                    <td><asp:Label ID="lblId" runat="server"></asp:Label>
                    </td>
                </tr> 
                  <tr>
                    <td>Hora</td>
                    <td><asp:DropDownList ID="ddlHoras" runat="server" DataSourceID="horaDB" DataTextField="hora" DataValueField="hora" Width="160px">
                         </asp:DropDownList>
                         <asp:SqlDataSource ID="horaDB" runat="server" ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" SelectCommand="SELECT hora FROM cat_hora ORDER BY hora ASC"></asp:SqlDataSource>
                    </td>
                </tr> 
                  <tr>
                    <td>Estado</td>
                    <td><asp:DropDownList ID="ddlEstados" runat="server" DataSourceID="" DataTextField="" DataValueField="" Width="160px">
                        <asp:ListItem Value="Pendiente">Pendiente</asp:ListItem>
                         </asp:DropDownList>

                    </td>
                </tr>
                 <tr>
                    <td>Cubiculo</td>
                    <td><asp:DropDownList ID="ddlCubiculos" runat="server" DataSourceID="cubiculoDS" DataTextField="cubiculo" DataValueField="cubiculo" Width="160px">
                     
                         </asp:DropDownList>

                        <asp:SqlDataSource ID="cubiculoDS" runat="server" ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" SelectCommand="SELECT cubiculo FROM cat_cubiculo ORDER BY cubiculo"></asp:SqlDataSource>

                    </td>
                </tr>

                <tr>
                    <td>Cliente</td>
                    <td> <asp:DropDownList ID="ddlClientes" runat="server" DataSourceID="clienteDB" DataTextField="nombre" DataValueField="cedcliente" Width="160px">
                         </asp:DropDownList>
                         <asp:SqlDataSource ID="clienteDB" runat="server" ConnectionString="<%$ ConnectionStrings:shiatsuDB %>" ProviderName="<%$ ConnectionStrings:shiatsuDB.ProviderName %>" 
                             SelectCommand="SELECT cedcliente, nombre  FROM cat_cliente ORDER BY nombre ASC"></asp:SqlDataSource>
                    </td>
                </tr>
                   <tr>
                    <td>Observaciones</td>
                    <td>    
                        <asp:TextBox ID="txtObservaciones" runat="server" MaxLength="100" Width="160px" ValidateRequestMode="Disabled"></asp:TextBox>
                       </td>
                </tr>
             </table>    
              <asp:Button ID="btnAgregar" runat="server" Text="Agregar" />      
             <asp:Button ID="btnModificar" runat="server" Text="Modificar" Visible="False" />
             <asp:HiddenField ID="hfHoraActual" runat="server" />
           
             <br>
             <asp:Label ID="lblMensaje" runat="server"></asp:Label>   
             </td>
                     <td>
                      
                     </td>
                 </tr>
                  
    </table>
   

    <h3>Citas del 
        <asp:Label ID="lblFechaTitulo" runat="server"></asp:Label>
        
    </h3> 
    <asp:GridView ID="gvDatos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="agendaDB" Width="100%">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" ShowDeleteButton="true" />
            <asp:BoundField DataField="id" HeaderText="Id" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="hora" HeaderText="Hora" SortExpression="hora" />
            <asp:BoundField DataField="telefono" HeaderText="Teléfono " SortExpression="telefono" />
            <asp:BoundField DataField="cliente" HeaderText="Cliente" SortExpression="cliente" />
            <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
            <asp:BoundField DataField="cubiculo" HeaderText="Cubiculo" SortExpression="cubiculo" > 
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="observaciones" HeaderText="Observaciones" SortExpression="observaciones" HtmlEncode="False" HtmlEncodeFormatString="False" />
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
        SelectCommand="SELECT id, fecha, hora,observaciones, telefono,cliente, (SELECT c.nombre  FROM cat_cliente c WHERE c.cedcliente = cliente ) nombre ,cubiculo FROM cita WHERE (fecha = ?) AND (hora = ?) AND (estado = 'Pendiente') ORDER BY hora ASC">
         <DeleteParameters>
             <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters> 
        <SelectParameters>
            <asp:ControlParameter ControlID="lblFecha" Name="fecha" PropertyName="Text" Type="String" /> 
             <asp:ControlParameter ControlID="hfHora" Name="hora" PropertyName="Value" Type="String" /> 
        </SelectParameters>
    </asp:SqlDataSource>



</asp:Content>
