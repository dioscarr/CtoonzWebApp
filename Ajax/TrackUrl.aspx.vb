Imports System.Web.Services
Public Class WebForm5
    Inherits System.Web.UI.Page
    Dim objCustomer As Customer
    Dim objCustomerList As CustomerList
    Dim myID As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        myID = Request.QueryString("ID")

    End Sub

    <WebMethod()> Public Shared Function WebMethodTrackUrl(ByVal name As String) As String
        Dim ID1 As String = name

        Dim mysharedcus As New Customer
        Dim myTrackUrl As String
        mysharedcus.Load(ID1)
        myTrackUrl = mysharedcus.TrackUrl
        Return myTrackUrl
    End Function

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        objcustomer = New Customer
        If objCustomerList Is Nothing Then
            objCustomerList = New CustomerList
        End If

        If Not myID = "" Then
            'checking if Upload control has files attached
            If TrackMp3.HasFile = True Then

                'Declare Variable(s)
                Dim Trackpath As String = ""
                'Get ID values from request

                'Object song created 


                Trackpath = Server.MapPath("~/MP3/" + TrackMp3.FileName.ToString())
                TrackMp3.SaveAs(Trackpath)

                objCustomer.Load(myID)

                With objCustomer
                    Dim replacedstring As String = ""

                    replacedstring = TrackMp3.FileName.Replace(" ", "%20")

                    .TrackUrl = replacedstring

                End With
                objCustomer.Save()
            End If

        End If


        Response.Redirect("SongsManagement.aspx")
    End Sub

    Public Sub ProcessRequest(context As HttpContext)
        Dim files As HttpFileCollection = context.Request.Files
        For Each key As String In files
            Dim file As HttpPostedFile = files(key)
            Dim fileName As String = file.FileName
            fileName = context.Server.MapPath("~/MP3/" & fileName)
            file.SaveAs(fileName)
        Next
        context.Response.ContentType = "text/plain"
        context.Response.Write("File(s) uploaded successfully!")
    End Sub

   
    Protected Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click

    End Sub
End Class