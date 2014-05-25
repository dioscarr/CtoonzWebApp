Public Class WebForm1
    Inherits System.Web.UI.Page

    Dim objCustomer(0) As Customer

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        'Step A-Begins Exeception handling.
        Try
            objCustomer(0) = New Customer

            objCustomer(0).Load(txtIDNumber.Text.Trim)



            GridView1.DataSource = objCustomer
            GridView1.DataBind()

            'Step B-Traps for Business Rule violations
        Catch objNSE As NotSupportedException
            lblMessage.Text = "Business Rule violation! " & objNSE.Message
            'Step C-Traps for ArgumentNullException when key is Nothing or null.
        Catch objX As ArgumentNullException
            'Step D-Inform User
            lblMessage.Text = objX.Message
            'Step E-Traps for general exceptions.
        Catch objE As Exception
            'Step F-Inform User
            lblMessage.Text = objE.Message
        End Try
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        Response.Redirect("pos.aspx")
    End Sub
End Class