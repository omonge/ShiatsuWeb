Public Class FacturaEncabezado

    Dim factura As String
    Dim fecha As DateTime
    Dim cliente As Cliente
    Dim estado As String
    Dim usuario As String

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
End Class
