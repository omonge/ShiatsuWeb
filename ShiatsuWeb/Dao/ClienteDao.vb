Imports MySql.Data.MySqlClient

Public Class ClienteDao

    Public Sub insertar(ByRef dato As Cliente)

        'variables
        Dim coneccion As MySqlConnection
        Dim dataAdapter As MySqlDataAdapter
        'conección
        Dim SuperSecreto As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shiatsuDB").ConnectionString
        coneccion = New MySqlConnection(SuperSecreto)
        'sql
        Dim sql As String = "INSERT INTO cat_cliente (usuario,estado,fmodifica,cedcliente,nombre,nombre_factura, " +
                            "email1, email2, direccion, provincia, canton, distrito,fecha_nacimiento, frecuencia_cita, lugar_profesion,nacionalidad, " +
                            "profesion,sexo,telefono_casa,telefono_celular,tipo_alopecia,tipo_cliente) " +
                            "VALUES (@usuario,@estado,@fmodifica,@cedcliente,@nombre,@nombre_factura, " +
                            "@email1, @email2, @direccion, @provincia, @canton, @distrito,@fecha_nacimiento, @frecuencia_cita, @lugar_profesion, @nacionalidad, " +
                            "@profesion,@sexo,@telefono_casa,@telefono_celular,@tipo_alopecia,@tipo_cliente)"

        'adapter
        dataAdapter = New MySqlDataAdapter()
        dataAdapter.InsertCommand = New MySqlCommand(sql, coneccion)
        'parametros
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@usuario", dato.metUsuario))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@estado", dato.metEstado))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@fmodifica", dato.metFmodifica))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@cedcliente", dato.metCedCliente))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@nombre", dato.metNombre))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@nombre_factura", dato.metFacturaNombre))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@email1", dato.metEmail1))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@email2", dato.metEmail2))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@direccion", dato.metDireccion))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@provincia", dato.metProvincia))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@canton", dato.metCanton))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@distrito", dato.metDistrito))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@fecha_nacimiento", dato.metFechaNacimiento))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@frecuencia_cita", dato.metFrecuenciaCita))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@lugar_profesion", dato.metLugarTrabajo))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@nacionalidad", dato.metNacionalidad))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@profesion", dato.metProfesion))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@sexo", dato.metSexo))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@telefono_casa", dato.metTelefonoCasa))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@telefono_celular", dato.metTelefonoCelular))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@tipo_alopecia", dato.metTipoAlopecia))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@tipo_cliente", dato.metTipoCliente))
        'abre
        coneccion.Open()
        'ejecuta
        dataAdapter.InsertCommand.ExecuteNonQuery()
        'cierra
        coneccion.Close()

    End Sub



    Public Sub modificar(ByRef dato As Cliente)

        'variables
        Dim coneccion As MySqlConnection
        Dim dataAdapter As MySqlDataAdapter
        'conección
        Dim SuperSecreto As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shiatsuDB").ConnectionString
        coneccion = New MySqlConnection(SuperSecreto)
        'sql
        Dim sql As String = "UPDATE cat_cliente SET usuario=@usuario,estado=@estado,fmodifica=@fmodifica,nombre=@nombre,nombre_factura=@nombre_factura, " +
                          "email1=@email1, email2=@email2, direccion=@direccion, provincia=@provincia, canton=@canton, distrito=@distrito,fecha_nacimiento=@fecha_nacimiento, " +
                          " frecuencia_cita=@frecuencia_cita, lugar_profesion=@lugar_profesion,nacionalidad=@nacionalidad, " +
                          "profesion=@profesion,sexo=@sexo,telefono_casa=@telefono_casa,telefono_celular=@telefono_celular,tipo_alopecia=@tipo_alopecia,tipo_cliente=@tipo_cliente " +
                          "WHERE cedcliente=@cedcliente"

        'adapter
        dataAdapter = New MySqlDataAdapter()
        dataAdapter.UpdateCommand = New MySqlCommand(sql, coneccion)
        'parametros 
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@usuario", dato.metUsuario))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@estado", dato.metEstado))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@fmodifica", dato.metFmodifica))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@cedcliente", dato.metCedCliente))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@nombre", dato.metNombre))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@nombre_factura", dato.metFacturaNombre))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@email1", dato.metEmail1))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@email2", dato.metEmail2))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@direccion", dato.metDireccion))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@provincia", dato.metProvincia))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@canton", dato.metCanton))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@distrito", dato.metDistrito))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@fecha_nacimiento", dato.metFechaNacimiento))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@frecuencia_cita", dato.metFrecuenciaCita))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@lugar_profesion", dato.metLugarTrabajo))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@nacionalidad", dato.metNacionalidad))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@profesion", dato.metProfesion))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@sexo", dato.metSexo))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@telefono_casa", dato.metTelefonoCasa))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@telefono_celular", dato.metTelefonoCelular))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@tipo_alopecia", dato.metTipoAlopecia))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@tipo_cliente", dato.metTipoCliente))
        'abre
        coneccion.Open()
        'ejecuta
        dataAdapter.UpdateCommand.ExecuteNonQuery()
        'cierra
        coneccion.Close()

    End Sub



    Public Function consulta(ByRef dato As Cliente) As Cliente

        'variables
        Dim coneccion As MySqlConnection
        Dim dataSet As DataSet
        Dim dataAdapter As MySqlDataAdapter
        ''abriendo la coneccion o enlace 
        Dim SuperSecreto As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shiatsuDB").ConnectionString
        coneccion = New MySqlConnection(SuperSecreto)
        'sql
        Dim sql As String = "select * from cat_cliente where cedcliente = @cedcliente"
        dataAdapter = New MySqlDataAdapter(sql, coneccion)
        'parametros
        dataAdapter.SelectCommand.Parameters.Add(New MySqlParameter("@cedcliente", dato.metCedCliente))
        dataSet = New DataSet()
        dataAdapter.Fill(dataSet, "cat_cliente")
        'verifica si existe fila
        Dim filas As DataRowCollection = dataSet.Tables("cat_cliente").Rows()
        If (filas.Count <> 0) Then
            Dim fila As DataRow = dataSet.Tables("cat_cliente").Rows(0)
            dato.metUsuario = fila("usuario")
            dato.metEstado = fila("estado")
            dato.metFmodifica = fila("fmodifica")
            dato.metCedCliente = fila("cedcliente")  
            dato.metEmail1 = IIf(IsDBNull(fila("email1")), "", fila("email1"))
            dato.metEmail2 = IIf(IsDBNull(fila("email2")), "", fila("email2"))
            dato.metDireccion = fila("direccion")
            dato.metProvincia = fila("Provincia")
            dato.metCanton = fila("Canton")
            dato.metDistrito = fila("Distrito")
            dato.metFechaNacimiento = fila("fecha_nacimiento")
            dato.metFrecuenciaCita = fila("frecuencia_cita")
            dato.metLugarTrabajo = IIf(IsDBNull(fila("lugar_profesion")), "", fila("lugar_profesion"))
            dato.metNacionalidad = fila("nacionalidad")
            dato.metProfesion = fila("Profesion")
            dato.metSexo = fila("sexo")
            dato.metTelefonoCasa = IIf(IsDBNull(fila("telefono_casa")), "", fila("telefono_casa"))
            dato.metTelefonoCelular = IIf(IsDBNull(fila("telefono_celular")), "", fila("telefono_celular"))
            dato.metTipoAlopecia = fila("tipo_alopecia")
            dato.metTipoCliente = fila("tipo_cliente")
            dato.metNombre = IIf(IsDBNull(fila("nombre")), "", fila("nombre"))
            dato.metFacturaNombre = IIf(IsDBNull(fila("nombre_factura")), "", fila("nombre_factura"))
            Return dato
        End If
        Return Nothing
    End Function


    Public Function existe(ByRef dato As Cliente) As Boolean

        'variables
        Dim coneccion As MySqlConnection
        Dim dataSet As DataSet
        Dim dataAdapter As MySqlDataAdapter
        ''abriendo la coneccion o enlace 
        Dim SuperSecreto As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shiatsuDB").ConnectionString
        coneccion = New MySqlConnection(SuperSecreto)
        'sql
        Dim sql As String = "select cedcliente from cat_cliente where cedcliente = @cedcliente"
        dataAdapter = New MySqlDataAdapter(sql, coneccion)
        'parametros
        dataAdapter.SelectCommand.Parameters.Add(New MySqlParameter("@cedcliente", dato.metCedCliente)) 
        dataSet = New DataSet()
        dataAdapter.Fill(dataSet, "cat_cliente")
        'verifica si existe fila
        Dim filas As DataRowCollection = dataSet.Tables("cat_cliente").Rows()
        If (filas.Count = 0) Then
            Return False
        Else
            Return True
        End If

    End Function
End Class
