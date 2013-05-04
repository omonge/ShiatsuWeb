Imports MySql.Data.MySqlClient

Public Class DiagnosticoDao

    Public Sub insertar(ByRef dato As Diagnostico)

        'variables
        Dim coneccion As MySqlConnection
        Dim dataAdapter As MySqlDataAdapter
        'conección
        Dim SuperSecreto As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shiatsuDB").ConnectionString
        coneccion = New MySqlConnection(SuperSecreto)
        'sql
        Dim sql As String = "INSERT INTO cat_diagnostico (usuario,estado,fmodifica,cedcliente,nombre,porcentaje_perdida, " +
                            "dermatitis_oleosa, dermatitis_seborreica, dermatitis_seca, caspa, hongo, deshidratacion, " +
                            "psoriasis, telanocitos, tipo_alopecia) " +
                            "VALUES (@usuario,@estado,@fmodifica,@cedcliente,@nombre,@porcentaje_perdida, " +
                            "@dermatitis_oleosa,@dermatitis_seborreica,@dermatitis_seca, @caspa, @hongo, @deshidratacion, " +
                            "@psoriasis, @telanocitos, @tipo_alopecia)"

        'sql = "INSERT INTO cat_diagnostico (usuario) VALUES(@usuario) "


        'adapter
        dataAdapter = New MySqlDataAdapter()
        dataAdapter.InsertCommand = New MySqlCommand(sql, coneccion)
        'parametros
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@usuario", dato.metUsuario))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@estado", dato.metEstado))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@fmodifica", dato.metFmodifica))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@cedcliente", dato.metCedCliente))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@nombre", dato.metNombre))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@porcentaje_perdida", dato.metPorcentajePerdida))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@dermatitis_oleosa", dato.metDermatitisOleosa))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@dermatitis_seborreica", dato.metDermatitisSeborreica))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@dermatitis_seca", dato.metDermatitisSeca))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@caspa", dato.metCaspa))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@hongo", dato.metHongo))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@deshidratacion", dato.metDeshidratacion))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@psoriasis", dato.metPsoriasis))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@telanocitos", dato.metTelanocitos))
        dataAdapter.InsertCommand.Parameters.Add(New MySqlParameter("@tipo_alopecia", dato.metTipoAlopecia.metId))
        'abre
        coneccion.Open()
        'ejecuta
        dataAdapter.InsertCommand.ExecuteNonQuery()
        'cierra
        coneccion.Close()

    End Sub



    Public Sub modificar(ByRef dato As Diagnostico)

        'variables
        Dim coneccion As MySqlConnection
        Dim dataAdapter As MySqlDataAdapter
        'conección
        Dim SuperSecreto As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shiatsuDB").ConnectionString
        coneccion = New MySqlConnection(SuperSecreto)
        'sql
        Dim sql As String = "UPDATE cat_diagnostico SET usuario=@usuario,estado=@estado,fmodifica=@fmodifica,nombre=@nombre,porcentaje_perdida=@porcentaje_perdida, " +
                          "dermatitis_oleosa=@dermatitis_oleosa, dermatitis_seborreica=@dermatitis_seborreica, dermatitis_seca=@dermatitis_seca, caspa=@caspa, hongo=@hongo, deshidratacion=@deshidratacion, " +
                          "psoriasis=@psoriasis, telanocitos=@telanocitos, tipo_alopecia=@tipo_alopecia " +
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
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@porcentaje_perdida", dato.metPorcentajePerdida))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@dermatitis_oleosa", dato.metDermatitisOleosa))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@dermatitis_seborreica", dato.metDermatitisSeborreica))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@dermatitis_seca", dato.metDermatitisSeca))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@caspa", dato.metCaspa))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@hongo", dato.metHongo))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@deshidratacion", dato.metDeshidratacion))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@psoriasis", dato.metPsoriasis))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@telanocitos", dato.metTelanocitos))
        dataAdapter.UpdateCommand.Parameters.Add(New MySqlParameter("@tipo_alopecia", dato.metTipoAlopecia.metId))
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
        Dim sql As String = "select cedcliente from cat_diagnostico where cedcliente = @cedcliente"
        dataAdapter = New MySqlDataAdapter(sql, coneccion)
        'parametros
        dataAdapter.SelectCommand.Parameters.Add(New MySqlParameter("@cedcliente", MySqlDbType.Int32))
        dataAdapter.SelectCommand.Parameters("@cedcliente").Value = dato.metId
        ''Creando el dataset y cargandolo
        dataSet = New DataSet()
        dataAdapter.Fill(dataSet, "cat_diagnostico")
        'verifica si existe fila
        Dim filas As DataRowCollection = dataSet.Tables("cat_diagnostico").Rows()
        If (filas.Count = 0) Then
            Return False
        Else
            Return True
        End If

    End Function
End Class
