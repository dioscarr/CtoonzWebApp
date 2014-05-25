Public Class WebForm6
    Inherits System.Web.UI.Page
    
    Private objCustomer As Customer
    Dim objrb As New RadioButtonList
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Try
            objCustomer.ImmediateDelete(Request.Params("ID"))
            Response.Redirect("SongsManagement.aspx")
        Catch objX As ArgumentNullException
            lblMessage.Text = objX.Message
        Catch objE As Exception
            lblMessage.Text = objE.Message
        End Try
    End Sub
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        Try
            With objCustomer
                .Track = txtTrackName.Text
                .Artist = txtArtist.Text
                .Status = txtStatus.Text
                .Album = txtAlbum.Text
            End With
            objCustomer.Save()
            Response.Redirect("SongsManagement.aspx")
        Catch objNSE As NotSupportedException
            lblMessage.Text = "Business Rule violation! " & objNSE.Message
        Catch objX As ArgumentNullException
            lblMessage.Text = objX.Message
        Catch objE As Exception
            lblMessage.Text = objE.Message
        Finally
            lblMessage.Text = ""
            txtIDNumber.Text = ""
            txtArtist.Text = ""
            txtTrackName.Text = ""
            txtAlbum.Text = ""
            txtStatus.Text = ""
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            objCustomer = New Customer
            objCustomer.Load(Request.Params("ID"))
            Session.Item("objCustomer") = objCustomer
            txtAlbum.Text = objCustomer.Album
            txtTrackName.Text = objCustomer.Track
            txtIDNumber.Text = objCustomer.ID
            txtStatus.Text = objCustomer.Status
            txtArtist.Text = objCustomer.Artist
        Else
            objCustomer = Session.Item("objCustomer")
        End If
       
    End Sub

    Protected Sub txtAlbum_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtAlbum.TextChanged

    End Sub
End Class