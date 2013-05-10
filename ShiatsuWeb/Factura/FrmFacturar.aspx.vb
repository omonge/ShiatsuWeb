Public Class FrmFacturar
    Inherits System.Web.UI.Page
    Dim usuario As Usuario
    Dim facturaDao As FacturaDao = New FacturaDao()
    Dim inventarioDao As InventarioDao = New InventarioDao()
    Dim citaDao As CitaDao = New CitaDao()

    '  Dermo, Capilar, Ionto, Regular, Precio Especial, Inicio

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'VERIFICA LA SEGURIDAD
        Usuario = Session("usuario")
        If (Usuario Is Nothing) Then
            Response.Redirect("../Login/FrmLogin.aspx")
        End If
        Me.lblCaja.Text = usuario.caja
        Me.lblMensaje.Text = ""
        Me.hfFecha.Value = DateTime.Now.ToString("yyyyMMdd")
        Me.montos()
    End Sub

    Protected Sub gvDatosP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvDatosP.SelectedIndexChanged
        Try

            Dim facturaEncabezado As FacturaEncabezado = Me.facturaDao.consultaEncabezadoFactura(CInt(Me.gvDatosP.SelectedRow.Cells(1).Text))

            Me.lblId.Text = facturaEncabezado.metFactura
            Me.txtCliente.Text = facturaEncabezado.metCliente.metCedCliente
            Me.txtTelefono.Text = facturaEncabezado.metCliente.metTelefonoCelular
            Me.txtTipoCliente.Text = facturaEncabezado.metCliente.metTipoCliente
            Me.txtUsuario.Text = facturaEncabezado.metUsuario
            Me.txtFecha.Text = facturaEncabezado.metFecha

            Me.gvProductos.DataBind()
            Me.montos()
            Me.btnFacturar.Visible = True
            Me.btnCancelar.Visible = True

        Catch ex As Exception
            Me.lblMensaje.ForeColor = Drawing.Color.Red
            Me.lblMensaje.Text = "Error: " + ex.Message
        End Try
    End Sub

    Protected Sub montos()
        Try 
            Dim subtotal As Double = 0
            Dim monto As Double = 0
            Dim cantidad As Integer = 0
            Dim total As Double = 0
            Dim iva As Double = 0

            For Each row As GridViewRow In Me.gvProductos.Rows
                monto = CDbl(row.Cells(4).Text)
                cantidad = CDbl(row.Cells(1).Text)
                subtotal += monto
            Next row
            If (Me.chkIva.Checked) Then
                iva = subtotal * 0.13
                total = subtotal + iva
            Else
                total = subtotal
            End If 

            Me.txtSubTotal.Text = FormatCurrency(subtotal, 2, TriState.True, TriState.True, TriState.True)
            Me.txtTotal.Text = FormatCurrency(total, 2, TriState.True, TriState.True, TriState.True)
            Me.txtImpuesto.Text = FormatCurrency(iva, 2, TriState.True, TriState.True, TriState.True)

        Catch ex As Exception
            Me.lblMensaje.ForeColor = Drawing.Color.Red
            Me.lblMensaje.Text = "Error: " + ex.Message
        End Try
    End Sub

    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try

            If (valiarDetalle()) Then
                Dim facturaDetalle As FacturaDetalle = New FacturaDetalle()
                facturaDetalle.metCantidad = CInt(Me.txtCantidad.Text)
                facturaDetalle.metProducto = CInt(Me.ddlProdcutos.SelectedValue)
                facturaDetalle.metFmodifica = DateTime.Now
                facturaDetalle.metFactura = Me.lblId.Text
                facturaDetalle.metProducto = CDbl(Me.ddlPrecios.SelectedValue)
                facturaDetalle.metUsuario = usuario.usuario
                Me.facturaDao.crearDetalle(facturaDetalle)
                Me.lblMensaje.ForeColor = Drawing.Color.Blue
                Me.lblMensajeDetalle.Text = "Registro agregado"

                Me.limpiar()
                Me.gvProductos.DataBind()
                Me.ddlProdcutos.DataBind()
                Me.montos()
            End If

        Catch ex As Exception
            Me.lblMensajeDetalle.ForeColor = Drawing.Color.Red
            Me.lblMensajeDetalle.Text = "Error: " + ex.Message
        End Try
    End Sub

    ''' <summary>
    ''' valida los detalles de la factura
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function valiarDetalle() As Boolean
        Try
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
        Catch ex As Exception
            Me.lblMensaje.ForeColor = Drawing.Color.Red
            Me.lblMensaje.Text = "Error: " + ex.Message
            Return False
        End Try
    End Function

    ''' <summary>
    ''' limpia los valores al agregar o modificar
    ''' </summary>
    ''' <remarks></remarks>
    Sub limpiar()
        Me.txtCantidad.Text = ""
    End Sub

    ''' <summary>
    ''' limpia los valores al agregar o modificar
    ''' </summary>
    ''' <remarks></remarks>
    Sub limpiarEncabezado()
        Me.txtImpuesto.Text = ""
        Me.txtSubTotal.Text = ""
        Me.txtTotal.Text = ""
        Me.txtFecha.Text = ""
        Me.txtTelefono.Text = ""
        Me.txtCliente.Text = ""
        Me.txtTipoCliente.Text = ""
        Me.txtUsuario.Text = ""
        Me.lblId.Text = ""
    End Sub

    Protected Sub btnModificarProducto_Click(sender As Object, e As EventArgs) Handles btnModificarProducto.Click
        Try
            Dim facturaDetalle As FacturaDetalle = New FacturaDetalle()
            facturaDetalle.metCantidad = CInt(Me.txtCantidad.Text)
            facturaDetalle.metProducto = CInt(Me.ddlProdcutos.SelectedValue)
            facturaDetalle.metFmodifica = DateTime.Now
            facturaDetalle.metFactura = Me.lblId.Text
            facturaDetalle.metPrecio = Me.ddlPrecios.SelectedValue
            facturaDetalle.metUsuario = Me.usuario.usuario
            facturaDetalle.metCantidadAnterior = CInt(Me.gvProductos.SelectedRow.Cells(1).Text)

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
            Me.montos()
            Me.lblMensaje.ForeColor = Drawing.Color.Blue
            Me.lblMensaje.Text = "Registro modificado"
        Catch ex As Exception
            Me.lblMensaje.ForeColor = Drawing.Color.Red
            Me.lblMensajeDetalle.Text = "Error: " + ex.Message
        End Try
    End Sub

    Protected Sub ddlProdcutos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProdcutos.SelectedIndexChanged
        Me.ddlPrecios.DataBind()
    End Sub

    Protected Sub gvProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvProductos.SelectedIndexChanged
        Me.txtCantidad.Text = Me.gvProductos.SelectedRow.Cells(1).Text
        Me.ddlProdcutos.SelectedValue = Me.gvProductos.SelectedRow.Cells(2).Text
        Me.btnAgregar.Visible = False
        Me.btnModificarProducto.Visible = True
    End Sub
    
    Protected Sub chkIva_CheckedChanged(sender As Object, e As EventArgs) Handles chkIva.CheckedChanged
        Me.montos()
    End Sub

    Protected Sub btnFacturar_Click(sender As Object, e As EventArgs) Handles btnFacturar.Click, btnCancelar.Click
        Try 
            Dim facturaEncabezado As FacturaEncabezado = New FacturaEncabezado()
            facturaEncabezado.metFactura = Me.lblId.Text
            facturaEncabezado.metImpuesto = CDbl(Me.txtImpuesto.Text)
            facturaEncabezado.metTotal = CDbl(Me.txtTotal.Text)
            facturaEncabezado.metSubTotal = CDbl(Me.txtSubTotal.Text)
            facturaEncabezado.metTipoPago = CDbl(Me.ddlTipoPago.SelectedValue)
            facturaEncabezado.metCaja = Me.lblCaja.Text
            facturaEncabezado.metEstado = facturaEncabezado.ESTADO_CERRADA
            Me.facturaDao.modificarEncabezado(facturaEncabezado)
            Dim cita As Cita = New Cita()
            cita.metEstado = facturaEncabezado.ESTADO_CERRADA
            cita.metUsuario = usuario.usuario
            cita.metFmodifica = DateTime.Now
            cita.metId = Me.lblId.Text
            Me.citaDao.cierre(cita)
            Me.btnFacturar.Visible = False
            Me.btnCancelar.Visible = False
            Me.limpiar()
            Me.limpiarEncabezado() 
            Me.gvDatosP.DataBind()
        Catch ex As Exception
            Me.lblMensaje.ForeColor = Drawing.Color.Red
            Me.lblMensaje.Text = "Error: " + ex.Message
        End Try
    End Sub
End Class