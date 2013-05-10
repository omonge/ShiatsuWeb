Public Class FrmRegistro
    Inherits System.Web.UI.Page
    Dim usuarioDao As UsuarioDao = New UsuarioDao()
    Dim usuario As Usuario = New Usuario()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'VERIFICA LA SEGURIDAD
        Usuario = Session("usuario")
        If (Usuario Is Nothing) Then
            Response.Redirect("../Login/FrmLogin.aspx")
        End If
        Me.lblMensaje.Text = ""
    End Sub

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try

            If (txtUserName.Text <> "" And txtNombre.Text <> "") Then

                Dim usuario As Usuario = New Usuario()
                usuario.caja = Me.ddlCaja.SelectedValue
                usuario.cubiculo = Me.ddlCubiculos.SelectedValue
                usuario.estado = Me.ddlEstados.SelectedValue
                usuario.usuario = Me.txtUserName.Text
                usuario.nombre = Me.txtNombre.Text
                usuario.contrasena = Me.txtPassword1.Text
                usuario.perfil = Me.ddlPerfil.SelectedValue
                usuarioDao.insertar(usuario)
                Me.lblError.ForeColor = Drawing.Color.Blue
                Me.lblMensaje.Text = "Registro agregado"

                Me.btnAgregar.Visible = True
                Me.btnModificar.Visible = False
                Me.gvDatos.DataBind() 'refresca los datos 
                Me.limpiar()
            Else
                Me.lblError.Text = "Campos con * son requeridos."
                Me.lblError.ForeColor = Drawing.Color.Red
            End If

        Catch ex As Exception
            Me.lblError.ForeColor = Drawing.Color.Red
            Me.lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub gvDatos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvDatos.SelectedIndexChanged
        Me.txtUserName.Text = Me.gvDatos.SelectedRow.Cells(1).Text
        Me.txtNombre.Text = Me.gvDatos.SelectedRow.Cells(2).Text
        Me.ddlPerfil.SelectedValue = Me.gvDatos.SelectedRow.Cells(3).Text
        Me.ddlCubiculos.SelectedValue = Me.gvDatos.SelectedRow.Cells(4).Text
        Me.ddlCaja.SelectedValue = Me.gvDatos.SelectedRow.Cells(5).Text
        Me.ddlEstados.SelectedValue = Me.gvDatos.SelectedRow.Cells(6).Text
        Me.btnAgregar.Visible = False
        Me.btnModificar.Visible = True
        Me.rfvContrasena1.Enabled = False
        Me.rfvContrasena2.Enabled = False
    End Sub

    Protected Sub limpiar()
        Me.txtUserName.Text = ""
        Me.txtNombre.Text = ""
        Me.txtPassword1.Text = ""
        Me.txtPassword2.Text = ""

    End Sub

    Protected Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
             
            If (txtUserName.Text <> "" And txtNombre.Text <> "") Then

                Dim usuario As Usuario = New Usuario()
                usuario.caja = Me.ddlCaja.SelectedValue
                usuario.cubiculo = Me.ddlCubiculos.SelectedValue
                usuario.estado = Me.ddlEstados.SelectedValue
                usuario.usuario = Me.txtUserName.Text
                usuario.nombre = Me.txtNombre.Text
                usuario.contrasena = Me.txtPassword1.Text
                usuario.perfil = Me.ddlPerfil.SelectedValue
                usuarioDao.modifica(usuario)
                Me.lblMensaje.ForeColor = Drawing.Color.Blue
                Me.lblMensaje.Text = "Registro modificado"
            Else
                Me.lblError.Text = "Campos con * son requeridos."
                Me.lblError.ForeColor = Drawing.Color.Red
            End If

            Me.btnAgregar.Visible = True
            Me.btnModificar.Visible = False
            Me.rfvContrasena1.Enabled = True
            Me.rfvContrasena2.Enabled = True
            Me.limpiar()
            Me.gvDatos.DataBind() 'refresca los datos 
        Catch ex As Exception
            Me.lblMensaje.ForeColor = Drawing.Color.Red
            Me.lblMensaje.Text = "Error: " + ex.Message
        End Try
    End Sub
End Class