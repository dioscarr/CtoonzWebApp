Option Explicit On
Option Strict On
Imports System.IO                                       'File/IO
Imports System.Data                                     'Data Access (DataSet)
Imports System.Data.SqlClient
Imports System.Data.OleDb 'OLEDB Provider
Imports System.Configuration

<Serializable()> _
Public MustInherit Class Dashboard
    Inherits BusinessBase

    Private _bkColor As String
    Private _bkImageurl As String



    Public Sub New()

        _bkColor = ""
        _bkImageurl = ""

    End Sub
    'Constructor with parameters
    Public Sub New(ByVal strbkColor As String, ByVal strbkImageurl As String)
        BKCOLOR = strbkColor
        BKIMAGECOLOR = strbkImageurl

    End Sub

    Public Property BKCOLOR() As String
        Get
            Return _bkColor
        End Get
        Set(value As String)
            If value = Nothing Then
            Else
                _bkColor = value
            End If
            MyBase.MarkDirty()
        End Set
    End Property

    Public Property BKIMAGECOLOR() As String

        Get
            Return _bkImageurl
        End Get
        Set(value As String)
            If value = Nothing Then

            Else
                _bkImageurl = value
            End If
            MyBase.MarkDirty()

        End Set


    End Property



End Class
