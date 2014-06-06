Option Explicit On
Option Strict On

Imports System.IO                                       'File/IO
Imports System.Data                                     'Data Access (DataSet)
'Imports System.Data.OleDb                               'OLEDB Provider
Imports System.Data.SqlClient
Imports System.Configuration                            'Configuration File for DB Connection
Imports System.Collections                              'Collection Library

'Configuration File for DB Connection
'Keep commented. will be configure later
'Imports System.Runtime.Serialization.Formatters.Binary  'Serialization Library
'Imports System.Runtime.Remoting                         'Remoting
'Imports System.Runtime.Remoting.Channels                'Remoting
'Imports System.Runtime.Remoting.Channels.Http           'Remoting 

<Serializable()> _
Public Class CustomerList
    Inherits BusinessCollectionBase


#Region "Connection String Declaration – FOR MS ACCESS 2003 DATABASE"
    'Data Access Connection string. If FULL PATHh is provide, database must
    'Be located in the Bin\Debug folder of application 
    'Private Const strConn As String = "Provider=Microsoft.Jet.OleDB.4.0;" & _
    '"Data Source=MyOwnDataBase.mdb"


    '********************************************************************************************************
    'Private Const strConn As String = "Data Source=HOME-VAIO\DRSQL;Initial Catalog=myssqldatabase;Integrated Security=True"
    ' Private Const strConn As String = "Data Source=mysqldtabase.mssql.somee.com;User ID=dioscarr_SQLLogin_1;Password=dmc10040"
    Private Const strConn As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ctoonz\Source\Repos\CtoonzWebApp2\Ajax\App_Data\Songs.mdf;Integrated Security=True"
#End Region

#Region "Private Data Declaration"
    Private Size As Integer = 9
    Private m_arrCustomerList(Size) As Customer

#End Region
    Dim colll As New Collection

#Region " Public Properties Decalration"

    '---------- COUNT ------------
    Public Shadows ReadOnly Property Count() As Integer
        Get
            Try
                Return MyBase.Dictionary.Count
            Catch objE As Exception
                Throw New System.Exception("Count Property Error: " & objE.Message)
            End Try
        End Get
    End Property
    '***************************************************************************************************************************
    '---------- ITEM ------------
    Public Property Item(ByVal key As String) As Customer
        Get
            Try
                Dim myCustomer As New Customer
                myCustomer = CType(MyBase.Dictionary.Item(key), Customer)
                Return myCustomer
            Catch objE As Exception
                Throw New System.Exception("Item Error: " & objE.Message)
            End Try
        End Get
        Set(ByVal value As Customer)
            Try
                If MyBase.Dictionary.Contains(key) Then
                    MyBase.Dictionary.Item(key) = value
                Else
                    Throw New System.ArgumentException("Customer Not Found, SET failed")
                End If
            Catch objA As ArgumentException
                Throw New System.ArgumentException(objA.Message)
            Catch objE As Exception
            End Try
        End Set
    End Property


    '***************************************************************************************************************************
    '---------- ADD ------------
    Public Sub Add(ByVal key As String, ByVal objCustomer As Customer)
        Try
            MyBase.Dictionary.Add(key, objCustomer)
        Catch objX As ArgumentNullException
            Throw New System.ArgumentNullException("Invalid Key Error: " & objX.Message)
        Catch objY As ArgumentException
            Throw New System.ArgumentException("Duplicate Key Error: " & objY.Message)
        Catch objE As Exception
            Throw New System.Exception("Add Method Error: " & objE.Message)
        End Try
    End Sub
    '***************************************************************************************************************************
    '---------- ADD ------------
    Public Sub Add(ByVal strIDNumByVal As String, ByVal SSNum As String, ByVal FName As String, ByVal LName As String, ByVal Bday As Date, ByVal Address As String, ByVal JobTitle As String, ByVal PhoneNumber As String, ByVal strusername As String, ByVal strPassword As String)
        Try
            Dim objItem As New Customer
            With objItem
                .ID = SSNum
                .Track = FName
                .Artist = LName
                .Status = PhoneNumber
                '.Address = Address
               

            End With
            MyBase.Dictionary.Add(objItem.ID, objItem)
        Catch objX As ArgumentNullException
            Throw New System.ArgumentNullException("Inval   id Key Error: " & objX.Message)
        Catch objY As ArgumentException
            Throw New System.ArgumentException("Duplicate Key Error: " & objY.Message)
        Catch objE As Exception
            Throw New System.Exception("Add Method Error: " & objE.Message)
        End Try
    End Sub
    '***************************************************************************************************************************
    '---------- EDIT ------------
    Public Function Edit(ByVal key As String, ByVal objItem As Customer) As Boolean

        Try

            Dim objCustomer As New Customer

            objCustomer = CType(MyBase.Dictionary.Item(key), Customer)

            If objItem Is Nothing Then
                'Step 4-Return False since not found
                Return False
            Else


                objCustomer.Track = objItem.Track
                objCustomer.Artist = objItem.Artist
                objCustomer.Status = objItem.Status
                objCustomer.Album = objItem.Album


                'check this out
                'MyBase.Dictionary.Remove(key)
                ' Add(objCustomer.SSNumber, objCustomer)


                Return True
            End If
        Catch objNSE As NotSupportedException
            Throw New System.NotSupportedException(objNSE.Message)

        Catch objX As ArgumentNullException

            Throw New System.ArgumentNullException("Invalid Key Error: " & objX.Message)

        Catch objE As Exception

            Throw New System.Exception("EditItem Error: " & objE.Message)
        End Try
    End Function
    '***************************************************************************************************************************
    '---------- EDIT ------------
    Public Function Edit(ByVal SSNum As String, ByVal FName As String, ByVal LName As String, ByVal Bday As Date, ByVal status As String, ByVal PhoneNumber As String, ByVal JobTitle As String, ByVal UserName As String, ByVal PassWord As String, ByVal strusername As String, ByVal strPassword As String) As Boolean
        Try
            'Step 1-Create temporary POINTER to Collection Items
            Dim objItem As Customer
            'Step 2-Get a Reference or pointer to the actual object inside the collection via KEY.
            'Use CType() function to convert object retrieved from list to Customer
            objItem = CType(MyBase.Dictionary.Item(SSNum), Customer)
            'Step 3-Verify object exists
            If objItem Is Nothing Then
                'Step 4-Return False since not found
                Return False
            Else
                'Step 5-Sets individual properties of actual object inside the collection.
                'NOTE THAT SINCE THE ID NUMBER OF THE Customer IS THE KEY, WE DO NOT
                'WANT TO MODIFY IT OR TAMPER WITH IT IN ANY WAY
                objItem.Track = FName
                objItem.Artist = LName
                objItem.Status = status

                'objItem.PhoneNumber = PhoneNumber



                'Step 5-Return True since edited
                Return True
            End If

        Catch objNSE As NotSupportedException
            Throw New System.NotSupportedException(objNSE.Message)

            'Step B-Traps for ArgumentNullException when key is Nothing or null.
        Catch objX As ArgumentNullException
            'Step C-Throw Collection ArgumentNullException
            Throw New System.ArgumentNullException("Invalid Key Error: " & objX.Message)
            'Step D-Traps for general exceptions.
        Catch objE As Exception
            'Step E-Throw an general exceptions
            Throw New System.Exception("EditItem Error: " & objE.Message)
        End Try
    End Function

    '---------- REMOVE ------------
    Public Function Remove(ByVal key As String) As Boolean
        Try

            If MyBase.Dictionary.Contains(key) Then

                MyBase.Dictionary.Remove(key)

                Return True
            Else

                Return False
            End If

        Catch objX As ArgumentNullException

            Throw New System.ArgumentNullException("Invalid Key Error: " & objX.Message)

        Catch objE As Exception

            Throw New System.Exception("Remove Error: " & objE.Message)
        End Try
    End Function


#End Region

#Region " Public Wrapper Method"
    Public Function Print(ByVal key As String) As Boolean


        Try

            Dim objItem As Customer

            objItem = CType(MyBase.Dictionary.Item(key), Customer)

            If objItem Is Nothing Then

                Return False
            Else



                Return True
            End If

        Catch objX As ArgumentNullException

            Throw New System.ArgumentNullException("Invalid Key Error: " & objX.Message)

        Catch objE As Exception

            Throw New System.Exception("PrintCustomer Error: " & objE.Message)
        End Try
    End Function

    Public Function Authenticate(ByVal strUser As String, ByVal strPass As String) As Boolean

        Load()

        Dim objDictionaryEntry As DictionaryEntry
        Dim objItem As Customer
        Dim myboolean As Boolean
        Try
            For Each objDictionaryEntry In MyBase.Dictionary
                objItem = CType(objDictionaryEntry.Value, Customer)
                myboolean = objItem.Authenticate(strUser, strPass)
                If myboolean = True Then
                    MyBase.Dictionary.Clear()
                    Return True
                    Exit Function
                End If
            Next

        Catch ex As Exception
            Throw New System.Exception("Authentication Method Error: " & ex.Message)
        End Try
        MyBase.Dictionary.Clear()
        Return False
    End Function

#End Region

#Region " public Regular Methods Declaration"
    Public Sub PrintAll()
        Try

            Dim objDictionaryEntry As DictionaryEntry
            Dim objItem As Customer

            For Each objDictionaryEntry In MyBase.Dictionary

                objItem = CType(objDictionaryEntry.Value, Customer)


            Next

        Catch objE As Exception

            Throw New System.Exception("PrintAll Method Error: " & objE.Message)
        End Try
    End Sub
    '***************************************************************************************************************************


    Public Shadows Sub Clear()
        Try
            'Step 1-Calls Collection.Clear() Method to do the work
            MyBase.Dictionary.Clear()
            'Step B-Traps for General exceptions
        Catch objex As Exception
            'Step C-Throw an General Execption to calling programs.
            Throw New System.Exception("Unexpected error clearing List. " & objex.Message)
        End Try
    End Sub
#End Region

#Region " Deferred Delete Business Logic "

    'Search and Find the first Dirty Child Object
    Public Overrides Function DeferredDelete(ByVal Key As String) As Boolean

        Dim objDEntry As DictionaryEntry
        Dim objItem As Customer

        'Search for Object to Mark Deferred Delete
        For Each objDEntry In MyBase.Dictionary
            objItem = CType(objDEntry.Value, Customer)
            'Find object
            If objItem.ID = Key Then
                'If OLD or NOT New 
                If Not objItem.IsNew Then
                    'Mark Object for Deletion
                    objItem.DeferredDelete()


                    'Return True and exit
                    Return True
                Else
                    'Object found but IsNew Do not mark for deletion.
                    'return false and exit
                    Return False
                End If
            End If
        Next

        'Search Completed. Object Not found return False
        Return False

    End Function
#End Region

#Region "Public Data Access Methods"

    '***************************************************************************************************************************


    '*********************************************************************
    ''' <summary>
    ''' [Optional] Calls Data Portal_Create to create a Collection Object. This
    ''' Method is not used in this class, but can be used in the
    ''' future to create objects that need data from database upon Creation
    ''' </summary>
    Public Shared Function Create() As CustomerList
        'Calls Local DatPortal_Create() To do the work
        Return DataPortal_Create()

    End Function
    '**************************************************************************
    ''' <summary>
    ''' Calls Data_Portal_Fetch to load all objects from database
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Load()
        'Calls Local DatPortal_Fetch() To do the work
        DataPortal_Fetch()

    End Sub
    '**************************************************************************
    ''' <summary>
    ''' Calls DataPortal_Save() to save all objects in collection to Database
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Save()
        'Verify there are dirty objects in Collection
        'Only modify if dirty, otherwise do nothing in this method
        If Me.IsDirty Then
            'Dirty Collection, go ahead and update
            DataPortal_Save()
        End If

    End Sub
    '**************************************************************************
    ''' <summary>
    ''' Calls DataPortal_DeleteObject to delete an object residing
    '''  In the collection from the database 
    ''' </summary>
    ''' <param name="Key"></param>
    ''' <remarks></remarks>
    Public Sub ImmediateDelete(ByVal Key As String)
        'Calls Local DatPortal_DeleteObject() To do the work
        DataPortal_Delete(Key)
    End Sub


#End Region

#Region "Protected Data Access Methods"
    '*********************************************************************
    'Protected Data Access Methods declarations


    '**************************************************************************

    Protected Shared Function DataPortal_Create() As CustomerList


        Return Nothing
    End Function

    '**************************************************************************
  
    Protected Sub DataPortal_Fetch()

        ' Dim objConn As New OleDbConnection(strConn)
        Dim objConn As New SqlConnection(strConn)

        Try
            objConn.Open()
            Dim strSQL As String = "SELECT ID FROM songs"
            'Dim objCmd As New OleDbCommand(strSQL, objConn)
            Dim objCmd As New SqlCommand(strSQL, objConn)
            'Dim objDR As OleDbDataReader = objCmd.ExecuteReader
            Dim objDR As SqlDataReader = objCmd.ExecuteReader

            If objDR.HasRows Then
                Do While objDR.Read
                    Dim objItem As New Customer
                    Dim strKey As String = CStr(objDR.GetInt32(0))
                    If strKey = "" Then

                    Else
                        objItem.Load(strKey)
                        Me.Add(objItem.ID, objItem)
                    End If
                    objItem = Nothing
                Loop
            Else
                Throw New System.ApplicationException("Load Error! Record Not Found")
            End If
            objCmd.Dispose()
            objCmd = Nothing
            objDR.Close()
            objDR = Nothing
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
    End Sub

    '**************************************************************************
    Protected Sub DataPortal_Save()
        Try
            Dim objDictionaryEntry As DictionaryEntry
            Dim objChild As Customer
            For Each objDictionaryEntry In MyBase.Dictionary
                objChild = CType(objDictionaryEntry.Value, Customer)
                objChild.Save()
            Next
        Catch objE As Exception
            Throw New System.Exception("Save Error! " & objE.Message)
        End Try
    End Sub

    '**************************************************************************
    Protected Sub DataPortal_Delete(ByVal Key As String)
        Try
            Dim objDictionaryEntry As DictionaryEntry
            Dim objItem As Customer

            For Each objDictionaryEntry In MyBase.Dictionary

                objItem = CType(objDictionaryEntry.Value, Customer)

                If objItem.ID = Key Then

                    objItem.ImmediateDelete(Key)

                End If
            Next
        Catch objE As Exception
            Throw New System.Exception("Save Error! " & objE.Message)
        End Try

    End Sub


#End Region

#Region "Helper Methods"

    
   
    Public Function ToArray() As Customer()

        Dim arrCustomerList(MyBase.Dictionary.Count - 1) As Customer 'Declare an empty array of Customers
        MyBase.Dictionary.Values.CopyTo(arrCustomerList, 0)   'Use Shared CopyTo() Method of Dictionary Class to convert Collection to Array
        Return arrCustomerList
    End Function
    '*********************************************************************
    'Methods used to assist other methods or maintenance

    '*********************************************************************
    'MustOverride GetDBConnectionString(Key) method must be implemented derived classes

    'Method will return the Database Connection string from a Configuration File
    'Method takes as parameter a key or ID of the location of the connection string
    'To return.
    Protected Function GetDBConnectionString(ByVal DBNameID As String) As String
        Return ConfigurationManager.AppSettings(DBNameID)
    End Function

#End Region


    Public Sub filterbyStatus(ByVal key As String)
        ' Dim objConn As New OleDbConnection(strConn)
        Dim objConn As New SqlConnection(strConn)

        Try
            objConn.Open()
            Dim strSQL As String = "SELECT * FROM songs where Status like @Status"
            'Dim objCmd As New OleDbCommand(strSQL, objConn)
            Dim objCmd As New SqlCommand(strSQL, objConn)
            Dim newkey As String = key + "%"
            objCmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = newkey
            'Dim objDR As OleDbDataReader = objCmd.ExecuteReader
            Dim objDR As SqlDataReader = objCmd.ExecuteReader

            If objDR.HasRows Then
                Do While objDR.Read
                    Dim objItem As New Customer
                    Dim strKey As String = CStr(objDR.GetInt32(0))
                    If strKey = "" Then

                    Else
                        objItem.Load(strKey)

                        Me.Add(objItem.ID, objItem)
                    End If
                    objItem = Nothing
                Loop
            Else
                Throw New System.ApplicationException("Load Error! Record Not Found")
            End If
            objCmd.Dispose()
            objCmd = Nothing
            objDR.Close()
            objDR = Nothing
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
    End Sub

    Public Sub filterbyTrack(ByVal key As String)
        ' Dim objConn As New OleDbConnection(strConn)
        Dim objConn As New SqlConnection(strConn)

        Try
            objConn.Open()
            Dim strSQL As String = "SELECT * FROM songs where Track like @Track"
            'Dim objCmd As New OleDbCommand(strSQL, objConn)
            Dim objCmd As New SqlCommand(strSQL, objConn)
            Dim newkey As String = key + "%"
            objCmd.Parameters.Add("@Track", SqlDbType.VarChar).Value = newkey
            'Dim objDR As OleDbDataReader = objCmd.ExecuteReader
            Dim objDR As SqlDataReader = objCmd.ExecuteReader

            If objDR.HasRows Then
                Do While objDR.Read
                    Dim objItem As New Customer
                    Dim strKey As String = CStr(objDR.GetInt32(0))
                    If strKey = "" Then

                    Else
                        objItem.Load(strKey)

                        Me.Add(objItem.ID, objItem)
                    End If
                    objItem = Nothing
                Loop
            Else
                Throw New System.ApplicationException("Load Error! Record Not Found")
            End If
            objCmd.Dispose()
            objCmd = Nothing
            objDR.Close()
            objDR = Nothing
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
    End Sub

    Public Sub filterbyArtist(ByVal key As String)
        ' Dim objConn As New OleDbConnection(strConn)
        Dim objConn As New SqlConnection(strConn)

        Try
            objConn.Open()
            Dim strSQL As String = "SELECT * FROM songs where Artist like @Artist"
            'Dim objCmd As New OleDbCommand(strSQL, objConn)
            Dim objCmd As New SqlCommand(strSQL, objConn)
            Dim newkey As String = "%" + key + "%"
            objCmd.Parameters.Add("@Artist", SqlDbType.VarChar).Value = newkey
            'Dim objDR As OleDbDataReader = objCmd.ExecuteReader
            Dim objDR As SqlDataReader = objCmd.ExecuteReader

            If objDR.HasRows Then
                Do While objDR.Read
                    Dim objItem As New Customer
                    Dim strKey As String = CStr(objDR.GetInt32(0))
                    If strKey = "" Then

                    Else
                        objItem.Load(strKey)

                        Me.Add(objItem.ID, objItem)
                    End If
                    objItem = Nothing
                Loop
            Else
                Throw New System.ApplicationException("Load Error! Record Not Found")
            End If
            objCmd.Dispose()
            objCmd = Nothing
            objDR.Close()
            objDR = Nothing
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
    End Sub


End Class

