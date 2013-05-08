Public Class FrmCatalogoCliente
    Inherits System.Web.UI.Page
    Dim usuario As Usuario
    Dim clienteDao As ClienteDao = New ClienteDao()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'VERIFICA LA SEGURIDAD
        Usuario = Session("usuario")
        If (Usuario Is Nothing) Then
            Response.Redirect("../Login/FrmLogin.aspx")
        End If
        Me.lblMensaje.Text = ""
    End Sub

      
    Protected Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click

        Select Case Me.ddlDiagnostico.SelectedItem.Text.Split(" ").Length

            Case 2
                Me.txtApellido1.Text = Me.ddlDiagnostico.SelectedItem.Text.Split(" ")(0)
                Me.txtNombre.Text = Me.ddlDiagnostico.SelectedItem.Text.Split(" ")(1)

            Case 3
                Me.txtApellido1.Text = Me.ddlDiagnostico.SelectedItem.Text.Split(" ")(0)
                Me.txtApellido2.Text = Me.ddlDiagnostico.SelectedItem.Text.Split(" ")(1)
                Me.txtNombre.Text = Me.ddlDiagnostico.SelectedItem.Text.Split(" ")(2)

            Case 4
                Me.txtApellido1.Text = Me.ddlDiagnostico.SelectedItem.Text.Split(" ")(0)
                Me.txtApellido2.Text = Me.ddlDiagnostico.SelectedItem.Text.Split(" ")(1)
                Me.txtNombre.Text = Me.ddlDiagnostico.SelectedItem.Text.Split(" ")(2)
                Me.txtNombre.Text += " " + Me.ddlDiagnostico.SelectedItem.Text.Split(" ")(3)
        End Select

        Me.txtIdentificacion.Text = Me.ddlDiagnostico.SelectedItem.Value
    End Sub

    ''' <summary>
    ''' valida los datos antes de insertar y modificar
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function validar() As Boolean
        If (Me.txtIdentificacion.Text = "" Or Me.txtNombre.Text = "") Then
            Me.lblMensaje.ForeColor = Drawing.Color.Red
            Me.lblMensaje.Text = "Valores requeridos"
            Return False
        Else
            Return True
        End If
    End Function

    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If (Me.validar()) Then
                Dim cliente As Cliente = New Cliente()

                cliente.metUsuario = usuario.usuario
                cliente.metEstado = Me.ddlEstado.SelectedValue
                cliente.metFmodifica = DateTime.Now
                cliente.metCedCliente = Me.txtIdentificacion.Text
                cliente.metNombre = Me.txtNombre.Text
                cliente.metFacturaNombre = Me.txtNombreFactura.Text
                cliente.metEmail1 = Me.txtCorreoPrincipal.Text
                cliente.metEmail2 = Me.txtCorreoSecundario.Text
                cliente.metDireccion = Me.txtDireccion.Text
                cliente.metProvincia = CInt(Me.ddlProvincia.SelectedValue)
                cliente.metCanton = CInt(Me.ddlCanton.SelectedValue)
                cliente.metDistrito = CInt(Me.ddlDistrito.SelectedValue)
                cliente.metFechaNacimiento = Convert.ToDateTime(Request.Form("datepicker"))
                cliente.metFrecuenciaCita = Me.ddlFrecuenciaCita.SelectedValue
                cliente.metLugarTrabajo = Me.txtLugarTrabajo.Text
                cliente.metNacionalidad = ""
                cliente.metProfesion = Me.ddlProfesion.Text
                cliente.metSexo = CInt(Me.ddlSexo.SelectedValue)
                cliente.metTelefonoCasa = Me.txtTelefonoCasa.Text
                cliente.metTelefonoCelular = Me.txtTelefonoCelular.Text
                cliente.metTipoAlopecia = CInt(Me.ddlTipoAlopecia.SelectedValue)
                cliente.metTipoCliente = Me.ddlTipocliente.SelectedValue
                 
                Me.clienteDao.insertar(cliente)
                Me.limpiar()
                Me.txtIdentificacion.Enabled = True
                Me.lblMensaje.ForeColor = Drawing.Color.Blue
                Me.lblMensaje.Text = "Registro agregado"
                Me.gvDatos.DataBind() 'refresca los datos
            End If
        Catch ex As Exception
            Me.lblMensaje.ForeColor = Drawing.Color.Red
            Me.lblMensaje.Text = "Error: " + ex.Message
        End Try
        
    End Sub

    ''' <summary>
    ''' limpia los valores al insertar y modificar
    ''' </summary>
    ''' <remarks></remarks>
    Sub limpiar()   
        Me.txtIdentificacion.Text = ""
        Me.txtNombre.Text = ""
        Me.txtNombreFactura.Text = ""
        Me.txtCorreoPrincipal.Text = ""
        Me.txtCorreoSecundario.Text = ""
        Me.txtDireccion.Text = ""
        Me.txtLugarTrabajo.Text = ""
        Me.ddlProfesion.Text = ""
        Me.txtTelefonoCasa.Text = ""
        Me.txtTelefonoCelular.Text = ""

    End Sub

    Protected Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try

            If (Me.validar()) Then
                Dim cliente As Cliente = New Cliente()

                cliente.metUsuario = usuario.usuario
                cliente.metEstado = Me.ddlEstado.SelectedValue
                cliente.metFmodifica = DateTime.Now
                cliente.metCedCliente = Me.txtIdentificacion.Text
                cliente.metNombre = Me.txtNombre.Text
                cliente.metFacturaNombre = Me.txtNombreFactura.Text
                cliente.metEmail1 = Me.txtCorreoPrincipal.Text
                cliente.metEmail2 = Me.txtCorreoSecundario.Text
                cliente.metDireccion = Me.txtDireccion.Text
                cliente.metProvincia = CInt(Me.ddlProvincia.SelectedValue)
                cliente.metCanton = CInt(Me.ddlCanton.SelectedValue)
                cliente.metDistrito = CInt(Me.ddlDistrito.SelectedValue)
                cliente.metFechaNacimiento = ""
                cliente.metFrecuenciaCita = Me.ddlFrecuenciaCita.SelectedValue
                cliente.metLugarTrabajo = Me.txtLugarTrabajo.Text
                cliente.metNacionalidad = ""
                cliente.metProfesion = Me.ddlProfesion.Text
                cliente.metSexo = CInt(Me.ddlSexo.SelectedValue)
                cliente.metTelefonoCasa = Me.txtTelefonoCasa.Text
                cliente.metTelefonoCelular = Me.txtTelefonoCelular.Text
                cliente.metTipoAlopecia = CInt(Me.ddlTipoAlopecia.SelectedValue)
                cliente.metTipoCliente = Me.ddlTipocliente.SelectedValue

                Me.clienteDao.modificar(cliente)

                Me.limpiar()
                Me.lblMensaje.ForeColor = Drawing.Color.Blue
                Me.lblMensaje.Text = "Registro modificado"

                Me.txtIdentificacion.Enabled = True
                Me.btnAgregar.Visible = True
                Me.btnModificar.Visible = False
                Me.gvDatos.DataBind() 'refresca los datos
            End If

        Catch ex As Exception
            Me.lblMensaje.ForeColor = Drawing.Color.Red
            Me.lblMensaje.Text = "Error: " + ex.Message
        End Try
    End Sub

    Protected Sub gvDatos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvDatos.SelectedIndexChanged
        Try
            Me.btnModificar.Visible = True
            Me.btnAgregar.Visible = False
            Me.txtIdentificacion.Enabled = False
            Dim cliente As Cliente = New Cliente()
            cliente.metCedCliente = Me.gvDatos.SelectedRow.Cells(4).Text
            cliente = Me.clienteDao.consulta(cliente)



            Me.ddlEstado.SelectedValue = cliente.metEstado
            Me.txtIdentificacion.Text = cliente.metCedCliente

            Select Case cliente.metNombre.Split(" ").Length

                Case 2
                    Me.txtApellido1.Text = cliente.metNombre.Split(" ")(0)
                    Me.txtNombre.Text = cliente.metNombre.Split(" ")(1)

                Case 3
                    Me.txtApellido1.Text = cliente.metNombre.Split(" ")(0)
                    Me.txtApellido2.Text = cliente.metNombre.Split(" ")(1)
                    Me.txtNombre.Text = cliente.metNombre.Split(" ")(2)

                Case 4
                    Me.txtApellido1.Text = cliente.metNombre.Split(" ")(0)
                    Me.txtApellido2.Text = cliente.metNombre.Split(" ")(1)
                    Me.txtNombre.Text = cliente.metNombre.Split(" ")(2)
                    Me.txtNombre.Text += " " + cliente.metNombre.Split(" ")(3)
            End Select
             
            Me.txtNombreFactura.Text = cliente.metFacturaNombre
            Me.txtCorreoPrincipal.Text = cliente.metEmail1
            Me.txtCorreoSecundario.Text = cliente.metEmail2
            Me.txtDireccion.Text = cliente.metDireccion

            Me.ddlProvincia.Text = cliente.metProvincia
            Me.ddlCanton.Text = cliente.metCanton
            Me.ddlDistrito.Text = cliente.metDistrito
            Me.ddlFrecuenciaCita.Text = cliente.metFrecuenciaCita
            Me.txtLugarTrabajo.Text = cliente.metLugarTrabajo
            'Me.dd.Text = Me.gvDatos.SelectedRow.Cells(16).Text nacionalidad

            '13 <asp:BoundField DataField="fecha_nacimiento" HeaderText="fecha_nacimiento" SortExpression="fecha_nacimiento" Visible="False" />
            Me.ddlProfesion.Text = cliente.metProfesion
            Me.ddlSexo.SelectedValue = cliente.metSexo
            Me.txtTelefonoCasa.Text = cliente.metTelefonoCasa
            Me.txtTelefonoCelular.Text = cliente.metTelefonoCelular
            Me.ddlTipoAlopecia.Text = cliente.metTipoAlopecia
            Me.ddlTipocliente.Text = cliente.metTipoCliente

        Catch ex As Exception
            Me.lblMensaje.ForeColor = Drawing.Color.Red
            Me.lblMensaje.Text = "Error: " + ex.Message
        End Try
    End Sub
End Class