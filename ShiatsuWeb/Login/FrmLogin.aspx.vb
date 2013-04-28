Public Class FrmLogin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnValidar_Click(sender As Object, e As EventArgs) Handles btnValidar.Click
        Try
            Dim usuario As Usuario = New Usuario()
            usuario.usuario = Me.txtIdentificacion.Text
            usuario.contrasena = Me.txtContrasena.Text

            Dim usuarioDao As UsuarioDao = New UsuarioDao()
            usuario = usuarioDao.consultar(usuario)

            If (usuario Is Nothing) Then
                Me.lblError.Text = "Usuario invalido."
            Else
                If (usuario.estado = "Inactivo") Then
                    lblError.Text = "Usuario inactivo, consulte con el administrador."
                    Me.lblError.ForeColor = Drawing.Color.Red
                Else
                    Session("usuario") = usuario
                    Response.Redirect("../Default.aspx")
                End If
            End If

        Catch ex As Exception
            Me.lblError.Text = "Error verifique que el usuario existe." + vbNewLine + ex.Message
            Me.lblError.ForeColor = Drawing.Color.Red
        End Try
    End Sub
End Class