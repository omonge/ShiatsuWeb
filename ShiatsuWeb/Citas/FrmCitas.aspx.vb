Public Class FrmCitas
    Inherits System.Web.UI.Page
    Dim usuario As Usuario
    Dim citaDao As CitaDao = New CitaDao()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'VERIFICA LA SEGURIDAD
        usuario = Session("usuario")
        If (usuario Is Nothing) Then
            Response.Redirect("../Login/FrmLogin.aspx")
        End If

        If (Me.lblFecha.Text = "") Then
            Me.lblFecha.Text = DateTime.Now.ToString("yyyyMMdd")
            Me.lblFechaTitulo.Text = Date.Now.ToLongDateString()
            Me.hfHora.Value = DateTime.Now.ToString("HH:00")
            Me.graficar()
        End If
        Me.hfHoraActual.Value = DateTime.Now.ToString("HH:MM")
        Me.lblMensaje.Text = "" 
    End Sub


    Protected Sub graficar()

        Dim serie1(Me.gvResumen.Rows().Count) As Decimal
        Dim serie2(Me.gvResumen.Rows().Count) As Decimal
        Dim categoriesAxis As String = ""

        For Each dato As GridViewRow In Me.gvResumen.Rows()
            categoriesAxis += dato.Cells(1).Text.Replace(":00", "") + ","
            serie1(dato.RowIndex) = CDec(dato.Cells(2).Text)
            serie2(dato.RowIndex) = CDec(dato.Cells(3).Text)
        Next

        Me.BarChart1.ChartTitle = "Citas del " + Me.lblFechaTitulo.Text
        Me.BarChart1.ChartType = AjaxControlToolkit.ChartType.StackedColumn ' tipo de estilo de grafico
        Me.BarChart1.CategoriesAxis = categoriesAxis.Substring(0, categoriesAxis.Length - 1) ' valores eje x
        Me.BarChart1.Series(0).Data = serie1 'citasConcretadas
        Me.BarChart1.Series(1).Data = serie2 'citasDisponibles 
        Me.BarChart1.DataBind()
    End Sub

    Protected Sub calAgenda_SelectionChanged(sender As Object, e As EventArgs) Handles calAgenda.SelectionChanged
        Me.lblFecha.Text = Me.calAgenda.SelectedDate.ToString("yyyyMMdd")
        Me.lblFechaTitulo.Text = Me.calAgenda.SelectedDate.ToLongDateString()

        Me.ddlEstados.Enabled = False
        Me.ddlEstados.SelectedValue = "Pendiente"
        Me.ddlClientes.Enabled = True
        Me.ddlHoras.Enabled = True
        Me.txtObservaciones.Text = ""

        Me.btnAgregar.Visible = True
        Me.btnModificar.Visible = False
        Me.refresh()
    End Sub


    ''' <summary>
    ''' este evento se ejecuta al agregar
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If (Me.lblFecha.Text = "") Then
                Me.lblMensaje.ForeColor = Drawing.Color.Red
                Me.lblMensaje.Text = "Valores requeridos"
            Else

                Dim cita As Cita = New Cita()
                cita.metCubiculo = Me.ddlCubiculos.Text
                cita.metEstado = Me.ddlEstados.Text
                cita.metFecha = Me.lblFecha.Text
                cita.metHora = Me.ddlHoras.Text
                cita.metCliente = Me.ddlClientes.Text
                cita.metObservaciones = Me.txtObservaciones.Text
                cita.metFmodifica = DateTime.Now
                cita.metUsuario = usuario.usuario
                Me.citaDao.insertar(cita)

                Me.lblMensaje.ForeColor = Drawing.Color.Blue
                Me.lblMensaje.Text = "Registro agregado"
                Me.refresh()
            End If
        Catch ex As Exception
            Me.lblMensaje.ForeColor = Drawing.Color.Red
            Me.lblMensaje.Text = "Error: " + ex.Message
        End Try
    End Sub

    ''' <summary>
    ''' este evento se ejecuta al modificar
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If (Me.lblFecha.Text = "") Then
                Me.lblMensaje.ForeColor = Drawing.Color.Red
                Me.lblMensaje.Text = "Valores requeridos"
            Else
                Dim cita As Cita = New Cita()
                cita.metId = Me.lblId.Text
                cita.metCubiculo = Me.ddlCubiculos.Text
                cita.metEstado = Me.ddlEstados.Text
                cita.metFecha = Me.lblFecha.Text
                cita.metHora = Me.ddlHoras.Text
                cita.metCliente = Me.ddlClientes.Text
                cita.metObservaciones = Me.txtObservaciones.Text
                cita.metFmodifica = DateTime.Now
                cita.metUsuario = usuario.usuario
                Me.citaDao.modificar(cita)

                Me.btnAgregar.Visible = True
                Me.btnModificar.Visible = False
                Me.lblMensaje.ForeColor = Drawing.Color.Blue
                Me.lblMensaje.Text = "Registro modificado"
                Me.refresh()
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
        If (Me.gvDatos.SelectedIndex >= 0) Then
            Me.lblId.Text = Me.gvDatos.SelectedRow.Cells(1).Text
            Me.ddlHoras.SelectedValue = Me.gvDatos.SelectedRow.Cells(2).Text
            Me.ddlClientes.SelectedValue = Me.gvDatos.SelectedRow.Cells(4).Text
            Me.ddlCubiculos.SelectedValue = Me.gvDatos.SelectedRow.Cells(6).Text
            Me.txtObservaciones.Text = Me.gvDatos.SelectedRow.Cells(7).Text
            Me.ddlEstados.SelectedValue = Cita.CITA_PENDIENTE

            Me.ddlEstados.Enabled = True
            Me.ddlClientes.Enabled = True
            Me.ddlHoras.Enabled = True

            Me.btnAgregar.Visible = False
            Me.btnModificar.Visible = True
             Me.refresh()
        End If
    End Sub


    Protected Sub gvResumen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvResumen.SelectedIndexChanged
        Me.hfHora.Value = Me.gvResumen.SelectedRow.Cells(1).Text
        Me.refresh()
    End Sub


    Protected Sub gvDatos_RowDeleted(sender As Object, e As GridViewDeletedEventArgs) Handles gvDatos.RowDeleted
        Me.refresh()
    End Sub

    Protected Sub refresh()
        Me.gvDatos.DataBind()
        Me.gvResumen.DataBind()
        Me.graficar()
    End Sub

End Class