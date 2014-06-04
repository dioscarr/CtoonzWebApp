Public Class WebForm2
    Inherits System.Web.UI.Page

    Private objCustomer As Customer
    Private objCustomerList As CustomerList
    Dim objrb As New RadioButtonList
    Dim path As String





    Public songpath As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            objCustomerList = New CustomerList
            objCustomer = New Customer

            Try
                objCustomerList.Load()
                Me.Session.Item("objCustomerList") = objCustomerList
                GridView1.DataSource = objCustomerList.ToArray
                GridView1.DataBind()
            Catch ex As ApplicationException
                lblMessage.Text = ex.Message
            Catch ex1 As Exception
                lblMessage.Text = ex1.Message

            End Try
        Else
            Try


                lblMessage.Text = ""
                objCustomer = New Customer
                objCustomerList = New CustomerList
                objCustomerList = Me.Session.Item("objCustomerList")
                GridView1.DataSource = objCustomerList.ToArray
                GridView1.DataBind()

            Catch ex As Exception
                lblMessage.Text = ex.Message
            End Try
        End If
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
       
        Try
            objCustomer = New Customer
            If objCustomerList Is Nothing Then
                objCustomerList = New CustomerList
            End If


          

            With objCustomer

                .Track = txtTrackName.Text
                .Artist = txtLname.Text
                .Status = txtSSNum.Text
                .Album = txtAlbum.Text
                
            End With
            objCustomer.Save()

            objCustomerList = Nothing
            objCustomerList = New CustomerList
            objCustomerList.Load()
            Me.Session.Item("objCustomerList") = objCustomerList

            If objCustomerList Is Nothing Then
                lblMessage.Text = "There is no information in the database"
            Else
                GridView1.DataSource = objCustomerList.ToArray

                GridView1.DataBind()

            End If




            'Me.Session.Item("objCustomerList") = objCustomerList
        Catch objNSE As NotSupportedException
            lblMessage.Text = "Business Rule violation! " & objNSE.Message
        Catch objX As ArgumentNullException
            lblMessage.Text = objX.Message
        Catch objY As ArgumentException
            lblMessage.Text = objY.Message
        Catch objE As Exception
            lblMessage.Text = objE.Message
        Finally

            txtTrackName.Text = ""
            txtLname.Text = ""
            txtSSNum.Text = ""
            txtAlbum.Text = ""
            path = ""
            songpath = ""


        End Try
    End Sub








    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnListAll.Click

        If objCustomerList Is Nothing Then
            lblMessage.Text = "There is no information in the database"
        Else
            GridView1.DataSource = objCustomerList.ToArray

            GridView1.DataBind()

            rb2.SelectedIndex = -1


        End If

    End Sub








    Protected Sub rb2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rb2.SelectedIndexChanged


        If Not objrb.SelectedValue Is Nothing Then
            btnFilter.Enabled = True


        End If


    End Sub

    Protected Sub btnSearchoutput_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFilter.Click

        Dim objFilter As New CustomerList


        Try
            If rb2.SelectedValue = "rbTrack" Then

                If objFilter Is Nothing Then
                    lblMessage.Text = "There is no information in the database"
                Else
                    objFilter.filterbyTrack(txtFiltrerID.Text)
                    GridView1.DataSource = objFilter.ToArray

                    GridView1.DataBind()

                End If
            ElseIf rb2.SelectedValue = "rbArtist" Then

                If objFilter Is Nothing Then
                    lblMessage.Text = "There is no information in the database"
                Else
                    objFilter.filterbyArtist(txtFiltrerID.Text)
                    GridView1.DataSource = objFilter.ToArray

                    GridView1.DataBind()

                End If

            ElseIf rb2.SelectedValue = "rbStatus" Then

                If objFilter Is Nothing Then
                    lblMessage.Text = "There is no information in the database"
                Else
                    objFilter.filterbyStatus(txtFiltrerID.Text)
                    GridView1.DataSource = objFilter.ToArray

                    GridView1.DataBind()

                End If
            End If

        Catch ex2 As NotSupportedException
            lblMessage.Text = ex2.Message
        Catch ex As ApplicationException
            lblMessage.Text = ex.Message
            GridView1.DataSource = ""

            GridView1.DataBind()
        Catch ex1 As Exception
            lblMessage.Text = ex1.Message
        Finally
            objFilter = Nothing
            rb2.SelectedIndex = -1
            txtFiltrerID.Text = ""
        End Try

    End Sub


End Class