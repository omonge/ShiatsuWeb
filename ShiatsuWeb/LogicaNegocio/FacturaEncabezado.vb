Public Class FacturaEncabezado

    Dim factura As String
    Dim fecha As DateTime
    Dim cliente As Cliente
    Dim estado As String
    Dim usuario As String
    Dim tipoPago As Integer 

    Dim total As Double
    Dim subTotal As Double
    Dim iva As Double

    Public ESTADO_ABIERTA As String = "Abierta"
    Public ESTADO_CERRADA As String = "Cerrada"

    Sub New()
        Me.fecha = Nothing
        Me.factura = vbNull
        Me.cliente = New Cliente()
        Me.estado = vbNull
        Me.usuario = vbNull
    End Sub

    Public Property metFactura() As String
        Get
            Return Me.factura
        End Get
        Set(ByVal value As String)
            Me.factura = value
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

    Public Property metFecha() As DateTime
        Get
            Return Me.fecha
        End Get
        Set(ByVal value As DateTime)
            Me.fecha = value
        End Set
    End Property

    Public Property metCliente() As Cliente
        Get
            Return Me.cliente
        End Get
        Set(ByVal value As Cliente)
            Me.cliente = value
        End Set
    End Property

    Public Property metEstado() As String
        Get
            Return Me.estado
        End Get
        Set(ByVal value As String)
            Me.estado = value
        End Set
    End Property

    Public Property metTotal() As Double
        Get
            Return Me.total
        End Get
        Set(ByVal value As Double)
            Me.total = value
        End Set
    End Property

    Public Property metSubTotal() As Double
        Get
            Return Me.subTotal
        End Get
        Set(ByVal value As Double)
            Me.subTotal = value
        End Set
    End Property

    Public Property metImpuesto() As Double
        Get
            Return Me.iva
        End Get
        Set(ByVal value As Double)
            Me.iva = value
        End Set
    End Property

    Public Property metTipoPago() As Integer
        Get
            Return Me.tipoPago
        End Get
        Set(ByVal value As Integer)
            Me.tipoPago = value
        End Set
    End Property
End Class
