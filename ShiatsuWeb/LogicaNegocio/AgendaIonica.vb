Public Class AgendaIonica

    Dim id              As Integer
    Dim cedCliente As Integer
    Dim nombre          As String
    Dim apellidos       As String
    Dim hora            As Integer 
    Dim fecha           As DateTime
    Dim usuario         As String
    Dim tipoCliente     As Integer
    Dim observaciones   As String 

    Dim estado As String
    Dim fmodifica As DateTime

    Sub New()
        Me.id           = vbNull
        Me.cedCliente   = vbNull
        Me.nombre       = vbNull
        Me.apellidos    = vbNull
        Me.hora         = vbNull
        Me.fecha        = Nothing
        Me.usuario      = vbNull
        Me.tipoCliente  = vbNull
        Me.observaciones= vbNull

        Me.estado       = vbNull
        Me.fmodifica    = Nothing
    End Sub

    Public Property metId() As Integer
        Get
            Return Me.id
        End Get
        Set(ByVal value As Integer)
            Me.id = value
        End Set
    End Property
    Public Property metCedCliente() As Integer
        Get
            Return Me.cedCliente
        End Get
        Set(ByVal value As Integer)
            Me.cedCliente = value
        End Set
    End Property
    Public Property metNombre() As String
        Get
            Return Me.nombre
        End Get
        Set(ByVal value As String)
            Me.nombre = value
        End Set
    End Property
    Public Property metApellidos() As String
        Get
            Return Me.apellidos
        End Get
        Set(ByVal value As String)
            Me.apellidos = value
        End Set
    End Property
    Public Property metHora() As Integer
        Get
            Return Me.hora
        End Get
        Set(ByVal value As Integer)
            Me.hora = value
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
    
    Public Property metTipoCliente() As Integer
        Get
            Return Me.tipoCliente
        End Get
        Set(ByVal value As Integer)
            Me.tipoCliente = value
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


    Public Property metEstado() As String
        Get
            Return Me.estado
        End Get
        Set(ByVal value As String)
            Me.estado = value
        End Set
    End Property

    
End Class
