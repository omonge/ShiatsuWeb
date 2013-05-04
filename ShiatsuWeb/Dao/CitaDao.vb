Imports MySql.Data.MySqlClient

Public Class CitaDao

    Public Sub insertar(ByRef dato As Cita)

        'variables
        Dim coneccion As MySqlConnection
        Dim dataAdapter As MySqlDataAdapter
        'conección
        Dim SuperSecreto As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shiatsuDB").ConnectionString
        coneccion = New MySqlConnection(SuperSecreto)
        'sql
        Dim sql As String = "INSERT INTO cita (cubiculo,estado,fecha,hora,cliente,observaciones,usuario,fmodifica) " +
                            "VALUES (@cubiculo,@estado,@fecha,@hora,@cliente,@observaciones,@usuario,@fmodifica)"
        'adapter
        dataAdapter = New MySqlDataAdapter()
        dataAdapter.InsertCommand = New MySqlCommand(sql, coneccion)
        'parametros
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@cubiculo", dato.metCubiculo))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@estado", dato.metEstado))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@fecha", dato.metFecha))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@hora", dato.metHora))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@cliente", dato.metCliente))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@observaciones", dato.metObservaciones))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@usuario", dato.metUsuario))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@fmodifica", dato.metFmodifica))
        'abre
        coneccion.Open()
        'ejecuta
        dataAdapter.InsertCommand.ExecuteNonQuery()
        'cierra
        coneccion.Close()

    End Sub



    Public Sub modificar(ByRef dato As Cita)

        'variables
        Dim coneccion As MySqlConnection
        Dim dataAdapter As MySqlDataAdapter
        'conección
        Dim SuperSecreto As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shiatsuDB").ConnectionString
        coneccion = New MySqlConnection(SuperSecreto)
        'sql
        Dim sql As String = "UPDATE cita SET cubiculo=@cubiculo, estado=@estado, fecha=@fecha,hora=@hora, cliente=@cliente, " +
                            "observaciones=@observaciones, usuario=@usuario, fmodifica=@fmodifica " +
                            "WHERE id=@id"
        'adapter
        dataAdapter = New MySqlDataAdapter()
        dataAdapter.UpdateCommand = New MySqlCommand(sql, coneccion)
        'parametros
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@cubiculo", dato.metCubiculo))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@estado", dato.metEstado))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@fecha", dato.metFecha))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@hora", dato.metHora))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@cliente", dato.metCliente))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@observaciones", dato.metObservaciones))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@usuario", dato.metUsuario))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@fmodifica", dato.metFmodifica))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@id", dato.metId))
        'abre
        coneccion.Open()
        'ejecuta
        dataAdapter.UpdateCommand.ExecuteNonQuery()
        'cierra
        coneccion.Close()

    End Sub



    Public Sub cierre(ByRef dato As Cita)

        'variables
        Dim coneccion As MySqlConnection
        Dim dataAdapter As MySqlDataAdapter
        'conección
        Dim SuperSecreto As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shiatsuDB").ConnectionString
        coneccion = New MySqlConnection(SuperSecreto)
        'sql
        Dim sql As String = "UPDATE cita SET estado=@estado, usuario=@usuario, fmodifica=@fmodifica " +
                            "WHERE id=@id"
        'adapter
        dataAdapter = New MySqlDataAdapter()
        dataAdapter.UpdateCommand = New MySqlCommand(sql, coneccion)
        'parametros 
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@estado", dato.metEstado)) 
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@usuario", dato.metUsuario))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@fmodifica", dato.metFmodifica))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@id", dato.metId))
        'abre
        coneccion.Open()
        'ejecuta
        dataAdapter.UpdateCommand.ExecuteNonQuery()
        'cierra
        coneccion.Close()

    End Sub



    Public Function existe(ByRef dato As Cita) As Boolean

        'variables
        Dim coneccion As MySqlConnection
        Dim dataSet As DataSet
        Dim dataAdapter As MySqlDataAdapter
        ''abriendo la coneccion o enlace 
        Dim SuperSecreto As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shiatsuDB").ConnectionString
        coneccion = New MySqlConnection(SuperSecreto)
        'sql
        Dim sql As String = "select id from cita where id = @id"
        dataAdapter = New MySqlDataAdapter(sql, coneccion)
        'parametros
        dataAdapter.SelectCommand.Parameters.Add(New MySqlParameter("@id", MySqlDbType.Int32))
        dataAdapter.SelectCommand.Parameters("@id").Value = dato.metId
        ''Creando el dataset y cargandolo
        dataSet = New DataSet()
        dataAdapter.Fill(dataSet, "Cita")
        'verifica si existe fila
        Dim filas As DataRowCollection = dataSet.Tables("Cita").Rows()
        If (filas.Count = 0) Then
            Return False
        Else
            Return True
        End If

    End Function
End Class
