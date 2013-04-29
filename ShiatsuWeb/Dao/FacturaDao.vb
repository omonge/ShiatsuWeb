Imports MySql.Data.MySqlClient

Public Class FacturaDao

 

    Public Sub crearEncabezado(ByRef dato As FacturaEncabezado)

        'variables
        Dim coneccion As MySqlConnection
        Dim dataAdapter As MySqlDataAdapter
        'conección
        Dim SuperSecreto As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shiatsuDB").ConnectionString
        coneccion = New MySqlConnection(SuperSecreto)
        'sql
        Dim sql As String = "INSERT INTO factura_encabezado(usuario,factura,fecha,cliente,estado) VALUES (@usuario,@factura,@fecha,@cliente,@estado)"
        'adapter
        dataAdapter = New MySqlDataAdapter()
        dataAdapter.InsertCommand = New MySqlCommand(sql, coneccion)
        'parametros
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@usuario", dato.metUsuario))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@factura", dato.metFactura))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@fecha", Date.Now))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@cliente", dato.metCliente))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@estado", dato.metEstado))
        'abre
        coneccion.Open()
        'ejecuta
        dataAdapter.InsertCommand.ExecuteNonQuery()
        'cierra
        coneccion.Close()

    End Sub



    Public Sub crearDetalle(ByRef dato As FacturaDetalle)

        'variables
        Dim coneccion As MySqlConnection
        Dim dataAdapter As MySqlDataAdapter
        'conección
        Dim SuperSecreto As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shiatsuDB").ConnectionString
        coneccion = New MySqlConnection(SuperSecreto)
        'sql
        Dim sql1 As String = "INSERT INTO factura_detalle(factura,fmodifica,usuario,producto,cantidad,precio)" +
                            "VALUES (@factura,@fmodifica,@usuario,@producto,@cantidad,@precio)"

        Dim sql2 As String = "UPDATE cat_inventario SET cantidad = cantidad - @cantidad WHERE id = @id"
        'adapter
        dataAdapter = New MySqlDataAdapter()
        dataAdapter.InsertCommand = New MySqlCommand(sql1, coneccion)
        dataAdapter.UpdateCommand = New MySqlCommand(sql2, coneccion)
        'parametros
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@factura", dato.metFactura))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@fmodifica", dato.metFmodifica))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@usuario", dato.metUsuario))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@producto", dato.metProducto))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@cantidad", dato.metCantidad))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@precio", dato.metPrecio))

        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@cantidad", dato.metCantidad))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@id", dato.metProducto))
        'abre
        coneccion.Open()
        'ejecuta
        dataAdapter.InsertCommand.ExecuteNonQuery()
        dataAdapter.UpdateCommand.ExecuteNonQuery()
        'cierra
        coneccion.Close()

    End Sub

    Public Sub modificarDetalle(ByRef dato As FacturaDetalle)

        'variables
        Dim coneccion As MySqlConnection
        Dim dataAdapter As MySqlDataAdapter
        'conección
        Dim SuperSecreto As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shiatsuDB").ConnectionString
        coneccion = New MySqlConnection(SuperSecreto)
        'sql
        Dim sql1 As String = "UPDATE factura_detalle SET " +
                            "fmodifica=@fmodifica, usuario=@usuario, cantidad=@cantidad " +
                            "WHERE factura=@factura AND producto=@producto "
 
        'adapter
        dataAdapter = New MySqlDataAdapter()
        dataAdapter.UpdateCommand = New MySqlCommand(sql1, coneccion) 
        'parametros
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@factura", dato.metFactura))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@fmodifica", dato.metFmodifica))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@usuario", dato.metUsuario))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@producto", dato.metProducto))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@cantidad", dato.metCantidad))
        'abre
        coneccion.Open()
        'ejecuta
        dataAdapter.UpdateCommand.ExecuteNonQuery() 
        'cierra
        coneccion.Close()
        
    End Sub



    Public Sub eliminarDetalle(ByRef dato As FacturaDetalle)

        'variables
        Dim coneccion As MySqlConnection
        Dim dataAdapter As MySqlDataAdapter
        'conección
        Dim SuperSecreto As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shiatsuDB").ConnectionString
        coneccion = New MySqlConnection(SuperSecreto)
        'sql
        Dim sql As String = "DELETE FROM  factura_detalle WHERE factura=@factura AND producto=@producto "
         
        'adapter
        dataAdapter = New MySqlDataAdapter()
        dataAdapter.DeleteCommand = New MySqlCommand(sql, coneccion)
        'parametros
        dataAdapter.DeleteCommand.Parameters.Add(New MySqlParameter("@factura", dato.metFactura))
        dataAdapter.DeleteCommand.Parameters.Add(New MySqlParameter("@producto", dato.metProducto))
        'abre
        coneccion.Open()
        'ejecuta
        dataAdapter.DeleteCommand.ExecuteNonQuery()
        'cierra
        coneccion.Close()

    End Sub



    Public Function existe(ByRef dato As FacturaEncabezado) As Boolean

        'variables
        Dim coneccion As MySqlConnection
        Dim dataSet As DataSet
        Dim dataAdapter As MySqlDataAdapter
        ''abriendo la coneccion o enlace 
        Dim SuperSecreto As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shiatsuDB").ConnectionString
        coneccion = New MySqlConnection(SuperSecreto)
        'sql
        Dim sql As String = "select factura from factura_encabezado where factura = @factura"
        dataAdapter = New MySqlDataAdapter(sql, coneccion)
        'parametros
        dataAdapter.SelectCommand.Parameters.Add(New MySqlParameter("@factura", MySqlDbType.Int32))
        dataAdapter.SelectCommand.Parameters("@factura").Value = dato.metFactura
        ''Creando el dataset y cargandolo
        dataSet = New DataSet()
        dataAdapter.Fill(dataSet, "factura_encabezado")
        'verifica si existe fila
        Dim filas As DataRowCollection = dataSet.Tables("factura_encabezado").Rows()
        If (filas.Count = 0) Then
            Return False
        Else
            Return True
        End If

    End Function


    Public Function consultaEncabezadoFactura(ByRef dato As Integer) As FacturaEncabezado

        'variables
        Dim coneccion As MySqlConnection
        Dim dataSet As DataSet
        Dim dataAdapter As MySqlDataAdapter
        ''abriendo la coneccion o enlace 
        Dim SuperSecreto As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shiatsuDB").ConnectionString
        coneccion = New MySqlConnection(SuperSecreto)
        'sql
        Dim sql As String = "select f.cliente,f.estado,f.fecha,f.factura,f.usuario,c.telefono_celular, c.tipo_cliente, c.nombre_factura " +
                            "from factura_encabezado f, cat_cliente c, cat_tipo_cliente t " +
                            "where f.factura = @factura AND c.cedcliente = f.cliente AND c.tipo_cliente = t.id "
        dataAdapter = New MySqlDataAdapter(sql, coneccion)
        'parametroid
        dataAdapter.SelectCommand.Parameters.Add(New MySqlParameter("@factura", dato)) 
        ''Creando el dataset y cargandolo
        dataSet = New DataSet()
        dataAdapter.Fill(dataSet, "factura_encabezado")
        'verifica si existe fila
        Dim filas As DataRowCollection = dataSet.Tables("factura_encabezado").Rows()
        If (filas.Count <> 0) Then
            Dim fila As DataRow = dataSet.Tables("factura_encabezado").Rows(0)
            Dim facturaEncabezado As FacturaEncabezado = New FacturaEncabezado()
            facturaEncabezado.metCliente.metCedCliente = fila("cliente")
            facturaEncabezado.metEstado = fila("estado")
            facturaEncabezado.metFecha = fila("fecha")
            facturaEncabezado.metFactura = fila("factura")
            facturaEncabezado.metUsuario = fila("usuario")
            facturaEncabezado.metCliente.metTelefonoCelular = fila("telefono_celular")
            facturaEncabezado.metCliente.metTipoCliente = fila("tipo_cliente")
            facturaEncabezado.metCliente.metFacturaNombre = fila("nombre_factura")
            Return facturaEncabezado
        Else
            Return Nothing
        End If

    End Function
End Class
