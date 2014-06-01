Public Class WebForm8
    Inherits System.Web.UI.Page
    Dim objCustomer As Customer
    Dim objCustomerList As CustomerList
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lyricspath As String = ""
        objCustomer = New Customer
        If objCustomerList Is Nothing Then
            objCustomerList = New CustomerList
        End If
        If LyricscPdf.HasFile = True Then
            Lyricspath = Server.MapPath("~/upfile/" + LyricscPdf.FileName.ToString())
            LyricscPdf.SaveAs(Lyricspath)
        End If
        objCustomer.Load(Request.Form("ID"))
        With objCustomer
            .LyricsUrl = Lyricspath.Replace(" ", "%20")
        End With
        objCustomer.Save()
        Response.Redirect("SongsManagement.aspx")
    End Sub

End Class