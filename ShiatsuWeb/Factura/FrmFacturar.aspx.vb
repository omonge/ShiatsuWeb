Public Class FrmFacturar
    Inherits System.Web.UI.Page
    Dim usuario As Usuario
    Dim facturaDao As FacturaDao = New FacturaDao()
    Dim inventarioDao As InventarioDao = New InventarioDao()

    '  Dermo, Capilar, Ionto, Regular, Precio Especial, Inicio

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'VERIFICA LA SEGURIDAD
        Usuario = Session("usuario")
        If (Usuario Is Nothing) Then
            Response.Redirect("../Login/FrmLogin.aspx")
        End If
        Me.lblMensaje.Text = ""
        Me.hfFecha.Value = DateTime.Now.ToString("yyyyMMdd")

    End Sub

    Protected Sub gvDatosP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvDatosP.SelectedIndexChanged
        Dim facturaEncabezado As FacturaEncabezado = Me.facturaDao.consultaEncabezadoFactura(CInt(Me.gvDatosP.SelectedRow.Cells(1).Text))

        Me.lblId.Text = facturaEncabezado.metFactura
        Me.lblCliente.Text = facturaEncabezado.metCliente.metCedCliente
        Me.lblTelefono.Text = facturaEncabezado.metCliente.metTelefonoCelular
        Me.lblTipoCliente.Text = facturaEncabezado.metCliente.metTipoCliente
        Me.lblUsuario.Text = facturaEncabezado.metUsuario
        Me.lblFecha.Text = facturaEncabezado.metFecha
         
        Me.gvProductos.DataBind()
        Me.montos()
    End Sub

    Protected Sub montos()
        Dim subtotal As Double = 0
        Dim monto As Double = 0
        Dim cantidad As Integer = 0
        Dim total As Double = 0

        For Each row As GridViewRow In Me.gvProductos.Rows
            monto = CDbl(row.Cells(4).Text)
            cantidad = CDbl(row.Cells(1).Text)
            subtotal += monto
        Next row
        If (Me.ddlImpuesto.SelectedValue <> "") Then
            total = subtotal + (subtotal * (Me.ddlImpuesto.SelectedValue / 100))
        Else
            total = subtotal
        End If
        Me.lblSubTotal.Text = subtotal
        Me.lblTotal.Text = total
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
        Me.montos()
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
  
End Class