Public Class Canton

    Dim id As Integer
    Dim descripcion As String
    Dim estado As String
    Dim usuario As String
    Dim provincia As Integer
    Dim fmodifica As DateTime


    Sub New()
        Me.fmodifica = Nothing
        Me.usuario = vbNull
        Me.id = vbNull
        Me.estado = vbNull
        Me.descripcion = vbNull
        Me.provincia = vbNull
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

    Public Property metEstado() As String
        Get
            Return Me.estado
        End Get
        Set(ByVal value As String)
            Me.estado = value
        End Set
    End Property

    Public Property metProvincia() As Integer
        Get
            Return Me.provincia
        End Get
        Set(ByVal value As Integer)
            Me.provincia = value
        End Set
    End Property

    Public Property metId() As Integer
        Get
            Return Me.id
        End Get
        Set(ByVal value As Integer)
            Me.id = value
        End Set
    End Property
End Class
