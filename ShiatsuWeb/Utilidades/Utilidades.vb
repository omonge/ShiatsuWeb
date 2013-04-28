Public Class Utilidades

    Public Shared Function quitaHTML(ByVal hilera As String)
        hilera.Replace("&nbsp;", " ")
        hilera.Replace("&#225;", "á")
        hilera.Replace("&#233;", "é")
        hilera.Replace("&#237;", "í")
        hilera.Replace("&#243;", "ó")
        hilera.Replace("&#250;", "ú")
        Return hilera
    End Function

End Class
