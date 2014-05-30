Imports System.Web.Services

Public Class WebForm7
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim myString As String = Request.Form("ID")

        Dim objcustomer As New Customer



        If Not myString = "" Then
            objcustomer.Load(myString)
            path.Text = objcustomer.TrackUrl
        Else

        End If

    End Sub







End Class