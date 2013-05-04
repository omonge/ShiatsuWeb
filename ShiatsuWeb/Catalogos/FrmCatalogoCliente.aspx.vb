Public Class FrmCatalogoCliente
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click

    End Sub

    Protected Sub ddlDiagnostico_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlDiagnostico.SelectedIndexChanged

        Select Case Me.ddlDiagnostico.SelectedItem.Text.Split(" ").Length

            Case 2
                Me.txtApellido1.Text = Me.ddlDiagnostico.SelectedItem.Text.Split(" ")(0)
                Me.txtNombre.Text = Me.ddlDiagnostico.SelectedItem.Text.Split(" ")(1)

            Case 3
                Me.txtApellido1.Text = Me.ddlDiagnostico.SelectedItem.Text.Split(" ")(0)
                Me.txtApellido2.Text = Me.ddlDiagnostico.SelectedItem.Text.Split(" ")(1)
                Me.txtNombre.Text = Me.ddlDiagnostico.SelectedItem.Text.Split(" ")(2)

            Case 4
                Me.txtApellido1.Text = Me.ddlDiagnostico.SelectedItem.Text.Split(" ")(0)
                Me.txtApellido2.Text = Me.ddlDiagnostico.SelectedItem.Text.Split(" ")(1)
                Me.txtNombre.Text = Me.ddlDiagnostico.SelectedItem.Text.Split(" ")(2)
                Me.txtNombre.Text += Me.ddlDiagnostico.SelectedItem.Text.Split(" ")(3)
        End Select

        Me.txtIdentificacion.Text = Me.ddlDiagnostico.SelectedItem.Value

    End Sub
End Class