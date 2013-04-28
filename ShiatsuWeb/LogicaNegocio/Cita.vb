Public Class Cita
    Dim id As Integer
    Dim cubiculo As Integer
    Dim estado As String
    Dim fecha As String
    Dim hora As String
    Dim cliente As String
    Dim observaciones As String
    Dim usuario As String
    Dim fmodifica As DateTime

    Public Shared CITA_PENDIENTE As String = "Pendiente"
    Public Shared CITA_FACTURA As String = "Factura"
    Public Shared CITA_COMPLETADA As String = "Completada"

    Sub New()
        Me.fecha = Nothing
        Me.fmodifica = Nothing
        Me.cliente = vbNull
        Me.observaciones = vbNull
        Me.hora = vbNull
        Me.cliente = vbNull
        Me.id = vbNull
        Me.cubiculo = vbNull
        Me.usuario = vbNull 
    End Sub

    Public Property metId() As Integer
        Get
            Return Me.id
        End Get
        Set(ByVal value As Integer)
            Me.id = value
        End Set
    End Property


    Public Property metFecha() As String
        Get
            Return Me.fecha
        End Get
        Set(ByVal value As String)
            Me.fecha = value
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

    Public Property metHora() As String
        Get
            Return Me.hora
        End Get
        Set(ByVal value As String)
            Me.hora = value
        End Set
    End Property

    Public Property metCliente() As String
        Get
            Return Me.cliente
        End Get
        Set(ByVal value As String)
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

    Public Property metCubiculo() As Integer
        Get
            Return Me.cubiculo
        End Get
        Set(ByVal value As Integer)
            Me.cubiculo = value
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

    Public Property metObservaciones() As String
        Get
            Return Me.observaciones
        End Get
        Set(ByVal value As String)
            Me.observaciones = value
        End Set
    End Property
End Class
