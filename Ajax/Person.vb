Option Explicit On
Option Strict On
Imports System.IO                                       'File/IO
Imports System.Data                                     'Data Access (DataSet)
Imports System.Data.SqlClient
Imports System.Data.OleDb 'OLEDB Provider
Imports System.Configuration                            'Configuration File for DB Connection
'Keep commented. will be configure later
'Imports System.Runtime.Serialization.Formatters.Binary  'Serialization Library
'Imports System.Runtime.Remoting                         'Remoting
'Imports System.Runtime.Remoting.Channels                'Remoting
'Imports System.Runtime.Remoting.Channels.Http           'Remoting 
<Serializable()> _
Public MustInherit Class person
    Inherits BusinessBase


    'Private regular Data 
    Private _Artist As String
    Private _track As String
    Private _Status As String
    Private _LyricsURL As String
    Private _TrackUrl As String
    Private _YoutubeUrl As String
    '  Private _Age As Integer
    ' Private _Address As String
    ' Private _PhoneNumber As String
    'Private Shared Data
    Private Shared _Count As Integer = 0
    Private _Album As String

    'constructor with no parameters
    Public Sub New()

        _Artist = ""
        _track = ""
        _Status = ""
        _Album = ""
        _LyricsURL = ""
        _TrackUrl = ""
        _YoutubeURL = ""

        _Count = _Count + 1

    End Sub
    'Constructor with parameters
    Public Sub New(ByVal strArtist As String, ByVal strTrack As String, _
                   ByVal strStstus As String, ByVal strAlbum As String, ByVal strLyricsUrl As String, ByVal strTrackUrl As String, ByVal strYoutubeUrl As String)

        Artist = strArtist
        Track = strTrack
        Status = strStstus
        Album = strAlbum
        LyricsUrl = strLyricsUrl
        TrackUrl = strTrackUrl
        YotubeUrl = strYoutubeUrl


        _Count = _Count + 1

    End Sub
    'Regualar Property SSNumber
    Public Property Artist() As String
        Get
            Return _Artist
        End Get
        Set(ByVal value As String)

            'NO-BLANK validation 
            If Len(Trim(value)) = 0 Then
                Throw New NotSupportedException("Business Rule: SSNumber cannot be blank")
            End If
            'WRITE-ONCE validation 
            'If Not Me.IsNew Then
            '    Throw New NotSupportedException("Business Rule: SSNum is Write-once")
            'End If
            'MAX-LENTHG VALIDATION 
            'If Len(value) <> 255 Then
            '    Throw New NotSupportedException("Business Rule: Length cannot be greater than 11 character")
            'End If

            _Artist = value

            MyBase.MarkDirty()
        End Set
    End Property
    'Regualar Property First Name
    Public Property Track() As String
        Get
            Return _Track
        End Get
        Set(ByVal value As String)
            'NO-BLANK validation 
            If Len(Trim(value)) = 0 Then
                Throw New NotSupportedException("Business Rule: Name cannot be blank")
            End If
            'MAX-LENTHG VALIDATION 
            If Len(value) >= 255 Then
                Throw New NotSupportedException("Business Rule:Length of string MUST BE less than 25 character")
            End If


            _track = value

            MyBase.MarkDirty()
        End Set
    End Property
    'Regualar Property Last Name
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            'NO-BLANK validation 
            If Len(Trim(value)) = 0 Then
                Throw New NotSupportedException("Business Rule: Last Name cannot be blank")
            End If
            'MAX-LENTHG VALIDATION 
            If Len(value) >= 255 Then
                Throw New NotSupportedException("Business Rule: Value not exact Lenght")
            End If
            _Status = value

            MyBase.MarkDirty()
        End Set
    End Property
    Public Property Album As String
        Get
            Return _Album
        End Get
        Set(ByVal value As String)

            'If Len(Trim(value)) = 0 Then
            '    Throw New NotSupportedException("Business Rule: Last Name cannot be blank")
            'End If
            If value = Nothing Then

            Else
                _Album = value

            End If
            MyBase.MarkDirty()
        End Set
    End Property
    Public Property LyricsUrl As String
        Get
            Return _LyricsURL
        End Get
        Set(ByVal value As String)

            If value = Nothing Then

            Else
                _LyricsURL = value

            End If
            MyBase.MarkDirty()
        End Set
    End Property
    Public Property TrackUrl As String
        Get
            Return _TrackUrl
        End Get
        Set(ByVal value As String)

            If value = Nothing Then

            Else
                _TrackUrl = value

            End If
            MyBase.MarkDirty()
        End Set
    End Property

    
    Public Shared Property Count() As Integer
        Get
            Return _Count
        End Get
        Set(ByVal value As Integer)
            _Count = value


        End Set
    End Property

    Public Property YotubeUrl As String

        Get
            Return _YoutubeUrl
        End Get
        Set(value As String)
            _YoutubeUrl = value
        End Set
    End Property



  

    'Print Method


    'UserName And Password Authentication
    Public MustOverride Function Authenticate(ByVal strUserName As String, ByVal strPassword As String) As Boolean



End Class
