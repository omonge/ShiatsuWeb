Imports MySql.Data.MySqlClient

Public Class AgendaIonicaDao


    Public Sub insertar(ByRef dato As AgendaIonica)
        'variables
        Dim coneccion As MySqlConnection
        Dim dataAdapter As MySqlDataAdapter
        'conección
        Dim SuperSecreto As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shiatsuDB").ConnectionString
        coneccion = New MySqlConnection(SuperSecreto)
        'sql
        Dim sql As String = "INSERT INTO  cat_agenda_ionica  (cedCliente,nombre, apellidos,hora,fecha,tipoCliente,observaciones,usuario,fmodifica) VALUES (@cedCliente,@nombre,@apellidos,@hora,@fecha,@tipocliente,@observaciones,@usuario,@fmodifica)"
        'adapter
        dataAdapter = New MySqlDataAdapter()
        dataAdapter.InsertCommand = New MySqlCommand(sql, coneccion)
        'parametros

        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@cedCliente", dato.metCedCliente))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@nombre", dato.metNombre))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@apellidos", dato.metApellidos))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@hora", dato.metHora))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@fecha", dato.metFecha))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@tipoCliente", dato.metTipoCliente))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@observaciones", dato.metObservaciones))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@usuario", dato.metUsuario))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@fmodifica", dato.metFmodifica)) '
        'abre
        coneccion.Open()
        'ejecuta
        dataAdapter.InsertCommand.ExecuteNonQuery()
        'cierra
        coneccion.Close()

    End Sub



    Public Sub modificar(ByRef dato As AgendaIonica)

        'variables
        Dim coneccion As MySqlConnection
        Dim dataAdapter As MySqlDataAdapter
        'conección
        Dim SuperSecreto As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shiatsuDB").ConnectionString
        coneccion = New MySqlConnection(SuperSecreto)
        'sql
        Dim sql As String = "UPDATE  cat_agenda_ionica  SET  cedcliente=@cedCliente,nombre=@nombre,apellidos=@apellidos,hora=@hora,fecha=@fecha,tipocliente=@tipoCliente,observaciones=@observaciones,usuario=@usuario, fmodifica=@fmodifica WHERE  id  = @id"
        'adapter
        dataAdapter = New MySqlDataAdapter()
        dataAdapter.UpdateCommand = New MySqlCommand(sql, coneccion)
        'parametros
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@id", dato.metId))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@cedCliente", dato.metCedCliente))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@nombre", dato.metNombre))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@apellidos", dato.metApellidos))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@hora", dato.metHora))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@fecha", dato.metFecha))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@tipoCliente", dato.metTipoCliente))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@observaciones", dato.metObservaciones))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@usuario", dato.metUsuario))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@fmodifica", dato.metFmodifica))
        'abre
        coneccion.Open()
        'ejecuta
        dataAdapter.UpdateCommand.ExecuteNonQuery()
        'cierra
        coneccion.Close()

    End Sub

End Class
