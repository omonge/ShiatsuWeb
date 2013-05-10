Public Class FrmVentasPorFecha
    Inherits System.Web.UI.Page
    Dim usuario As Usuario
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'VERIFICA LA SEGURIDAD
        usuario = Session("usuario")
        If (usuario Is Nothing) Then
            Response.Redirect("../Login/FrmLogin.aspx")
        End If 
        Me.lblMensaje.Text = ""

        If (Me.txtFechaInicio.Text = "") Then
            Me.txtFechaInicio.Text = DateTime.Now.ToString("yyyyMMdd")
            Me.txtFechaFin.Text = DateTime.Now.ToString("yyyyMMdd")
            btnConsultat_Click(sender, e)
        End If

    End Sub

    Protected Sub btnConsultat_Click(sender As Object, e As EventArgs) Handles btnConsultat.Click

        Me.consultaDS.SelectCommand =
            "SELECT e.factura, e.caja, e.fecha, e.cliente," +
            "(SELECT c.nombre_factura FROM cat_cliente c WHERE c. cedcliente=e.cliente) nombre," +
            "(SELECT c.descripcion FROM cat_tipo_pago c WHERE c.id =e.tipo_pago) tipo_pago, e.subtotal, e.iva, e.total " +
            "FROM factura_encabezado e " +
            "WHERE e.estado = 'Cerrada' AND DATE_FORMAT(fecha, '%Y%m%d') between  '" + Me.txtFechaInicio.Text + "' and  '" + Me.txtFechaFin.Text + "'" +
            IIf((Me.ddlCaja.SelectedValue = "0" Or Me.ddlCaja.SelectedValue = ""), " ", " and caja =" + Me.ddlCaja.SelectedValue) +
            IIf((Me.ddlTipoPago.SelectedValue = "0" Or Me.ddlTipoPago.SelectedValue = ""), "", " and tipo_pago =" + Me.ddlTipoPago.SelectedValue) +
            " union all " +
            " SELECT null factura, null fecha, null caja, null cliente, null nombre,'Totales' tipo_pago, sum(e.subtotal) subtotal, sum(e.iva) iva, sum(e.total) total " +
            " FROM factura_encabezado e " +
            " WHERE e.estado = 'Cerrada' AND DATE_FORMAT(fecha, '%Y%m%d') between  '" + Me.txtFechaInicio.Text + "' and  '" + Me.txtFechaFin.Text + "'" +
            IIf((Me.ddlCaja.SelectedValue = "0" Or Me.ddlCaja.SelectedValue = ""), " ", " and caja =" + Me.ddlCaja.SelectedValue) +
            IIf((Me.ddlTipoPago.SelectedValue = "0" Or Me.ddlTipoPago.SelectedValue = ""), " ", " and tipo_pago =" + Me.ddlTipoPago.SelectedValue)


    End Sub
End Class