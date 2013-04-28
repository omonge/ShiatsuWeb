Imports MySql.Data.MySqlClient

Public Class InventarioDao


    Public Sub insertar(ByRef dato As Inventario)
        'variables
        Dim coneccion As MySqlConnection
        Dim dataAdapter As MySqlDataAdapter
        'conección
        Dim SuperSecreto As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shiatsuDB").ConnectionString
        coneccion = New MySqlConnection(SuperSecreto)
        'sql
        Dim sql As String = "INSERT INTO  cat_inventario  (cantidad,descripcion,estado,usuario,fmodifica,precio1,precio2,precio3) VALUES (@cantidad,@descripcion,@estado,@usuario,@fmodifica,@precio1,@precio2,@precio3)"
        'adapter
        dataAdapter = New MySqlDataAdapter()
        dataAdapter.InsertCommand = New MySqlCommand(sql, coneccion)
        'parametros
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@cantidad", dato.metCantidad))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@descripcion", dato.metDescripcion))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@estado", dato.metEstado))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@usuario", dato.metUsuario))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@fmodifica", dato.metFmodifica))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@precio1", dato.metPrecio1))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@precio2", dato.metPrecio2))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@precio3", dato.metPrecio3))
        'abre
        coneccion.Open()
        'ejecuta
        dataAdapter.InsertCommand.ExecuteNonQuery()
        'cierra
        coneccion.Close()

    End Sub



    Public Sub modificar(ByRef dato As Inventario)

        'variables
        Dim coneccion As MySqlConnection
        Dim dataAdapter As MySqlDataAdapter
        'conección
        Dim SuperSecreto As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shiatsuDB").ConnectionString
        coneccion = New MySqlConnection(SuperSecreto)
        'sql
        Dim sql As String = "UPDATE  cat_inventario  SET  cantidad  = @cantidad,  descripcion  = @descripcion,  estado  = @estado, usuario=@usuario, " +
                            "fmodifica=@fmodifica, precio1=@precio1, precio2=@precio2, precio3=@precio3 WHERE  id  = @id"
        'adapter
        dataAdapter = New MySqlDataAdapter()
        dataAdapter.UpdateCommand = New MySqlCommand(sql, coneccion)
        'parametros
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@id", dato.metId))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@cantidad", dato.metCantidad))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@descripcion", dato.metDescripcion))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@estado", dato.metEstado))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@usuario", dato.metUsuario))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@fmodifica", dato.metFmodifica))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@precio1", dato.metPrecio1))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@precio2", dato.metPrecio2))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@precio3", dato.metPrecio3))
        'abre
        coneccion.Open()
        'ejecuta
        dataAdapter.UpdateCommand.ExecuteNonQuery()
        'cierra
        coneccion.Close()

    End Sub


    Public Sub modificarCantidad(ByRef dato As Inventario)

        'variables
        Dim coneccion As MySqlConnection
        Dim dataAdapter As MySqlDataAdapter
        'conección
        Dim SuperSecreto As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shiatsuDB").ConnectionString
        coneccion = New MySqlConnection(SuperSecreto)
        'sql
        Dim sql As String = "UPDATE  cat_inventario  SET  cantidad  =cantidad + @cantidad,   WHERE  id  = @id"
        'adapter
        dataAdapter = New MySqlDataAdapter()
        dataAdapter.UpdateCommand = New MySqlCommand(sql, coneccion)
        'parametros
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@id", dato.metId))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@cantidad", dato.metCantidad))
        'abre
        coneccion.Open()
        'ejecuta
        dataAdapter.UpdateCommand.ExecuteNonQuery()
        'cierra
        coneccion.Close()

    End Sub


    Public Sub modificarCantidad(ByRef cantidadActual As Integer, ByRef cantidadAnterior As Integer, ByRef producto As Integer)

        'variables
        Dim coneccion As MySqlConnection
        Dim dataAdapter As MySqlDataAdapter
        Dim cantidad As Integer
        'conección
        Dim SuperSecreto As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shiatsuDB").ConnectionString
        coneccion = New MySqlConnection(SuperSecreto)
        'sql
        Dim sql2 As String
        '            2                1
        If (cantidadActual > cantidadAnterior) Then
            'rebajo del inventario
            sql2 = "UPDATE cat_inventario SET cantidad = (cantidad - @cantidad) WHERE id = @id"
            cantidad = cantidadActual - cantidadAnterior
        Else
            'cargo al inventario
            sql2 = "UPDATE cat_inventario SET cantidad = (cantidad + @cantidad) WHERE id = @id"
            cantidad = cantidadAnterior - cantidadActual
        End If
        'adapter
        dataAdapter = New MySqlDataAdapter()
        dataAdapter.UpdateCommand = New MySqlCommand(sql2, coneccion)
        'parametros
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@cantidad", cantidad))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@id", producto))
        'abre
        coneccion.Open()
        'ejecuta
        dataAdapter.UpdateCommand.ExecuteNonQuery()
        'cierra
        coneccion.Close()

    End Sub


End Class
