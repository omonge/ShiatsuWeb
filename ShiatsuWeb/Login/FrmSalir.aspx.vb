Public Class FrmSalir
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session.Remove("usuario")
        Response.Redirect("FrmLogin.aspx")
    End Sub
     
End Class