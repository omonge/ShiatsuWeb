Public Class FrmCatalogoInventario
    Inherits System.Web.UI.Page
    Dim usuario As Usuario
    Dim inventarioDao As InventarioDao = New InventarioDao()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'VERIFICA LA SEGURIDAD
        Usuario = Session("usuario")
        If (Usuario Is Nothing) Then
            Response.Redirect("../Login/FrmLogin.aspx")
        End If
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
                Dim inventario As Inventario = New Inventario()
                inventario.metCantidad = Me.txtCantidad.Text
                inventario.metEstado = Me.ddlEstados.SelectedValue
                inventario.metDescripcion = Me.txtDescripcion.Text
                inventario.metFmodifica = DateTime.Now
                inventario.metUsuario = Me.usuario.usuario
                inventario.metPrecio1 = Me.txtPrecio1.Text
                inventario.metPrecio2 = Me.txtPrecio2.Text
                inventario.metPrecio3 = Me.txtPrecio3.Text
                Me.inventarioDao.insertar(inventario)
                Me.lblMensaje.ForeColor = Drawing.Color.Blue
                Me.lblMensaje.Text = "Registro agregado"
                Me.limpiar()
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
        If (Me.txtDescripcion.Text = "" Or
            Me.txtCantidad.Text = "") Then
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
        Me.txtId.Text = ""
        Me.txtDescripcion.Text = ""
        Me.txtCantidad.Text = ""
        Me.txtPrecio1.Text = ""
        Me.txtPrecio2.Text = ""
        Me.txtPrecio3.Text = ""
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
                Dim inventario As Inventario = New Inventario()
                inventario.metCantidad = Me.txtCantidad.Text
                inventario.metEstado = Me.ddlEstados.SelectedValue
                inventario.metDescripcion = Me.txtDescripcion.Text
                inventario.metFmodifica = DateTime.Now
                inventario.metUsuario = Me.usuario.usuario
                inventario.metId = Me.txtId.Text
                inventario.metPrecio1 = Me.txtPrecio1.Text
                inventario.metPrecio2 = Me.txtPrecio2.Text
                inventario.metPrecio3 = Me.txtPrecio3.Text
                Me.inventarioDao.modificar(inventario)
                Me.lblMensaje.ForeColor = Drawing.Color.Blue
                Me.lblMensaje.Text = "Registro modificado"
                Me.btnModificar.Visible = False
                Me.btnAgregar.Visible = True
                Me.limpiar()
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

            Me.txtId.Text = Me.gvDatos.SelectedRow.Cells(1).Text
            Me.txtCantidad.Text = Me.gvDatos.SelectedRow.Cells(2).Text
            Me.txtDescripcion.Text = Me.gvDatos.SelectedRow.Cells(3).Text
            Me.ddlEstados.SelectedValue = Me.gvDatos.SelectedRow.Cells(4).Text

            Me.txtPrecio1.Text = Me.gvDatos.SelectedRow.Cells(5).Text
            Me.txtPrecio2.Text = Me.gvDatos.SelectedRow.Cells(6).Text
            Me.txtPrecio3.Text = Me.gvDatos.SelectedRow.Cells(7).Text
        Catch ex As Exception
            Me.lblMensaje.ForeColor = Drawing.Color.Red
            Me.lblMensaje.Text = "Error: " + ex.Message
        End Try
    End Sub
End Class