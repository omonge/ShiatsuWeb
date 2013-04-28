Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class UsuarioDao

    ''' <summary>
    ''' consulta un objeto de usuario
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function consultar(ByVal usuario As Usuario) As Usuario
        ''Objetos OLEDB que se ocupan
        Dim coneccion As MySqlConnection
        Dim dataSet As DataSet
        Dim dataAdapter As MySqlDataAdapter
        Dim tieneParametros As Boolean = False

        ''abriendo la coneccion o enlace 
        Dim SuperSecreto As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shiatsuDB").ConnectionString
        coneccion = New MySqlConnection(SuperSecreto)

        Dim sql As String = "select cubiculo,usuario,nombre, password,perfil,estado  from cat_usuario where "
        If (usuario.usuario <> "") Then
            sql = sql + "usuario = '" + usuario.usuario + "' "
            tieneParametros = True
        End If
        If (usuario.contrasena <> "") Then
            If (tieneParametros) Then
                sql = sql + "and password = '" + usuario.contrasena + "' "
            Else
                sql = sql + "password = '" + usuario.contrasena + "' "
            End If
        End If

        dataAdapter = New MySqlDataAdapter(sql, coneccion)

        ''Creando el dataset y cargandolo
        dataSet = New DataSet()
        dataAdapter.Fill(dataSet, "Usuario")
        ''Cargando el datagridview
        Dim filas As DataRowCollection = dataSet.Tables("Usuario").Rows()
        If (filas.Count <> 0) Then
            Dim fila As DataRow = dataSet.Tables("Usuario").Rows(0)
            usuario.nombre = fila("nombre")
            usuario.perfil = fila("perfil")
            usuario.estado = fila("estado")
            usuario.cubiculo = fila("cubiculo")
            Return usuario
        Else
            Return Nothing
        End If

    End Function

    ''' <summary>
    ''' verifica si el objeto de usuario existe
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function existe(ByVal usuario As Usuario) As Boolean

        ''Objetos OLEDB que se ocupan
        Dim coneccion As MySqlConnection
        Dim dataSet As DataSet
        Dim dataAdapter As MySqlDataAdapter 

         ''abriendo la coneccion o enlace 
        Dim SuperSecreto As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shiatsuDB").ConnectionString
        coneccion = New MySqlConnection(SuperSecreto)

        Dim sql As String = "select * from Usuario where usuario = @usuario"
        dataAdapter = New MySqlDataAdapter(sql, coneccion)
        dataAdapter.SelectCommand.Parameters.Add(New MySqlParameter("@usuario", MySqlDbType.VarString))
        dataAdapter.SelectCommand.Parameters("@usuario").Value = usuario.usuario

        ''Creando el dataset y cargandolo
        dataSet = New DataSet()
        dataAdapter.Fill(dataSet, "Usuario")
        ''Cargando el datagridview
        Dim filas As DataRowCollection = dataSet.Tables("Usuario").Rows()
        If (filas.Count = 0) Then
            Return False
        Else
            Return True
        End If

    End Function


End Class
