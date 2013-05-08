Public Class Cliente
    Dim cedCliente As String
    Dim direccion As String
    Dim estado As String
    Dim email1 As String
    Dim email2 As String
    Dim facturaNombre As String
    Dim lugarTrabajo As String
    Dim sexo As String
    Dim nombre As String 
    Dim fechaNacimiento As Date
    Dim frecuenciaCita As Integer
    Dim nacionalidad As Integer
    Dim profesion As Integer
    Dim telefonoCasa As String
    Dim telefonoCelular As String
    Dim usuario As String
    Dim provincia As Integer
    Dim canton As Integer
    Dim distrito As Integer
    Dim tipoCliente As Integer
    Dim tipoAlopecia As Integer
    Dim fmodifica As DateTime

    Public Property metDireccion() As String
        Get
            Return Me.direccion
        End Get
        Set(ByVal value As String)
            Me.direccion = value
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

    Public Property metTipoCliente() As Integer
        Get
            Return Me.tipoCliente
        End Get
        Set(ByVal value As Integer)
            Me.tipoCliente = value
        End Set
    End Property

    Public Property metTipoAlopecia() As Integer
        Get
            Return Me.tipoAlopecia
        End Get
        Set(ByVal value As Integer)
            Me.tipoAlopecia = value
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

    Public Property metFacturaNombre() As String
        Get
            Return Me.facturaNombre
        End Get
        Set(ByVal value As String)
            Me.facturaNombre = value
        End Set
    End Property

    Public Property metLugarTrabajo() As String
        Get
            Return Me.lugarTrabajo
        End Get
        Set(ByVal value As String)
            Me.lugarTrabajo = value
        End Set
    End Property

    Public Property metSexo() As String
        Get
            Return Me.sexo
        End Get
        Set(ByVal value As String)
            Me.sexo = value
        End Set
    End Property

    Public Property metEmail1() As String
        Get
            Return Me.email1
        End Get
        Set(ByVal value As String)
            Me.email1 = value
        End Set
    End Property

    Public Property metEmail2() As String
        Get
            Return Me.email2
        End Get
        Set(ByVal value As String)
            Me.email2 = value
        End Set
    End Property

    Public Property metCedCliente() As String
        Get
            Return Me.cedCliente
        End Get
        Set(ByVal value As String)
            Me.cedCliente = value
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

    Public Property metNombre() As String
        Get
            Return Me.nombre
        End Get
        Set(ByVal value As String)
            Me.nombre = value
        End Set
    End Property

    Public Property metFechaNacimiento() As Date
        Get
            Return Me.fechaNacimiento
        End Get
        Set(ByVal value As Date)
            Me.fechaNacimiento = value
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


    Public Property metFrecuenciaCita() As Integer
        Get
            Return Me.frecuenciaCita
        End Get
        Set(ByVal value As Integer)
            Me.frecuenciaCita = value
        End Set
    End Property

    Public Property metNacionalidad() As Integer
        Get
            Return Me.nacionalidad
        End Get
        Set(ByVal value As Integer)
            Me.nacionalidad = value
        End Set
    End Property

   

    Public Property metTelefonoCasa() As String
        Get
            Return Me.telefonoCasa
        End Get
        Set(ByVal value As String)
            Me.telefonoCasa = value
        End Set
    End Property

    Public Property metTelefonoCelular() As String
        Get
            Return Me.telefonoCelular
        End Get
        Set(ByVal value As String)
            Me.telefonoCelular = value
        End Set
    End Property

    Public Property metProfesion() As Integer
        Get
            Return Me.profesion
        End Get
        Set(ByVal value As Integer)
            Me.profesion = value
        End Set
    End Property

    Public Property metCanton() As Integer
        Get
            Return Me.canton
        End Get
        Set(ByVal value As Integer)
            Me.canton = value
        End Set
    End Property

    Public Property metDistrito() As Integer
        Get
            Return Me.distrito
        End Get
        Set(ByVal value As Integer)
            Me.distrito = value
        End Set
    End Property

End Class 
   