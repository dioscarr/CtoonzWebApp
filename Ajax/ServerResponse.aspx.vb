Public Class WebForm4
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objFilter As New CustomerList
        Try

            If Not Request.Form("userid") = "ID" Then



            ElseIf Not Request.Form("userid") = "" Then
                objFilter.filterbyTrack(Request.Form("userid").Trim)

                Dim i As Integer = 0

                While (i <= objFilter.ToArray.Count - 1)
                    mylabel.Text += "<li>" & objFilter.ToArray(i).Track & "</li>"
                    i += 1
                End While


            End If
        Catch ex1 As ApplicationException
            mylabel.Text = "record not found"
        Catch ex2 As NotSupportedException
            mylabel.Text = "not Supported"
        Catch ex As Exception
            mylabel.Text = "Exception"
        End Try
    End Sub

End Class