Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        'VERIFICA LA SEGURIDAD
        Dim usuario As Usuario = Session("usuario")
        If (usuario Is Nothing) Then
            Response.Redirect("Login/FrmLogin.aspx")
        End If
    End Sub
End Class