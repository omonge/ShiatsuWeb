Public Class Inventario
    Dim usuario As String
    Dim fmodifica As DateTime
    Dim estado As String
    Dim cantidad As Integer
    Dim id As Integer
    Dim descripcion As String

    Dim precio1 As Double
    Dim precio2 As Double
    Dim precio3 As Double

    Sub New()
        Me.fmodifica = Nothing
        Me.usuario = vbNull
        Me.id = vbNull
        Me.estado = vbNull
        Me.cantidad = vbNull
        Me.descripcion = vbNull
        Me.precio1 = vbNull
        Me.precio2 = vbNull
        Me.precio3 = vbNull
    End Sub

    Public Property metFmodifica() As DateTime
        Get
            Return Me.fmodifica
        End Get
        Set(ByVal value As DateTime)
            Me.fmodifica = value
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

    Public Property metDescripcion() As String
        Get
            Return Me.descripcion
        End Get
        Set(ByVal value As String)
            Me.descripcion = value
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

    Public Property metEstado() As String
        Get
            Return Me.estado
        End Get
        Set(ByVal value As String)
            Me.estado = value
        End Set
    End Property

    Public Property metId() As String
        Get
            Return Me.id
        End Get
        Set(ByVal value As String)
            Me.id = value
        End Set
    End Property

    Public Property metPrecio1() As Double
        Get
            Return Me.precio1
        End Get
        Set(ByVal value As Double)
            Me.precio1 = value
        End Set
    End Property

    Public Property metPrecio2() As Double
        Get
            Return Me.precio2
        End Get
        Set(ByVal value As Double)
            Me.precio2 = value
        End Set
    End Property


    Public Property metPrecio3() As Double
        Get
            Return Me.precio3
        End Get
        Set(ByVal value As Double)
            Me.precio3 = value
        End Set
    End Property
End Class


