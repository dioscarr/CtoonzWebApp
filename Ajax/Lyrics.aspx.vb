Imports System.IO
Public Class WebForm10
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim objCustomer As New Customer
        objCustomer.Load(Request.Form("ID"))
        Dim path As String = objCustomer.LyricsUrl



        ' If Not path = "" Then

        'Dim sr As StreamReader = New StreamReader(objCustomer.LyricsUrl)

        '  Do While sr.Peek() >= 0

        'myLyrics.Text += sr.ReadLine() + "<br/>"
        myLyrics.Text = "yes this is working"
        '  Loop
        '  sr.Close()


        '  End If
    End Sub

End Class