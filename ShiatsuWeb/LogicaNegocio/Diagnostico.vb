Public Class Diagnostico

    Dim estado As String
    Dim usuario As String
    Dim fmodifica As DateTime

    Dim cedcliente As String
    Dim nombre As String
    Dim porcentajePerdida As Double
    Dim dertatitisOleosa As String
    Dim dertatitisSeborreica As String
    Dim dertatitisSeca As String
    Dim caspa As String
    Dim hongo As String
    Dim deshidratacion As String
    Dim psoriasis As String
    Dim telanocitos As String
    Dim tipoAlopecia As TipoAlopecia
    Dim observaciones As String

    Sub New()
        Me.fmodifica = Nothing
        Me.tipoAlopecia = New TipoAlopecia()
        Me.usuario = vbNull 
        Me.estado = vbNull 
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

    Public Property metEstado() As String
        Get
            Return Me.estado
        End Get
        Set(ByVal value As String)
            Me.estado = value
        End Set
    End Property

    Public Property metCedCliente() As String
        Get
            Return Me.cedcliente
        End Get
        Set(ByVal value As String)
            Me.cedcliente = value
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

    Public Property metPorcentajePerdida() As Double
        Get
            Return Me.porcentajePerdida
        End Get
        Set(ByVal value As Double)
            Me.porcentajePerdida = value
        End Set
    End Property

    Public Property metDermatitisOleosa() As String
        Get
            Return Me.dertatitisOleosa
        End Get
        Set(ByVal value As String)
            Me.dertatitisOleosa = value
        End Set
    End Property

    Public Property metDermatitisSeborreica() As String
        Get
            Return Me.dertatitisSeborreica
        End Get
        Set(ByVal value As String)
            Me.dertatitisSeborreica = value
        End Set
    End Property

    Public Property metDermatitisSeca() As String
        Get
            Return Me.dertatitisSeca
        End Get
        Set(ByVal value As String)
            Me.dertatitisSeca = value
        End Set
    End Property

    Public Property metCaspa() As String
        Get
            Return Me.caspa
        End Get
        Set(ByVal value As String)
            Me.caspa = value
        End Set
    End Property

    Public Property metHongo() As String
        Get
            Return Me.hongo
        End Get
        Set(ByVal value As String)
            Me.hongo = value
        End Set
    End Property

    Public Property metDeshidratacion() As String
        Get
            Return Me.deshidratacion
        End Get
        Set(ByVal value As String)
            Me.deshidratacion = value
        End Set
    End Property

    Public Property metPsoriasis() As String
        Get
            Return Me.psoriasis
        End Get
        Set(ByVal value As String)
            Me.psoriasis = value
        End Set
    End Property

    Public Property metTelanocitos() As String
        Get
            Return Me.telanocitos
        End Get
        Set(ByVal value As String)
            Me.telanocitos = value
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

    Public Property metTipoAlopecia() As TipoAlopecia
        Get
            Return Me.tipoAlopecia
        End Get
        Set(ByVal value As TipoAlopecia)
            Me.tipoAlopecia = value
        End Set
    End Property
End Class
