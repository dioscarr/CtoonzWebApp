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


                Trackpath = Server.MapPath(TrackMp3.FileName.ToString())
                TrackMp3.SaveAs(Trackpath)

                objCustomer.Load(myID)

                With objCustomer
                    .TrackUrl = TrackMp3.FileName.Replace(" ", "%20")

                End With
                objCustomer.Save()
            End If

        End If


        Response.Redirect("SongsManagement.aspx")
    End Sub
End Class