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
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnApply.Click
        Try
            With objCustomer
                .Track = txtTrackName.Text
                .Artist = txtArtist.Text
                .Status = txtStatus.Text
                .Album = txtAlbum.Text
                .YoutubeUrl = txtYoutubeID.Text
            End With
           



            'checking if Upload control has files attached
            If LyricscPdf.HasFile = True Then

                'Declare Variable(s)
                Dim Lyricspath As String = ""

                'Object song created 

                Lyricspath = Server.MapPath(LyricscPdf.FileName.ToString())
                LyricscPdf.SaveAs(Lyricspath)

                Dim nospace As String = ""
                nospace = LyricscPdf.FileName.Replace(" ", "%20")
                With objCustomer
                    .LyricsUrl = nospace
                End With
                
            End If
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
            txtYoutubeID.Text = objCustomer.YoutubeUrl
        Else
            objCustomer = Session.Item("objCustomer")
        End If
        txtIDNumber.Visible = False
    End Sub

    Protected Sub txtAlbum_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtAlbum.TextChanged

    End Sub
End Class