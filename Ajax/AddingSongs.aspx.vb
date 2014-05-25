Public Class WebForm3
    Inherits System.Web.UI.Page

    Dim objcustomer As Customer



    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Try
            objcustomer = New Customer

            'Step 1-Calls Collection Add(Value1,Value2,.) pass text control arguments
            With objcustomer
                .ID = txtIDNumber.Text
                .Track = txtfName.Text
                .Artist = txtLname.Text
                .Status = txtSSNum.Text
                '.Address = txtAddress.Text
                '.PhoneNumber = txtPhone.Text
            End With

            objcustomer.Save()

            'Step B-Traps for Business Rule violations
        Catch objNSE As NotSupportedException
            lblMessage.Text = "Business Rule violation! " & objNSE.Message
            'Step C-Traps for ArgumentNullException when key is Nothing or null.
        Catch objX As ArgumentNullException
            'Step D-Inform User
            lblMessage.Text = objX.Message
            'Step E-Traps for ArgumentExecption when KEY is duplicate.
        Catch objY As ArgumentException
            'Step F-Inform User
            lblMessage.Text = objY.Message
            'Step G-Traps for general exceptions.
        Catch objE As Exception
            'Step H-Inform User
            lblMessage.Text = objE.Message
        Finally

        End Try
        Response.Redirect("pos.aspx")
    End Sub
End Class