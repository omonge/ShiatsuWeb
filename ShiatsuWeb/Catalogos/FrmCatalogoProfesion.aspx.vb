﻿Public Class FrmCatalogoProfesion
    Inherits System.Web.UI.Page
    Dim usuario As Usuario
    Dim profesionDao As ProfesionDao = New ProfesionDao()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'VERIFICA LA SEGURIDAD
        usuario = Session("usuario")
        If (usuario Is Nothing) Then
            Response.Redirect("../Login/FrmLogin.aspx")
        End If
        Me.lblMensaje.Text = ""
    End Sub


    ''' <summary>
    ''' este evento se ejecuta al agregar
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If (Me.validar()) Then
                Dim profesion As Profesion = New Profesion()

                profesion.metEstado = Me.ddlEstados.SelectedValue
                profesion.metDescripcion = Me.txtDescripcion.Text
                profesion.metFmodifica = DateTime.Now
                profesion.metUsuario = Me.usuario.usuario
                Me.profesionDao.insertar(profesion)
                Me.limpiar() 
                Me.lblMensaje.ForeColor = Drawing.Color.Blue
                Me.lblMensaje.Text = "Registro agregado"
                Me.gvDatos.DataBind() 'refresca los datos
            End If
        Catch ex As Exception
            Me.lblMensaje.ForeColor = Drawing.Color.Red
            Me.lblMensaje.Text = "Error: " + ex.Message
        End Try
    End Sub

    ''' <summary>
    ''' valida los datos antes de insertar y modificar
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function validar() As Boolean
        If (Me.txtDescripcion.Text = "") Then
            Me.lblMensaje.ForeColor = Drawing.Color.Red
            Me.lblMensaje.Text = "Valores requeridos"
            Return False
        Else
            Return True
        End If
    End Function

    ''' <summary>
    ''' limpia los valores al insertar y modificar
    ''' </summary>
    ''' <remarks></remarks>
    Sub limpiar()
        Me.txtId.Text = ""
        Me.txtDescripcion.Text = ""
    End Sub

    ''' <summary>
    ''' este evento se ejecuta al modificar
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try

            If (Me.validar()) Then
                Dim profesion As Profesion = New Profesion()
                profesion.metId = Me.txtId.Text
                profesion.metEstado = Me.ddlEstados.SelectedValue
                profesion.metDescripcion = Me.txtDescripcion.Text
                profesion.metFmodifica = DateTime.Now
                profesion.metUsuario = Me.usuario.usuario
                Me.profesionDao.modificar(profesion)

                Me.limpiar()
                Me.lblMensaje.ForeColor = Drawing.Color.Blue
                Me.lblMensaje.Text = "Registro modificado"

                Me.btnAgregar.Visible = True
                Me.btnModificar.Visible = False
                Me.gvDatos.DataBind() 'refresca los datos
            End If

        Catch ex As Exception
            Me.lblMensaje.ForeColor = Drawing.Color.Red
            Me.lblMensaje.Text = "Error: " + ex.Message
        End Try
    End Sub


    ''' <summary>
    ''' este evento se ejecuta al seleccionar en el data table
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub gvDatos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvDatos.SelectedIndexChanged
        Try
            Me.btnModificar.Visible = True
            Me.btnAgregar.Visible = False

            Me.txtId.Text = Me.gvDatos.SelectedRow.Cells(1).Text
            Me.ddlEstados.SelectedValue = Me.gvDatos.SelectedRow.Cells(2).Text
            Me.txtDescripcion.Text = Me.gvDatos.SelectedRow.Cells(3).Text
        Catch ex As Exception
            Me.lblMensaje.ForeColor = Drawing.Color.Red
            Me.lblMensaje.Text = "Error: " + ex.Message
        End Try
    End Sub

End Class