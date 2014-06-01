Imports System.Web.Services


Public Class WebForm7
    Inherits System.Web.UI.Page
    Dim objcustomer As New Customer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

       
        Dim myString As String = Request.Form("ID")





        If Not myString = "" Then
            Try
                objcustomer.Load(myString)
                path.Text = objcustomer.TrackUrl
            Catch ex As Exception
                path.Text = ex.Message
            End Try


        Else

        End If

    End Sub

End Class