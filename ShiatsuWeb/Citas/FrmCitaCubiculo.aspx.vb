
Public Class FrmCitaCubiculo
    Inherits System.Web.UI.Page
    Dim usuario As Usuario
    Dim cliente As String
    Dim facturaDao As FacturaDao = New FacturaDao()
    Dim citaDao As CitaDao = New CitaDao()
    Dim inventarioDao As InventarioDao = New InventarioDao()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'VERIFICA LA SEGURIDAD
        usuario = Session("usuario")
        If (usuario Is Nothing) Then
            Response.Redirect("../Login/FrmLogin.aspx")
        Else
            Me.hfFecha.Value = Date.Now.ToString("yyyyMMdd")
            Me.lblCubiculoP.Text = usuario.cubiculo
            Me.lblCubiculoF.Text = usuario.cubiculo
        End If
        'limpia los mensajes de la pantalla
        Me.lblMensaje.Text = ""
    End Sub

    ''' <summary>
    ''' este evento se ejecuta al seleccionar en el data table
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub gvDatos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvDatosP.SelectedIndexChanged
        If (Me.gvDatosP.SelectedIndex >= 0) Then
            Me.lblId.Text = Me.gvDatosP.SelectedRow.Cells(1).Text
            cliente = Me.gvDatosP.SelectedRow.Cells(4).Text
            Me.txtObservaciones.Text = Me.gvDatosP.SelectedRow.Cells(7).Text

            Dim facturaEncabezado As FacturaEncabezado = New FacturaEncabezado()
            facturaEncabezado.metCliente.metCedCliente = cliente
            facturaEncabezado.metEstado = facturaEncabezado.ESTADO_ABIERTA
            facturaEncabezado.metFactura = CInt(Me.lblId.Text)
            facturaEncabezado.metFecha = DateTime.Now
            facturaEncabezado.metUsuario = usuario.usuario

            If (Me.facturaDao.existe(facturaEncabezado)=False) Then
                Me.facturaDao.crearEncabezado(facturaEncabezado)
            End If

            Me.ddlEstados.Enabled = True
            Me.btnAgregar.Visible = True
            Me.btnModificar.Visible = True
        End If
    End Sub

    ''' <summary>
    ''' este evento se ejecuta al modificar
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try 

            Dim cita As Cita = New Cita()
            cita.metId = Me.lblId.Text
            cita.metCubiculo = Me.gvDatosP.SelectedRow.Cells(6).Text
            cita.metEstado = Me.ddlEstados.Text
            cita.metFecha = Me.hfFecha.Value
            cita.metHora = Me.gvDatosP.SelectedRow.Cells(2).Text
            cita.metCliente = Me.gvDatosP.SelectedRow.Cells(4).Text
            cita.metObservaciones = Me.txtObservaciones.Text
            cita.metFmodifica = DateTime.Now
            cita.metUsuario = usuario.usuario
            Me.citaDao.modificar(cita)

            Me.gvDatosF.DataBind()
            Me.gvDatosP.DataBind()

            Me.lblId.Text = ""
            Me.lblMensaje.ForeColor = Drawing.Color.Blue
            Me.lblMensaje.Text = "Registro modificado"
         Catch ex As Exception
            Me.lblMensaje.ForeColor = Drawing.Color.Red
            Me.lblMensaje.Text = "Error: " + ex.Message
        End Try

    End Sub

    ''' <summary>
    ''' este evento se ejecuta al agregar
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try

            If (valiarDetalle()) Then
                Dim facturaDetalle As FacturaDetalle = New FacturaDetalle()
                facturaDetalle.metCantidad = CInt(Me.txtCantidad.Text)
                facturaDetalle.metProducto = CInt(Me.ddlProdcutos.SelectedValue)
                facturaDetalle.metFmodifica = DateTime.Now
                facturaDetalle.metFactura = Me.lblId.Text
                facturaDetalle.metUsuario = usuario.usuario
                Me.facturaDao.crearDetalle(facturaDetalle)
                Me.lblMensaje.ForeColor = Drawing.Color.Blue
                Me.lblMensaje.Text = "Registro agregado"

                Me.limpiar()
                Me.gvProductos.DataBind()
                Me.ddlProdcutos.DataBind()
            End If

        Catch ex As Exception
            Me.lblMensaje.ForeColor = Drawing.Color.Red
            Me.lblMensaje.Text = "Error: " + ex.Message
        End Try
    End Sub

    ''' <summary>
    ''' valida los detalles de la factura
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function valiarDetalle() As Boolean
        If (Me.txtCantidad.Text = "") Then
            Me.lblMensaje.ForeColor = Drawing.Color.Red
            Me.lblMensaje.Text = "Valores requeridos"
            Return False
        Else
            Dim stock As String = Me.ddlProdcutos.SelectedItem.Text.Split(":")(1).Trim()
            If (CInt(stock) < CInt(Me.txtCantidad.Text)) Then
                Me.lblMensaje.ForeColor = Drawing.Color.Red
                Me.lblMensaje.Text = "No se dispone de esa cantidad de productos, cantidad actual: " + stock
                Return False
            End If
            Return True
            End If
    End Function

    ''' <summary>
    ''' limpia los valores al agregar o modificar
    ''' </summary>
    ''' <remarks></remarks>
    Sub limpiar()
        Me.txtCantidad.Text = ""
    End Sub
 

    ''' <summary>
    ''' selecciona los un detalle
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub gvProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvProductos.SelectedIndexChanged
        Me.txtCantidad.Text = Me.gvProductos.SelectedRow.Cells(2).Text 
        Me.ddlProdcutos.SelectedValue = Me.gvProductos.SelectedRow.Cells(3).Text
        Me.btnAgregar.Visible = False  
        Me.btnModificarProducto.Visible = True
    End Sub

    ''' <summary>
    ''' modifica los detalles
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnModificarProducto_Click(sender As Object, e As EventArgs) Handles btnModificarProducto.Click
        Dim facturaDetalle As FacturaDetalle = New FacturaDetalle()
        facturaDetalle.metCantidad = CInt(Me.txtCantidad.Text)
        facturaDetalle.metProducto = CInt(Me.ddlProdcutos.SelectedValue)
        facturaDetalle.metFmodifica = DateTime.Now
        facturaDetalle.metFactura = Me.lblId.Text
        facturaDetalle.metUsuario = Me.usuario.usuario
        facturaDetalle.metCantidadAnterior = CInt(Me.gvProductos.SelectedRow.Cells(2).Text)

        If (Me.txtCantidad.Text = "0") Then 
            Me.facturaDao.eliminarDetalle(facturaDetalle)
            Me.inventarioDao.modificarCantidad(facturaDetalle.metCantidad, facturaDetalle.metCantidadAnterior, facturaDetalle.metProducto)
        Else
            Me.facturaDao.modificarDetalle(facturaDetalle)
            Me.inventarioDao.modificarCantidad(facturaDetalle.metCantidad, facturaDetalle.metCantidadAnterior, facturaDetalle.metProducto)
        End If

        Me.gvProductos.DataBind()
        Me.ddlProdcutos.DataBind()
        Me.limpiar()

        Me.btnAgregar.Visible = True
        Me.btnModificarProducto.Visible = False
    End Sub
End Class