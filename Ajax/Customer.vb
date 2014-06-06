Option Explicit On
Option Strict On

Imports System.IO
Imports System.Configuration
Imports System.Data.SqlClient
'Imports System.Data.OleDb

Public Class Customer
    Inherits person

#Region "Connection String Declaration – FOR MS ACCESS 2003 DATABASE"
    'Data Access Connection string. If FULL PATHh is provide, database must
    ''Be located in the Bin\Debug folder of application 
    ' Private Const strConn As String = "Provider=Microsoft.Jet.OleDB.4.0;" & _
    ' "Data Source=MyOwnDataBase.mdb"

    '********************************************************************************************************
    'Private Const strConn As String = "Data Source=HOME-VAIO\DRSQL;Initial Catalog=myssqldatabase;Integrated Security=True"
    'Catalog=mysqldatabase;Integrated Security=True
    ' Private Const strConn As String = "Data Source=mysqldtabase.mssql.somee.com;User ID=dioscarr_SQLLogin_1;Password=dmc10040"
    Private Const strConn As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ctoonz\Source\Repos\CtoonzWebApp2\Ajax\App_Data\Songs.mdf;Integrated Security=True"
#End Region

#Region "Private data members:"
    Private _ID As String

#End Region

#Region "Public Properties:"
    'Regualar Property IDNumber
    Public Property ID() As String
        Get
            Return _ID
        End Get
        Set(ByVal value As String)
            'NO-BLANK validation 
            'If Len(Trim(value)) = 0 Then
            '    Throw New NotSupportedException("Business Rule: Name cannot be blank")
            'End If
            'WRITE-ONCE validation 
            If Not Me.IsNew Then
                Throw New NotSupportedException("Business Rule: SSNum is Write-once")
            End If
            'MAX-LENTHG VALIDATION 
            _ID = value

            MyBase.MarkDirty()
        End Set
    End Property

   
#End Region

#Region " Public Constructor Methods: "
    'constructor with no parameters
    Public Sub New()

        '    MyBase.New()

        '    Count = Count + 1
        '    _ID = ""

    End Sub
    'Constructor with parameters
    Public Sub New(ByVal strTrack As String, ByVal strArtist As String, _
                   ByVal strStatus As String, ByVal strAlbum As String, ByVal strLyricsUrl As String, ByVal strTrackUrl As String, ByVal strYoutubeUrl As String)

        MyBase.New(strTrack, strArtist, strStatus, strAlbum, strLyricsUrl, strTrackUrl, strYoutubeUrl)

        Track = strTrack
        Artist = strArtist
        Status = strStatus
        Album = strAlbum
        LyricsUrl = strLyricsUrl
        YoutubeUrl = strYoutubeUrl


        Count = Count + 1

    End Sub

#End Region

  
    Public Overrides Function Authenticate(ByVal strUserName As String, ByVal strPassword As String) As Boolean
        Return False

    End Function

    '#End Region

#Region "Public Overridable Methods "
    Overridable Sub Product_Rental()

    End Sub
    Overridable Sub Product_Return()

    End Sub
#End Region


#Region "Public Data Access Methods"
    '*********************************************************************
    'Public interface to Create objects via OBJECT FACTORY METHOD
    Public Shared Function Create() As Customer
        'Calls internal DataPortal_Create method to do the work
        Return DataPortal_Create()
    End Function
    '*********************************************************************
    Public Sub Load(ByVal Key As String)
        'Calls Local DatPortal_Fetch(Key) To do the work
        DataPortal_Fetch(Key)

    End Sub
    '*********************************************************************
    Public Sub Save()
        'Only If Marked for deletion & Old then delete record, otherwise do nothing
        If Me.IsDeleted And Not Me.IsNew Then
            'Calls Local DataPortal_Delete(Key) to execute query
            DataPortal_Delete(Me.ID)

        Else
            'Only if dirty, Update or Insert, otherwise do nothing
            If Me.IsDirty Then
                If Me.IsNew Then
                    'We are new so insert new record in database
                    'Calls Local DataPortal_Insert() to execute query
                    DataPortal_Insert()
                Else
                    'We are OLD so updated record in database
                    'Calls Local DataPortal_Update() to execute query
                    DataPortal_Update()
                End If
            End If

        End If

    End Sub
    '*********************************************************************

    Public Sub ImmediateDelete(ByVal Key As String)

        DataPortal_Delete(Key)
    End Sub

#End Region

#Region "Protected Data Access Methods"
    '*********************************************************************



    Protected Shared Function DataPortal_Create() As Customer




        Return Nothing
    End Function


    Protected Sub DataPortal_Fetch(ByVal Key As String)
        '
        'Dim objConn As New OleDbConnection(strConn)
        Dim objConn As New SqlConnection(strConn)
        Try

            'Step 3-Create SQL

            objConn.Open()
            Dim strSQL As String = "SELECT * FROM songs WHERE ID = @ID"
            'Dim objCmd As New OleDbCommand(strSQL, objConn)
            Dim objCmd As New SqlCommand(strSQL, objConn)
            'objCmd.Parameters.Add("@Customer_ID", OleDbType.VarChar).Value = Key
            objCmd.Parameters.Add("@ID", SqlDbType.NChar).Value = Key
            ' Dim objDR As OleDbDataReader = objCmd.ExecuteReader
            Dim objDR As SqlDataReader = objCmd.ExecuteReader

            If objDR.HasRows Then
                objDR.Read()
                If IsDBNull(CStr(objDR.Item(5))) Then
                    Me._ID = CStr(objDR.Item(0)).Trim
                    Me.Track = CStr(objDR.Item(1)).Trim
                    Me.Artist = CStr(objDR.Item(2)).Trim
                    Me.Status = CStr(objDR.Item(3)).Trim
                    Me.Album = CStr(objDR.Item(4)).Trim
                    Me.LyricsUrl = CStr(objDR.Item(5)).ToString.Trim
                    Me.TrackUrl = CStr(objDR.Item(6)).Trim
                    Me.YoutubeUrl = CStr(objDR.Item(7)).Trim
                Else

                    Me._ID = CStr(objDR.Item(0)).Trim
                    Me.Track = CStr(objDR.Item(1)).Trim
                    Me.Artist = CStr(objDR.Item(2)).Trim
                    Me.Status = CStr(objDR.Item(3)).Trim
                    Me.Album = CStr(objDR.Item(4)).Trim
                    Me.LyricsUrl = CStr(objDR.Item(5)).Trim
                    Me.TrackUrl = CStr(objDR.Item(6)).Trim
                    Me.YoutubeUrl = CStr(objDR.Item(7)).Trim
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


    Protected Sub DataPortal_Update()

        'Dim objConn As New OleDbConnection(strConn)
        Dim objConn As New SqlConnection(strConn)
        Try

            objConn.Open()

            Dim strSQL As String
            strSQL = "UPDATE songs SET Track = @Track, Artist = @Artist, Status = @Status, Album = @Album, LyricsUrl = @LyricsUrl, TrackUrl = @TrackUrl, YoutubeUrl = @YoutubeUrl where ID=@ID"

            'Dim objCmd As New OleDbCommand(strSQL, objConn)
            Dim objCmd As New SqlCommand(strSQL, objConn)



            objCmd.Parameters.Add("@ID", SqlDbType.NChar).Value = Me.ID
            objCmd.Parameters.Add("@Track", SqlDbType.VarChar).Value = Me.Track
            objCmd.Parameters.Add("@Artist", SqlDbType.VarChar).Value = Me.Artist
            objCmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = Me.Status
            objCmd.Parameters.Add("@Album", SqlDbType.VarChar).Value = Me.Album
            objCmd.Parameters.Add("@LyricsUrl", SqlDbType.VarChar).Value = Me.LyricsUrl
            objCmd.Parameters.Add("@TrackUrl", SqlDbType.VarChar).Value = Me.TrackUrl
            objCmd.Parameters.Add("@YoutubeUrl", SqlDbType.VarChar).Value = Me.YoutubeUrl



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


    Protected Sub DataPortal_Insert()
        ' Dim objConn As New OleDbConnection(strConn)
        Dim objConn As New SqlConnection(strConn)
        Try

            objConn.Open()

            Dim strSQL As String
            strSQL = "INSERT INTO Songs (Track, Artist, Status, Album, LyricsUrl, TrackUrl, YoutubeUrl) VALUES(@Track, @Artist, @Status, @Album, @LyricsUrl, @TrackUrl, @YoutubeUrl)"

            'Dim objCmd As New OleDbCommand(strSQL, objConn)
            Dim objCmd As New SqlCommand(strSQL, objConn)

            'objCmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = Me.ID
            objCmd.Parameters.Add("@Track", SqlDbType.VarChar).Value = Me.Track
            objCmd.Parameters.Add("@Artist", SqlDbType.VarChar).Value = Me.Artist
            objCmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = Me.Status
            objCmd.Parameters.Add("@Album", SqlDbType.VarChar).Value = Me.Album
            objCmd.Parameters.Add("@LyricsUrl", SqlDbType.VarChar).Value = Me.LyricsUrl
            objCmd.Parameters.Add("@TrackUrl", SqlDbType.VarChar).Value = Me.TrackUrl
            objCmd.Parameters.Add("@YoutubeUrl", SqlDbType.VarChar).Value = Me.YoutubeUrl

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


    Protected Sub DataPortal_Delete(ByVal Key As String)
        'Dim objConn As New OleDbConnection(strConn)
        Dim objConn As New SqlConnection(strConn)
        Try

            objConn.Open()

            Dim strSQL As String = "DELETE FROM songs WHERE ID = @ID"

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

#End Region

#Region "Helper Methods"

    '*********************************************************************
    'Method will return the Database Connection string from a Configuration File
    'Method takes as parameter a key or ID of the location of the connection string
    'To return.
    Protected Function GetDBConnectionString(ByVal DBNameID As String) As String
        Return ConfigurationManager.AppSettings(DBNameID)
    End Function

#End Region

    'Private Shared Function DataPortal_Create() As Customer
    '    Throw New NotImplementedException
    'End Function


End Class
