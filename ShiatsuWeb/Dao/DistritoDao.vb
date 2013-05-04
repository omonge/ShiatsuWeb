Imports MySql.Data.MySqlClient

Public Class DistritoDao

    Public Sub insertar(ByRef dato As Distrito)
        'variables
        Dim coneccion As MySqlConnection
        Dim dataAdapter As MySqlDataAdapter
        'conección
        Dim SuperSecreto As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shiatsuDB").ConnectionString
        coneccion = New MySqlConnection(SuperSecreto)
        'sql
        Dim sql As String = "INSERT INTO  cat_distrito (descripcion,estado,usuario,fmodifica,provincia,canton) VALUES (@descripcion,@estado,@usuario,@fmodifica,@provincia,@canton)"
        'adapter
        dataAdapter = New MySqlDataAdapter()
        dataAdapter.InsertCommand = New MySqlCommand(sql, coneccion)
        'parametros
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@descripcion", dato.metDescripcion))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@estado", dato.metEstado))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@usuario", dato.metUsuario))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@provincia", dato.metProvincia))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@canton", dato.metCanton))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@fmodifica", dato.metFmodifica))
        'abre
        coneccion.Open()
        'ejecuta
        dataAdapter.InsertCommand.ExecuteNonQuery()
        'cierra
        coneccion.Close()

    End Sub



    Public Sub modificar(ByRef dato As Distrito)

        'variables
        Dim coneccion As MySqlConnection
        Dim dataAdapter As MySqlDataAdapter
        'conección
        Dim SuperSecreto As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shiatsuDB").ConnectionString
        coneccion = New MySqlConnection(SuperSecreto)
        'sql
        Dim sql As String = "UPDATE  cat_distrito SET  descripcion  = @descripcion,  estado  = @estado, usuario=@usuario, " +
                            "fmodifica=@fmodifica, provincia=@provincia, canton=@canton  WHERE  id  = @id"
        'adapter
        dataAdapter = New MySqlDataAdapter()
        dataAdapter.UpdateCommand = New MySqlCommand(sql, coneccion)
        'parametros
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@id", dato.metId))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@descripcion", dato.metDescripcion))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@estado", dato.metEstado))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@usuario", dato.metUsuario))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@provincia", dato.metProvincia))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@canton", dato.metCanton))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@fmodifica", dato.metFmodifica))
        'abre
        coneccion.Open()
        'ejecuta
        dataAdapter.UpdateCommand.ExecuteNonQuery()
        'cierra
        coneccion.Close()

    End Sub

End Class
