Option Explicit On
Option Strict On

Imports System.IO
Imports System.Configuration
Imports System.Data.SqlClient
Public Class DashboardMethods
    Inherits Dashboard



#Region "Connection String Declaration – FOR MS ACCESS 2003 DATABASE" 
    Private Const strConn As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ctoonz\Source\Repos\CtoonzWebApp2\Ajax\App_Data\Songs.mdf;Integrated Security=True"
#End Region

#Region "Private data members:"
    Private _ID As String

#End Region



    Public Sub load()
        '
        'Dim objConn As New OleDbConnection(strConn)
        Dim objConn As New SqlConnection(strConn)
        Try

           
            objConn.Open()
            Dim strSQL As String = "SELECT * FROM Dashboard"
            'Dim objCmd As New OleDbCommand(strSQL, objConn)
            Dim objCmd As New SqlCommand(strSQL, objConn)
           
            Dim objDR As SqlDataReader = objCmd.ExecuteReader

            If objDR.HasRows Then
                objDR.Read()
                If IsDBNull(CStr(objDR.Item(0))) Then
                    Me._ID = CStr(objDR.Item(0)).Trim
                    Me.BKCOLOR = CStr(objDR.Item(1)).Trim
                    Me.BKIMAGECOLOR = CStr(objDR.Item(2)).Trim

                Else
                    Me._ID = CStr(objDR.Item(0)).Trim
                    Me.BKCOLOR = CStr(objDR.Item(1)).Trim
                    Me.BKIMAGECOLOR = CStr(objDR.Item(2)).Trim
                End If

            Else

                Throw New System.ApplicationException("Load Error! Record Not Found")
            End If

        Catch objBOEx As NotSupportedException
            Throw New System.NotSupportedException(objBOEx.Message)
        Catch objA As ApplicationException
            Throw New System.ApplicationException(objA.Message)
        Catch objEx As Exception
            Throw New System.Exception("Load Error: " & objEx.Message)

        Finally

            objConn.Close()
            objConn.Dispose()
            objConn = Nothing
        End Try

        MyBase.MarkOld()

    End Sub

    Public Sub Save()

        If Me.IsDeleted And Not Me.IsNew Then
            'Calls Local DataPortal_Delete(Key) to execute query
            Delete(Me._ID)

        Else
            'Only if dirty, Update or Insert, otherwise do nothing
            If Me.IsDirty Then
                If Me.IsNew Then
                    'We are new so insert new record in database
                    'Calls Local DataPortal_Insert() to execute query
                    Insert()
                Else
                    'We are OLD so updated record in database
                    'Calls Local DataPortal_Update() to execute query
                    'Update()
                End If
            End If

        End If

    End Sub
    Public Sub Update()

        'Dim objConn As New OleDbConnection(strConn)
        Dim objConn As New SqlConnection(strConn)
        Try

            objConn.Open()

            Dim strSQL As String
            strSQL = "UPDATE Dashboard SET BK_Color = @BK_Color, BK_Imageurl = @BK_Imageurl where ID=@ID"

            'Dim objCmd As New OleDbCommand(strSQL, objConn)
            Dim objCmd As New SqlCommand(strSQL, objConn)



            objCmd.Parameters.Add("@ID", SqlDbType.NChar).Value = "1"
            objCmd.Parameters.Add("@BK_Color", SqlDbType.VarChar).Value = Me.BKCOLOR
            objCmd.Parameters.Add("@BK_Imageurl", SqlDbType.VarChar).Value = Me.BKIMAGECOLOR




            'Step 6-Execute Non-Row Query Test result and throw exception if failed 
            Dim intRecordsAffected As Integer = objCmd.ExecuteNonQuery()
            If intRecordsAffected <> 1 Then


                Throw New System.ApplicationException("UPDATE Query Failed")
            End If
            'Step 7-Terminate Command Object
            objCmd.Dispose()
            objCmd = Nothing
            'Step B-Trap for BO, App & General Exceptions 
        Catch objBOEx As NotSupportedException
            Throw New System.NotSupportedException(objBOEx.Message)
        Catch objA As ApplicationException
            Throw New System.ApplicationException(objA.Message)
        Catch objEx As Exception
            Throw New System.Exception("Update Error: " & objEx.Message)
        Finally 'Step 8-Terminate connection 
            objConn.Close()
            objConn.Dispose()
            objConn = Nothing

        End Try

        MyBase.MarkOld()
    End Sub

    Public Sub Insert()
        ' Dim objConn As New OleDbConnection(strConn)
        Dim objConn As New SqlConnection(strConn)
        Try

            objConn.Open()

            Dim strSQL As String
            strSQL = "INSERT INTO Dashboard (BK_Color, BK_Imageurl) VALUES(@BK_Color, @BK_Imageurl)"

            'Dim objCmd As New OleDbCommand(strSQL, objConn)
            Dim objCmd As New SqlCommand(strSQL, objConn)

            objCmd.Parameters.Add("@BK_Color", SqlDbType.VarChar).Value = Me.BKCOLOR
            objCmd.Parameters.Add("@BK_Imageurl", SqlDbType.VarChar).Value = Me.BKIMAGECOLOR

            Dim intRecordsAffected As Integer = objCmd.ExecuteNonQuery()
            If intRecordsAffected <> 1 Then
                Throw New System.ApplicationException("INSERT Query Failed")
            End If

            objCmd.Dispose()
            objCmd = Nothing

        Catch objBO As NotSupportedException
            Throw New System.NotSupportedException(objBO.Message)
        Catch objA As ApplicationException
            Throw New System.ApplicationException(objA.Message)
        Catch objEx As Exception
            Throw New System.Exception("Insert Error: " & objEx.Message)
        Finally
            'Step 8-Terminate connection
            objConn.Close()
            objConn.Dispose()
            objConn = Nothing
        End Try
        MyBase.MarkOld()
    End Sub


    Public Sub Delete(ByVal Key As String)
        'Dim objConn As New OleDbConnection(strConn)
        Dim objConn As New SqlConnection(strConn)
        Try

            objConn.Open()

            Dim strSQL As String = "DELETE FROM Dashboard WHERE ID = @ID"

            ' Dim objCmd As New OleDbCommand(strSQL, objConn)
            Dim objCmd As New SqlCommand(strSQL, objConn)
            objCmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Key

            Dim intRecordsAffected As Integer = objCmd.ExecuteNonQuery()
            If intRecordsAffected <> 1 Then
                Throw New System.ApplicationException("DELETE Query Failed")
            End If

            objCmd.Dispose()
            objCmd = Nothing

        Catch objBO As NotSupportedException
            Throw New System.NotSupportedException(objBO.Message)
        Catch objA As ApplicationException
            Throw New System.ApplicationException(objA.Message)
        Catch objEx As Exception
            Throw New System.Exception("Delete Error: " & objEx.Message)
        Finally

            objConn.Close()
            objConn.Dispose()
            objConn = Nothing
        End Try
        MyBase.MarkNew()
    End Sub
End Class
