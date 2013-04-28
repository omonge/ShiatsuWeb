Public Class FacturaDetalle

    Dim fmodifica As DateTime
    Dim usuario As String
    Dim producto As Integer
    Dim cantidad As Integer
    Dim factura As Integer

    Dim cantidadAnterior As Integer
     
    Sub New()
        Me.fmodifica = Nothing
        Me.usuario = vbNull
        Me.producto = vbNull
        Me.cantidad = vbNull
        Me.factura = vbNull
    End Sub

    Public Property metFactura() As Integer
        Get
            Return Me.factura
        End Get
        Set(ByVal value As Integer)
            Me.factura = value
        End Set
    End Property

    Public Property metFmodifica() As DateTime
        Get
            Return Me.fmodifica
        End Get
        Set(ByVal value As DateTime)
            Me.fmodifica = value
        End Set
    End Property


    Public Property metCantidad() As Integer
        Get
            Return Me.cantidad
        End Get
        Set(ByVal value As Integer)
            Me.cantidad = value
        End Set
    End Property

    Public Property metCantidadAnterior() As Integer
        Get
            Return Me.cantidadAnterior
        End Get
        Set(ByVal value As Integer)
            Me.cantidadAnterior = value
        End Set
    End Property

    Public Property metProducto() As Integer
        Get
            Return Me.producto
        End Get
        Set(ByVal value As Integer)
            Me.producto = value
        End Set
    End Property

    Public Property metUsuario() As String
        Get
            Return Me.usuario
        End Get
        Set(ByVal value As String)
            Me.usuario = value
        End Set
    End Property
End Class
