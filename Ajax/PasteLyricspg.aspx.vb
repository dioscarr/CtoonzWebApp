Imports System.Web.Services

Public Class WebForm8
    Inherits System.Web.UI.Page
    Dim objCustomer As Customer
    Dim objCustomerList As CustomerList
    Dim myID As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        myID = Request.QueryString("ID")

    End Sub

    

    <WebMethod()> Public Shared Function testmethod(ByVal name As String) As String
        Dim ID1 As String = name

        Dim mysharedcus As New Customer
        Dim LyricsUrl As String
        mysharedcus.Load(ID1)
        LyricsUrl = mysharedcus.LyricsUrl

        'LyricsUrl.Split("upfile")

        Return LyricsUrl
    End Function

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        objCustomer = New Customer
        If objCustomerList Is Nothing Then
            objCustomerList = New CustomerList
        End If

        If Not myID = "" Then
            'checking if Upload control has files attached
            If LyricscPdf.HasFile = True Then

                'Declare Variable(s)
                Dim Lyricspath As String = ""
                'Get ID values from request

                'Object song created 

                
                Lyricspath = Server.MapPath(LyricscPdf.FileName.ToString())
                LyricscPdf.SaveAs(Lyricspath)

                objCustomer.Load(myID)
                Dim nospace As String = ""
                nospace = LyricscPdf.FileName.Replace(" ", "%20")
                With objCustomer
                    .LyricsUrl = nospace

                End With
                objCustomer.Save()
            End If

        End If


        Response.Redirect("SongsManagement.aspx")
    End Sub
End Class