Public Class startpage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        If txtUsername.Text = "ctoonz" And txtPassword.Text = "dmc10040" Then

            Response.Redirect("SongsManagement.aspx")

        Else
            txtUsername.Text = "wrong username or password"
        End If




    End Sub
End Class