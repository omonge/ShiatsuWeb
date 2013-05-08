Public Class FrmCatalogoDiagnostico
    Inherits System.Web.UI.Page
    Dim usuario As Usuario
    Dim diagnosticoDao As DiagnosticoDao = New DiagnosticoDao()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'VERIFICA LA SEGURIDAD
        usuario = Session("usuario")
        If (usuario Is Nothing) Then
            Response.Redirect("../Login/FrmLogin.aspx")
        End If
        Me.lblMensaje.Text = ""
    End Sub


    ''' <summary>
    ''' este evento se ejecuta al agregar
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If (Me.validar()) Then
                Dim diagnostico As Diagnostico = New Diagnostico()

                diagnostico.metEstado = Me.ddlEstados.SelectedValue
                diagnostico.metCaspa = Me.txtCaspa.Text
                diagnostico.metFmodifica = DateTime.Now
                diagnostico.metUsuario = Me.usuario.usuario
                diagnostico.metCedCliente = Me.txtIdentificacion.Text
                diagnostico.metDermatitisOleosa = Me.txtDermatitisOleosa.Text
                diagnostico.metDermatitisSeborreica = Me.txtDermatitisisSeborreica.Text
                diagnostico.metDermatitisSeca = Me.txtDermatitisSeca.Text
                diagnostico.metDeshidratacion = Me.txtDeshidratacion.Text
                diagnostico.metHongo = Me.txtHongos.Text
                diagnostico.metNombre = Me.txtApellido1.Text + " " + Me.txtApellido2.Text + " " + Me.txtNombre.Text
                diagnostico.metObservaciones = Me.txtObservaciones.Text
                diagnostico.metPorcentajePerdida = CDbl(Me.txtIPorcentajePerdida.Text)
                diagnostico.metPsoriasis = Me.txtPsoriasis.Text
                diagnostico.metTelanocitos = Me.txtTelanocitos.Text
                diagnostico.metTipoAlopecia.metId = CInt(Me.ddlTipoAlopecia.SelectedItem.Value)

                Me.diagnosticoDao.insertar(diagnostico)
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

    ''' <summary>
    ''' limpia los valores al insertar y modificar
    ''' </summary>
    ''' <remarks></remarks>
    Sub limpiar()
        Me.txtIdentificacion.Text = ""
        Me.txtObservaciones.Text =
        Me.txtNombre.Text = ""
        Me.txtApellido1.Text = ""
        Me.txtApellido2.Text = ""
        Me.txtIPorcentajePerdida.Text = "0.0"
        Me.txtDermatitisOleosa.Text = ""
        Me.txtDermatitisSeca.Text = ""
        Me.txtDermatitisisSeborreica.Text = ""
        Me.txtCaspa.Text = ""
        Me.txtHongos.Text = ""
        Me.txtDeshidratacion.Text = ""
        Me.txtPsoriasis.Text = ""
        Me.txtTelanocitos.Text = ""
        Me.txtObservaciones.Text = ""
    End Sub

    ''' <summary>
    ''' este evento se ejecuta al modificar
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try

            If (Me.validar()) Then
                Dim diagnostico As Diagnostico = New Diagnostico()

                diagnostico.metEstado = Me.ddlEstados.SelectedValue
                diagnostico.metCaspa = Me.txtCaspa.Text
                diagnostico.metFmodifica = DateTime.Now
                diagnostico.metUsuario = Me.usuario.usuario
                diagnostico.metCedCliente = Me.txtIdentificacion.Text
                diagnostico.metDermatitisOleosa = Me.txtDermatitisOleosa.Text
                diagnostico.metDermatitisSeborreica = Me.txtDermatitisisSeborreica.Text
                diagnostico.metDermatitisSeca = Me.txtDermatitisSeca.Text
                diagnostico.metDeshidratacion = Me.txtDeshidratacion.Text
                diagnostico.metHongo = Me.txtHongos.Text
                diagnostico.metNombre = Me.txtApellido1.Text + " " + Me.txtApellido2.Text + " " + Me.txtNombre.Text
                diagnostico.metObservaciones = Me.txtObservaciones.Text
                diagnostico.metPorcentajePerdida = CDbl(Me.txtIPorcentajePerdida.Text)
                diagnostico.metPsoriasis = Me.txtPsoriasis.Text
                diagnostico.metTelanocitos = Me.txtTelanocitos.Text
                diagnostico.metTipoAlopecia.metId = CInt(Me.ddlTipoAlopecia.SelectedItem.Value)

                Me.diagnosticoDao.modificar(diagnostico)

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


    ''' <summary>
    ''' este evento se ejecuta al seleccionar en el data table
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub gvDatos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvDatos.SelectedIndexChanged
        Try
            Me.btnModificar.Visible = True
            Me.btnAgregar.Visible = False
            Me.txtIdentificacion.Enabled = False 
            Me.txtIdentificacion.Text = Me.gvDatos.SelectedRow.Cells(1).Text

            Select Case Me.gvDatos.SelectedRow.Cells(2).Text.Split(" ").Length

                Case 2
                    Me.txtApellido1.Text = Me.gvDatos.SelectedRow.Cells(2).Text.Split(" ")(0)
                    Me.txtNombre.Text = Me.gvDatos.SelectedRow.Cells(2).Text.Split(" ")(1) 

                Case 3
                    Me.txtApellido1.Text = Me.gvDatos.SelectedRow.Cells(2).Text.Split(" ")(0)
                    Me.txtApellido2.Text = Me.gvDatos.SelectedRow.Cells(2).Text.Split(" ")(1)
                    Me.txtNombre.Text = Me.gvDatos.SelectedRow.Cells(2).Text.Split(" ")(2)

                Case 4
                    Me.txtApellido1.Text = Me.gvDatos.SelectedRow.Cells(2).Text.Split(" ")(0)
                    Me.txtApellido2.Text = Me.gvDatos.SelectedRow.Cells(2).Text.Split(" ")(1)
                    Me.txtNombre.Text = Me.gvDatos.SelectedRow.Cells(2).Text.Split(" ")(2)
                    Me.txtNombre.Text += " " + Me.gvDatos.SelectedRow.Cells(2).Text.Split(" ")(3)
            End Select

           
            Me.ddlTipoAlopecia.Text = Me.gvDatos.SelectedRow.Cells(3).Text
            Me.txtIPorcentajePerdida.Text = Me.gvDatos.SelectedRow.Cells(4).Text
            Me.txtDermatitisOleosa.Text = Me.gvDatos.SelectedRow.Cells(5).Text
            Me.txtDermatitisSeca.Text = Me.gvDatos.SelectedRow.Cells(6).Text
            Me.txtDermatitisisSeborreica.Text = Me.gvDatos.SelectedRow.Cells(7).Text
            Me.txtCaspa.Text = Me.gvDatos.SelectedRow.Cells(8).Text
            Me.txtHongos.Text = Me.gvDatos.SelectedRow.Cells(9).Text
            Me.txtDeshidratacion.Text = Me.gvDatos.SelectedRow.Cells(10).Text
            Me.txtPsoriasis.Text = Me.gvDatos.SelectedRow.Cells(11).Text
            Me.txtTelanocitos.Text = Me.gvDatos.SelectedRow.Cells(12).Text
            ' Me.txtObservaciones.Text = Me.gvDatos.SelectedRow.Cells(13).Text


        Catch ex As Exception
            Me.lblMensaje.ForeColor = Drawing.Color.Red
            Me.lblMensaje.Text = "Error: " + ex.Message
        End Try
    End Sub

End Class